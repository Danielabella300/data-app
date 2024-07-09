namespace DataApp;

public class Program
{
    /// <summary>
    /// Changed over from void to Tasks to run concurrenty
    /// </summary>
    public static async Task Main(string[] args)
    {
        var manager = new DataManager();
        Task<int>[] tasks = new Task<int>[12];

        for (int i = 0; i <= 10; i++)
        {
            int index = i;
            tasks[index] = Task.Run(() => manager.ConsolidateDataFromSources(index));
        }

        tasks[11] = Task.Run(() => manager.ConsolidateDataFromSources(27));

        int[] results = await Task.WhenAll(tasks);

        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine($"Consolidated dataId {i}. Result={results[i]}");
        }

        Console.WriteLine($"Consolidated dataId 27. Result={results[11]}");

        Console.WriteLine("Completed");

        /*
        var manager = new DataManager();
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine($"Consolidated dataId {i}. Result=" + manager.ConsolidateDataFromSources(i));
        }

        Console.WriteLine("Consolidated dataId 27. Result=" + manager.ConsolidateDataFromSources(27));

        Console.WriteLine("Completed");
        */
    }
}