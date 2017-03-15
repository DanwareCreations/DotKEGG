namespace DotKEGG {

    public sealed class RNumber : KeggId {

        public RNumber(uint number) {
            Number = number;
        }

        public ReactionDb Database => _db as ReactionDb;

    }

}
