namespace DotKEGG {

    public sealed class RNumber : KeggId {

        public RNumber(uint number) {
            Number = number;
            _db = ReactionDb.Instance;
        }

    }

}
