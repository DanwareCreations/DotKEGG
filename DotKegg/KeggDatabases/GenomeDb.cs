using System;

namespace DotKEGG {
    
    public sealed class GenomeDb: KeggDb {

        private static GenomeDb _instance = new GenomeDb();

        private GenomeDb() {
            Name = "genome";
            Abbreviation = "genome";
            Prefix = "T";
        }

        public static GenomeDb Instance => _instance;

        public static TNumber Genome(uint number) {
            return new TNumber(number);
        }

        public override KeggId Entry(uint number) {
            return new TNumber(number);
        }

    }

}
