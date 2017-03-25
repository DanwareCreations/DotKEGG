namespace DotKEGG {

    /// <summary>
    /// Represents the <token>DiseaseDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class DiseaseDb : KeggDb {

        private static DiseaseDb _instance => new DiseaseDb();

        private DiseaseDb() {
            Name = "disease";
            Abbreviation = "ds";
            Prefix = "H";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static DiseaseDb Instance => _instance;

        /// <summary>
        /// Returns the <token>DiseaseDbLink</token> database entry with the given <token>DiseaseDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>DiseaseDbPrefix</token> number of the <token>DiseaseDbLink</token> database entry.</param>
        /// <returns>A lightweight object representing the <token>DiseaseDbLink</token> database entry with the given <token>DiseaseDbPrefix</token> number.</returns>
        public static HNumber Disease(uint number) {
            return new HNumber(number);
        }

        /// <inheritdoc/>
        public override KeggId Entry(uint number) {
            return new HNumber(number);
        }

    }

}
