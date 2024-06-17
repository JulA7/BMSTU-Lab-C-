using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public struct Meter
    {
        public decimal Value { get; set; }

        // арифметические операторы +, -, *, /
        public static Meter operator +(Meter meter1, Meter meter2)
        {
            return new Meter { Value = meter1.Value + meter2.Value };
        }
        public static Meter operator -(Meter meter1, Meter meter2)
        {
            return new Meter { Value = meter1.Value - meter2.Value };
        }
        public static Meter operator *(Meter meter1, Meter meter2)
        {
            return new Meter { Value = meter1.Value * meter2.Value };
        }
        public static Meter operator /(Meter meter1, Meter meter2)
        {
            return new Meter { Value = meter1.Value / meter2.Value };
        }

        // унарные + и -
        public static Meter operator ++(Meter meter1)
        {
            return new Meter { Value = meter1.Value + 1 };
        }
        public static Meter operator --(Meter meter1)
        {
            return new Meter { Value = meter1.Value - 1 };
        }

        // операторы сравнения ==, !=, >, <, >=, <=
        public static bool operator !=(Meter meter1, Meter meter2)
        {
            return meter1.Value != meter2.Value;
        }
        public static bool operator ==(Meter meter1, Meter meter2)
        {
            return meter1.Value == meter2.Value;
        }
        public static bool operator >(Meter meter1, Meter meter2)
        {
            return meter1.Value > meter2.Value;
        }
        public static bool operator <(Meter meter1, Meter meter2)
        {
            return meter1.Value < meter2.Value;
        }
        public static bool operator >=(Meter meter1, Meter meter2)
        {
            return meter1.Value >= meter2.Value;
        }
        public static bool operator <=(Meter meter1, Meter meter2)
        {
            return meter1.Value <= meter2.Value;
        }
       
        // операторы неявного и явного приведения типа
        public static implicit operator Meter(decimal x)
        {
            return new Meter { Value = x };
        }

        public static explicit operator decimal(Meter meter)
        {
            return meter.Value;
        }

        // 1 in = 0.0254 m
        public static implicit operator Inch(Meter meter)
        {
            return new Inch { Value = meter.Value / (decimal)0.0254 };
        }

        public static explicit operator Meter(Inch inch)
        {
            return new Meter { Value = inch.Value * (decimal)0.0254 };
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
            return obj is Meter ? ((Meter)obj).Value == Value : false;
        }
    }
}
