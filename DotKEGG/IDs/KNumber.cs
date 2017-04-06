namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the <token>OrthologyDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class KNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Orthology identifier (a.k.a., KNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public KNumber(uint number) {
            Number = number;
            _db = OrthologyDb.Instance;
        }

    }

}
