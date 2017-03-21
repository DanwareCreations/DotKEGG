namespace DotKEGG {

    public sealed class RCNumber : KeggId {

        public RCNumber(uint number) {
            Number = number;
            _db = ReactionClassDb.Instance;
        }

        public ReactionClassDb Database => (ReactionClassDb)_db;

    }

}
