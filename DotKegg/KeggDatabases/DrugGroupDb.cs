namespace DotKEGG {
    
    public sealed class DrugGroupDb : KeggDb {

        private static DrugGroupDb _instance = new DrugGroupDb();

        private DrugGroupDb() {
            Name = "dgroup";
            Abbreviation = "dg";
            Prefix = "DG";
        }

        public static DrugGroupDb Instance => _instance;

        public static DGNumber NewDGNumber(uint number) {
            return new DGNumber(number);
        }

    }

}
