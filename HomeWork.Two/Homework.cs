// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HomeWork.Two.Struct;

namespace HomeWork.Two
{
    static class HomeWork
    {
        private const string Login = "root";
        private const string Password = "GeekBrains";

        internal static void Main(string[] args)
        {
            ExerciseOne();
            ExerciseTwo();
            ExerciseThree();
            ExerciseFour();
            ExerciseFive();
            ExerciseSix();
            ExerciseSeven();
        }

        private static void ExerciseSeven()
        {
            Console.WriteLine("Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b). " +
                              "Разработать рекурсивный метод, который считает сумму чисел от a до b. Serov");

            static void PrintAllNumbersBetweenTwoDigit(int a, int b)
            {
                Console.WriteLine(a);
                if (a < b)
                    PrintAllNumbersBetweenTwoDigit(a + 1, b);
            }

            static int GetCalculatedSumBetweenTwoNumber(int a, int b, ref int sum)
            {
                if (a <= b)
                {
                    sum += a;
                    GetCalculatedSumBetweenTwoNumber(a + 1, b, ref sum);
                }

                return sum;
            }

            try
            {
                Console.Write("a: ");
                var a = int.Parse(Console.ReadLine()!);
                Console.Write("b: ");
                var b = int.Parse(Console.ReadLine()!);
                PrintAllNumbersBetweenTwoDigit(a, b);
                var sum = 0;
                Console.WriteLine($"Sum: {GetCalculatedSumBetweenTwoNumber(a, b, ref sum)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseSix()
        {
            Console.WriteLine("Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до " +
                              "1 000 000 000. «Хорошим» называется число, которое делится на сумму своих цифр. " +
                              "Реализовать подсчёт времени выполнения программы, используя структуру DateTime. Serov");
            var count = 0;
            var startTime = DateTime.Now;

            for (var i = 1; i <= 1000000000; i++)
            {
                var sum = 0;
                var temp = i;
                while (temp != 0)
                {
                    sum += temp % 10;
                    temp /= 10;
                }

                if (i % sum == 0) count++;
            }

            Console.WriteLine($"Result: {count}. Time to run this exercise: {DateTime.Now - startTime}");
        }

        private static void ExerciseFive()
        {
            Console.WriteLine("Написать программу, которая запрашивает массу и рост человека, вычисляет его " +
                              "индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме. " +
                              "Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса. Serov");

            static string GetTipByBmi(double height, double weight)
            {
                var bmi = weight / Math.Pow(height, 2);
                var normalBmi = new NormalBmi(18.5, 25);
                if (bmi < normalBmi.MinNormalValue) return "You must eat more.";
                return bmi > normalBmi.MaxNormalValue ? "You must lose weight." : "Great!";
            }

            static string GetAdvancedTipByBmi(double height, double weight)
            {
                var normalBmi = new NormalBmi(18.5, 25);
                var bmi = weight / Math.Pow(height, 2);
                var normalWeight = new double();

                if (bmi > normalBmi.MaxNormalValue || bmi < normalBmi.MinNormalValue)
                    normalWeight = normalBmi.MiddleNormalValue * Math.Pow(height, 2);
                else return "Great!";

                return normalWeight < weight
                    ? $"You must lose weight on {weight - normalWeight:F2} kg"
                    : $"You must gain weight {normalWeight - weight:F2} kg";
            }

            try
            {
                Console.Write("Height (cm): ");
                var height = double.Parse(Console.ReadLine()!) / 100;
                Console.Write("Weight (kg): ");
                var weight = double.Parse(Console.ReadLine()!);

                Console.WriteLine(GetTipByBmi(height, weight));
                Console.WriteLine(GetAdvancedTipByBmi(height, weight));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseFour()
        {
            Console.WriteLine("Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. " +
                              "На выходе истина, если прошел авторизацию, и ложь, если не прошел " +
                              "(Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля, " +
                              "написать программу: пользователь вводит логин и пароль, программа пропускает его " +
                              "дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя " +
                              "попытками. Serov");

            static bool Authorize(string login, string password)
            {
                return login.Equals(Login) && password.Equals(Password);
            }

            try
            {
                var countAttempt = 0;
                var hasSuccess = false;
                do
                {
                    Console.Write("Login: ");
                    var login = Console.ReadLine()!;
                    Console.Write("Password: ");
                    var password = Console.ReadLine()!;

                    if (Authorize(login, password))
                    {
                        Console.WriteLine($"Hello, {login}!");
                        return;
                    }

                    Console.WriteLine("Incorrect login/password!");
                    countAttempt++;
                } while (!hasSuccess && countAttempt < 3);

                throw new TooManyAttemptLoginException("Your attempt to log into your account was unsuccessful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseThree()
        {
            Console.WriteLine("С клавиатуры вводятся числа, пока не будет введен 0. " +
                              "Подсчитать сумму всех нечетных положительных чисел. Serov");

            try
            {
                IList<int> evenList = new Collection<int>();
                while (true)
                {
                    Console.Write("Number: ");
                    var num = int.Parse(Console.ReadLine()!);
                    if (num == 0) break;
                    if (num % 2 == 1 && num > 0) evenList.Add(num);
                }

                Console.WriteLine($"Sum of even numbers: {evenList.Sum()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseTwo()
        {
            Console.WriteLine("Написать метод подсчета количества цифр числа. Serov");

            static int GetCountDigitsFromNumber(int number)
            {
                int count = 0;
                while (number >= 1)
                {
                    count++;
                    number = number / 10;
                }

                return count;
            }

            try
            {
                Console.Write("Your number: ");
                var num = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"Result: {GetCountDigitsFromNumber(num)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseOne()
        {
            Console.WriteLine("Написать метод, возвращающий минимальное из трёх чисел. Serov");

            static int GetMinimumFromNumbers(IEnumerable<int> numbers)
            {
                int min = int.MaxValue;

                foreach (var num in numbers)
                    if (num < min)
                        min = num;

                return min;
            }

            try
            {
                int[] arr = new int[3];
                for (var i = 0; i < arr.Length; i++)
                {
                    Console.Write($"Input x{i}: ");
                    arr[i] = int.Parse(Console.ReadLine()!);
                }

                Console.WriteLine($"Minimum of all numbers: {GetMinimumFromNumbers(arr)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}