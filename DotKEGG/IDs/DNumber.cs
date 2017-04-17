namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the DRUG database.
    /// </summary>
    /// <seealso cref="DrugDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <inheritdoc/>
    public sealed class DNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Drug identifier (a.k.a., DNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public DNumber(uint number) {
            Number = number;
            _db = DrugDb.Instance;
        }

    }

}
