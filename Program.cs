using System.Threading;

namespace project_15_04_25
{
    public class Program
    {
        private readonly Thread _thread;

        public Program()
        {
            _thread = new (WorkerMethod);
            _thread.Start();
        }

        void WorkerMethod()
        {
            for (int i = 0; i <= 50; i++)
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
