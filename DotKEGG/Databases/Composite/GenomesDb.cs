namespace DotKEGG {

    /// <summary>
    /// Represents the <token>GenomesDbLink</token> composite database.
    /// </summary>
    /// <seealso cref="TNumber"/>
    /// <seealso cref="OrganismCode"/>
    /// <seealso cref="GenesDb"/>
    /// <seealso cref="GenomeDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class GenomesDb : KeggCompositeDb {

        private static GenomesDb s_instance = new GenomesDb();

        private GenomesDb() {
            Name = "genomes";
            Abbreviation = "gn";
        }

        /// <summary>
        /// <token>CompositeDbInstanceSummary</token>
        /// </summary>
        public static GenomesDb Instance => s_instance;

        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GenomeDbEntryComments"]/*'/>
        public static TNumber Genome(uint number) => new TNumber(number);

    }

}
