namespace Src.fuzzy_logic.Set
{
    /// <summary>
    /// Definition of a fuzzy set that has a left shoulder shape. (the
    /// minimum value this variable can accept is *any* value less than the
    /// midpoint.)
    /// </summary>
    public class FuzzySetLeftShoulder : FuzzySet
    {
        /// <summary>
        /// The values that define the shape of this FLV
        /// </summary>
        public readonly double PeakPoint, RightOffset, LeftOffset;

        public FuzzySetLeftShoulder(double peakPoint, double rightOffset, double leftOffset): base(((peakPoint - leftOffset) + peakPoint) / 2)
        {
            PeakPoint = peakPoint; 
            RightOffset = rightOffset;
            LeftOffset = leftOffset;
        }

        public override double CalculateDom(double value)
        {
            // Test for the case where the left or right offsets are zero
            // (to prevent divide by zero errors below).
            if ((RightOffset == 0 || LeftOffset == 0) && PeakPoint == value)
            {
                return 1.0;
            }

            // Find DOM if right of center.
            if ((value >= PeakPoint) && (value < (PeakPoint + RightOffset)) )
            {
                double grad = 1.0 / -RightOffset;

                return grad * (value - PeakPoint) + 1.0;
            }

            // Find DOM if left of center.
            if ( (value < PeakPoint) && (value >= PeakPoint - LeftOffset) )
            {
                return 1.0;
            }

            // Out of range of this FLV, return zero.
            return 0.0;
        }
    }
}
