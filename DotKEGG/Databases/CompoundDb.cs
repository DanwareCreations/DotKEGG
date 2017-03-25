namespace DotKEGG {

    /// <summary>
    /// Represents the <token>CompoundDbLink</token> database.
    /// </summary>
    /// <remarks>
    /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="CompoundVsComposite"]/*'/>
    /// </remarks>
    /// <inheritdoc/>
    public sealed class CompoundDb : KeggDb {

        private static CompoundDb _instance = new CompoundDb();

        private CompoundDb() {
            Name = "compound";
            Abbreviation = "cpd";
            Prefix = "C";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static CompoundDb Instance => _instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="CompoundDbEntryComments"]/*'/>
        public static CNumber Compound(uint number) {
            return new CNumber(number);
        }

        /// <inheritdoc/>
        public override KeggId Entry(uint number) {
            return new CNumber(number);
        }

    }

}
