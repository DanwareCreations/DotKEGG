namespace DotKEGG {

    /// <summary>
    /// Represents the <token>CompoundDbLink</token> database.
    /// </summary>
    /// <remarks>
    /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="CompoundVsComposite"]/*'/>
    /// </remarks>
    /// <seealso cref="CNumber"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class CompoundDb : KeggDb {

        private static CompoundDb s_instance = new CompoundDb();
        
        private CompoundDb() : base("compound", "cpd", "C") { }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static CompoundDb Instance => s_instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="CompoundDbEntryComments"]/*'/>
        public static CNumber Compound(uint number) => new CNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new CNumber(number);

    }

}
