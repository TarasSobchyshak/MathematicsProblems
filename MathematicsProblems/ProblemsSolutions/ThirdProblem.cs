namespace ProblemsSolutions
{
    public class ThirdProblem
    {

        public ThirdProblem(double[] x, double[] y)
        {
            double temp1;
            double temp2;
            for (int i = 0; i < x.Length; ++i)
            {
                for (int j = 0; j < x.Length - 1; ++j)
                {
                    if (x[j + 1] < x[j])
                    {
                        temp1 = x[j + 1];
                        temp2 = y[j + 1];
                        x[j + 1] = x[j];
                        y[j + 1] = y[j];
                        x[j] = temp1;
                        y[j] = temp2;
                    }
                }
            }
            X = x;
            Y = y;
            N = X.Length;
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

        public int CountOfPeaks()
        {
            if (N == 0) return 0;
            if (N <= 2) return 1;
            int res = 0;
            for (int i = 1; i < N - 1; ++i)
            {
                if ((Y[i] > Y[i + 1]) && (Y[i] > Y[i - 1])) res++;
            }
            if (X[0] > X[1]) res++;
            if (X[N - 1] > X[N - 2]) res++;
            return res;
        }
    }
}
