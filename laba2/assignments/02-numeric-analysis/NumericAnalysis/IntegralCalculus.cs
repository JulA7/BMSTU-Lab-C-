using System;

namespace NumericAnalysis;

public class IntegralCalculus
{
    public static double trapezoidalIntegral(double a, double b, int n, Func<double, double> func)
    {
        double width = (b - a) / n;

        double trapezoidal_integral = 0;
        for (int step = 0; step < n; step++)
        {
            double x1 = a + step * width;
            double x2 = a + (step + 1) * width;

            trapezoidal_integral += 0.5 * (x2 - x1) * (func(x1) + func(x2));
        }

        return trapezoidal_integral;
    }

    public static double Calculate(Func<double, double> func, double x1, double x2, double precision)
    {
        int countSegments = Convert.ToInt32((x2 - x1) / precision);
        double value = trapezoidalIntegral(x1, x2, countSegments, func);
        return value;
    }
}
