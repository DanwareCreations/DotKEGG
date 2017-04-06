namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the <token>CompoundDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class CNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Compound identifier (a.k.a., CNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public CNumber(uint number) {
            Number = number;
            _db = CompoundDb.Instance;
        }

    }

}
