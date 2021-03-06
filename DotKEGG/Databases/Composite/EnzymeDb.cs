﻿namespace DotKEGG {

    /// <summary>
    /// Represents the <token>EnzymeDbLink</token> composite database.
    /// </summary>
    /// <seealso cref="ECNumber"/>
    /// <seealso cref="KNumber"/>
    /// <seealso cref="RNumber"/>
    /// <seealso cref="OrthologyDb"/>
    /// <seealso cref="ReactionDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class EnzymeDb : KeggCompositeDb {

        private static EnzymeDb s_instance = new EnzymeDb();

        private EnzymeDb() : base("enzyme", "ec") { }

        /// <summary>
        /// <token>CompositeDbInstanceSummary</token>
        /// </summary>
        public static EnzymeDb Instance => s_instance;

        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="ReactionDbEntryComments"]/*'/>
        public static RNumber Reaction(uint number) => new RNumber(number);
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="OrthologyDbEntryComments"]/*'/>
        public static KNumber Orthology(uint number) => new KNumber(number);
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="EnzymeDbEntryComments"]/*'/>
        public static ECNumber Enzyme(ECEnzymeClass ecClass, uint id2, uint id3, uint serialId) =>
            new ECNumber(ecClass, id2, id3, serialId);

    }

}
