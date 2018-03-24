using System;
using static System.Math;

namespace DataStructureDemo
{
    struct MyStrangeNumber : IEquatable<MyStrangeNumber>
    {
        private double value;

        public MyStrangeNumber(double value)
        {
            this.value = value;
        }

        public override string ToString() => 
            value.ToString();

        public bool Equals(MyStrangeNumber other) =>
            this == other;

        public static implicit operator MyStrangeNumber(double value) =>
            new MyStrangeNumber(value);

        public static MyStrangeNumber operator +(MyStrangeNumber arg) =>
            arg;

        public static MyStrangeNumber operator -(MyStrangeNumber arg) =>
            new MyStrangeNumber(-arg.value);

        public static MyStrangeNumber operator +(MyStrangeNumber lha, MyStrangeNumber rha) =>
            new MyStrangeNumber(lha.value + rha.value);

        public static MyStrangeNumber operator +(MyStrangeNumber lha, double rha) =>
            lha + new MyStrangeNumber(rha);

        public static MyStrangeNumber operator +(double lha, MyStrangeNumber rha) =>
            rha + lha;

        public static MyStrangeNumber operator ^(MyStrangeNumber @base, double degree) =>
            new MyStrangeNumber(Pow(@base.value, degree));

        public static bool operator ==(MyStrangeNumber lha, MyStrangeNumber rha) =>
            lha.value == rha.value;

        public static bool operator !=(MyStrangeNumber lha, MyStrangeNumber rha) =>
            !(lha == rha);

        public static bool operator <=(MyStrangeNumber lha, MyStrangeNumber rha) =>
            lha.value <= rha.value;

        public static bool operator >=(MyStrangeNumber lha, MyStrangeNumber rha) =>
            lha.value >= rha.value;

        public static bool operator >(MyStrangeNumber lha, MyStrangeNumber rha) =>
            !(lha <= rha);

        public static bool operator <(MyStrangeNumber lha, MyStrangeNumber rha) =>
            !(lha >= rha);
    }
}
