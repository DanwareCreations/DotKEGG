namespace DotKEGG {

    public sealed class GNumber : KeggId {

        public GNumber(uint number) {
            Number = number;
            _db = GlycanDb.Instance;
        }

    }

}
