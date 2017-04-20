namespace DotKEGG {

    /// <summary>
    /// Represents the <token>DrugDbLink</token> database.
    /// </summary>
    /// <seealso cref="DNumber"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggId"/>
    /// <inheritdoc/>
    public sealed class DrugDb : KeggDb {

        private static DrugDb s_instance = new DrugDb();

        private DrugDb() : base("drug", "dr", "D") { }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static DrugDb Instance => s_instance;

        /// <summary>
        /// Returns the <token>DrugDbLink</token> database entry with the given <token>DrugDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>DrugDbPrefix</token> number of the <token>DrugDbLink</token> database entry.</param>
        /// <returns>A lightweight object representing the <token>DrugDbLink</token> database entry with the given <token>DrugDbPrefix</token> number.</returns>
        public static DNumber Drug(uint number) => new DNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new DNumber(number);

    }

}
