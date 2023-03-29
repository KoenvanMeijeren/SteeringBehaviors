namespace Src.fuzzy_logic.Set
{
    public abstract class FuzzySet
    {
        /// <summary>
        /// This will hold the degree of membership of a given value in this set.
        /// </summary>
        public double Dom { get; protected set; }

        /// <summary>
        /// This is the maximum of the set's membership function. For instance, if
        /// the set is triangular then this will be the peak point of the triangular.
        /// if the set has a plateau then this value will be the mid point of the
        /// plateau. This value is set in the constructor to avoid run-time
        /// calculation of mid-point values.
        /// </summary>
        public readonly double RepresentativeValue;

        protected FuzzySet(double representativeValue)
        {
            Dom = 0;
            RepresentativeValue = representativeValue;
        }

        /// <summary>
        /// Return the degree of membership in this set of the given value. NOTE,
        /// this does not set m_dDOM to the DOM of the value passed as the parameter.
        /// This is because the centroid defuzzification method also uses this method
        /// to determine the DOMs of the values it uses as its sample points.
        /// </summary>
        public abstract double CalculateDom(double value);

        /// <summary>
        /// If this fuzzy set is part of a consequent FLV, and it is fired by a rule
        /// then this method sets the DOM (in this context, the DOM represents a
        /// confidence level)to the maximum of the parameter value or the set's
        /// existing DOM value
        /// </summary>
        public void OrWithDom(double value)
        {
            if (!(value > Dom))
            {
                return;
            }

            Dom = value;
        }

        public void ResetDom()
        {
            Dom = 0;
        }
    }
}
