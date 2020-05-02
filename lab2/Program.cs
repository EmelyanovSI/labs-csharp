using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab2
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
                    if (task < 1 || 3 < task)
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
                        case 3:
                            Task3();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Woops! There are only 3 tasks!");
                }
                Console.Write("\nLab2: Press Enter to repeat...");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key == ConsoleKey.Enter);
        }
        static void Task1()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                SubTask1();
                SubTask2();
                SubTask3();
                Console.Write("\nTask1: Press Enter to repeat...");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key == ConsoleKey.Enter);
        }
        static void Task2()
        {
            do
            {
                switch (menu())
                {
                    case 1:
                        try
                        {
                            Console.Write("length: ");
                            int length = Convert.ToInt32(Console.ReadLine());
                            if (length > 0)
                            {
                                Console.Write("array: ");
                                int[] array = Regex.Split(Console.ReadLine().Trim(), @"[ :;,.!?/(|)]+").Select(el => Convert.ToInt32(el)).ToArray();
                                Console.WriteLine(SubTask1(out String task, ref length, array));
                            }
                            else
                            {
                                Console.WriteLine("Length of array < 1, try again!");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input error, try again!");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        try
                        {
                            Console.Write("length: ");
                            int length = Convert.ToInt32(Console.ReadLine());
                            if (length > 0)
                            {
                                int[,] matrix = new int[length, length];
                                Console.WriteLine("matrix:");
                                for (int i = 0; i < length; ++i)
                                {
                                    int[] array = Regex.Split(Console.ReadLine().Trim(), @"[ :;,.!?/(|)]+").Select(el => Convert.ToInt32(el)).ToArray();
                                    if (array.Length != length)
                                    {
                                        throw new IndexOutOfRangeException();
                                    }
                                    for (int j = 0; j < length; ++j)
                                    {
                                        matrix[i, j] = array[j];
                                    }
                                }
                                SubTask2(length, matrix);
                            }
                            else
                            {
                                Console.WriteLine("Length of array < 1, try again!");
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input error, try again!");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine($"Array`s length must be bigger, try againg!");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine(SubTask3("SubTask3"));
                        Console.ReadKey();
                        break;
                    case 4:
                        Task3();
                        Console.ReadKey();
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
                Console.WriteLine("1. Min Element");
                Console.WriteLine("2. Matrix & Vector");
                Console.WriteLine("3. Transpose Matrix");
                Console.WriteLine("4. Task3");
                Console.WriteLine("e. Exit");
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
                if (1 > menu || menu > 4)
                {
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return menu;
            } while (true);
        }
        static void SubTask1()
        {
            Console.Clear();
            Console.WriteLine("SubTask1");
            try
            {
                Console.Write("length: ");
                int length = Convert.ToInt32(Console.ReadLine());
                if (length > 0)
                {
                    Console.Write("array: ");
                    int[] array = Regex.Split(Console.ReadLine().Trim(), @"[ :;,.!?/(|)]+").Select(el => Convert.ToInt32(el)).ToArray();
                    if (array.Length != length)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    Console.Write("array: ");
                    for (int i = 0; i < length; ++i)
                    {
                        Console.Write($"{array[i]} ");
                    }
                    Console.WriteLine();
                    Console.Write("t: ");
                    int t = Convert.ToInt32(Console.ReadLine());
                    Console.Write("s: ");
                    int s = Convert.ToInt32(Console.ReadLine());
                    int min = int.MaxValue;
                    for (int i = 0; i < array.Length; ++i)
                    {
                        if (array[i] > s)
                        {
                            break;
                        }
                        if (array[i] < t)
                        {
                            if (array[i] <= min)
                            {
                                min = array[i];
                            }
                        }
                    }
                    if (min == int.MaxValue)
                    {
                        Console.WriteLine($"min: undefined");
                    }
                    else
                    {
                        Console.WriteLine($"min: {min}");
                    }
                }
                else
                {
                    Console.WriteLine("Length of array < 1, try again!");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Input error, try again!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Array`s length must be bigger, try againg!");
            }
            Console.ReadKey();
        }
        static void SubTask2()
        {
            Console.Clear();
            Console.WriteLine("SubTask2");
            try
            {
                Console.Write("length: ");
                int length = Convert.ToInt32(Console.ReadLine());
                if (length > 0)
                {
                    int[,] matrix = new int[length, length];
                    Console.WriteLine("matrix:");
                    for (int i = 0; i < length; ++i)
                    {
                        int[] array = Regex.Split(Console.ReadLine().Trim(), @"[ :;,.!?/(|)]+").Select(el => Convert.ToInt32(el)).ToArray();
                        if (array.Length != length)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        for (int j = 0; j < length; ++j)
                        {
                            matrix[i, j] = array[j];
                        }
                    }
                    Console.WriteLine("matrix:");
                    for (int i = 0; i < length; ++i)
                    {
                        for (int j = 0; j < length; ++j)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                    int[] b = new int[length];
                    for (int i = 0; i < length; ++i)
                    {
                        int el = 0;
                        for (int j = 0; j < length; ++j)
                        {
                            if (matrix[i, j] % 2 == 0)
                            {
                                ++el;
                            }
                        }
                        b[i] = el;
                    }
                    Console.Write($"b: ");
                    for (int i = 0; i < length; ++i)
                    {
                        Console.Write($"{b[i]} ");
                    }
                }
                else
                {
                    Console.WriteLine("Length of array < 1, try again!");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Input error, try again!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Array`s length must be bigger, try againg!");
            }
            Console.ReadKey();
        }
        static void SubTask3()
        {
            Console.Clear();
            Console.WriteLine("SubTask3");
            try
            {
                Console.Write("length: ");
                int length = Convert.ToInt32(Console.ReadLine());
                if (length > 0)
                {
                    int[,] matrix = new int[length, length];
                    Console.WriteLine("matrix:");
                    for (int i = 0; i < length; ++i)
                    {
                        int[] array = Regex.Split(Console.ReadLine().Trim(), @"[ :;,.!?/(|)]+").Select(el => Convert.ToInt32(el)).ToArray();
                        if (array.Length != length)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        for (int j = 0; j < length; ++j)
                        {
                            matrix[i, j] = array[j];
                        }
                    }
                    Console.WriteLine("matrix:");
                    for (int i = 0; i < length; ++i)
                    {
                        for (int j = 0; j < length; ++j)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"transpose matrix:");
                    for (int i = 0; i < length; ++i)
                    {
                        for (int j = 0; j < length; ++j)
                        {
                            Console.Write($"{matrix[j, i]} ");

                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Length of array < 1, try again!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input error, try again!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Array`s length must be bigger, try againg!");
            }
            Console.ReadKey();
        }
        static string SubTask1(out string str, ref int length, params int[] array)
        {
            Console.Clear();
            Console.WriteLine(str = "SubTask1");
            try
            {
                if (array.Length != length)
                {
                    throw new IndexOutOfRangeException();
                }
                Console.Write("array: ");
                for (int i = 0; i < length; ++i)
                {
                    Console.Write($"{array[i]} ");
                }
                Console.WriteLine();
                Console.Write("t: ");
                int t = Convert.ToInt32(Console.ReadLine());
                Console.Write("s: ");
                int s = Convert.ToInt32(Console.ReadLine());
                int min = int.MaxValue;
                for (int i = 0; i < array.Length; ++i)
                {
                    if (array[i] > s)
                    {
                        break;
                    }
                    if (array[i] < t)
                    {
                        if (array[i] <= min)
                        {
                            min = array[i];
                        }
                    }
                }
                if (min == int.MaxValue)
                {
                    Console.WriteLine($"min: undefined");
                }
                else
                {
                    Console.WriteLine($"min: {min}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input error, try again!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Array`s length must be bigger, try againg!");
            }
            Console.ReadKey();
            return str;
        }
        static void SubTask2(int length, int[,] matrix)
        {
            Console.Clear();
            Console.WriteLine("SubTask2");
            Console.WriteLine("matrix:");
            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            int[] b = new int[length];
            for (int i = 0; i < length; ++i)
            {
                int el = 0;
                for (int j = 0; j < length; ++j)
                {
                    if (matrix[i, j] % 2 == 0)
                    {
                        ++el;
                    }
                }
                b[i] = el;
            }
            Console.Write($"b: ");
            for (int i = 0; i < length; ++i)
            {
                Console.Write($"{b[i]} ");
            }
            Console.ReadKey();
        }
        static string SubTask3(string str)
        {
            Console.Clear();
            Console.WriteLine(str);
            try
            {
                Console.Write("length: ");
                int length = Convert.ToInt32(Console.ReadLine());
                if (length > 0)
                {
                    int[,] matrix = new int[length, length];
                    Console.WriteLine("matrix:");
                    for (int i = 0; i < length; ++i)
                    {
                        int[] array = Regex.Split(Console.ReadLine().Trim(), @"[ :;,.!?/(|)]+").Select(el => Convert.ToInt32(el)).ToArray();
                        if (array.Length != length)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        for (int j = 0; j < length; ++j)
                        {
                            matrix[i, j] = array[j];
                        }
                    }
                    Console.WriteLine("matrix:");
                    for (int i = 0; i < length; ++i)
                    {
                        for (int j = 0; j < length; ++j)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"transpose matrix:");
                    for (int i = 0; i < length; ++i)
                    {
                        for (int j = 0; j < length; ++j)
                        {
                            Console.Write($"{matrix[j, i]} ");

                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Length of array < 1, try again!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input error, try again!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Array`s length must be bigger, try againg!");
            }
            Console.ReadKey();
            return str;
        }
        static void Task3()
        {

        }
    }
}
