namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the PATHWAY database.
    /// </summary>
    /// <seealso cref="PathwayDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <inheritdoc/>
    public sealed class MapNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Pathway identifier (a.k.a., MapNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public MapNumber(uint number) : base(PathwayDb.Instance, number) { }

    }

}
