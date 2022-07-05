namespace LIB.FileWordAnalyzer
{
    public interface ISectionStatus
    {
        long CurrentPosition { get; set; }
        long TotalLength { get; set; }
        decimal Progress { get; }
    }
}