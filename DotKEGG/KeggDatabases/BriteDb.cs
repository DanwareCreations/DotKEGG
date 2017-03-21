using System;

namespace DotKEGG {

    public sealed class BriteDb : KeggDb {

        private static BriteDb _instance = new BriteDb();

        private BriteDb() {
            Name = "brite";
            Abbreviation = "br";
            Prefix = "br";
        }

        public static BriteDb Instance => _instance;

        public static BrNumber BriteHierarchy(uint number) {
            return new BrNumber(number);
        }

        public override KeggId Entry(uint number) {
            return new BrNumber(number);
        }
    }

}
