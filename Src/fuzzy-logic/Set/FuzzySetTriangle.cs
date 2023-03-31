namespace Src.fuzzy_logic.Set
{
    /// <summary>
    /// This is a simple class to define fuzzy sets that have a triangular
    /// shape and can be defined by a mid point, a left displacement and a
    /// right displacement.
    /// </summary>
    public class FuzzySetTriangle : FuzzySet
    {
        /// <summary>
        /// The values that define the shape of this FLV
        /// </summary>
        public readonly double MidPoint, RightOffset, LeftOffset;

        public FuzzySetTriangle(double midPoint, double rightOffset, double leftOffset) : base(midPoint)
        {
            MidPoint = midPoint;
            RightOffset = rightOffset;
            LeftOffset = leftOffset;
        }

        public override double CalculateDom(double value)
        {
            // Test for the case where the triangle's left or right offsets are zero
            if ((RightOffset == 0 || LeftOffset == 0) && MidPoint == value)
            {
                return 1.0;
            }

            // Find DOM if left of center
            if ((value <= MidPoint) && (value > (MidPoint - LeftOffset)))
            {
                double grad = 1.0 / LeftOffset;

                return grad * (value - (MidPoint - LeftOffset));
            }

            // Find DOM if right of center
            if ((value > MidPoint) && (value < (MidPoint + RightOffset)))
            {
                double grad = 1.0 / -RightOffset;

                return grad * (value - MidPoint) + 1.0;
            }

            // Out of range of this FLV, return zero
            return 0.0;
        }
    }
}
