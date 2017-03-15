namespace DotKEGG {

    public sealed class DGNumber : KeggId {

        public DGNumber(uint number) {
            Number = number;
        }

        public DrugGroupDb Database => _db as DrugGroupDb;

    }

}
