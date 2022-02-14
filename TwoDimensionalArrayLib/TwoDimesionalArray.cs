using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace TwoDimensionalArrayLib
{
    public class TwoDimensionalArray
    {
        private int _sizeX;
        private int _sizeY;
        private int[,] _array;
        private string? _path;

        public int SizeX => _sizeX;
        public int SizeY => _sizeY;
        public int[,] Array
        {
            get => _array;
            set => _array = value;
        }
        public string? Path
        {
            get => _path;
            set => _path = value;
        }

        public int MaxElement
        {
            get
            {
                var max = int.MinValue;
                for (var i = 0; i < _sizeX; i++)
                    for (var j = 0; j < _sizeY; j++)
                        if (max < _array[i, j])
                            max = _array[i, j];
                return max;
            }
        }

        public int MinElement
        {
            get
            {
                var min = int.MaxValue;
                for (var i = 0; i < _sizeX; i++)
                    for (var j = 0; j < _sizeY; j++)
                        if (min > _array[i, j])
                            min = _array[i, j];
                return min;
            }
        }

        public TwoDimensionalArray(int sizeX, int sizeY)
        {
            _path = null;
            _sizeX = sizeX;
            _sizeY = sizeY;
            _array = new int[sizeX, sizeY];
            Random random = new();
            for (var i = 0; i < sizeX; i++)
                for (var j = 0; j < sizeY; j++)
                    _array[i, j] = random.Next(-10000, 10000);
        }

       
        public TwoDimensionalArray(int sizeX, int sizeY, string path)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _array = new int[sizeX, sizeY];
            _path = path;
        }

        public int GetSum()
        {
            var sum = 0;
            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                    sum += _array[i, j];
            return sum;
        }

        public int GetSum(int moreThan)
        {
            int sum = 0;
            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                    if (moreThan < _array[i, j])
                        sum += _array[i, j];
            return sum;
        }

        public void GetNumberOfMaxElement(out NumberOfElement? number)
        {
            number = null;
            var max = int.MinValue;
            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                    if (max < _array[i, j])
                    {
                        max = _array[i, j];
                        number = new(i, j);
                    }
        }
        
        public void FillArrayFromFile()
        {
            IList<int> valuesFromFile = new Collection<int>();
            try
            {
                if (_path != null)
                    using (StreamReader sr = new(_path))
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
                    _path = $"{AppDomain.CurrentDomain.BaseDirectory}{System.IO.Path.DirectorySeparatorChar}NewFile.txt";
                    File.Create(_path);
                    Console.WriteLine($"File was be created to path: {_path}");
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

            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                    if (valuesFromFile.Count != 0)
                    {
                        _array[i, j] = valuesFromFile[0];
                        valuesFromFile.RemoveAt(0);
                    }
                    else break;
        }

        public void WriteArrayToFile()
        {
            try
            {
                if (_path != null)
                    using (StreamWriter sw = new(_path))
                    {
                        for (var i = 0; i < _sizeX; i++)
                            for (var j = 0; j < _sizeY; j++)
                                sw.WriteLine(_array[i, j]);
                    }
            }
            catch (DirectoryNotFoundException ex)
            {
                try
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    _path = $"{AppDomain.CurrentDomain.BaseDirectory}{System.IO.Path.DirectorySeparatorChar}NewFile.txt";
                    File.Create(_path);
                    Console.WriteLine($"File was be created to path: {_path}");
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
        }
    }

    public struct NumberOfElement
    {
        public int X { get; }

        public int Y { get; }

        public NumberOfElement(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}