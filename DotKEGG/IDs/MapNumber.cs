namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the <token>PathwayDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class MapNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Pathway identifier (a.k.a., MapNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public MapNumber(uint number) {
            Number = number;
            _db = PathwayDb.Instance;
        }

    }

}
