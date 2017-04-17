namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the MODULE database.
    /// </summary>
    /// <seealso cref="ModuleDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <inheritdoc/>
    public sealed class MNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Module identifier (a.k.a., MNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public MNumber(uint number) {
            Number = number;
            _db = ModuleDb.Instance;
        }

    }

}
