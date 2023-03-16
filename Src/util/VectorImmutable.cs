using System;
using System.Globalization;

namespace Src.util
{
    public class VectorImmutable
    {
        public readonly double X, Y, Length, LengthSquared;
        public double XRounded => Math.Round(X, 2);
        public double YRounded => Math.Round(Y, 2);

        public VectorImmutable(double x, double y)
        {
            X = x;
            Y = y;
            LengthSquared = (X * X) + (Y * Y);
            Length = Math.Sqrt(LengthSquared);
        }

        public static VectorImmutable operator +(VectorImmutable left, VectorImmutable right) => new VectorImmutable(left.X + right.X, left.Y + right.Y);
        public static VectorImmutable operator +(VectorImmutable left, double value) => new VectorImmutable(left.X + value, left.Y + value);
        public static VectorImmutable operator +(double value, VectorImmutable vector) => vector + value;
        public VectorImmutable Add(double x, double y) => new VectorImmutable(X + x, Y + y);

        public static VectorImmutable operator -(VectorImmutable vector, VectorImmutable right) => new VectorImmutable(vector.X - right.X, vector.Y - right.Y);
        public static VectorImmutable operator -(VectorImmutable vector, double value) => new VectorImmutable(vector.X - value, vector.Y - value);
        public static VectorImmutable operator -(double value, VectorImmutable vector) => vector - value;
        public VectorImmutable Subtract(double x, double y) => new VectorImmutable(X - x, Y - y);
        public VectorImmutable SubtractX(double amount) => new VectorImmutable(X - amount, Y);
        public VectorImmutable SubtractY(double amount) => new VectorImmutable(X, Y - amount);

        public static VectorImmutable operator *(VectorImmutable left, VectorImmutable right) => new VectorImmutable(left.X * right.X, left.Y * right.Y);
        public static VectorImmutable operator *(VectorImmutable left, double value) => new VectorImmutable(left.X * value, left.Y * value);
        public static VectorImmutable operator *(double value, VectorImmutable vector) => vector * value;
        public VectorImmutable Multiply(double x, double y) => new VectorImmutable(X * x, Y * y);

        public static VectorImmutable operator /(VectorImmutable vector, double value)
        {
            if (value == 0.0)
            {
                throw new ArithmeticException("Cannot divide vector by zero!");
            }

            return new VectorImmutable(vector.X / value, vector.Y / value);
        }

        public VectorImmutable Divide(double x, double y)
        {
            if (x == 0.0 || y == 0.0)
            {
                throw new ArithmeticException("Cannot divide vector by zero!");
            }

            return new VectorImmutable(X / x, Y / y);
        }

        public VectorImmutable Normalize() => Length == 0 ? new VectorImmutable(X, Y) : this / Length;

        public VectorImmutable Truncate(double max) => !(Length > max) ? new VectorImmutable(X, Y) : Normalize() * max;

        public override string ToString() => $"({XRounded.ToString(CultureInfo.InvariantCulture)},{YRounded.ToString(CultureInfo.InvariantCulture)})";
    }
}
