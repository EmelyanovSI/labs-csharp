﻿using System;

namespace lab5
{
    class Lab5
    {
        private static string MENU =
            "1. Task1\n" +
            "2. Task2\n" +
            "e. Exit\n";
        delegate int Func(int x, int y);

        static void Main(string[] args)
        {
            do
            {
                switch (menu())
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    default:
                        return;
                }
            } while (true);
        }
        static int menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(MENU);
                Console.Write("> ");
                String input = Console.ReadLine().Trim();
                if (input.ToLower().Equals("exit") || input.ToLower().Equals("e") ||
                        input.ToLower().Equals("quit") || input.ToLower().Equals("q"))
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                int menu;
                try
                {
                    menu = Convert.ToInt32(input);
                }
                catch (Exception)
                {
                    Console.Clear();
                    continue;
                }
                if (1 > menu || menu > 2)
                {
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return menu;
            } while (true);
        }
        static void Task1()
        {
            Console.Write("x: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Function#: ");
            int fun = Convert.ToInt32(Console.ReadLine());
            if (fun == 1)
            {
                Func func = FuncF;
                Console.WriteLine("z: " + FuncZ(func, x, y));

            }
            else if (fun == 2)
            {
                Func func = FuncG;
                Console.WriteLine("z: " + FuncZ(func, x, y));
            }
            else
            {
                Console.WriteLine("Input error, try again!");
            }
            Console.ReadKey();
        }
        static void Task2()
        {
            
        }
        static int FuncF(int x, int y) => x + y + 2;
        static int FuncG(int x, int y) => 7 * x + y;
        static int FuncZ(Func func, int x, int y) => 5 * func(x, y) - 2 * func(x, y - 1);
    }
}
