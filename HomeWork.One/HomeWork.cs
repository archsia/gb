// See https://aka.ms/new-console-template for more information

using System;
using Gb.HomeWork.One;

namespace HomeWork.One
{
    class ExOne
    {
        public static void Main(string[] args)
        {
            ExerciseOne();
            ExerciseTwo();
            ExerciseThree();
            ExerciseFour();
            ExerciseFive();
            ExerciseSix();
        }

        private static void ExerciseSix()
        {
            Helper.PrintToCenter("test print to center.");
        }

        private static void ExerciseFive()
        {
            string str = "Ivan Serov, Ivanovo";
            Console.WriteLine(str);
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);
            Console.WriteLine(str);

            static void Print(string ms, int x, int y)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(ms);
            }
            
            Print(str, (Console.WindowWidth - str.Length) / 2, Console.CursorTop);
        }

        private static void ExerciseFour()
        {
            int x1, x2, temp;
            
            Console.Write("x1: ");
            x1 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("x2: ");
            x2 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            temp = x1;
            x1 = x2;
            x2 = temp;
            Console.WriteLine($"x1: {x1}\tx2: {x2}");
            
            x2 = x1 + x2;
            x1 = x2 - x1;
            x2 = x2 - x1;
            Console.WriteLine($"x1: {x1}\tx2: {x2}");
        }

        private static void ExerciseThree()
        {
            int x1, x2, y1, y2;
            try
            {
                Console.Write("x1: ");
                x1 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.Write("y1: ");
                y1 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.Write("x2: ");
                x2 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.Write("y2: ");
                y2 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                Console.WriteLine($"Result: {Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)):F2}");
                
                static double GetDistanceBetweenTwoPoints(int x2, int x1, int y2, int y1)
                {
                    return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                }
                Console.WriteLine($"Result: {GetDistanceBetweenTwoPoints(x2, x1, y2, y1):F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseTwo()
        {
            double height;
            double weight;
            try
            {
                Console.Write("Height (cm): ");
                height = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException()) / 100;
                Console.Write("Weight (kg): ");
                weight = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.WriteLine($"Result: {weight / Math.Pow(height, 2)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseOne()
        {
            string? name;
            string? surname;
            int? age;
            double? height;
            double? weight;

            try
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("Surname: ");
                surname = Console.ReadLine();
                Console.Write("Age: ");
                age = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.Write("Height: ");
                height = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.Write("Weight: ");
                weight = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                Console.WriteLine("Name: " + name + "\tSurname: " + surname + "\tAge: " + age + "\tHeight: " + height +
                                  "\tWeight: " + weight);
                Console.WriteLine("Name: {0}\tSurname: {1}\tAge: {2}\tHeight: {3}\tWeight: {4}", name, surname, age,
                    height, weight);
                Console.WriteLine($"Name: {name}\tSurname: {surname}\tAge: {age}\tHeight: {height}\tWeight: {weight}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}