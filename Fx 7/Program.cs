using System;

class Program
{
    static double F(double x)
    {
        return x * x - 2;
    }

    static double F_prime(double x)
    {
        //F(x) = x^2 - 2
        return 2 * x;
    }

    static double NewtonMethod(double initialGuess, double tolerance = 0.0001, int maxIterations = 100)
    {
        double x_n = initialGuess;

        for (int i = 0; i < maxIterations; i++)
        {
            double f_x_n = F(x_n);
            double f_prime_x_n = F_prime(x_n);


            if (Math.Abs(f_prime_x_n) < 0.0001)
            {
                Console.WriteLine("Производная слишком мала, метод может не сработать.");
                return double.NaN;
            }

            double x_n1 = x_n - f_x_n / f_prime_x_n;

            if (Math.Abs(F(x_n1)) < tolerance)
            {
                return x_n1;
            }

            x_n = x_n1;
        }

        Console.WriteLine("Достигнуто максимальное количество итераций.");
        return x_n;
    }

    static void Main()
    {
        Console.WriteLine("F(x) = x^2 - 2");
        double initialGuess = -1.0; 
        double root = NewtonMethod(initialGuess);
        Console.WriteLine($"Корень уравнения: {root}");
        Console.Read();
    }
}