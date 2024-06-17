using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public struct Inch
    {
        public decimal Value { get; set; }

        // арифметические операторы +, -, *, /
        public static Inch operator +(Inch inch1, Inch inch2)
        {
            return new Inch { Value = inch1.Value + inch2.Value };
        }
        public static Inch operator -(Inch inch1, Inch inch2)
        {
            return new Inch { Value = inch1.Value - inch2.Value };
        }
        public static Inch operator *(Inch inch1, Inch inch2)
        {
            return new Inch { Value = inch1.Value * inch2.Value };
        }
        public static Inch operator /(Inch inch1, Inch inch2)
        {
            return new Inch { Value = inch1.Value / inch2.Value };
        }

        // унарные + и -
        public static Inch operator ++(Inch inch1)
        {
            return new Inch { Value = inch1.Value + 1 };
        }
        public static Inch operator --(Inch inch1)
        {
            return new Inch { Value = inch1.Value - 1 };
        }

        // операторы сравнения ==, !=, >, <, >=, <=
        public static bool operator !=(Inch inch1, Inch inch2)
        {
            return inch1.Value != inch2.Value;
        }
        public static bool operator ==(Inch inch1, Inch inch2)
        {
            return inch1.Value == inch2.Value;
        }
        public static bool operator >(Inch inch1, Inch inch2)
        {
            return inch1.Value > inch2.Value;
        }
        public static bool operator <(Inch inch1, Inch inch2)
        {
            return inch1.Value < inch2.Value;
        }
        public static bool operator >=(Inch inch1, Inch inch2)
        {
            return inch1.Value >= inch2.Value;
        }
        public static bool operator <=(Inch inch1, Inch inch2)
        {
            return inch1.Value <= inch2.Value;
        }
        // операторы явного и неявного приведения типа

        public static implicit operator Inch(decimal x)
        {
            return new Inch { Value = x };
        }
        public static explicit operator decimal(Inch inch)
        {
            return inch.Value;
        }

        // 1 in = 0.0254 m
        public static implicit operator Meter(Inch inch)
        {

            return new Meter { Value = inch.Value * (decimal)0.0254 };
        }
        public static explicit operator Inch(Meter meter)
        {
            return new Inch { Value = meter.Value / (decimal)0.0254 };
        }
        // методы ToString, GetHashCode и Equals
        public override string ToString()
        {
            return Value.ToString();
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is Inch ? ((Inch)obj).Value == Value : false;
        }
    }
}
