namespace DotKEGG {
    
    public sealed class GenomeDb: KeggDb {

        public GenomeDb() {
            Name = "genome";
            Abbreviation = "genome";
            Prefix = "T";
        }

        public static TNumber NewTNumber(uint number) {
            return new TNumber(number);
        }

    }

}
