namespace DotKEGG {

    /// <summary>
    /// Represents the <token>ReactionClassDbLink</token> database.
    /// </summary>
    /// <seealso cref="RCNumber"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class ReactionClassDb : KeggDb {

        private static ReactionClassDb s_instance = new ReactionClassDb();

        private ReactionClassDb() : base("rclass", "rc", "RC") { }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static ReactionClassDb Instance => s_instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionClassDbEntryComments"]/*'/>
        public static RCNumber ReactionClass(uint number) => new RCNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new RCNumber(number);

    }

}
