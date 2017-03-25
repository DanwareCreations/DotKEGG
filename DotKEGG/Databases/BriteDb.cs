namespace DotKEGG {

    /// <summary>
    /// Represents the <token>BriteDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class BriteDb : KeggDb {

        private static BriteDb _instance = new BriteDb();

        private BriteDb() {
            Name = "brite";
            Abbreviation = "br";
            Prefix = "BR";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static BriteDb Instance => _instance;

        /// <summary>
        /// Returns the <token>BriteDbLink</token> hierarchy entry with the given <token>BriteDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>BriteDbPrefix</token> number of the <token>BriteDbLink</token> hierarchy entry.</param>
        /// <returns>A lightweight object representing the <token>BriteDbLink</token> hierarchy entry with the given <token>BriteDbPrefix</token> number.</returns>
        public static BRNumber BriteHierarchy(uint number) {
            return new BRNumber(number);
        }

        /// <inheritdoc/>
        public override KeggId Entry(uint number) {
            return new BRNumber(number);
        }
    }

}
