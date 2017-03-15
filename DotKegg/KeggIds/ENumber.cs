namespace DotKEGG {

    public sealed class ENumber : KeggId {

        public ENumber(uint number) {
            Number = number;
        }

        public EnvironDb Database => _db as EnvironDb;

    }

}
