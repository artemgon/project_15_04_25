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
            _thread = new (() => WorkerMethod(start, end));
            _thread.Start();
        }

        void WorkerMethod(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void Main()
        {
            _ = new Program();
        }
    }
}
