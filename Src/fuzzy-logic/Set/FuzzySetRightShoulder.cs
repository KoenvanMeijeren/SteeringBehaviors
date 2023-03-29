namespace Src.fuzzy_logic.Set
{
    /// <summary>
    /// Definition of a fuzzy set that has a right shoulder shape. (the
    /// maximum value this variable can accept is *any* value greater than
    /// the midpoint.
    /// </summary>
    public class FuzzySetRightShoulder : FuzzySet
    {
        /// <summary>
        /// The values that define the shape of this FLV
        /// </summary>
        public readonly double PeakPoint, RightOffset, LeftOffset;

        public FuzzySetRightShoulder(double peakPoint, double rightOffset, double leftOffset): base(((peakPoint + rightOffset) + peakPoint) / 2)
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

            // Find DOM if left of center
            if ( (value <= PeakPoint) && (value > (PeakPoint - LeftOffset)) )
            {
                double grad = 1.0 / LeftOffset;

                return grad * (value - (PeakPoint - LeftOffset));
            }
            // Find DOM if right of center and less than center + right offset
            if ( (value > PeakPoint) && (value <= PeakPoint + RightOffset) )
            {
                return 1.0;
            }

            return 0;
        }
    }
}
