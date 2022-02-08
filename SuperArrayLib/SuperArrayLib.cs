using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace SuperArrayLib
{
    public class SuperArray
    {
        private readonly int[] _array;

        public int[] Array => _array;

        public int Sum
        {
            get
            {
                var sum = 0;
                foreach (var num in _array)
                    sum += num;
                return sum;
            }
        }

        public int MaxCount
        {
            get
            {
                var count = 1;
                var max = int.MinValue;

                for (var i = 0; i < _array.Length; i++)
                {
                    if (_array[i] == max && i != 0)
                        count++;
                    else if (max < _array[i])
                    {
                        count = 1;
                        max = _array[i];
                    }
                }

                return count;
            }
        }

        public SuperArray(int[] array)
        {
            _array = array;
        }

        public SuperArray(int startNumber, int sizeArray, int step)
        {
            _array = new int[sizeArray];
            var value = startNumber;

            for (var i = 0; i < sizeArray; i++)
            {
                _array[i] = value;
                value += step;
            }
        }

        public void Multi(int numberToMultiply)
        {
            for (var i = 0; i < _array.Length; i++)
            {
                _array[i] *= numberToMultiply;
            }
        }

        public int[] Inverse()
        {
            int[] result = new int[_array.Length];
            for (var i = 0; i < _array.Length; i++)
            {
                result[i] = -_array[i];
            }

            return result;
        }

        public static int[] GetArrayFromFile(string path)
        {
            IList<int> valuesFromFile = new Collection<int>();
            try
            {
                using (StreamReader sr = new(path))
                {
                    while (sr.Peek() >= 0)
                        valuesFromFile.Add(int.Parse(sr.ReadLine()!));
                }
            }
            catch (FileNotFoundException ex)
            {
                try
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    path = $"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}NewFile.txt";
                    File.Create(path);
                    Console.WriteLine($"Created file by path: {path}");
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"\nError: {exc.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            return valuesFromFile.ToArray();
        }

        public static int[] GetRandomArray(int arraySize)
        {
            int[] result = new int[arraySize];
            Random random = new();
            for (var i = 0; i < arraySize; i++)
                result[i] = random.Next(-10000, 10000);
            return result;
        }

        public static void PrintPairNumbers(int[] array)
        {
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

        public override string ToString()
        {
            return $"({string.Join(", ", Array.ToArray())})";
        }
    }
}