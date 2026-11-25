namespace RetryAnalysis;

public enum Verdict
{
    NotRun,
    Passed,
    Flaky,
    Failed
}

public record Attempt(int Number, string Outcome);

public static class RetryAnalyzer
{
    /// <summary>
    /// Final verdict for one test case, from its attempts in the order they ran.
    /// Outcome is "Pass", "Fail" or "Skip", compared case-insensitively.
    /// Skipped attempts are ignored. Only the first (1 + maxRetries) remaining attempts count.
    /// NotRun: no counted attempts. Passed: the first counted attempt passed.
    /// Flaky: a later counted attempt passed. Failed: no counted attempt passed.
    /// </summary>
    public static Verdict Evaluate(IReadOnlyList<Attempt> attempts, int maxRetries)
    {
        int limit = maxRetries;
        int counted = 0;

        foreach (var attempt in attempts)
        {
            // Attempt skipped, doesnt count in attempt budget
            if (attempt.Outcome.Equals("Skip", StringComparison.OrdinalIgnoreCase))
                continue;
            // Validates if theres any retries left on the attempt budget if true breaks the cycle
            if (counted >= limit+1)
                break;
            counted++; //count up
            //if the attempt its successful asks if the counter its 1, if true the veredict its passed if not its flaky
            if (attempt.Outcome.Equals("Pass", StringComparison.OrdinalIgnoreCase))
                return counted == 1 ? Verdict.Passed : Verdict.Flaky;
        }
        return counted == 0 ? Verdict.NotRun : Verdict.Failed;
    }
}
