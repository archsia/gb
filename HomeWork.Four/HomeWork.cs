// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using SuperArrayLib;
using TwoDimensionalArrayLib;

namespace HomeWork.Four
{
    static class HomeWork
    {
        private const string pathToFileNumbers =
            "/home/dev/Documents/projects/Gb/HomeWork.Four/bin/Debug/net6.0/NewFile1.txt";
        private const string pathToFileCredentials =
            "/home/dev/Documents/projects/Gb/HomeWork.Four/bin/Debug/net6.0/credentials.txt";
        private const string pathToFileWithArray =
            "/home/dev/Documents/projects/Gb/HomeWork.Four/bin/Debug/net6.0/NewFile2.txt";
        
        static void Main(string[] args)
        {
            ExerciseOne();
            ExerciseTwo();
            ExerciseThree();
            ExerciseFour();
            ExerciseFive();
        }

        private static void ExerciseFive()
        {
            Console.WriteLine("Реализовать библиотеку с классом для работы с двумерным массивом. " +
                              "Реализовать конструктор, заполняющий массив случайными числами. Создать методы, " +
                              "которые возвращают сумму всех элементов массива, сумму всех элементов массива больше " +
                              "заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее " +
                              "максимальный элемент массива, метод, возвращающий номер максимального элемента массива " +
                              "(через параметры, используя модификатор ref или out).\nДобавить конструктор и методы, " +
                              "которые загружают данные из файла и записывают данные в файл.\nОбработать возможные " +
                              "исключительные ситуации при работе с файлами.");
            
            TwoDimensionalArray tw = new TwoDimensionalArray(10, 10);
            for (var i = 0; i < tw.SizeX; i++)
            {
                for (var j = 0; j < tw.SizeY; j++)
                    Console.Write($"{tw.Array[i, j]}\t");
                Console.WriteLine();
            }
            
            Console.WriteLine($"Sum: {tw.GetSum()}");
            Console.WriteLine($"Sum: {tw.GetSum(9000)}");
            Console.WriteLine($"Max: {tw.MaxElement}");
            Console.WriteLine($"Min: {tw.MinElement}");
            NumberOfElement? number;
            tw.GetNumberOfMaxElement(out number);
            Console.WriteLine($"Number of max: {number}");
            TwoDimensionalArray tw1 = new(10, 10, pathToFileWithArray);
            tw.Path = pathToFileWithArray;
            tw.WriteArrayToFile();
            tw1.FillArrayFromFile();
            for (var i = 0; i < tw1.SizeX; i++)
            {
                for (var j = 0; j < tw1.SizeY; j++)
                    Console.Write($"{tw1.Array[i, j]}\t");
                Console.WriteLine();
            }
        }

        private static void ExerciseFour()
        {
            Console.WriteLine(
                "Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.\n" +
                "Создайте структуру Account, содержащую Login и Password.");
            try
            {
                var countLines = File.ReadLines(pathToFileCredentials).Count();
                Account[] accounts = new Account[countLines/2];

                using (StreamReader sr = new(pathToFileCredentials))
                {
                    var i = 0;
                    while (sr.Peek() >= 0)
                    {
                        accounts[i] = new Account(sr.ReadLine()!, sr.ReadLine()!);
                        i++;
                    }
                }

                Console.WriteLine(string.Join(", ", accounts.ToArray()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseThree()
        {
            Console.WriteLine("Дописать класс для работы с одномерным массивом. Реализовать конструктор, " +
                              "создающий массив определенного размера и заполняющий массив числами от начального " +
                              "значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов " +
                              "массива, метод Inverse, возвращающий новый массив с измененными знаками у всех " +
                              "элементов массива (старый массив, остается без изменений), метод Multi, " +
                              "умножающий каждый элемент массива на определённое число, свойство MaxCount, " +
                              "возвращающее количество максимальных элементов.\nСоздать библиотеку содержащую класс " +
                              "для работы с массивом. Продемонстрировать работу библиотеки.\nПодсчитать частоту " +
                              "вхождения каждого элемента в массив (коллекция Dictionary<int,int>)");
            SuperArray sa = new(0, 20, 2);
            Console.WriteLine($"Initialize: {sa.ToString()}");
            Console.WriteLine($"Sum: {sa.Sum}");
            Console.WriteLine($"Inverse: ({String.Join(", ", sa.Inverse().ToArray())})");
            sa.Multi(2);
            Console.WriteLine($"Multiply: {sa.ToString()}");
            SuperArray sa1 = new(SuperArray.GetRandomArray(1000000));
            Console.WriteLine($"Max count: {sa1.MaxCount}");

            IDictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var num in sa1.Array)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else dict[num] = 1;
            }

            Console.WriteLine($"Max value: {dict.Keys.Max()}");
            Console.WriteLine($"Count max value: {dict[dict.Keys.Max()]}");
        }

        private static void ExerciseTwo()
        {
            Console.WriteLine("\nРеализуйте задачу 1 в виде статического класса StaticClass; " +
                              "Класс должен содержать статический метод, который принимает на вход массив и решает " +
                              "задачу 1;\nДобавьте статический метод для считывания массива из текстового файла. " +
                              "Метод должен возвращать массив целых чисел;\nДобавьте обработку ситуации отсутствия " +
                              "файла на диске. Serov");
            int[] array = SuperArray.GetRandomArray(20);
            SuperArray.PrintPairNumbers(array);

            Console.WriteLine(
                $"\nResult from file: ({string.Join(", ", SuperArray.GetArrayFromFile(pathToFileNumbers))})");
        }

        private static void ExerciseOne()
        {
            Console.WriteLine("Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые " +
                              "значения от –10 000 до 10 000 включительно. Заполнить случайными числами. " +
                              "\nНаписать программу, позволяющую найти и вывести количество пар элементов массива, " +
                              "в которых только одно число делится на 3.\nВ данной задаче под парой подразумевается " +
                              "два подряд идущих элемента массива. Serov");
            int[] array = SuperArray.GetRandomArray(20);

            IList<int[]> result = new Collection<int[]>();
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (array[i] % 3 == 0 && array[i + 1] % 3 != 0)
                {
                    result.Add(new[] {array[i], array[i + 1]});
                }
            }

            Console.WriteLine($"Result: {result.Count}");
            Console.Write("Elements: ");
            foreach (var r in result)
            {
                Console.Write($"({string.Join(", ", r)})\t");
            }
        }
    }
}