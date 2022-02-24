// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Xml.Serialization;
using HomeWork.Eight.Player;
using HomeWork.Eight.ScorePoint;

namespace HomeWork.Eight
{
    internal static class Homework
    {
        private static void Main(string[] args)
        {
            // ExerciseOne();
            // ExerciseTwo();
            ExerciseFour();
            // ExerciseFive();
        }

        private static void ExerciseFive()
        {
            Console.WriteLine("Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок). Serov");
            List<PersonDto> list;
            list = new List<PersonDto>();
            StreamReader sr = new StreamReader("/home/dev/Documents/projects/Gb/HomeWork.Six/bin/Debug/net6.0/students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine()!.Split(';');
                    list.Add(new PersonDto(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]),  int.Parse(s[6]),  int.Parse(s[7]), s[8]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            sr.Close();

            try
            {
                XmlSerializer xmlSerializer = new(list.GetType());
                using FileStream fileStream =
                    new($"{Directory.GetCurrentDirectory()}/file.xml", FileMode.Create, FileAccess.Write);
                {
                    xmlSerializer.Serialize(fileStream, list);
                }
            }
            catch (DirectoryNotFoundException)
            {
                File.Create($"{Directory.GetCurrentDirectory()}/file.xml");
            }
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
