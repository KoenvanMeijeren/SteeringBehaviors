using System;
using System.Globalization;

namespace Src.util
{

    public class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        public double LengthSquared()
        {
            return (X * X) + (Y * Y);
        }

        public Vector Add(Vector vector)
        {
            X += vector.X;
            Y += vector.Y;
            return this;
        }

        public Vector Add(double x, double y)
        {
            X += x;
            Y += y;
            return this;
        }

        public Vector Subtract(Vector vector)
        {
            X -= vector.X;
            Y -= vector.Y;
            return this;
        }

        public Vector Subtract(double x, double y)
        {
            X -= x;
            Y -= y;
            return this;
        }

        public Vector SubtractY(double amount)
        {
            Y -= amount;
            return this;
        }

        public Vector SubtractX(double amount)
        {
            X -= amount;
            return this;
        }

        public Vector Multiply(double value)
        {
            X *= value;
            Y *= value;
            return this;
        }

        public Vector Divide(double value)
        {
            if (value == 0 || value == 0.0)
            {
                throw new ArithmeticException("Cannot divide vector by zero!");
            }

            X /= value;
            Y /= value;
            return this;
        }

        public void SetXPosition(double x)
        {
            X = x;
        }

        public void SetYPosition(double y)
        {
            Y = y;
        }

        public Vector Normalize()
        {
            double length = Length();
            return length == 0 ? this : Divide(length);
        }

        public Vector Truncate(double max)
        {
            if (!(Length() > max))
            {
                return this;
            }

            Normalize();
            Multiply(max);
            return this;
        }

        public Vector Clone()
        {
            return new Vector(X, Y);
        }

        public override string ToString()
        {
            return $"({Math.Round(X, 2).ToString(CultureInfo.InvariantCulture)},{Math.Round(Y, 2).ToString(CultureInfo.InvariantCulture)})";
        }
    }
}
