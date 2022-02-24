// See https://aka.ms/new-console-template for more information

using System;
using System.Globalization;
using System.Net;
using HomeWork.Eight.ScorePoint;
using Player;

namespace HomeWork.Eight
{
    internal static class Homework
    {
        private static void Main(string[] args)
        {
            // ExerciseOne();
            // ExerciseTwo();
            ExerciseFour();
        }

        private static void ExerciseFour()
        {
            User user = new("test");
            Score score = new(100, user);

            ScoreManager sm = new("/home/dev/Documents/projects/Gb/HomeWork.Eight/bin/Debug/net6.0/scores");
            sm.Add(score);
            Console.WriteLine(sm.Scores);
            sm.Save();
        }

        private static class Cconsole
        {
            public delegate void WriteHandler(string message);
            public static event WriteHandler TextInput;

            public static string ReadLine()
            {
                var message = Console.ReadLine()!;
                TextInput.Invoke(message);
                return message;
            }
        }

        private static void ExerciseTwo()
        {
            Cconsole.TextInput += DisplayMessage;
            Console.Write("Input: ");
            Cconsole.ReadLine();
            void DisplayMessage(string message) => Console.WriteLine($"Your input: {message}");
        }

        private static void ExerciseOne()
        {
            Console.WriteLine("С помощью рефлексии выведите все свойства структуры DateTime. Serov");
            Type dateTime = typeof(DateTime);
            foreach (var field in dateTime.GetFields())
            {
                Console.WriteLine(field.Name);
            }
        }
    }
}
