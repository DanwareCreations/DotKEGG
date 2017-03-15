namespace DotKEGG {
    
    public sealed class DrugGroupDb : KeggDb {

        public DrugGroupDb() {
            Name = "dgroup";
            Abbreviation = "dg";
            Prefix = "DG";
        }

        public static DGNumber NewDGNumber(uint number) {
            return new DGNumber(number);
        }

    }

}
