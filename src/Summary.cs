namespace RetryAnalysis;

public static class Summary
{
    public static string Format(IEnumerable<Verdict> verdicts) =>
        string.Join(", ", verdicts.GroupBy(v => v).OrderBy(g => g.Key).Select(g => g.Key + "=" + g.Count()));
}
