namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the REACTION database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class RNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Reaction identifier (a.k.a., RNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public RNumber(uint number) {
            Number = number;
            _db = ReactionDb.Instance;
        }

    }

}
