namespace DotKEGG {
    
    public sealed class ReactionDb : KeggDb {

        private static ReactionDb _instance = new ReactionDb();

        private ReactionDb() {
            Name = "reaction";
            Abbreviation = "rn";
            Prefix = "R";
        }

        public static ReactionDb Instance => _instance;

        public static RNumber Reaction(uint number) {
            return new RNumber(number);
        }

        public override KeggId Entry(uint number) {
            return new RNumber(number);
        }

    }

}
