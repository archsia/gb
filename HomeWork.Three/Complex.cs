using System;

namespace HomeWork.Three
{
    /// <summary>
    /// Комплексное число
    /// </summary>
    struct Complex
    {
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double im;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double re;

        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Plus(Complex x)
        {
            Complex y;
            y.re = re + x.re;
            y.im = im + x.im;
            return y;
        }

        /// <summary>
        /// Вычитание комплексных чисел.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Minus(Complex x)
        {
            Complex y;
            y.re = re - x.re;
            y.im = im - x.im;
            return y;
        }

        public override string ToString()
        {
            return im >= 0 ? $"{re} + {im}i": $"{re} - {Math.Abs(im)}i";
        }
    }

    /// <summary>
    /// Комплексное число
    /// </summary>
    class ComplexClass
    {
        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        private double im;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double Re { get; set; }


        public ComplexClass()
        {
        }

        public ComplexClass(double re, double im)
        {
            this.Re = re;
            this.im = im;
        }

        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexClass Plus(ComplexClass x)
        {
            return new ComplexClass(Re + x.Re, im + x.im);
        }        
        
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexClass Minus(ComplexClass x)
        {
            return new ComplexClass(Re - x.Re, im - x.im);
        }
        
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexClass Multiply(ComplexClass x)
        {
            return new ComplexClass(Re*x.Re-im*x.im, Re*x.im+x.Re*im);
        }

        public override string ToString()
        {
            return im >= 0 ? $"{Re} + {im}i": $"{Re} - {Math.Abs(im)}i";
        }
    }
}