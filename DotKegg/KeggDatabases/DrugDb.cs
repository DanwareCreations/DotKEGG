namespace DotKEGG {
    
    public sealed class DrugDb : KeggDb {

        public DrugDb() {
            Name = "drug";
            Abbreviation = "dr";
            Prefix = "D";
        }

        public static DNumber NewDNumber(uint number) {
            return new DNumber(number);
        }

    }

}
