using System.Collections.Generic;
using Src.fuzzy_logic.Set;
using Src.fuzzy_logic.Term;

namespace Src.fuzzy_logic
{
    /// <summary>
    /// Class to define a fuzzy linguistic variable (FLV).
    /// An FLV comprises of a number of fuzzy sets.
    /// </summary>
    public class FuzzyVariable
    {
        private readonly Dictionary<string, FuzzySet> _members = new Dictionary<string, FuzzySet>();

        /// <summary>
        /// The following methods create instances of the sets named in the method
        /// name and add them to the member set map. Each time a set of any type is
        /// added the _minRange and _maxRange are adjusted accordingly. All of the
        /// methods return a proxy class representing the newly created instance. This
        /// proxy set can be used as an operand when creating the rule base.
        /// </summary>
        public FuzzyTermSet AddLeftShoulderSet(string name, double min, double peak, double max)
        {
            return AddFuzzyTermSet(name, new FuzzySetLeftShoulder(peak, peak - min, peak - max));
        }

        public FuzzyTermSet AddRightShoulderSet(string name, double min, double peak, double max)
        {
            return AddFuzzyTermSet(name, new FuzzySetRightShoulder(peak, peak - min, peak - max));
        }

        public FuzzyTermSet AddTriangleSet(string name, double min, double mid, double max)
        {
            return AddFuzzyTermSet(name, new FuzzySetTriangle(mid, mid - min, mid - max));
        }

        private FuzzyTermSet AddFuzzyTermSet(string name, FuzzySet set)
        {
            _members.Add(name, set);

            return _members.TryGetValue(name, out FuzzySet fuzzySet) ? new FuzzyTermSet(fuzzySet) : null;
        }

        /// <summary>
        /// Fuzzify a value by calculating its DOM in each of this variable's subsets.
        /// </summary>
        public void Fuzzify(double value)
        {
            foreach (FuzzySet set in _members.Values)
            {
                set.DegreeOfMembership = set.CalculateDom(value);
            }
        }

        /// <summary>
        /// Defuzzify the variable using the max average method.
        /// </summary>
        public double DeFuzzifyMaxAv()
        {
            double top = 0, bottom = 0;

            foreach (FuzzySet set in _members.Values)
            {
                top += set.RepresentativeValue * set.DegreeOfMembership;
                bottom += set.DegreeOfMembership;
            }

            // Make sure bottom is not equal to zero
            if (bottom == 0)
            {
                return 0;
            }

            return top / bottom;
        }
    }
}
