namespace DotKEGG {

    public sealed class ENumber : KeggId {

        public ENumber(uint number) {
            Number = number;
            _db = EnvironDb.Instance;
        }

        public EnvironDb Database => _db as EnvironDb;

    }

}
