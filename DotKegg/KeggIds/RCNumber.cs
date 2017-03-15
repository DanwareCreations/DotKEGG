namespace DotKEGG {

    public sealed class RCNumber : KeggId {

        public RCNumber(uint number) {
            Number = number;
        }

        public ReactionClassDb Database => _db as ReactionClassDb;

    }

}
