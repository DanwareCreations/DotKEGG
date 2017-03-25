namespace DotKEGG {

    /// <summary>
    /// Represents the <token>ReactionDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class ReactionDb : KeggDb {

        private static ReactionDb _instance = new ReactionDb();

        private ReactionDb() {
            Name = "reaction";
            Abbreviation = "rn";
            Prefix = "R";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static ReactionDb Instance => _instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionDbEntryComments"]/*'/>
        public static RNumber Reaction(uint number) {
            return new RNumber(number);
        }

        /// <inheritdoc/>
        public override KeggId Entry(uint number) {
            return new RNumber(number);
        }

    }

}
