using System;
using System.Globalization;

namespace SteeringCS.util
{

    public class Vector2D
    {
        public double EastPosition { get; set; }
        public double NorthPosition { get; set; }

        public Vector2D() : this(0, 0)
        {

        }

        public Vector2D(double eastPosition, double northPosition)
        {
            EastPosition = eastPosition;
            NorthPosition = northPosition;
        }

        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        public double LengthSquared()
        {
            return (EastPosition * EastPosition) + (NorthPosition * NorthPosition);
        }

        public Vector2D Add(Vector2D vector)
        {
            EastPosition += vector.EastPosition;
            NorthPosition += vector.NorthPosition;
            return this;
        }

        public Vector2D Subtract(Vector2D vector)
        {
            EastPosition -= vector.EastPosition;
            NorthPosition -= vector.NorthPosition;
            return this;
        }

        public Vector2D Multiply(double value)
        {
            EastPosition *= value;
            NorthPosition *= value;
            return this;
        }

        public Vector2D Divide(double value)
        {
            if (value == 0 || value == 0.0)
            {
                throw new ArithmeticException("Cannot divide vector by zero!");
            }

            EastPosition /= value;
            NorthPosition /= value;
            return this;
        }

        public Vector2D Normalize()
        {
            var length = Length();
            return length == 0 ? this : Divide(length);
        }

        public Vector2D Truncate(double max)
        {
            if (!(Length() > max))
            {
                return this;
            }

            Normalize();
            Multiply(max);
            return this;
        }

        public Vector2D Clone()
        {
            return new Vector2D(EastPosition, NorthPosition);
        }

        public override string ToString()
        {
            return $"({Math.Round(EastPosition, 2).ToString(CultureInfo.InvariantCulture)},{Math.Round(NorthPosition, 2).ToString(CultureInfo.InvariantCulture)})";
        }
    }
}
