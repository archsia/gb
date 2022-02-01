// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HomeWork.Three
{
    internal static class Homework
    {
        static void Main(string[] args)
        {
            ExerciseOne();
            ExerciseTwo();
            ExerciseThree();
        }

        private static void ExerciseThree()
        {
            Console.WriteLine("Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. " +
                              "Предусмотреть методы сложения, вычитания, умножения и деления дробей. " +
                              "Написать программу, демонстрирующую все разработанные элементы класса. " +
                              "Добавить свойства типа int для доступа к числителю и знаменателю; " +
                              "Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; " +
                              "Добавить проверку, чтобы знаменатель не равнялся 0. " +
                              "Выбрасывать исключение ArgumentException('Знаменатель не может быть равен 0'); " +
                              "Добавить упрощение дробей. Serov");
            SimpleFraction sf1 = new(1, 6);
            SimpleFraction sf2 = new(2, 6);
            Console.WriteLine($"Cardinal: {sf1.Cardinal}");
            Console.WriteLine($"Ordinal: {sf1.Ordinal}");
            Console.WriteLine($"Decimal: {sf1.Decimal}");
            Console.WriteLine($"Plus: {sf1 + sf2}");
            Console.WriteLine($"Minus: {sf1 - sf2}");
            Console.WriteLine($"Multiply: {sf1 * sf2}");
            Console.WriteLine($"Divide: {sf1 / sf2}");
            try
            {
                SimpleFraction fail = new(1, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine($"Reduce: {(sf1 + sf2).ToReduce()}");
        }

        private static void ExerciseTwo()
        {
            Console.WriteLine("С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). " +
                              "Требуется подсчитать сумму всех нечётных положительных чисел. " +
                              "Сами числа и сумму вывести на экран, используя tryParse. Serov");
            try
            {
                IList<int> evenList = new Collection<int>();
                while (true)
                {
                    Console.Write("Number: ");
                    if (!int.TryParse(Console.ReadLine()!, out var num))
                        throw new Exception("Unresolved symbol for int type.");

                    if (num == 0) break;
                    if (num % 2 == 1 && num > 0) evenList.Add(num);
                }

                Console.WriteLine($"Elements: {string.Join(", ", evenList.ToArray())}");
                Console.WriteLine($"Sum of positive even numbers: {evenList.Sum()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ExerciseOne()
        {
            Console.WriteLine("Дописать структуру Complex, добавив метод вычитания комплексных чисел. " +
                              "Продемонстрировать работу структуры. Дописать класс Complex, добавив методы вычитания " +
                              "и произведения чисел. Проверить работу класса. Добавить диалог с использованием " +
                              "switch демонстрирующий работу класса. Serov");
            Complex complexStruct1 = new Complex(1, 1);
            Complex complexStruct2 = new Complex(2, -2);
            Console.WriteLine(complexStruct2.Minus(complexStruct1));

            ComplexClass complexClass1 = new(1, 1);
            ComplexClass complexClass2 = new(2, 2);
            Console.WriteLine(complexClass1.Multiply(complexClass2));
            Console.WriteLine("0 + 4i" == complexClass1.Multiply(complexClass2).ToString());

            try
            {
                Console.Write("re1: ");
                var re1 = double.Parse(Console.ReadLine()!);
                Console.Write("im1: ");
                var im1 = double.Parse(Console.ReadLine()!);
                Console.Write("re2: ");
                var re2 = double.Parse(Console.ReadLine()!);
                Console.Write("im2: ");
                var im2 = double.Parse(Console.ReadLine()!);
                Console.Write("Operand (+, -, *): ");
                var operand = Console.ReadLine()!;

                ComplexClass testComplex1 = new(re1, im1);
                ComplexClass testComplex2 = new(re2, im2);
                switch (operand)
                {
                    case "+":
                        Console.WriteLine(testComplex1.Plus(testComplex2));
                        break;
                    case "-":
                        Console.WriteLine(testComplex1.Minus(testComplex2));
                        break;
                    case "*":
                        Console.WriteLine(testComplex1.Multiply(testComplex2));
                        break;
                    default:
                        throw new Exception("Undefined operator.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}