namespace DotKEGG {
    
    public sealed class DiseaseDb : KeggDb {

        private static DiseaseDb _instance => new DiseaseDb();

        private DiseaseDb() {
            Name = "disease";
            Abbreviation = "ds";
            Prefix = "H";
        }

        public static DiseaseDb Instance => _instance;

        public static HNumber Disease(uint number) {
            return new HNumber(number);
        }

        public override KeggId Entry(uint number) {
            return new HNumber(number);
        }

    }

}
