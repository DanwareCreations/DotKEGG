namespace DotKEGG {
    
    public sealed class ReactionDb : KeggDb {

        public ReactionDb() {
            Name = "reaction";
            Abbreviation = "rn";
            Prefix = "R";
        }

        public static RNumber NewRNumber(uint number) {
            return new RNumber(number);
        }

    }

}
