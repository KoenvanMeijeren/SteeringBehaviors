﻿using System;
using System.Globalization;

namespace Src.util
{

    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vector(double xPosition, double yPosition)
        {
            X = xPosition;
            Y = yPosition;
        }

        public double Length() => Math.Sqrt(LengthSquared());

        public double LengthSquared() => (X * X) + (Y * Y);

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

        public Vector SubtractX(double amount)
        {
            X -= amount;
            return this;
        }
        
        public Vector SubtractY(double amount)
        {
            Y -= amount;
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
            if (value == 0.0)
            {
                throw new ArithmeticException("Cannot divide vector by zero!");
            }

            X /= value;
            Y /= value;
            return this;
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

        public Vector Clone() => new Vector(X, Y);

        public override string ToString() => $"({Math.Round(X, 2).ToString(CultureInfo.InvariantCulture)}," +
                                             $"{Math.Round(Y, 2).ToString(CultureInfo.InvariantCulture)})";
    }
}
