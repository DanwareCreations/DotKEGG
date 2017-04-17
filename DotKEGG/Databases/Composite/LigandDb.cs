﻿namespace DotKEGG {

    /// <summary>
    /// Represents the <token>LigandDbLink</token> composite database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class LigandDb : KeggCompositeDb {

        private static LigandDb s_instance = new LigandDb();

        private LigandDb() {
            Name = "ligand";
            Abbreviation = "ligand";
        }

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
        public static ECNumber Enzyme(ECNumber.Class ecClass, uint id2, uint id3, uint serialId) =>
            new ECNumber(ecClass, id2, id3, serialId);

    }

}
