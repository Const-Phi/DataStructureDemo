using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Dimension), "Dimension must be greater then or equal zero.");
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

        public double this[int index]
        {
            get
            {
                return coordinates[index];
            }
            set
            {
                coordinates[index] = value;
            }
        }

        public override string ToString() => $"{{{string.Join("; ", this)}}}";

        public IEnumerator<double> GetEnumerator()
        {
            for (var i = 0; i < Dimension; ++i)
                yield return coordinates[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Equals(Point other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(other, this))
                return true;

            if (GetType() != other.GetType() || 
                Dimension != other.Dimension)
                return false;

            return DistanceBetween(this, other) <= double.Epsilon;
        }

        public int CompareTo(Point other) =>
            (int) this.Zip(other, (c1, c2) => c1 - c2).Sum();
 
        public static double DistanceBetween(Point p1, Point p2)
        {
            if (p1.Dimension != p2.Dimension)
                throw new ArgumentException();

            return p1.Zip(p2, (c1, c2) => Math.Abs(c1 - c2)).Sum();
        }

        public object Clone() => new Point(this);


        public class PointIterator : IEnumerator<double>
        {
            private const int defaultIndexValue = -1;

            private Point point;

            private int index = defaultIndexValue;

            public PointIterator(Point point)
            {
                this.point = point;
            }

            public double Current
            {
                get
                {
                    return point[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                ++index;
                return index < point.Dimension;
            }

            public void Reset()
            {
                index = defaultIndexValue;
            }
        }
    }
}
