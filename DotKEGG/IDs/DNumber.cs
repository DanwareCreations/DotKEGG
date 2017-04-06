namespace DotKEGG {

    public sealed class DNumber : KeggId {

        public DNumber(uint number) {
            Number = number;
            _db = DrugDb.Instance;
        }

    }

}
