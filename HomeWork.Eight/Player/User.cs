namespace HomeWork.Eight.Player
{
    public struct User
    {
        public string Nickname { get; }

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