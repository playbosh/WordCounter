using LIB.FileWordAnalyzer;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LIB.FileWordAnalyzer
{
    public class AnalyzerSection
    {
        public Dictionary<string, int> Analyze(SectionParser parser, CancellationToken token = default)
        {
            return Analyze(parser.ReadSegments(token), token);
        }

        public Dictionary<string, int> Analyze(IEnumerable<string> segments, CancellationToken token = default)
        {
            var analysisDictionary = new Dictionary<string, int>();
            foreach (var segment in segments)
            {
                if (analysisDictionary.ContainsKey(segment))
                {
                    analysisDictionary[segment] += 1;
                }
                else
                {
                    analysisDictionary.Add(segment, 1);
                }

                if (token.IsCancellationRequested)
                {
                    return null;
                }
            }
            return analysisDictionary;
        }
    }
}