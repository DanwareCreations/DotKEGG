namespace DotKEGG {

    public sealed class OrthologyDb : KeggDb {

        public OrthologyDb() {
            Name = "orthology";
            Abbreviation = "ko";
            Prefix = "K";
        }

        public static KNumber NewKNumber(uint number) {
            return new KNumber(number);
        }

    }

}
