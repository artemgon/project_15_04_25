using System.Threading;
using System;
using System.Collections.Generic;
using System.IO;

namespace project_15_04_25
{
    public class Program
    {
        private readonly Thread _calcThread;
        private readonly Thread _fileThread;
        private float _min, _max, _avg;
        private List<float> _list;

        public Program()
        {
            _min = 0;
            _max = 0;
            _avg = 0;
            _list = [];

            _calcThread = new Thread(DoCalcs);
            _calcThread.Start();
            _calcThread.Join();
            Console.WriteLine("Calculations done, now writing to file...");

            _fileThread = new Thread(DoFile);
            _fileThread.Start();
            _fileThread.Join();
            Console.WriteLine("File writing done.");
        }

        private void DoCalcs()
        {
            _list = ListGenerate();
            _min = Min(_list);
            _max = Max(_list);
            _avg = Average(_list);

            Console.WriteLine($"Min: {_min}");
            Console.WriteLine($"Max: {_max}");
            Console.WriteLine($"Average: {_avg}");
        }

        private void DoFile()
        {
            try
            {
                using (StreamWriter writer = new ("results.txt"))
                {
                    writer.WriteLine("First 100 numbers from the list:");
                    for (int i = 0; i < 100 && i < _list.Count; i++)
                    {
                        writer.WriteLine(_list[i]);
                    }

                    writer.WriteLine();
                    writer.WriteLine($"Calculation results:");
                    writer.WriteLine($"Minimum value: {_min}");
                    writer.WriteLine($"Maximum value: {_max}");
                    writer.WriteLine($"Average value: {_avg}");
                }

                Console.WriteLine("Results successfully written to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        public static List<float> ListGenerate()
        {
            List<float> list = [];
            Random random = new ();
            for (int i = 0; i < 10000; i++)
            {
                list.Add((float)(random.NextDouble() * 10));
            }
            return list;
        }

        public static float Min(List<float> list)
        {
            float min = list[0];
            foreach (float number in list)
            {
                if (number < min)
                {
                    min = number;
                }
            }
            return min;
        }

        public static float Max(List<float> list)
        {
            float max = list[0];
            foreach (float number in list)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            return max;
        }

        public static float Average(List<float> list)
        {
            float sum = 0;
            foreach (float number in list)
            {
                sum += number;
            }
            return sum / list.Count;
        }

        static void Main()
        {
            _ = new Program();
        }
    }
}
