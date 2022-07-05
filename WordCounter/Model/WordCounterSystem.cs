using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Model
{
    public class WordCounterSystem
    {
        public readonly WordFiles _wordFiles = new WordFiles();
        public readonly WordResult _wordResults = new WordResult();

        public WordCounterSystem()
        {
            _wordFiles = new WordFiles();
            _wordResults = new WordResult();
        }
    }
}
