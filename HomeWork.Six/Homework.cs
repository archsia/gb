// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HomeWork.Six
{
    internal static class HomeWork
    {
        private delegate double Fun(double x, double a);

        private delegate double Fun1(double x);

        static void Main(string[] args)
        {
            ExerciseOne();
            ExerciseTwo();
            ExerciseThree();
        }

        private static void ExerciseThree()
        {
            Console.WriteLine(@"Переделать программу Пример использования коллекций для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;");
            List<(string, string, string, string, string, int, int, int, string)> list;
            list = new List<(string, string, string, string, string, int, int, int, string)>();
            StreamReader sr = new StreamReader("/home/dev/Documents/projects/Gb/HomeWork.Six/bin/Debug/net6.0/students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine()!.Split(';');
                    // Console.WriteLine("{0}", s[0], s[1], s[2], s[3], s[4]);
                    list.Add((s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]),  int.Parse(s[6]),  int.Parse(s[7]), s[8]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            sr.Close();
            list.Sort();

            var countMasters = list.Count(student => student.Item7 == 5 || student.Item7 == 6);
            Console.WriteLine("количество студентов учащихся на 5 и 6 курсах: {0}", countMasters);

            IDictionary<int, int> youngStudents = new Dictionary<int, int>();
            foreach (var student in list)
            {
                if (student.Item6 >= 18 && student.Item6 <= 20)
                    if (youngStudents.ContainsKey(student.Item7))
                        youngStudents[student.Item7]++;
                    else youngStudents[student.Item7] = 1;
            }
            
            youngStudents.ToList().ForEach(student => Console.WriteLine($"{student.Key} курс: {student.Value}"));

            Console.WriteLine("Sort by years old:");
            list = list.OrderBy(student => student.Item6).ToList();
            list.ForEach(student => Console.WriteLine(string.Join(", ", student)));
            
            Console.WriteLine("Sort by course & years old:");
            list = list.OrderBy(student => student.Item7).ThenBy(student => student.Item6).ToList();
            list.ForEach(student => Console.WriteLine(string.Join(", ", student)));
            
            Console.ReadKey();
        }


        private static void ExerciseTwo()
        {
            Console.WriteLine("Модифицировать программу нахождения минимума функции так, чтобы можно было передавать " +
                              "функцию в виде делегата.\nСделать меню с различными функциями и представить " +
                              "пользователю выбор, для какой функции и на каком отрезке находить минимум. " +
                              "Использовать массив (или список) делегатов, в котором хранятся различные функции." +
                              "\nПеределать функцию Load, чтобы она возвращала массив считанных значений. " +
                              "Пусть она возвращает минимум через параметр (с использованием модификатора out). Serov");
            IList<Fun> dels = new List<Fun>() {MyFunc1, MyFunc2};

            Console.WriteLine("Choose method from: ");
            foreach (var del in dels)
            {
                Regex r = new(@"_{2,2}[A-Za-z0-9]*");
                del.GetInvocationList().ToList()
                    .ForEach(del => Console.WriteLine(r.Match(del.Method.Name).ToString()[2..]));
            }

            var method = Console.ReadLine()!;
            double a;
            double x;

            switch (method)
            {
                case "MyFunc1":
                    Console.Write("a: ");
                    a = double.Parse(Console.ReadLine()!);
                    Console.Write("x: ");
                    x = double.Parse(Console.ReadLine()!);
                    Console.WriteLine(dels[0](a, x));
                    break;
                case "MyFunc2":
                    Console.Write("a: ");
                    a = double.Parse(Console.ReadLine()!);
                    Console.Write("x: ");
                    x = double.Parse(Console.ReadLine()!);
                    Console.WriteLine(dels[1](a, x));
                    break;
                default:
                    throw new NotImplementedException();
            }

            static double F(double x)
            {
                return x * x - 50 * x + 10;
            }

            static void SaveFunc(string fileName, double a, double b, double h)
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                double x = a;
                while (x <= b)
                {
                    bw.Write(F(x));
                    x += h; // x=x+h;
                }

                bw.Close();
                fs.Close();
            }

            static ICollection<double> Load(string fileName, out double min)
            {
                ICollection<double> result = new Collection<double>();
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                min = double.MaxValue;
                double d;
                for (int i = 0; i < fs.Length / sizeof(double); i++)
                {
                    // Считываем значение и переходим к следующему
                    d = bw.ReadDouble();
                    result.Add(d);
                    if (d < min) min = d;
                }

                bw.Close();
                fs.Close();
                return result;
            }


            static double MyFunc1(double x, double a)
            {
                return a * x * x;
            }

            static double MyFunc2(double x, double a)
            {
                return a * x * x + x;
            }
        }

        private static void ExerciseOne()
        {
            Console.WriteLine("Изменить программу вывода таблицы функции так, чтобы можно было передавать функции " +
                              "типа double (double, double). Продемонстрировать работу на функции с функцией a*x^2 и " +
                              "функцией a*sin(x). Serov");
            Table(MyFunc1, 1, 3, 3);
            Table((x, a) => a * Math.Sin(x), 1, 3, 3);

            static void Table(Fun f, double x, double a, double b)
            {
                Console.WriteLine("----- X ----- Y -----");
                while (x <= b)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, f(x, a));
                    x += 1;
                }

                Console.WriteLine("---------------------");
            }

            static double MyFunc1(double x, double a)
            {
                return a * x * x;
            }
        }
    }
}