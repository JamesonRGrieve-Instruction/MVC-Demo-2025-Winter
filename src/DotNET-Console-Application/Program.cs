namespace DotNET_Console_Application;

class Program
{
    static async Task Main(string[] args)
    {
        Task<int> result1 = PerformCalculationAsync(2);
        Task<int> result2 = PerformCalculationAsync(5);
        Task<int> result3 = PerformCalculationAsync(3);
        await Task.WhenAll(result1, result2, result3);
        Console.WriteLine($"{result1.Result} {result2.Result} {result3.Result}");
    }

    static async Task<int> PerformCalculationAsync(int seconds)
    {
        Console.WriteLine($"Performing calculation taking {seconds}s.");
        await Task.Delay(seconds * 1000); // Simulate long running task
        Console.WriteLine($"Performed calculation after {seconds}s.");
        return 42; // Return some result
    }

}
