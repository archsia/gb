namespace HomeWork.Two.Struct
{
    internal readonly struct NormalBmi
    {
        public double MinNormalValue { get; }

        public double MaxNormalValue { get; }

        public double MiddleNormalValue => (MaxNormalValue + MinNormalValue) / 2;

        public NormalBmi(double minNormalValue, double maxNormalValue)
        {
            MinNormalValue = minNormalValue;
            MaxNormalValue = maxNormalValue;
        }
    }
}