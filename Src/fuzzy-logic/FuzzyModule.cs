using System.Collections.Generic;
using Src.fuzzy_logic.Term;

namespace Src.fuzzy_logic
{
    /// <summary>
    /// This class describes a fuzzy module: a collection of fuzzy variables
    /// and the rules that operate on them.
    /// </summary>
    public class FuzzyModule
    {
        private readonly Dictionary<string, FuzzyVariable> _variables = new Dictionary<string, FuzzyVariable>();
        private readonly List<FuzzyRule> _rules = new List<FuzzyRule>();

        /// <summary>
        /// Creates a new "empty" fuzzy variable and returns a reference to it.
        /// </summary>
        public FuzzyVariable CreateFlv(string name) 
        {
            _variables.Add(name, new FuzzyVariable());

            return _variables.TryGetValue(name, out FuzzyVariable fuzzyVariable) ? fuzzyVariable : null;
        }

        /// <summary>
        /// Adds a rule to the module.
        /// </summary>
        public void AddRule(FuzzyTerm antecedent, FuzzyTerm consequence) => _rules.Add(new FuzzyRule(antecedent, consequence));

        /// <summary>
        /// This method calls the Fuzzify method of the variable with the same name as the key.
        /// </summary>
        public void Fuzzify(string nameFlv, double value) 
        {
            if (_variables.TryGetValue(nameFlv, out FuzzyVariable fuzzyVariable))
            {
                fuzzyVariable.Fuzzify(value);
            }
        }

        /// <summary>
        /// Given a fuzzy variable and a defuzzification method this returns a crisp value.
        /// </summary>
        public double DeFuzzify(string key)
        {
            if (!_variables.TryGetValue(key, out FuzzyVariable fuzzyVariable))
            {
                return 0;
            }
            
            foreach (FuzzyRule rule in _rules)
            {
                rule.ResetConsequence();
                rule.CalculateConsequence();
            }

            return fuzzyVariable.DeFuzzifyMaxAv();

        }
    }
}
