using System.Threading;

namespace project_15_04_25
{
    public class Program
    {
        private readonly Thread _thread;

        public Program()
        {
            int start, end;

            Console.WriteLine("Enter start number: ");
            start = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter end number: ");
            end = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Enter amount of min threads: ");
            int minThreads = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter amount of max threads: ");
            int maxThreads = int.Parse(Console.ReadLine() ?? "0");

            ThreadPool.SetMinThreads(minThreads, minThreads);
            ThreadPool.SetMaxThreads(maxThreads, maxThreads);

            ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
            ThreadPool.GetMaxThreads(out int workerThreads, out int completionPortThreads);

            _thread = new (() => WorkerMethod(start, end));
            _thread.Start();
        }

        public static void WorkerMethod(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }

        static void Main()
        {
            _ = new Program();
        }
    }
}
