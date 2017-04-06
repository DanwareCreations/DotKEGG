namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the <token>GlycanDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class GNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Glycan identifier (a.k.a., GNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public GNumber(uint number) {
            Number = number;
            _db = GlycanDb.Instance;
        }

    }

}
