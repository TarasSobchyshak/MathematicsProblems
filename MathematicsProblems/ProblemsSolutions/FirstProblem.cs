using System.Linq;
using static System.Math;

namespace ProblemsSolutions
{
    public class FirstProblem
    {
        public FirstProblem(double[] x, double[] y)
        {
            X = x;
            Y = y;
            Init();
        }

        private double x;
        private double y;
        private double xy;
        private double xx;
        public double M
        {
            get;
            private set;
        }
        public double B
        {
            get;
            private set;
        }
        public int N
        {
            get;
            private set;
        }
        public double[] X
        {
            get;
            private set;
        }
        public double[] Y
        {
            get;
            private set;
        }

        private void Init()
        {
            x = Mean(X);
            y = Mean(Y);
            xy = Mean(X, Y);
            xx = Mean(X, X);
            N = X.Length;
            M = (x * y - xy) / (x * x - xx);
            B = y - M * x;
        }

        public double SErl()
        {
            double sum = 0;
            for (int i = 0; i < X.Length; ++i)
            {
                sum += Pow(Y[i] - (M * X[i] + B), 2);
            }
            return sum / N / N;
        }
        public double SEy()
        {
            double sum = 0;
            for (int i = 0; i < X.Length; ++i)
            {
                sum += Pow(Y[i] - y, 2);
            }
            return sum / N / N;
        }

        public double Rsquared() => 1 - SErl() / SEy();

        public static double Mean(double[] a) => a.Sum() / a.Length;

        public static double Mean(double[] a, double[] b)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                sum += a[i] * b[i];
            }
            return sum / a.Length;
        }
    }
}
