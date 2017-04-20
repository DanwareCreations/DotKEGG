namespace DotKEGG {

    /// <summary>
    /// Represents the <token>BriteDbLink</token> database.
    /// </summary>
    /// <seealso cref="BRNumber"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggId"/>
    /// <inheritdoc/>
    public sealed class BriteDb : KeggDb {

        private static BriteDb s_instance = new BriteDb();

        private BriteDb() : base("brite", "br", "BR") { }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static BriteDb Instance => s_instance;

        /// <summary>
        /// Returns the <token>BriteDbLink</token> hierarchy entry with the given <token>BriteDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>BriteDbPrefix</token> number of the <token>BriteDbLink</token> hierarchy entry.</param>
        /// <returns>A lightweight object representing the <token>BriteDbLink</token> hierarchy entry with the given <token>BriteDbPrefix</token> number.</returns>
        public static BRNumber BriteHierarchy(uint number) => new BRNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new BRNumber(number);
    }

}
