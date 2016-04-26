using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemsSolutions;

namespace MathematicsProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = { -2, -1, 1, 4 };
            double[] y = { -3, -1, 2, 3 };
            FirstProblem fp = new FirstProblem(x, y);
            Console.WriteLine("First problem output:");
            Console.WriteLine($"y = {fp.M:0.0000} x + {fp.B:0.0000}");
            Console.WriteLine($"SErl = {fp.SErl():0.0000}");            // regression line errors 
            Console.WriteLine($"SEy = {fp.SEy():0.0000}");              // Y mean line errors  
            Console.WriteLine($"R squared = {fp.Rsquared():0.0000}");
            Console.WriteLine($"X (7) = {((7 - fp.B) / fp.M):0.0000}");
            Console.WriteLine($"Y (2.5) = {(2.5 * fp.M + fp.B):0.0000}");

            Console.WriteLine();
            Console.WriteLine("Second problem output:");


            Console.ReadKey();
        }
    }
}
