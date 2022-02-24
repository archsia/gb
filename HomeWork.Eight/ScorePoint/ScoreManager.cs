using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace HomeWork.Eight.ScorePoint
{
    public class ScoreManager
    {
        private string _fileName;
        private List<Score> _list;

        public int Count => _list!.Count;
        public Score this[int index] => _list![index];
        public ICollection<Score> Scores => _list;

        public ScoreManager(string fileName)
        {
            _fileName = fileName;
            _list = new List<Score>();
        }

        public void Add(Score score)
        {
            _list.Add(score);
        }

        public void Remove(int index)
        {
            if (index < _list!.Count && index >= 0)
                _list.RemoveAt(index);
        }

        public void Load()
        {
            try
            {
                XmlSerializer xmlSerializer = new(typeof(List<Score>));
                using FileStream fileStream = new(_fileName, FileMode.Open, FileAccess.Read);
                {
                    if (fileStream.Length > 0)
                        _list = (List<Score>) xmlSerializer.Deserialize(fileStream)!;
                    else
                        _list = new List<Score>();
                }
            }
            catch (FileNotFoundException ex)
            {
                File.Create(_fileName);
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new(typeof(List<Score>));
            using FileStream fileStream = new(_fileName, FileMode.Create, FileAccess.Write);
            {
                xmlSerializer.Serialize(fileStream, _list);
            }
        }
    }
}