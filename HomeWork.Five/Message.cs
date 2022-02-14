using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HomeWork.Five
{
    public enum RemovePattern
    {
        LastChar,
        MaxLength
    }

    public static class Message
    {
        private static readonly char[] DefaultDelimiters = {' ', ',', ':', ';', '!', '?', '.', '\t', '\n'};

        public static ICollection<string> RemoveAllWords(string from, object value,
            RemovePattern pattern = RemovePattern.LastChar)
        {
            ICollection<string> result = new Collection<string>();

            switch (pattern)
            {
                case RemovePattern.LastChar:
                {
                    foreach (var str in from.Split(DefaultDelimiters))
                    {
                        if (str.Length > 0 && !str.EndsWith((string) value))
                            result.Add(str);
                    }

                    break;
                }
                case RemovePattern.MaxLength:
                    foreach (var str in from.Split(DefaultDelimiters))
                    {
                        var isLettersOnly = true;

                        if (str.Length > 0 && str.Length < (int) value)
                        {
                            foreach (var ch in str.Where(ch => !char.IsLetter(ch)))
                                isLettersOnly = false;
                            if (isLettersOnly)
                                result.Add(str);
                        }
                    }

                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public static string GetWordByMaxLength(string from)
        {
            ICollection<string> strings = new Collection<string>();
            foreach (var str in from.Split(DefaultDelimiters))
            {
                if (str.Length > 0)
                    strings.Add(str);
            }

            return strings.OrderByDescending(s => s.Length).First();
        }

        public static string GetWordsByMaxLength(string from)
        {
            StringBuilder sb = new();
            ICollection<string> strings = new Collection<string>();
            foreach (var str in from.Split(DefaultDelimiters))
            {
                if (str.Length > 0)
                    strings.Add(str);
            }

            var maxLength = strings.Max(str => str == "" ? 0 : str.Length);
            IEnumerable<string> longestStrings = strings.Where(str => (str == "" ? 0 : str.Length) == maxLength);
            foreach (var str in longestStrings)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }

        public static IDictionary<string, int> GetFrequency(string from)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();

            foreach (var str in from.Split(DefaultDelimiters))
            {
                if (str.Length > 0)
                {
                    if (result.ContainsKey(str.ToLower()))
                        result[str.ToLower()]++;
                    else result[str.ToLower()] = 1;
                }
            }

            return result;
        }

        public static bool CheckTransposition(string from, string to)
        {
            IDictionary<char, int> dictFrom = new Dictionary<char, int>();
            IDictionary<char, int> dictTo = new Dictionary<char, int>();
            var result = true;

            foreach (var ch in from)
            {
                if (dictFrom.ContainsKey(ch))
                    dictFrom[ch]++;
                else dictFrom[ch] = 1;
            }

            foreach (var ch in to)
            {
                if (dictTo.ContainsKey(ch))
                    dictTo[ch]++;
                else dictTo[ch] = 1;
            }

            foreach (var pair in dictFrom)
            {
                int value;
                if (dictTo.TryGetValue(pair.Key, out value))
                {
                    if (value != pair.Value)
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}