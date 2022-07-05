using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Model
{
    public class WordFiles
    {
        public readonly List<Files> _wordFilesToSearch;

        public WordFiles()
        {
            _wordFilesToSearch = new List<Files>();
        }

        public void RemoveFiles()
        {
            _wordFilesToSearch.Clear();
        }
    }
}
