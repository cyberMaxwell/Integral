using System;

namespace Integral
{
    class Integral
    {
        public static double integFT(double a, double b, int n)
        {
            
            double sum = 0, step;
            int i;
            if (0 == n) return sum;

            step = (b - a) / (1.0 * n);
            for (i = 1; i < n; ++i)
            {
                sum += f(a + i * step);
            }
            sum += (f(a) + f(b)) / 2;
            sum *= step;
            return sum;
        }

        private static double f(double x)
        {
            return Math.Pow(x, 3) - Math.Pow(x, 2) - 9 * x + 9;
        }
    }
}
