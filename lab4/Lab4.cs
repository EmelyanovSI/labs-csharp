using System;

namespace lab4
{
    class Lab4
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
            Notebook notebook = new Notebook();
            Notebook notebook1 = new Notebook(new Person("Ivanov", new DateTime(), 1234567));
            Notebook notebook2 = new Notebook(notebook1.List);
            Notebook notebook3 = new Notebook("Ivanov", new DateTime(), 1234567);
            Console.WriteLine($"{notebook1}\n{notebook2}\n{notebook3}");
            notebook.List.AddRange((notebook1 + notebook2).List);
            notebook.Add(new Person("Emelyanov", new DateTime(), 9999999));
            notebook.Remove(1);
            Console.WriteLine(notebook);
            notebook.Sort();
            Console.WriteLine(notebook);
            Console.WriteLine(notebook.GetByNumber(9999999));
            Console.WriteLine(notebook.Search("Ivanov"));
            Console.WriteLine(notebook.List[0]);
            Console.WriteLine(notebook[1]);
            Console.ReadKey();
        }
        static void Task2()
        {
            Vehicle[] vehicles = new Vehicle[4];
            vehicles[0] = new Car { coordinateX = 1, coordinateY = 11, cost = 5000, speed = 200, year = 2015 };
            Plane p = new Plane { coordinateX = 3, coordinateY = 2, cost = 123133412, speed = 1030, year = 2018 };
            p.setCapacity(100);
            vehicles[1] = p;
            Ship s = new Ship { coordinateX = 5, coordinateY = 7, cost = 5123000, speed = 120, year = 2000 };
            s.setCapacity(1300);
            s.setPort("Spain");
            vehicles[2] = s;
            vehicles[3] = new Car { coordinateX = 1, coordinateY = 11, cost = 5000, speed = 200, year = 2015 };
            Console.WriteLine("Transport list:");
            for (int i = 0; i < vehicles.Length; i++)
            {
                Console.WriteLine(vehicles[i]);
            }
            Console.Write("1st vehicle equals 2nd vehicle : ");
            Console.WriteLine(vehicles[0].Equals(vehicles[1]));
            Console.Write("1st vehicle equals 4nd vehicle : ");
            Console.WriteLine(vehicles[0].Equals(vehicles[3]));
            Console.ReadKey();
        }
    }
}
