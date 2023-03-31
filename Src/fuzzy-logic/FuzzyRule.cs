using Src.fuzzy_logic.Term;

namespace Src.fuzzy_logic
{
    /// <summary>
    /// This class implements a fuzzy rule of the form:
    /// IF fzVar1 AND fzVar2 AND ... fzVarN THEN fzVar.c
    /// </summary>
    public class FuzzyRule
    {
        private readonly FuzzyTerm _antecedent, _consequence;

        public FuzzyRule(FuzzyTerm antecedent, FuzzyTerm consequence)
        {
            _antecedent = antecedent;
            _consequence = consequence;
        }

        public void ResetConsequence() => _consequence.ResetDom();

        /// <summary>
        /// This method updates the DOM (the confidence) of the consequent term with
        /// the DOM of the antecedent term. 
        /// </summary>
        public void CalculateConsequence() => _consequence.OrWithDom(_antecedent.GetDom());
    }
}
