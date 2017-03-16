namespace DotKEGG {
    
    public sealed class DiseaseDb : KeggDb {

        private static DiseaseDb _instance => new DiseaseDb();

        private DiseaseDb() {
            Name = "disease";
            Abbreviation = "ds";
            Prefix = "H";
        }

        public static DiseaseDb Instance => _instance;

        public static HNumber NewHNumber(uint number) {
            return new HNumber(number);
        }

    }

}
