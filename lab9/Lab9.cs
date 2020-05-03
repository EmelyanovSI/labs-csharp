using System;
using System.Threading;
using System.Threading.Tasks;

namespace lab9
{
    class Lab9
    {
        private static string MENU =
            "1. Task1\n" +
            "2. Task2\n" +
            "3. Task3\n" +
            "e. Exit\n";

        public static void Main(string[] args)
        {
            do
            {
                switch (Menu())
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
                    default:
                        return;
                }
            } while (true);
        }
        static int Menu()
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
                if (1 > menu || menu > 3)
                {
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return menu;
            } while (true);
        }
        public static void Task1()
        {
            for (int i = 1; i <= 8; ++i) { new Eater(i); }
            Console.ReadKey();
        }
        public static void Task2()
        {
            Console.WriteLine("Async Call");
            CalcAsync();
            Console.WriteLine("After Async");
            Console.ReadKey();
        }
        public static void Task3()
        {
            ManualResetEvent evtObj = new ManualResetEvent(false);
            new Task3("Событийный поток 1", evtObj);
            Console.WriteLine("Основной поток ожидает событие");
            evtObj.WaitOne();
            Console.WriteLine("Основной поток получил уведомление о событии от первого потока");
            evtObj.Reset();
            new Task3("Событийный поток 2", evtObj);
            evtObj.WaitOne();
            Console.WriteLine("Основной поток получил уведомление о событии от второго потока");
            Console.ReadKey();
        }
        static void Calc()
        {
            Thread.Sleep(1000);
        }
        static async void CalcAsync()
        {
            Console.WriteLine("Async Method Start");
            await Task.Run(() => Calc());
            Console.WriteLine("Async Method End");
        }
    }
    class Task3
    {
        public Thread Thrd;
        readonly ManualResetEvent mre;

        public Task3(string name, ManualResetEvent evt)
        {
            Thrd = new Thread(this.Run) { Name = name };
            mre = evt;
            Thrd.Start();
        }
        void Run()
        {
            Console.WriteLine("Внутри потока " + Thrd.Name);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Thrd.Name);
                Thread.Sleep(500);
            }
            Console.WriteLine(Thrd.Name + " завершен!");
            mre.Set();
        }
    }
    class Food
    {
        public static int food = 5;
        public static Semaphore empty = new Semaphore(1, 1);
        public static Semaphore empty2 = new Semaphore(1, 1);
    }
    class Cook
    {
        public void Cooking()
        {
            Food.empty.WaitOne();
            Console.WriteLine("Повар готовит еду");
            Thread.Sleep(1500);
            Food.food += 5;
            Food.empty.Release();
        }
    }
    class Eater
    {
        public static Cook cook = new Cook();

        public Eater(int i)
        {
            Thread myThread = new Thread(Eat) { Name = $"Дикарь {i}" };
            myThread.Start();
        }
        public void Eat()
        {
            Food.empty2.WaitOne();
            Food.food--;
            if (Food.food == -1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} зовет повара");
                CallCook();
            }
            Food.empty2.Release();
            Console.WriteLine($"{Thread.CurrentThread.Name} ест");
            Thread.Sleep(500);
            Console.WriteLine($"{Thread.CurrentThread.Name} поел");
        }
        public void CallCook()
        {
            cook.Cooking();
        }
    }
}
