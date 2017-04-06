namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the <token>EnvironDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class ENumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Environ identifier (a.k.a., ENumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public ENumber(uint number) {
            Number = number;
            _db = EnvironDb.Instance;
        }

    }

}
