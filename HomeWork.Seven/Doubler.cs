using System;

namespace HomeWork.Seven
{
    class Doubler
    {
        public int Actions { get; set; }

        public int CurrentValue { get; set; }

        public int FinishValue { get; set; }

        public void IncreaseValueBy1()
        {
            CurrentValue++;
            Actions++;
        }

        public void MultiplyValueBy2()
        {
            CurrentValue *= 2;
            Actions++;
        }

        public void ResetValue()
        {
            CurrentValue = 1;
            Actions = 0;
        }

        public void StartGame()
        {
            var rnd = new Random();
            Actions = 0;
            CurrentValue = 1;
            FinishValue = rnd.Next(5, 100);
        }
    }
}