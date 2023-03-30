using Src.fuzzy_logic.Set;

namespace Src.fuzzy_logic.Term
{
    public class FuzzyTermVery : FuzzyTerm
    {
        private readonly FuzzySet _set;

        public FuzzyTermVery(FuzzySet set)
        {
            _set = set;
        }

        public override FuzzyTerm Clone() => new FuzzyTermSet(_set);
        public override double GetDom() => _set.Dom * _set.Dom;
        public override void ResetDom() => _set.ResetDom();
        public override void OrWithDom(double value) => _set.OrWithDom(value * value);
    }
}
