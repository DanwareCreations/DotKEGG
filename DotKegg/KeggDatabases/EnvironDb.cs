namespace DotKEGG {
    
    public sealed class EnvironDb : KeggDb {

        public EnvironDb() {
            Name = "environ";
            Abbreviation = "ev";
            Prefix = "E";
        }

        public static ENumber NewENumber(uint number) {
            return new ENumber(number);
        }

    }

}
