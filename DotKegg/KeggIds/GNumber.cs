namespace DotKEGG {

    public sealed class GNumber : KeggId {

        public GNumber(uint number) {
            Number = number;
        }

        public GlycanDb Database => _db as GlycanDb;

    }

}
