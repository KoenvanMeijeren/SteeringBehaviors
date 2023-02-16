using System;
using System.Globalization;

namespace SteeringCS.util
{

    public class Vector2D
    {
        public double XPosition { get; private set; }
        public double YPosition { get; private set; }

        public Vector2D() : this(0, 0)
        {

        }

        public Vector2D(double xPosition, double yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        public double LengthSquared()
        {
            return (XPosition * XPosition) + (YPosition * YPosition);
        }

        public Vector2D Add(Vector2D vector)
        {
            XPosition += vector.XPosition;
            YPosition += vector.YPosition;
            return this;
        }
        
        public Vector2D Add(double x, double y)
        {
            XPosition += x;
            YPosition += y;
            return this;
        }

        public Vector2D Subtract(Vector2D vector)
        {
            XPosition -= vector.XPosition;
            YPosition -= vector.YPosition;
            return this;
        }
        
        public Vector2D Subtract(double x, double y)
        {
            XPosition -= x;
            YPosition -= y;
            return this;
        }

        public Vector2D Multiply(double value)
        {
            XPosition *= value;
            YPosition *= value;
            return this;
        }

        public Vector2D Divide(double value)
        {
            if (value == 0 || value == 0.0)
            {
                throw new ArithmeticException("Cannot divide vector by zero!");
            }

            XPosition /= value;
            YPosition /= value;
            return this;
        }

        public void SetXPosition(double x)
        {
            XPosition = x;
        }
        
        public void SetYPosition(double y)
        {
            YPosition = y;
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
            return new Vector2D(XPosition, YPosition);
        }

        public override string ToString()
        {
            return $"({Math.Round(XPosition, 2).ToString(CultureInfo.InvariantCulture)},{Math.Round(YPosition, 2).ToString(CultureInfo.InvariantCulture)})";
        }
    }
}
