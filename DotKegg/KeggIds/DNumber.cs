namespace DotKEGG {

    public sealed class DNumber : KeggId {

        public DNumber(uint number) {
            Number = number;
        }

        public DrugDb Database => _db as DrugDb;

    }

}
