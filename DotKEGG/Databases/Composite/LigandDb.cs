namespace DotKEGG {

    /// <summary>
    /// Represents the <token>LigandDbLink</token> composite database.
    /// </summary>
    /// <seealso cref="CNumber"/>
    /// <seealso cref="ECNumber"/>
    /// <seealso cref="GNumber"/>
    /// <seealso cref="RNumber"/>
    /// <seealso cref="RCNumber"/>
    /// <seealso cref="CompoundDb"/>
    /// <seealso cref="EnzymeDb"/>
    /// <seealso cref="GlycanDb"/>
    /// <seealso cref="ReactionDb"/>
    /// <seealso cref="ReactionClassDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class LigandDb : KeggCompositeDb {

        private static LigandDb s_instance = new LigandDb();

        private LigandDb() : base("ligand", "ligand") { }

        /// <summary>
        /// <token>CompositeDbInstanceSummary</token>
        /// </summary>
        public static LigandDb Instance => s_instance;

        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="CompoundDbEntryComments"]/*'/>
        public static CNumber Compound(uint number) => new CNumber(number);
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GlycanDbEntryComments"]/*'/>
        public static GNumber Glycan(uint number) => new GNumber(number);
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionDbEntryComments"]/*'/>
        public static RNumber Reaction(uint number) => new RNumber(number);
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionClassDbEntryComments"]/*'/>
        public static RCNumber ReactionClass(uint number) => new RCNumber(number);
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="EnzymeDbEntryComments"]/*'/>
        public static ECNumber Enzyme(ECEnzymeClass ecClass, uint id2, uint id3, uint serialId) =>
            new ECNumber(ecClass, id2, id3, serialId);

    }

}
