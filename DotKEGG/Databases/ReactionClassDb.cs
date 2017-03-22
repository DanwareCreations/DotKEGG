namespace DotKEGG {
    
    public sealed class ReactionClassDb : KeggDb {

        private static ReactionClassDb _instance = new ReactionClassDb();

        private ReactionClassDb() {
            Name = "rclass";
            Abbreviation = "rc";
            Prefix = "RC";
        }

        public static ReactionClassDb Instance => _instance;

        public static RCNumber ReactionClass(uint number) {
            return new RCNumber(number);
        }

        public override KeggId Entry(uint number) {
            return new RCNumber(number);
        }

    }

}
