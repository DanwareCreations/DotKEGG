namespace DotKEGG {

    public sealed class GenomesDb : KeggCompositeDb {

        private static GenomesDb _instance = new GenomesDb();

        private GenomesDb() {
            Name = "genomes";
            Abbreviation = "gn";
        }

        public static GenomesDb Instance => _instance;

        public static TNumber Genome(uint number) {
            return new TNumber(number);
        }

    }

}
