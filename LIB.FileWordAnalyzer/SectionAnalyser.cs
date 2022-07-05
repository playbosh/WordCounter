using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace LIB.FileWordAnalyzer
{

    public class SectionAnalyser : AnalyzerSection, IDisposable
    {
        private readonly SectionParser _parser;

        public SectionAnalyser(SectionParser parser)
        {
            _parser = parser;
        }

        public SectionAnalyser(Stream stream, Encoding encoding = default)
            : this(new SectionParser(stream, encoding))
        {
        }

        public Dictionary<string,int> Analyze(CancellationToken token = default)
        {
            return base.Analyze(_parser, token);
        }

        public void Dispose()
        {
            _parser?.Dispose();
        }
    }
}