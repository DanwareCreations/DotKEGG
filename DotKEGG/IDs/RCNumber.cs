namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the RCLASS database.
    /// </summary>
    /// <seealso cref="ReactionClassDb"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class RCNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Reaction Class identifier (a.k.a., RCNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public RCNumber(uint number) {
            Number = number;
            _db = ReactionClassDb.Instance;
        }

    }

}
