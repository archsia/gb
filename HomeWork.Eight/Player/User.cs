using System.Xml.Serialization;

namespace Player
{
    public class User
    {
        private string _nickname;
        [XmlAttribute]
        public string Nickname => _nickname;

        public User()
        {
            
        }
        public User(string nickname)
        {
            _nickname = nickname;
        }

        public override string ToString()
        {
            return _nickname;
        }
    }
}