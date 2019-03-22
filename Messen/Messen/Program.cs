using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messen
{
    class Program
    {
        static void Main(string[] args)
        {
            Test schleifenTest = new Test(DemoSynchron, DemoTask);

            Console.WriteLine(schleifenTest.RunTestForAllMethods());

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void DemoSynchron()
        {
            double[] values = new double[100_000_000];
            for (int i = 0; i < 100_000_000; i++)
            {
                values[i] = i * Math.Pow(i, 0.33333333) - Math.Sin(Math.PI * i);
            }
        }
        private static void DemoTask()
        {
            double[] values = new double[100_000_000];
            Parallel.For(0, 100_000_000, i =>
              {
                  values[i] = i * Math.Pow(i, 0.33333333) - Math.Sin(Math.PI * i);
              });
        }
    }
}
