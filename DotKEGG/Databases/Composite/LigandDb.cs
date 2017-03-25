namespace DotKEGG {

    /// <summary>
    /// Represents the <token>LigandDbLink</token> composite database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class LigandDb : KeggCompositeDb {

        private static LigandDb _instance = new LigandDb();

        private LigandDb() {
            Name = "ligand";
            Abbreviation = "ligand";
        }

        /// <summary>
        /// <token>CompositeDbInstanceSummary</token>
        /// </summary>
        public static LigandDb Instance => _instance;

        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="CompoundDbEntryComments"]/*'/>
        public static CNumber Compound(uint number) {
            return new CNumber(number);
        }
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GlycanDbEntryComments"]/*'/>
        public static GNumber Glycan(uint number) {
            return new GNumber(number);
        }
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionDbEntryComments"]/*'/>
        public static RNumber Reaction(uint number) {
            return new RNumber(number);
        }
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionClassDbEntryComments"]/*'/>
        public static RCNumber ReactionClass(uint number) {
            return new RCNumber(number);
        }
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="EnzymeDbEntryComments"]/*'/>
        public static ECNumber Enzyme(ECNumber.Class ecClass, uint id2, uint id3, uint serialId) {
            return new ECNumber(ecClass, id2, id3, serialId);
        }

    }

}
