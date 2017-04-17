namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the GLYCAN database.
    /// </summary>
    /// <seealso cref="GlycanDb"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
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
