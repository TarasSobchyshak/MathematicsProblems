namespace ProblemsSolutions
{
    public class SecondProblem
    {
        public SecondProblem(double[] x, double[] y)
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
            Init();
        }

        private double yR;
        private double yL;
        private double xR;
        private double xL;
        public double SlopeM
        {
            get;
            private set;
        }
        public double SlopeB
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
            N = X.Length;
            FirstProblem fp = new FirstProblem(X, Y);
            yR = Y[Y.Length - 1] + fp.M;
            yL = Y[0] - fp.M;
            xR = X[X.Length - 1];
            xL = X[0];
            SlopeM = (yR - yL) / (xR - xL);
            SlopeB = xL * SlopeM + yL;
        }
    }
}
