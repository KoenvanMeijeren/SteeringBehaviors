namespace Src.fuzzy_logic.Set
{
    /// <summary>
    /// This defines a fuzzy set that is a singleton (a range
    /// over which the DOM is always 1.0)
    /// </summary>
    public class FuzzySetSingleton : FuzzySet
    {
        /// <summary>
        /// The values that define the shape of this FLV
        /// </summary>
        public readonly double MidPoint, RightOffset, LeftOffset;

        public FuzzySetSingleton(double midPoint, double rightOffset, double leftOffset): base(midPoint)
        {
            MidPoint = midPoint; 
            RightOffset = rightOffset;
            LeftOffset = leftOffset;
        }

        public override double CalculateDom(double value)
        {
            if ((value >= MidPoint - LeftOffset) && (value <= MidPoint + RightOffset))
            {
                return 1.0;
            }
            
            // Out of range of this FLV, return zero
            return 0.0;
        }
    }
}
