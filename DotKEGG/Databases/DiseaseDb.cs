namespace DotKEGG {

    /// <summary>
    /// Represents the <token>DiseaseDbLink</token> database.
    /// </summary>
    /// <seealso cref="HNumber"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggId"/>
    /// <inheritdoc/>
    public sealed class DiseaseDb : KeggDb {

        private static DiseaseDb s_instance = new DiseaseDb();

        private DiseaseDb() : base("disease", "ds", "H") { }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static DiseaseDb Instance => s_instance;

        /// <summary>
        /// Returns the <token>DiseaseDbLink</token> database entry with the given <token>DiseaseDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>DiseaseDbPrefix</token> number of the <token>DiseaseDbLink</token> database entry.</param>
        /// <returns>A lightweight object representing the <token>DiseaseDbLink</token> database entry with the given <token>DiseaseDbPrefix</token> number.</returns>
        public static HNumber Disease(uint number) => new HNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new HNumber(number);

    }

}
