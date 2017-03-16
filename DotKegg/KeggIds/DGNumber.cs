namespace DotKEGG {

    public sealed class DGNumber : KeggId {

        public DGNumber(uint number) {
            Number = number;
            _db = DrugGroupDb.Instance;
        }

        public DrugGroupDb Database => _db as DrugGroupDb;

    }

}
