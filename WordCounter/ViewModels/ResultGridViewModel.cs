using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Model;

namespace WordCounter.ViewModels
{
    public class ResultGridViewModel : ViewModelBase
    {
        private readonly KeyValuePair<string, int> _results;
        public string Word => _results.Key;
        public int WordCount => _results.Value;

        public ResultGridViewModel(KeyValuePair<string,int> result)
        {
            _results = result;
        }
    }
}
