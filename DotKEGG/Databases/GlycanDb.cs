namespace DotKEGG {

    /// <summary>
    /// Represents the <token>GlycanDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class GlycanDb: KeggDb {

        private static GlycanDb _instance = new GlycanDb();

        private GlycanDb() {
            Name = "glycan";
            Abbreviation = "gl";
            Prefix = "G";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static GlycanDb Instance => _instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GlycanDbEntryComments"]/*'/>
        public static GNumber Glycan(uint number) {
            return new GNumber(number);
        }

        /// <inheritdoc/>
        public override KeggId Entry(uint number) {
            return new GNumber(number);
        }

    }

}
