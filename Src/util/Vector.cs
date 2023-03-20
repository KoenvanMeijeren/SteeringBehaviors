using System;
using System.Globalization;

namespace Src.util
{
    public class Vector
    {
        public readonly double X, Y, Length, LengthSquared;
        public double XRounded => Math.Round(X, 2);
        public double YRounded => Math.Round(Y, 2);

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
            LengthSquared = (X * X) + (Y * Y);
            Length = Math.Sqrt(LengthSquared);
        }

        public static Vector operator +(Vector left, Vector right) => new Vector(left.X + right.X, left.Y + right.Y);
        public static Vector operator +(Vector left, double value) => new Vector(left.X + value, left.Y + value);
        public static Vector operator +(double value, Vector vector) => vector + value;
        public Vector Add(double x, double y) => new Vector(X + x, Y + y);

        public static Vector operator -(Vector vector, Vector right) => new Vector(vector.X - right.X, vector.Y - right.Y);
        public static Vector operator -(Vector vector, double value) => new Vector(vector.X - value, vector.Y - value);
        public static Vector operator -(double value, Vector vector) => vector - value;
        public Vector Subtract(double x, double y) => new Vector(X - x, Y - y);
        public Vector SubtractX(double amount) => new Vector(X - amount, Y);
        public Vector SubtractY(double amount) => new Vector(X, Y - amount);

        public static Vector operator *(Vector left, Vector right) => new Vector(left.X * right.X, left.Y * right.Y);
        public static Vector operator *(Vector left, double value) => new Vector(left.X * value, left.Y * value);
        public static Vector operator *(double value, Vector vector) => vector * value;
        public Vector Multiply(double x, double y) => new Vector(X * x, Y * y);

        public static Vector operator /(Vector vector, double value)
        {
            if (value == 0.0)
            {
                throw new ArithmeticException("Cannot divide vector by zero!");
            }

            return new Vector(vector.X / value, vector.Y / value);
        }

        public Vector Divide(double x, double y)
        {
            if (x == 0.0 || y == 0.0)
            {
                throw new ArithmeticException("Cannot divide vector by zero!");
            }

            return new Vector(X / x, Y / y);
        }

        public Vector Normalize() => Length == 0 ? new Vector(X, Y) : this / Length;

        public Vector Truncate(double max) => !(Length > max) ? new Vector(X, Y) : Normalize() * max;

        public bool IsEmpty() => X == 0.0 && Y == 0.0;

        public bool IsInRange(Vector start, Vector end)
        {
            if (!(X > start.X) || !(X < end.X))
            {
                return false;
            }

            return Y > start.Y && Y < end.Y;
        }
        
        public override string ToString() => $"({XRounded.ToString(CultureInfo.InvariantCulture)},{YRounded.ToString(CultureInfo.InvariantCulture)})";
    }
}
