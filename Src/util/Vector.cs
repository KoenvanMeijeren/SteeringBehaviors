using System;
using System.Globalization;

namespace Src.util
{
    public class Vector : IEquatable<Vector>
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
        public static Vector operator +(Vector vector, double value) => new Vector(vector.X + value, vector.Y + value);
        public static Vector operator +(double value, Vector vector) => vector + value;
        public Vector Add(double x, double y) => new Vector(X + x, Y + y);

        public static Vector operator -(Vector left, Vector right) => new Vector(left.X - right.X, left.Y - right.Y);
        public static Vector operator -(Vector vector, double value) => new Vector(vector.X - value, vector.Y - value);
        public static Vector operator -(double value, Vector vector) => vector - value;
        public Vector Subtract(double x, double y) => new Vector(X - x, Y - y);
        public Vector SubtractX(double amount) => new Vector(X - amount, Y);
        public Vector SubtractY(double amount) => new Vector(X, Y - amount);

        public static Vector operator *(Vector left, Vector right) => new Vector(left.X * right.X, left.Y * right.Y);
        public static Vector operator *(Vector vector, double value) => new Vector(vector.X * value, vector.Y * value);
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

        public double DistanceBetween(Vector vector)
        {
            Vector result = this - vector;

            return result.Length;
        }

        public override string ToString() => $"({XRounded.ToString(CultureInfo.InvariantCulture)},{YRounded.ToString(CultureInfo.InvariantCulture)})";

        public bool Equals(Vector other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return X.Equals(other.X) && Y.Equals(other.Y) && Length.Equals(other.Length) && LengthSquared.Equals(other.LengthSquared);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Length.GetHashCode();
                hashCode = (hashCode * 397) ^ LengthSquared.GetHashCode();
                return hashCode;
            }
        }
    }
}
