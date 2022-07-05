using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Model
{
    public class Result
    {
        public string Word { get; }
        public int Counter { get; }

        public Result(string _word, int _count)
        {
            Word = _word;
            Counter = _count;
        }
    }
}
