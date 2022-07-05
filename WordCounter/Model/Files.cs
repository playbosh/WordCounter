using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Model
{
    public class Files
    {
        public string FilePath { get; }
        public long FileSize { get; }

        public string FileContent { get; }

        public Files(string _filePath, long _fileSize, string _fileContent)
        {
            FilePath = _filePath;
            FileSize = _fileSize;
            FileContent = _fileContent;
        }
    }
}
