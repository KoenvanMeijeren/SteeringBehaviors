using System;
using System.Collections.Generic;
using System.Linq;
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
        private double _minRange, _maxRange;
        
        /// <summary>
        /// This method is called with the upper and lower bound of a set each time a
        /// new set is added to adjust the upper and lower range values accordingly.
        /// </summary>
        private void AdjustRangeToFit(double min, double max) 
        {
            if (min < _minRange)
            {
                _minRange = min;
            }
            
            if (max > _maxRange)
            {
                _maxRange = max;
            }
        }
        
        /// <summary>
        /// The following methods create instances of the sets named in the method
        /// name and add them to the member set map. Each time a set of any type is
        /// added the _minRange and _maxRange are adjusted accordingly. All of the
        /// methods return a proxy class representing the newly created instance. This
        /// proxy set can be used as an operand when creating the rule base.
        /// </summary>
        public FuzzyTermSet AddLeftShoulderSet(string name, double min, double peak, double max) 
        {
            return AddFuzzyTermSet(name, new FuzzySetLeftShoulder(peak, peak - min, peak - max), min, max);
        }

        public FuzzyTermSet AddRightShoulderSet(string name, double min, double peak, double max)
        {
            return AddFuzzyTermSet(name, new FuzzySetRightShoulder(peak, peak - min, peak - max), min, max);
        }

        public FuzzyTermSet AddTriangleSet(string name, double min, double mid, double max)
        {
            return AddFuzzyTermSet(name, new FuzzySetTriangle(mid, mid - min, mid - max), min, max);
        }

        private FuzzyTermSet AddFuzzyTermSet(string name, FuzzySet set, double min, double max)
        {
            _members.Add(name, set);
            AdjustRangeToFit(min, max);
            
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
        /// <returns></returns>
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

        /// <summary>
        /// Defuzzify the variable using the centroid method.
        /// </summary>
        public double DeFuzzifyCentroid(int numSamples)
        {
            // Calculate the step size
            double stepSize = (_maxRange - _minRange) / numSamples;
            double totalArea    = 0;
            double sumOfMoments = 0;

            // Step through the range of this variable in increments equal to StepSize
            // adding up the contribution (lower of CalculateDOM or the actual DOM of this
            // variable's fuzzified value) for each subset. This gives an approximation of
            // the total area of the fuzzy manifold.(This is similar to how the area under
            // a curve is calculated using calculus... the heights of lots of 'slices' are
            // summed to give the total area.).
            //
            // In addition the moment of each slice is calculated and summed. Dividing
            // the total area by the sum of the moments gives the centroid. (Just like
            // calculating the center of mass of an object).
            for (int sample = 1; sample <= numSamples; sample++)
            {
                // For each set get the contribution to the area. This is the lower of the 
                // value returned from CalculateDOM or the actual DOM of the fuzzified 
                // value itself.
                foreach (double contribution in _members.Select(member => member.Value).Select(set => Math.Min(set.CalculateDom(_minRange + sample * stepSize), set.DegreeOfMembership)))
                {
                    totalArea += contribution;
                    sumOfMoments += (_minRange + sample * stepSize)  * contribution;
                }
            }

            // Make sure total area is not equal to zero.
            if (totalArea == 0)
            {
                return 0;
            }
  
            return sumOfMoments / totalArea;
        }
    }
}
