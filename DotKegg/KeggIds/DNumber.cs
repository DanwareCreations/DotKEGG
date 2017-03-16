namespace DotKEGG {

    public sealed class DNumber : KeggId {

        public DNumber(uint number) {
            Number = number;
            _db = DrugDb.Instance;
        }

        public DrugDb Database => _db as DrugDb;

    }

}
