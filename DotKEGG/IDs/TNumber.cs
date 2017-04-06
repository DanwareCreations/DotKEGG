namespace DotKEGG {

    public sealed class TNumber : KeggId {

        public TNumber(uint number) {
            Number = number;
            _db = GenomeDb.Instance;
        }

    }

}
