namespace DotKEGG {
    
    public sealed class DiseaseDb : KeggDb {

        public DiseaseDb() {
            Name = "disease";
            Abbreviation = "ds";
            Prefix = "H";
        }

        public static HNumber NewHNumber(uint number) {
            return new HNumber(number);
        }

    }

}
