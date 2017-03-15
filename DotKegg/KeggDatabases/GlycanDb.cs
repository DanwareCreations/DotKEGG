namespace DotKEGG {
    
    public sealed class GlycanDb: KeggDb {

        public GlycanDb() {
            Name = "glycan";
            Abbreviation = "gl";
            Prefix = "G";
        }

        public static GNumber NewGNumber(uint number) {
            return new GNumber(number);
        }

    }

}
