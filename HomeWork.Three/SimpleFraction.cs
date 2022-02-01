using System;

namespace HomeWork.Three
{
    public class SimpleFraction
    {
        private int _cardinal;
        private int _ordinal;

        public int Cardinal => _cardinal;
        public int Ordinal => _ordinal;
        public double Decimal => ((double) _cardinal / (double) _ordinal);

        public SimpleFraction(int cardinal, int ordinal)
        {
            if (ordinal == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0.");

            _cardinal = cardinal;
            _ordinal = ordinal;
        }

        public static SimpleFraction operator +(SimpleFraction sf) => sf;

        public static SimpleFraction operator -(SimpleFraction sf) => new(-sf._cardinal, sf._ordinal);

        public static SimpleFraction operator +(SimpleFraction sf1, SimpleFraction sf2)
            => new(sf1._cardinal * sf2._ordinal + sf2._cardinal * sf1._ordinal, sf1._ordinal * sf2._ordinal);

        public static SimpleFraction operator -(SimpleFraction sf1, SimpleFraction sf2) => sf1 + (-sf2);

        public static SimpleFraction operator *(SimpleFraction sf1, SimpleFraction sf2)
            => new(sf1._cardinal * sf2._cardinal, sf1._ordinal * sf2._ordinal);

        public static SimpleFraction operator /(SimpleFraction sf1, SimpleFraction sf2)
        {
            if (sf2._cardinal == 0)
                throw new DivideByZeroException();

            return new SimpleFraction(sf1._cardinal * sf2._ordinal, sf1._ordinal * sf2._cardinal);
        }

        public SimpleFraction ToReduce()
        {
            int gcd = GetGcd(_cardinal, _ordinal);

            if (gcd != 0)
            {
                return new SimpleFraction(_cardinal /= gcd, _ordinal /= gcd);
            }

            return this;
        }

        private static int GetGcd(int x1, int x2)
        {
            int temp;
            x1 = Math.Abs(x1);
            x2 = Math.Abs(x2);

            while (x2 != 0 && x1 != 0)
            {
                if (x1 % x2 > 0)
                {
                    temp = x1;
                    x1 = x2;
                    x2 = temp % x2;
                }
                else break;
            }

            if (x2 != 0 && x1 != 0) return x2;
            return 0;
        }

        public override string ToString() => $"{_cardinal}/{_ordinal}";
    }
}