namespace Sweeft9
{
    class Program
    {
        static SemaphoreSlim semaphore = new SemaphoreSlim(1);

        static async Task Main(string[] args)
        {
            Console.WriteLine("Press Ctrl+C to exit.");
            await RunAsync();
        }

        // Main asynchronous method that runs the continuous output and periodic message tasks
        static async Task RunAsync()
        {
            while (true)
            {
                await Task.WhenAll(ContinuousOutput(), PeriodicMessage());
            }
        }

        // Method to continuously output numbers with a brief delay
        static async Task ContinuousOutput()
        {
            await semaphore.WaitAsync();
            try
            {
                DateTime startTime = DateTime.Now;

                // Continue outputting '1' and '0' for 5 seconds
                while (DateTime.Now - startTime < TimeSpan.FromSeconds(5))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("1");
                    await Task.Delay(100);
                    Console.Write("0");
                    await Task.Delay(100);
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

        // Method to display a periodic message every 5 seconds
        static async Task PeriodicMessage()
        {
            await Task.Delay(5000); // Wait for 5 seconds
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNeo, you are the chosen one"); // Display the message
            await Task.Delay(5000); // Wait for another 5 seconds
        }
    }
}
