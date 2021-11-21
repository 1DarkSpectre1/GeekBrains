using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace less_5
{
    class RationalNumbers
    {
        private int _numerator;
        private int _denominator;

        public int Numerator { get => _numerator; set => _numerator = value; }
        public int Denominator { get => _denominator; set => _denominator = value; }
        public RationalNumbers()
        {
            this._numerator = 0;
            this._denominator = 0;
        }
        public RationalNumbers(int numerator, int denominator)
        {
            this._numerator = numerator;
            this._denominator = denominator;
        }
        public static RationalNumbers operator +(RationalNumbers rn1, RationalNumbers rn2)
        {
            if (rn1.Denominator == rn2.Denominator)
            {
                return new RationalNumbers(rn1.Numerator+rn2.Numerator, rn1.Denominator);
            }
            return new RationalNumbers(rn1.Numerator * rn2.Denominator + rn2.Numerator * rn1.Denominator, rn1.Denominator*rn2.Denominator);
        }
        public static RationalNumbers operator -(RationalNumbers rn1, RationalNumbers rn2)
        {
            if (rn1.Denominator == rn2.Denominator)
            {
                return new RationalNumbers(rn1.Numerator - rn2.Numerator, rn1.Denominator);
            }
            return new RationalNumbers(rn1.Numerator * rn2.Denominator - rn2.Numerator * rn1.Denominator, rn1.Denominator * rn2.Denominator);
        }
        public static RationalNumbers operator *(RationalNumbers rn1, RationalNumbers rn2)
        {
            return new RationalNumbers(rn1.Numerator * rn2.Numerator, rn1.Denominator * rn2.Denominator);
        }
        public static RationalNumbers operator /(RationalNumbers rn1, RationalNumbers rn2)
        {
            return new RationalNumbers(rn1.Numerator * rn2.Denominator, rn1.Denominator * rn2.Numerator);
        }
        //не смог реализовать % потому как не совсем понял что надо. Это остаток от деления но у дроби нет остатка.
        // public static RationalNumbers operator %(RationalNumbers Rn1, RationalNumbers Rn2)
        public static RationalNumbers operator ++(RationalNumbers rn)
        {
            return new RationalNumbers(rn.Numerator += rn.Denominator, rn.Denominator);  
        }
        public static RationalNumbers operator --(RationalNumbers rn)
        {
            return new RationalNumbers(rn.Numerator -= rn.Denominator, rn.Denominator);
        }
        public static bool operator >(RationalNumbers rn1, RationalNumbers rn2)
        {
            if (rn1.Denominator == rn2.Denominator)
            {
                return rn1.Numerator > rn2.Numerator;
            }
            return (rn1.Numerator * rn2.Denominator > rn2.Numerator * rn1.Denominator);
        }

        public static bool operator <(RationalNumbers rn1, RationalNumbers rn2)
        {
            if (rn1.Denominator == rn2.Denominator)
            {
                return rn1.Numerator < rn2.Numerator;
            }
            return (rn1.Numerator * rn2.Denominator < rn2.Numerator * rn1.Denominator);
        }

        public static bool operator >=(RationalNumbers rn1, RationalNumbers rn2)
        {
            if (rn1.Denominator == rn2.Denominator)
            {
                return rn1.Numerator >= rn2.Numerator;
            }
            return (rn1.Numerator * rn2.Denominator > rn2.Numerator * rn1.Denominator);
        }

        public static bool operator <=(RationalNumbers rn1, RationalNumbers rn2)
        {
            if (rn1.Denominator == rn2.Denominator)
            {
                return rn1.Numerator <= rn2.Numerator;
            }
            return (rn1.Numerator * rn2.Denominator <= rn2.Numerator * rn1.Denominator);
        }
        public static bool operator ==(RationalNumbers rn1, RationalNumbers rn2)
        {
            if (rn1.Denominator == rn2.Denominator)
            {
                return rn1.Numerator == rn2.Numerator;
            }
            return (rn1.Numerator * rn2.Denominator == rn2.Numerator * rn1.Denominator);
        }

        public static bool operator !=(RationalNumbers rn1, RationalNumbers rn2)
        {
            if (rn1.Denominator == rn2.Denominator)
            {
                return rn1.Numerator != rn2.Numerator;
            }
            return (rn1.Numerator * rn2.Denominator != rn2.Numerator * rn1.Denominator);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            RationalNumbers m = obj as RationalNumbers; // возвращает null если объект нельзя привести к типу RationalNumbers
            if (m as RationalNumbers == null)
                return false;
            if (m.Denominator == this.Denominator)
            {
                return m.Numerator == this.Numerator;
            }
            return (m.Numerator * this.Denominator == this.Numerator * m.Denominator);
        }
        public override string ToString() => $"{Numerator} / {Denominator}";

        public static explicit operator int(RationalNumbers rn)
        {
            return rn.Numerator/rn.Denominator;
        }
        public static explicit operator double(RationalNumbers rn)
        {
            return (double)rn.Numerator / rn.Denominator;
        }
        public static explicit operator float(RationalNumbers rn)
        {
            return (float)rn.Numerator / rn.Denominator;
        }
    }
}
