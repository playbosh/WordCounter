namespace LIB.FileWordAnalyzer
{
    public class AnalyzerResult
    {
        public string Word { get; set; }
        public int Count { get; set; }

        internal AnalyzerResult(string _word, int _count)
        {
            Word = _word;
            Count = _count;
        }
    }
}