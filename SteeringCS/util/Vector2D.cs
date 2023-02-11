using System;

namespace SteeringCS.util
{
   
    public class Vector2D
    {
        public double EastPosition { get; private set; }
        public double NorthPosition { get; private set; }

        public Vector2D() : this(0,0)
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

        public Vector2D Add(Vector2D vehicle)
        {
            EastPosition += vehicle.EastPosition;
            NorthPosition += vehicle.NorthPosition;
            return this;
        }

        public Vector2D Subtract(Vector2D vehicle)
        {
            EastPosition -= vehicle.EastPosition;
            NorthPosition -= vehicle.NorthPosition;
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
            EastPosition /= value;
            NorthPosition /= value;
            return this;
        }

        public Vector2D Normalize()
        {
            return Divide(Length());
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
            return $"({EastPosition},{NorthPosition})";
        }
    }


}
