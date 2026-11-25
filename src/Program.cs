using RetryAnalysis;

Console.WriteLine("Example 1: " + RetryAnalyzer.Evaluate(new[] { new Attempt(1, "Fail"), new Attempt(2, "Pass") }, 1));
Console.WriteLine("Example 2: " + RetryAnalyzer.Evaluate(new[] { new Attempt(1, "pass") }, 0));
Console.WriteLine("Example 3: " + RetryAnalyzer.Evaluate(new[] { new Attempt(1, "Skip"), new Attempt(2, "Fail"), new Attempt(3, "Pass") }, 1));
Console.WriteLine("Example 3: " + RetryAnalyzer.Evaluate(new[] { new Attempt(1, "Pass"), new Attempt(2, "Skip"), new Attempt(3, "Skip") }, 1));