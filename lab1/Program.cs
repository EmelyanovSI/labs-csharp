using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                try
                {
                    const double xn = -8;
                    const double xk = 10;
                    Console.WriteLine($"xn: {xn}");
                    Console.WriteLine($"xk: {xk}");
                    Console.Write(" h: ");
                    double h = Convert.ToDouble(Console.ReadLine());
                    if (h <= 0)
                    {
                        throw new Exception();
                    }
                    Table(xn, xk, h);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Woops! h <= 0");
                }
                Console.Write("Press Enter to repeat...");
                keyInfo = Console.ReadKey();
                Console.Clear();
            } while (keyInfo.Key == ConsoleKey.Enter);
        }

        static double Func(double x)
        {
            double f = 0;
            if (x >= -8 && x <= -5)
            {
                f = -2;
            }
            else if (x > -5 && x < -3)
            {
                f = x + 3;
            }
            else if (x >= -3 && x <= 3)
            {
                f = Math.Sqrt(Math.Abs(Math.Pow(x, 2) - 9));
            }
            else if (x > 3 && x < 8)
            {
                f = 0.5 * (x - 3);
            }
            else if (x >= 8 && x <= 10)
            {
                f = 3;
            }
            return f;
        }

        static void Table(double xn, double xk, double h)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("|   f   |   x   |");
            Console.WriteLine("-----------------");
            for (double i = xn; i <= xk; i += h)
            {
                Console.WriteLine($"|{Math.Round(Func(i), 2), 7}|{Math.Round(i, 2), 7}|");
            }
            Console.WriteLine("-----------------");
        }
    }
}
