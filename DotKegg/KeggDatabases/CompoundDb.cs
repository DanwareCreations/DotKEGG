namespace DotKEGG {
    
    public sealed class CompoundDb : KeggDb {

        public CompoundDb() {
            Name = "compound";
            Abbreviation = "cpd";
            Prefix = "C";
        }

        public static CNumber NewCNumber(uint number) {
            return new CNumber(number);
        }

    }

}
