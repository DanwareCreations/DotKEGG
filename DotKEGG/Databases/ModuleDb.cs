namespace DotKEGG {

    /// <summary>
    /// Represents the <token>ModuleDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class ModuleDb : KeggDb {

        private static ModuleDb _instance = new ModuleDb();

        private ModuleDb() {
            Name = "module";
            Abbreviation = "md";
            Prefix = "M";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static ModuleDb Instance => _instance;

        /// <summary>
        /// Returns the <token>ModuleDbLink</token> entry with the given <token>ModuleDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>ModuleDbPrefix</token> number of the <token>ModuleDbLink</token> entry.</param>
        /// <returns>A lightweight object representing the <token>ModuleDbLink</token> entry with the given <token>ModuleDbPrefix</token> number.</returns>
        public static MNumber Module(uint number) {
            return new MNumber(number);
        }

        /// <inheritdoc/>
        public override KeggId Entry(uint number) {
            return new MNumber(number);
        }

    }

}
