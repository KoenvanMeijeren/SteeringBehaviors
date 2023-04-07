using System.Collections.Generic;
using System.Linq;
using Src.fuzzy_logic.Term;

namespace Src.fuzzy_logic.Operator
{
    /// <summary>
    /// Provides the fuzzy AND operator to be used in the creation of a fuzzy rule base.
    /// </summary>
    public class FuzzyOperatorAnd : FuzzyTerm
    {
        private readonly List<FuzzyTerm> _terms = new List<FuzzyTerm>();
        private FuzzyOperatorAnd(FuzzyOperatorAnd fuzzyOperatorAnd) => _terms.AddRange(fuzzyOperatorAnd._terms);

        public FuzzyOperatorAnd(FuzzyTerm term)
        {
            _terms.Add(term.Clone());
        }

        public FuzzyOperatorAnd(FuzzyTerm term1, FuzzyTerm term2)
        {
            _terms.Add(term1.Clone());
            _terms.Add(term2.Clone());
        }

        public override FuzzyTerm Clone() => new FuzzyOperatorAnd(this);
        public override double GetDom() => _terms.Select(term => term.GetDom()).Prepend(double.MaxValue).Min();
        public override void ResetDom() => _terms.ForEach((term) => term.ResetDom());
        public override void OrWithDom(double value) => _terms.ForEach(term => term.OrWithDom(value));
    }
}
