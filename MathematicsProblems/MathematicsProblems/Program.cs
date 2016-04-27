using System;
using System.Text;
using ProblemsSolutions;
using Microsoft.Office.Interop.Excel;
using System.Linq;

namespace MathematicsProblems
{
    class Program
    {
        static Application xlsApp;
        static Workbook wb;
        static Sheets sheets;

        static void Main(string[] args)
        {
            Console.WriteLine("Loading data sets...");
            Open(Environment.CurrentDirectory + @"\Data.xlsx");
            double[] x1 = GetColumn(1, 1);
            double[] y1 = GetColumn(1, 2);
            double[] x2 = GetColumn(2, 1);
            double[] y2 = GetColumn(2, 2);
            double[] x3 = GetColumn(3, 1);
            double[] y3 = GetColumn(3, 2);
            Close();
            Console.Clear();

            FirstProblem fp = new FirstProblem(x1, y1);
            Console.WriteLine("First problem output:");
            // Console.WriteLine($"{Print(fp.X)}");
            // Console.WriteLine($"{Print(fp.Y)}");
            Console.WriteLine($"y = {fp.M:0.0000} x + {fp.B:0.0000}");
            Console.WriteLine($"SErl = {fp.SErl():0.0000}");            // regression line errors 
            Console.WriteLine($"SEy = {fp.SEy():0.0000}");              // Y mean line errors  
            Console.WriteLine($"R squared = {fp.Rsquared():0.0000}");
            Console.WriteLine($"X (7) = {((7 - fp.B) / fp.M):0.0000}");
            Console.WriteLine($"Y (2.5) = {(2.5 * fp.M + fp.B):0.0000}");

            Console.WriteLine();

            SecondProblem sp = new SecondProblem(x2, y2);
            Console.WriteLine("Second problem output:");
            // Console.WriteLine($"{Print(sp.X)}");
            // Console.WriteLine($"{Print(sp.Y)}");
            Console.WriteLine($"y = {sp.SlopeM} x + {sp.SlopeB}");
            double temp = sp.X[0] + (sp.X[sp.X.Length - 1] - sp.X[0]) / 2;
            Console.WriteLine($"Center: [{temp}, {sp.SlopeM * temp + sp.SlopeB}]");
            Console.WriteLine();

            ThirdProblem tp = new ThirdProblem(x3, y3);
            Console.WriteLine("Third problem output:");
            // Console.WriteLine($"{Print(tp.X)}");
            // Console.WriteLine($"{Print(tp.Y)}");
            Console.WriteLine($"Count of peaks = {tp.CountOfPeaks()}");

            Console.ReadKey();
        }

        static void Open(string filename)
        {
            xlsApp = new Application();
            wb = xlsApp.Workbooks.Open(filename, 0,
                true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true);
            sheets = wb.Worksheets;
        }
        static void Close()
        {
            wb.Close(false, "", false);
            xlsApp.Quit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        static double[] GetColumn(int sheet, int column)
        {
            Range firstColumn = ((Worksheet)sheets.get_Item(sheet)).UsedRange.Columns[column];

            return ((Array)firstColumn.Cells.Value)
                        .OfType<object>()
                        .Select(x => double.Parse(x.ToString()))
                        .ToArray();
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
