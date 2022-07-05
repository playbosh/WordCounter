using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace LIB.FileWordAnalyzer
{
    public class SectionParser : IDisposable
    {
        private BinaryReader _binaryReader;
        private int _cacheSize = 8 * 1024;

        public List<char> Delimiter { get; set; }

        public ISectionStatus StatusObject { get; set; }

        public int CacheSize
        {
            get => _cacheSize;
            set
            {
                if (value < 64)
                {
                    throw new AggregateException($"Cannot use less cache than 64 characters");
                }
                _cacheSize = value;
            }
        }

        public SectionParser(Stream stream, Encoding encoding = default)
        {
            encoding = encoding ?? Encoding.UTF8;
            _binaryReader = new BinaryReader(stream, encoding);

            Delimiter = new List<char>
            {
                (char) 0x20, //SP - Space
                (char) 0x0D, //CR
                (char) 0x0A, //LF
            };
        }

        public IEnumerable<string> ReadSegments(CancellationToken token = default)
        {
            var readCount = 0;
            var buffer = new char[_cacheSize];
            var sb = new StringBuilder(32);

            if (StatusObject != null)
            {
                StatusObject.TotalLength = _binaryReader.BaseStream.Length;
            }

            while ((readCount = _binaryReader.Read(buffer, 0, buffer.Length)) != 0)
            {
                for (int i = 0; i < readCount; i++)
                {
                    if (Delimiter.Contains(buffer[i]))
                    {
                        if (sb.Length > 0)
                        {
                            yield return sb.ToString();
                            sb.Clear();
                        }
                    }
                    else
                    {
                        sb.Append(buffer[i]);
                    }
                }

                if (StatusObject != null)
                {
                    StatusObject.CurrentPosition = _binaryReader.BaseStream.Position;
                }

                if (token.IsCancellationRequested)
                {
                    yield break;
                }
            }

            if (sb.Length > 0)
            {
                yield return sb.ToString();
            }
        }

        public SectionParser EnableStatusUpdates()
        {
            return EnableStatusUpdates<SectionStatus>();
        }

        public SectionParser EnableStatusUpdates<T>()
            where T : ISectionStatus, new()
        {
            StatusObject = new T();
            return this;
        }

        public SectionParser SetDelimiter(params char[] delimiter)
        {
            Delimiter = delimiter.ToList();
            return this;
        }

        public SectionParser SetCacheSize(int size)
        {
            CacheSize = size;
            return this;
        }

        public void Dispose()
        {
            _binaryReader?.Dispose();
        }
    }
}