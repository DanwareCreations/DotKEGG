namespace DotKEGG {

    /// <summary>
    /// Represents the <token>ModuleDbLink</token> database.
    /// </summary>
    /// <seealso cref="MNumber"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggId"/>
    /// <inheritdoc/>
    public sealed class ModuleDb : KeggDb {

        private static ModuleDb s_instance = new ModuleDb();

        private ModuleDb() {
            Name = "module";
            Abbreviation = "md";
            Prefix = "M";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static ModuleDb Instance => s_instance;

        /// <summary>
        /// Returns the <token>ModuleDbLink</token> entry with the given <token>ModuleDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>ModuleDbPrefix</token> number of the <token>ModuleDbLink</token> entry.</param>
        /// <returns>A lightweight object representing the <token>ModuleDbLink</token> entry with the given <token>ModuleDbPrefix</token> number.</returns>
        public static MNumber Module(uint number) => new MNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new MNumber(number);

    }

}
