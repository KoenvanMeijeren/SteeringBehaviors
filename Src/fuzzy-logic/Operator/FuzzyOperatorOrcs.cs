using System.Collections.Generic;
using System.Linq;
using Src.fuzzy_logic.Term;

namespace Src.fuzzy_logic.Operator
{
    /// <summary>
    /// Provides the fuzzy OR operator to be used in the creation of a fuzzy rule base.
    /// </summary>
    public class FuzzyOperatorOr : FuzzyTerm
    {
        private readonly List<FuzzyTerm> _terms = new List<FuzzyTerm>();
        private FuzzyOperatorOr(FuzzyOperatorOr fuzzyOperatorOr) => _terms.AddRange(fuzzyOperatorOr._terms);

        public FuzzyOperatorOr(FuzzyTerm term)
        {
            _terms.Add(term.Clone());
        }

        public FuzzyOperatorOr(FuzzyTerm term1, FuzzyTerm term2)
        {
            _terms.Add(term1.Clone());
            _terms.Add(term2.Clone());
        }

        public override FuzzyTerm Clone() => new FuzzyOperatorOr(this);
        public override double GetDom() => _terms.Select(fuzzyTerm => fuzzyTerm.GetDom()).Prepend(double.MinValue).Max();
        public override void ResetDom() => _terms.ForEach((term) => term.ResetDom());
        public override void OrWithDom(double value) => _terms.ForEach(term => term.OrWithDom(value));
    }
}
