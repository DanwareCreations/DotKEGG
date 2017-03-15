namespace DotKEGG {

    public sealed class BrNumber : KeggId {

        public BrNumber(uint number) {
            Number = number;
        }

        public BriteDb Database => _db as BriteDb;

    }

}
