namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the <token>GenomeDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class TNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Genome identifier (a.k.a., TNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public TNumber(uint number) {
            Number = number;
            _db = GenomeDb.Instance;
        }

    }

}
