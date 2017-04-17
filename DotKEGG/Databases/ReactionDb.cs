namespace DotKEGG {

    /// <summary>
    /// Represents the <token>ReactionDbLink</token> database.
    /// </summary>
    /// <seealso cref="RNumber"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class ReactionDb : KeggDb {

        private static ReactionDb s_instance = new ReactionDb();

        private ReactionDb() {
            Name = "reaction";
            Abbreviation = "rn";
            Prefix = "R";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static ReactionDb Instance => s_instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionDbEntryComments"]/*'/>
        public static RNumber Reaction(uint number) => new RNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new RNumber(number);

    }

}
