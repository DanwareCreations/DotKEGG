namespace DotKEGG {
    
    public sealed class GlycanDb: KeggDb {

        private static GlycanDb _instance = new GlycanDb();

        private GlycanDb() {
            Name = "glycan";
            Abbreviation = "gl";
            Prefix = "G";
        }

        public static GlycanDb Instance => _instance;

        public static GNumber NewGNumber(uint number) {
            return new GNumber(number);
        }

    }

}
