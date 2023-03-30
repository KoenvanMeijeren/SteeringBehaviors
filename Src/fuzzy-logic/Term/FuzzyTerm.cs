namespace Src.fuzzy_logic.Term
{
    /// <summary>
    /// Abstract class to provide an interface for classes able to be
    /// used as terms in a fuzzy if-then rule base.
    /// </summary>
    public abstract class FuzzyTerm
    {
        /// <summary>
        /// All terms must implement a virtual constructor.
        /// </summary>
        public abstract FuzzyTerm Clone();

        /// <summary>
        /// Retrieves the degree of membership of the term.
        /// </summary>
        public abstract double GetDom();

        /// <summary>
        /// Resets the degree of membership of the term.
        /// </summary>
        public abstract void ResetDom();

        /// <summary>
        /// Method for updating the DOM of a consequent when a rule fires.
        /// </summary>
        public abstract void OrWithDom(double value);
    }
}
