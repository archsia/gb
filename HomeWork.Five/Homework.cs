// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace HomeWork.Five
{
    internal static class Homework
    {
        static void Main(string[] args)
        {
            ExerciseOne();
            ExerciseTwo();
            ExerciseThree();
            ExerciseFour();
        }

        private static void ExerciseFour()
        {
            Console.WriteLine(@"Задача ЕГЭ.
                                На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
                                В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
                                каждая из следующих N строк имеет следующий формат: <Фамилия> <Имя> <оценки>, 
                                где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, 
                                состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, 
                                соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, 
                                а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
                                Иванов Петр 4 5 3

                                Требуется написать как можно более эффективную программу, которая будет выводить на 
                                экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть 
                                ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их 
                                фамилии и имена. Serov");
            Console.Write("Count of people: ");
            var countOfPeople = int.Parse(Console.ReadLine()!);
            ICollection<string> journal = new Collection<string>();

            for (var i = 0; i < countOfPeople; i++)
            {
                Console.Write("<Фамилия> <Имя> <оценки>: ");
                journal.Add(Console.ReadLine()!);
            }

            IDictionary<double, ICollection<string>> peopleDict = GetDict(journal);
            List<double> rating = new(peopleDict.Keys);
            rating.Sort();

            for (var i = 0; i < 3; i++)
            {
                foreach (var pair in peopleDict[rating[i]])
                {
                    Console.WriteLine($"{i+1} {pair}");
                }
            }

            #region Local functions

            IDictionary<double, ICollection<string>> GetDict(ICollection<string> value)
            {
                IDictionary<double, ICollection<string>> result = new Dictionary<double, ICollection<string>>();
                foreach (var str in value)
                {
                    string[] array = str.Split();
                    var middle = double.Parse(array[2]) + double.Parse(array[3]) + double.Parse(array[4]) / 3;
                    if (result.ContainsKey(middle))
                    {
                        result[middle].Add($"{array[0]} {array[1]}");
                    }
                    else
                    {
                        ICollection<string> peoples = new List<string>();
                        peoples.Add($"{array[0]} {array[1]}");
                        result[middle] = peoples;
                    }
                }

                return result;
            }

            #endregion
        }

        private static void ExerciseThree()
        {
            Console.WriteLine(
                "Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.");
            Console.WriteLine(Message.CheckTransposition("asdf", "sdfa"));
            Console.WriteLine(Message.CheckTransposition("asdf", "sdfv"));
        }

        private static void ExerciseTwo()
        {
            const string task =
                "Разработать статический класс Message, содержащий следующие статические методы для обработки " +
                "текста:\nа) Вывести только те слова сообщения, которые содержат не более n букв." +
                "\nб) Удалить из сообщения все слова, которые заканчиваются на заданный символ." +
                "\nв) Найти самое длинное слово сообщения." +
                "\nг) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения." +
                "\nСоздать метод, который производит частотный анализ текста. " +
                "В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает " +
                "сколько раз каждое из слов массива входит в этот текст.";
            Console.WriteLine($"{task} Serov");

            Console.WriteLine("<-----------------GetSeparatedWordsByLength----------------->");
            Console.WriteLine(string.Join(", ", Message.RemoveAllWords(task, 2, RemovePattern.MaxLength)).ToArray());
            Console.WriteLine("<-----------------RemoveAllWords----------------->");
            Console.WriteLine(string.Join(", ", Message.RemoveAllWords(task, "я")).ToArray());
            Console.WriteLine("<-----------------GetWordByMaxLength----------------->");
            Console.WriteLine(Message.GetWordByMaxLength(task));
            Console.WriteLine("<-----------------GetWordsByMaxLength----------------->");
            Console.WriteLine(Message.GetWordsByMaxLength(task));
            Console.WriteLine("<-----------------GetFrequency----------------->");
            Console.WriteLine(Message.GetFrequency(task));
        }

        private static void ExerciseOne()
        {
            Console.WriteLine("Создать программу, которая будет проверять корректность ввода логина. " +
                              "Корректным логином будет строка от 2 до 10 символов, содержащая только буквы " +
                              "латинского алфавита или цифры, при этом цифра не может быть первой: " +
                              "\nбез использования регулярных выражений;\nс использованием регулярных выражений.\nSerov");

            Console.WriteLine($"{CheckCorrectLogin("Test123456")}");
            Console.WriteLine($"{CheckCorrectLogin("Test12345678")}");
            Console.WriteLine($"{CheckCorrectLogin("Тест")}");
            Console.WriteLine($"{CheckCorrectLogin("1Test")}");

            Regex r = new Regex(@"^\D[A-Za-z0-9]{2,10}$");
            Console.WriteLine($"Test1: {r.IsMatch("Test1")}");
            Console.WriteLine($"1Test: {r.IsMatch("1Test")}");
            Console.WriteLine($"T: {r.IsMatch("T")}");
            Console.WriteLine($"213124: {r.IsMatch("213124")}");
            Console.WriteLine($"TestTestTest: {r.IsMatch("TestTestTest")}");

            static string CheckCorrectLogin(string login)
            {
                var result = $"{login}: OK.";
                try
                {
                    CheckCorrectLength(login);
                    CheckCorrectStart(login);
                    CheckCorrectEntries(login);
                }
                catch (Exception ex)
                {
                    result = $"Error: {ex.Message}";
                }

                return result;

                #region Local functions

                static void CheckCorrectLength(string s)
                {
                    if (!(s.Length >= 2 && s.Length <= 10))
                    {
                        throw new Exception($"Login \"{s}\" must be is 2-10 characters.");
                    }
                }

                static void CheckCorrectStart(string s)
                {
                    if (char.IsDigit(s[0]))
                    {
                        throw new Exception($"Login \"{s}\" can't start from a digit.");
                    }
                }

                static void CheckCorrectEntries(string s)
                {
                    if (s.Any(ch =>
                        ch is not (>= 'A' and <= 'Z') && ch is not (>= 'a' and <= 'z') &&
                        ch is not (>= '0' and <= '9')))
                    {
                        throw new Exception(
                            $"Login \"{s}\" must contain only latin characters (A-z) and digits (0-9).");
                    }
                }

                #endregion
            }
        }
    }
}