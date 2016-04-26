using System;
using System.Text;
using ProblemsSolutions;

namespace MathematicsProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 10 };
            double[] y = { 0, 5, 1, 0, 9, 5, 4, 3, 8 };
            FirstProblem fp = new FirstProblem(x, y);
            Console.WriteLine("First problem output:");
            Console.WriteLine($"{Print(x)}");
            Console.WriteLine($"{Print(y)}");
            Console.WriteLine($"y = {fp.M:0.0000} x + {fp.B:0.0000}");
            Console.WriteLine($"SErl = {fp.SErl():0.0000}");            // regression line errors 
            Console.WriteLine($"SEy = {fp.SEy():0.0000}");              // Y mean line errors  
            Console.WriteLine($"R squared = {fp.Rsquared():0.0000}");
            Console.WriteLine($"X (7) = {((7 - fp.B) / fp.M):0.0000}");
            Console.WriteLine($"Y (2.5) = {(2.5 * fp.M + fp.B):0.0000}");

            Console.WriteLine();

            Console.WriteLine("Second problem output:");
            Console.WriteLine($"{Print(x)}");
            Console.WriteLine($"{Print(y)}");

            Console.WriteLine();

            ThirdProblem tp = new ThirdProblem(x, y);
            Console.WriteLine("Third problem output:");
            Console.WriteLine($"{Print(x)}");
            Console.WriteLine($"{Print(y)}");
            Console.WriteLine($"Coutn of peaks = {tp.CountOfPeaks()}");

            Console.ReadKey();
        }

        static string Print(double[] a)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var x in a)
            {
                sb.Append($"{x:0.0000}\t");
            }
            return sb.ToString();
        }
    }
}
