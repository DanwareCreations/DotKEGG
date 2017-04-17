namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the KEGG BRITE database.
    /// </summary>
    /// <seealso cref="BriteDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <inheritdoc/>
    public sealed class BRNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Brite identifier (a.k.a., BRNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public BRNumber(uint number) {
            Number = number;
            _db = BriteDb.Instance;
        }

    }

}
