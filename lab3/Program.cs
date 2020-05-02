using System;
using System.Text.RegularExpressions;

namespace lab3
{
    class Program
    {
        private static string MENU =
            "1. Task1\n" +
            "2. Task2\n" +
            "e. Exit\n";

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
            Console.WriteLine("Input text:");
            String str = Console.ReadLine().Trim();
            str = Regex.Replace(str, "[^ ] {1}[^ ]", ", ");
            str = Regex.Replace(str, "[^ ] {2}[^ ]", ": ");
            str = Regex.Replace(str, "[^ ] {3} *[^ ]", "- ");
            Console.WriteLine(str);
            Console.ReadKey();
        }
        static void Task2()
        {

        }
    }
}
