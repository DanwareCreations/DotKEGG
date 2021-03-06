﻿namespace DotKEGG {

    /// <summary>
    /// Represents the <token>GenesDbLink</token> composite database.
    /// </summary>
    /// <seealso cref="ECNumber"/>
    /// <seealso cref="TNumber"/>
    /// <seealso cref="OrganismCode"/>
    /// <seealso cref="EnzymeDb"/>
    /// <seealso cref="GenomeDb"/>
    /// <seealso cref="GenomesDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class GenesDb : KeggCompositeDb {

        private static GenesDb s_instance = new GenesDb();

        private GenesDb() : base("genes", "genes") { }

        /// <summary>
        /// <token>CompositeDbInstanceSummary</token>
        /// </summary>
        public static GenesDb Instance => s_instance;

        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GenomeDbEntryComments"]/*'/>
        public static TNumber Genome(uint number) => new TNumber(number);

    }

}
