namespace DotKEGG {

    /// <summary>
    /// Represents the <token>ReactionClassDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class ReactionClassDb : KeggDb {

        private static ReactionClassDb _instance = new ReactionClassDb();

        private ReactionClassDb() {
            Name = "rclass";
            Abbreviation = "rc";
            Prefix = "RC";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static ReactionClassDb Instance => _instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionClassDbEntryComments"]/*'/>
        public static RCNumber ReactionClass(uint number) {
            return new RCNumber(number);
        }

        /// <inheritdoc/>
        public override KeggId Entry(uint number) {
            return new RCNumber(number);
        }

    }

}
