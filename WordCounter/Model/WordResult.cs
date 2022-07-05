using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Model
{
    public class WordResult
    {
        public Dictionary<string, int> _result { get; set; }

        public WordResult()
        {
            _result = new Dictionary<string, int>();
        }

        /*
        public void GetAnalyseResult(List<Files> search)
        {
            Class1 test = new Class1();

            foreach(Files data in search)
            {
                _result = test.Analyse(
                 File.ReadAllText(data.FilePath),
                 new List<char>
                    {
                        (char) 0x20, //Space
                        (char) 0x0A, //LF
                        (char) 0x0D, //CR
            
                    },
                 _result
                );
            }

            Class1 test2= new Class1();
        }
        */
    }
}
