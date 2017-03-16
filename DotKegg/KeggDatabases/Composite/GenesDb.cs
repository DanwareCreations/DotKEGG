namespace DotKEGG {

    public sealed class GenesDb : KeggCompositeDb {

        private static GenesDb _instance = new GenesDb();

        private GenesDb() {
            Name = "genes";
            Abbreviation = "genes";
        }

        public static GenesDb Instance => _instance;

        public static TNumber Genome(uint number) {
            return new TNumber(number);
        }

    }

}
