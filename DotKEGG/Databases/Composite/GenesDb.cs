namespace DotKEGG {

    /// <summary>
    /// Represents the <token>GenesDbLink</token> composite database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class GenesDb : KeggCompositeDb {

        private static GenesDb _instance = new GenesDb();

        private GenesDb() {
            Name = "genes";
            Abbreviation = "genes";
        }

        /// <summary>
        /// <token>CompositeDbInstanceSummary</token>
        /// </summary>
        public static GenesDb Instance => _instance;

        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GenomeDbEntryComments"]/*'/>
        public static TNumber Genome(uint number) {
            return new TNumber(number);
        }

    }

}
