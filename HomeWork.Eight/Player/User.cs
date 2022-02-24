namespace HomeWork.Eight.Player
{
    public class User
    {
        public string Nickname { get; }

        public User()
        {
        }

        public User(string nickname)
        {
            Nickname = nickname;
        }

        public override string ToString()
        {
            return Nickname;
        }
    }
}