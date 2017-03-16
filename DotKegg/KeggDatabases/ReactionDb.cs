namespace DotKEGG {
    
    public sealed class ReactionDb : KeggDb {

        private static ReactionDb _instance = new ReactionDb();

        private ReactionDb() {
            Name = "reaction";
            Abbreviation = "rn";
            Prefix = "R";
        }

        public static ReactionDb Instance => _instance;

        public static RNumber NewRNumber(uint number) {
            return new RNumber(number);
        }

    }

}
