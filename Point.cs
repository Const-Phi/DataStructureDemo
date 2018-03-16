using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureDemo
{
    class Point : IEnumerable<double>, IEquatable<Point>, ICloneable, IComparable<Point>
    {
        private int dimension;

        public int Dimension
        {
            get { return dimension; }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Dimension), "Dimension must be greater then zero.");
                dimension = value;

                coordinates = new double[Dimension];
            }
        }

        private double[] coordinates;

        #region .ctors

        public Point(int dimension)
        {
            Dimension = dimension;
        }

        public Point(params double[] coordinates)
        {
            if (coordinates == null)
                throw new ArgumentNullException(nameof(coordinates));

            Dimension = coordinates.GetLength(0);
            Array.Copy(coordinates, this.coordinates, Dimension);
        }

        public Point(IEnumerable<double> coordinates)
        {
            if (coordinates == null)
                throw new ArgumentNullException(nameof(coordinates));

            Dimension = coordinates.Count();
            for (var i = 0; i < Dimension; ++i)
                this.coordinates[i] = coordinates.ElementAt(i);
        }

        #endregion

        public override string ToString() => $"{{{string.Join("; ", this)}}}";

        public IEnumerator<double> GetEnumerator()
        {
            for (var i = 0; i < Dimension; ++i)
                yield return coordinates[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Equals(Point other)
        {
            if (Dimension != other.Dimension)
                return false;

            return DistanceBetween(this, other) <= double.Epsilon;
        }

        public object Clone()
        {
            return new Point(this);
        }

        public static double DistanceBetween(Point p1, Point p2)
        {
            if (p1.Dimension != p2.Dimension)
                throw new ArgumentException();

            return p1.Zip(p2, (c1, c2) => Math.Abs(c1 - c2)).Sum();
        }

        public int CompareTo(Point other) => 
            (int)this.Zip(other, (c1, c2) => c1 - c2).Sum();

    }
}
