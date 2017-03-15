namespace DotKEGG {

    public sealed class BriteDb : KeggDb {

        public BriteDb() {
            Name = "brite";
            Abbreviation = "br";
            Prefix = "br";
        }

        public static BrNumber NewBrNumber(uint number) {
            return new BrNumber(number);
        }

    }

}
