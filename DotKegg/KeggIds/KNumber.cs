namespace DotKEGG {

    public sealed class KNumber : KeggId {

        public KNumber(uint number) {
            Number = number;
        }

        public OrthologyDb Database => _db as OrthologyDb;

    }

}
