namespace DotKEGG {

    /// <summary>
    /// Represents the <token>DrugGroupDbLink</token> database.
    /// </summary>
    /// <seealso cref="DGNumber"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggId"/>
    /// <inheritdoc/>
    public sealed class DrugGroupDb : KeggDb {

        private static DrugGroupDb s_instance = new DrugGroupDb();

        private DrugGroupDb() {
            Name = "dgroup";
            Abbreviation = "dg";
            Prefix = "DG";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static DrugGroupDb Instance => s_instance;

        /// <summary>
        /// Returns the <token>DrugGroupDbLink</token> database entry with the given <token>DrugGroupDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>DrugGroupDbPrefix</token> number of the <token>DrugGroupDbLink</token> database entry.</param>
        /// <returns>A lightweight object representing the <token>DrugGroupDbLink</token> database entry with the given <token>DrugGroupDbPrefix</token> number.</returns>
        public static DGNumber DrugGroup(uint number) => new DGNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new DGNumber(number);

    }

}
