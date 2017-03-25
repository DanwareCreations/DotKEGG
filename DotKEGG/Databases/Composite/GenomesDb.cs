namespace DotKEGG {

    /// <summary>
    /// Represents the <token>GenomesDbLink</token> composite database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class GenomesDb : KeggCompositeDb {

        private static GenomesDb _instance = new GenomesDb();

        private GenomesDb() {
            Name = "genomes";
            Abbreviation = "gn";
        }

        /// <summary>
        /// <token>CompositeDbInstanceSummary</token>
        /// </summary>
        public static GenomesDb Instance => _instance;

        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GenomeDbEntryComments"]/*'/>
        public static TNumber Genome(uint number) {
            return new TNumber(number);
        }

    }

}
