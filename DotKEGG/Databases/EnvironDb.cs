namespace DotKEGG {

    /// <summary>
    /// Represents the <token>EnvironDbLink</token> database.
    /// </summary>
    /// <seealso cref="ENumber"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggId"/>
    /// <inheritdoc/>
    public sealed class EnvironDb : KeggDb {

        private static EnvironDb s_instance = new EnvironDb();

        private EnvironDb() : base("environ", "ev", "E") { }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static EnvironDb Instance => s_instance;

        /// <summary>
        /// Returns the <token>EnvironDbLink</token> database entry with the given <token>EnvironDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>EnvironDbPrefix</token> number of the <token>EnvironDbLink</token> database entry.</param>
        /// <returns>A lightweight object representing the <token>EnvironDbLink</token> database entry with the given <token>EnvironDbPrefix</token> number.</returns>
        public static ENumber Environ(uint number) => new ENumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new ENumber(number);

    }

}
