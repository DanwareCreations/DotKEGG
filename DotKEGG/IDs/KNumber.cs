namespace DotKEGG {

    public sealed class KNumber : KeggId {

        public KNumber(uint number) {
            Number = number;
            _db = OrthologyDb.Instance;
        }

    }

}
