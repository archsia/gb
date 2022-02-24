using System;
using System.Xml.Serialization;
using HomeWork.Eight.Player;

namespace HomeWork.Eight.ScorePoint
{
    public class Score
    {
        public User User { get; set; }
        public int Value { get; set; }

        public Score()
        {
            
        }
        public Score(int value)
        {
            Value = value;
            User = null;
        }
        
        public Score(int value, User user)
        {
            Value = value;
            User = user;
        }

        public static Score operator +(Score score) => score;

        public static Score operator -(Score score) => new Score(-score.Value);

        public static Score operator +(Score score1, Score score2) => new Score(score1.Value + score2.Value);

        public static Score operator *(Score score1, Score score2) => new Score(score1.Value * score2.Value);

        public static Score operator /(Score score1, Score score2) => new Score(score1.Value * score2.Value);

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}