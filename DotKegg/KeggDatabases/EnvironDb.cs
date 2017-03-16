namespace DotKEGG {
    
    public sealed class EnvironDb : KeggDb {

        private static EnvironDb _instance = new EnvironDb();

        private EnvironDb() {
            Name = "environ";
            Abbreviation = "ev";
            Prefix = "E";
        }

        public static EnvironDb Instance => _instance;

        public static ENumber NewENumber(uint number) {
            return new ENumber(number);
        }

    }

}
