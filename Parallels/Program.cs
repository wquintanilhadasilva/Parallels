using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace POCParalells
{
    class Program
    {
        static void Main(string[] args)
        {

            var watch = Stopwatch.StartNew();

            for (int i = 2; i < 20; i++)
            {
                var result = SumRootN(i);
                Console.WriteLine("root {0}  :  {1}", i, result);
            }

            Console.WriteLine("Tempo decorrido A: {0}", watch.ElapsedMilliseconds);

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            watch.Reset();
            watch.Start();

            Parallel.For(2, 20, (i) =>
            {
                var result = SumRootN(i);
                Console.WriteLine("root {0}  :  {1}", i, result);
            });

            Console.WriteLine("Tempo decorrido B: {0}", watch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        public static double SumRootN(int root)
        {
            double result = 0;
            for (int i = 1; i < 10000000; i++)
            {
                result += Math.Exp(Math.Log(i) / root);
            }

            return result;
        }
    }
}