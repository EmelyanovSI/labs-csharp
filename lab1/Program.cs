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
                Console.Clear();
                try
                {
                    Console.Write("Task: ");
                    int task = Convert.ToInt32(Console.ReadLine());
                    if (task < 1 || 2 < task)
                    {
                        throw new Exception();
                    }
                    switch (task)
                    {
                        case 1:
                            Task1();
                            break;
                        case 2:
                            Task2();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Woops! There are only 2 tasks!");
                }
                Console.Write("\nLab1: Press Enter to repeat...");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key == ConsoleKey.Enter);
        }
        static void Task1()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
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
                Console.Write("\nTask1: Press Enter to repeat...");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key == ConsoleKey.Enter);
        }
        static void Task2()
        {
            const double a = Math.PI / 5;
            const double b = Math.PI;
            const double k = 10;
            const double h = (b - a) / k;
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                try
                {
                    Console.Write("Epsilon: ");
                    if (!double.TryParse(Console.ReadLine(), out double accuracy) || accuracy <= 0)
                    {
                        throw new Exception("Invalid accuracy, try again!");
                    }
                    Print();
                    for (double x = a; x <= b; x += h)
                    {
                        double sx = 0;
                        double xn = 1;
                        int n = 1;
                        while (Math.Abs(xn) > accuracy)
                        {
                            sx += xn = Math.Cos((2 * n - 1) * x) / Math.Pow(2 * n++ - 1, 2);
                        }
                        double fx = Math.Pow(Math.PI / 4, 2) - Math.PI / 4 * Math.Abs(x);
                        Print(x, sx, n, fx);
                    }
                    Console.WriteLine("-------------------------------------------------");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.Write("\nTask2: Press Enter to repeat...");
                keyInfo = Console.ReadKey();
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
        public static void Print()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|    x    |     S(x)    |    N    |     F(x)    |");
        }
        public static void Print(double x, double sx, double accuracy, double fx)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"|  {string.Format("{0, 5:f3}", x)}  |  {string.Format("{0, 9:f3}", sx)}  |  {string.Format("{0, 5:f}", accuracy)}  |  {string.Format("{0, 9:f3}", fx)}  |");
        }
    }
}
