using System;
using Src.fuzzy_logic.Set;

namespace Src.fuzzy_logic.Term
{
    public class FuzzyTermFairly : FuzzyTerm
    {
        private readonly FuzzySet _set;

        public FuzzyTermFairly(FuzzySet set)
        {
            _set = set;
        }

        public override FuzzyTerm Clone() => new FuzzyTermSet(_set);
        public override double GetDom() => Math.Sqrt(_set.DegreeOfMembership);
        public override void ResetDom() => _set.ResetDom();
        public override void OrWithDom(double value) => _set.OrWithDom(Math.Sqrt(value));
    }
}
