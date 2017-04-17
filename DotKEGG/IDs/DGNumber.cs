namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the DGROUP database.
    /// </summary>
    /// <seealso cref="DrugGroupDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <inheritdoc/>
    public sealed class DGNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Drug Group identifier (a.k.a., DGNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public DGNumber(uint number) {
            Number = number;
            _db = DrugGroupDb.Instance;
        }

    }

}
