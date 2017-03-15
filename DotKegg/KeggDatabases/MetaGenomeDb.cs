namespace DotKEGG {

    public sealed class MetaGenomeDb: KeggDb {

        public MetaGenomeDb() {
            Name = "genomes";
            Abbreviation = "gn";
            Prefix = "T";
        }

        public static TNumber NewTNumber(uint number) {
            return new TNumber(number);
        }

    }

}
