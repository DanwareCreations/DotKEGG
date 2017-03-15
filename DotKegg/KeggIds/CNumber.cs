namespace DotKEGG {

    public sealed class CNumber : KeggId {

        public CNumber(uint number) {
            Number = number;
        }

        public CompoundDb Database => _db as CompoundDb;

    }

}
