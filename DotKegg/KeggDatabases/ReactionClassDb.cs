namespace DotKEGG {
    
    public sealed class ReactionClassDb : KeggDb {

        public ReactionClassDb() {
            Name = "rclass";
            Abbreviation = "rc";
            Prefix = "RC";
        }

        public static RCNumber NewRCNumber(uint number) {
            return new RCNumber(number);
        }

    }

}
