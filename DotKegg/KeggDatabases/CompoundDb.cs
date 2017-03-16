namespace DotKEGG {
    
    public sealed class CompoundDb : KeggDb {

        private static CompoundDb _instance = new CompoundDb();

        private CompoundDb() {
            Name = "compound";
            Abbreviation = "cpd";
            Prefix = "C";
        }

        public static CompoundDb Instance => _instance;

        public static CNumber NewCNumber(uint number) {
            return new CNumber(number);
        }

    }

}
