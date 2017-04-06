namespace DotKEGG {

    public sealed class BRNumber : KeggId {

        public BRNumber(uint number) {
            Number = number;
            _db = BriteDb.Instance;
        }

    }

}
