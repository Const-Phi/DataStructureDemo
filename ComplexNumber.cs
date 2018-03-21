using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureDemo
{
    class ComplexNumber
    {
        double re, im;

        public ComplexNumber(double re = 0, double im = 0)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString() => 
            $"<{re}; {im}>";

        public static implicit operator ComplexNumber(double value) => 
            new ComplexNumber(value);

        public static explicit operator double(ComplexNumber value) =>
            value.re;
    }
}
