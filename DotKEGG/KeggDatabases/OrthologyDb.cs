namespace DotKEGG {

    public sealed class OrthologyDb : KeggDb {

        private static OrthologyDb _instance = new OrthologyDb();

        private OrthologyDb() {
            Name = "orthology";
            Abbreviation = "ko";
            Prefix = "K";
        }

        public static OrthologyDb Instance => _instance;

        public static KNumber Orthology(uint number) {
            return new KNumber(number);
        }

        public override KeggId Entry(uint number) {
            return new KNumber(number);
        }

    }

}
