namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the REACTION database.
    /// </summary>
    /// <seealso cref="ReactionDb"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class RNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Reaction identifier (a.k.a., RNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public RNumber(uint number) : base(ReactionDb.Instance, number) { }

    }

}
