namespace DotKEGG {
    
    public sealed class ReactionClassDb : KeggDb {

        private static ReactionClassDb _instance = new ReactionClassDb();

        private ReactionClassDb() {
            Name = "rclass";
            Abbreviation = "rc";
            Prefix = "RC";
        }

        public static ReactionClassDb Instance => _instance;

        public static RCNumber NewRCNumber(uint number) {
            return new RCNumber(number);
        }

    }

}
