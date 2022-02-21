// See https://aka.ms/new-console-template for more information

using System;

namespace HomeWork.Seven
{
    internal static class HomeWork
    {
        private static void Main(string[] args)
        {
            ExerciseOne();
            ExerciseTwo();
        }

        private static void ExerciseOne()
        {
            Console.WriteLine(@"а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. Игрок должен получить это число за минимальное количество ходов.
в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте библиотечный обобщенный класс System.Collections.Generic.Stack<int>Stack.
Вся логика игры должна быть реализована в классе с удвоителем. Serov");
            while (true)
            {
                Doubler doubler = new();
                doubler.StartGame();
                LabelRefresh:
                Console.Clear();
                Console.Title = "Doubler";
                Console.WriteLine(
                    $"Need: {doubler.FinishValue}\tCurrent: {doubler.CurrentValue}\tActions: {doubler.Actions}\n");
                if (doubler.CurrentValue > doubler.FinishValue)
                {
                    Console.WriteLine("Lose!\nTry to repeat [0]");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.NumPad0:
                            continue;
                        case ConsoleKey.D0:
                            continue;
                    }
                }

                if (doubler.CurrentValue == doubler.FinishValue)
                {
                    Console.WriteLine("Great!\nTry to repeat [0]");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.NumPad0:
                            continue;
                    }
                }

                Console.WriteLine("1.+1\n2.*2\n3.reset to 1\n4.exit");
                LabelReset:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                        doubler.IncreaseValueBy1();
                        goto LabelRefresh;
                    case ConsoleKey.D1:
                        doubler.IncreaseValueBy1();
                        goto LabelRefresh;
                    case ConsoleKey.NumPad2:
                        doubler.MultiplyValueBy2();
                        goto LabelRefresh;
                    case ConsoleKey.D2:
                        doubler.MultiplyValueBy2();
                        goto LabelRefresh;
                    case ConsoleKey.NumPad3:
                        doubler.ResetValue();
                        goto LabelRefresh;
                    case ConsoleKey.D3:
                        doubler.ResetValue();
                        goto LabelRefresh;
                    case ConsoleKey.NumPad4:
                        Console.WriteLine($"Actions: {doubler.Actions}");
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine($"Actions: {doubler.Actions}");
                        Environment.Exit(0);
                        break;
                    default:
                        continue;
                }
            }
        }

        private static void ExerciseTwo()
        {
            Console.WriteLine(@"Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число 
от 1 до 100, а человек пытается его угадать за минимальное число попыток. 
Компьютер говорит, больше или меньше загаданное число введенного.
            a) Для ввода данных от человека используется элемент TextBox;
            б) **Реализовать отдельную форму c TextBox для ввода числа. Serov");
            Console.Title = "Searcher";
            var number = 0;
            Random rnd = new();
            var searchingNumber = rnd.Next(0, 100);
            do
            {
                Console.Write("Your number: ");
                number = int.Parse(Console.ReadLine()!);
                if (number == searchingNumber)
                    Console.WriteLine("Great!");
                else if (number < searchingNumber)
                    Console.WriteLine("More.");
                else Console.WriteLine("Less.");
            } while (number > 0 && number != searchingNumber);
        }
    }
}