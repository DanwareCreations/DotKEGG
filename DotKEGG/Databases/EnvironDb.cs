namespace DotKEGG {

    /// <summary>
    /// Represents the <token>EnvironDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class EnvironDb : KeggDb {

        private static EnvironDb _instance = new EnvironDb();

        private EnvironDb() {
            Name = "environ";
            Abbreviation = "ev";
            Prefix = "E";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static EnvironDb Instance => _instance;

        /// <summary>
        /// Returns the <token>EnvironDbLink</token> database entry with the given <token>EnvironDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>EnvironDbPrefix</token> number of the <token>EnvironDbLink</token> database entry.</param>
        /// <returns>A lightweight object representing the <token>EnvironDbLink</token> database entry with the given <token>EnvironDbPrefix</token> number.</returns>
        public static ENumber Environ(uint number) {
            return new ENumber(number);
        }

        /// <inheritdoc/>
        public override KeggId Entry(uint number) {
            return new ENumber(number);
        }

    }

}
