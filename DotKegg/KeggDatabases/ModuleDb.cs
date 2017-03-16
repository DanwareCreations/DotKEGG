namespace DotKEGG {

    public sealed class ModuleDb : KeggDb {

        private static ModuleDb _instance = new ModuleDb();

        private ModuleDb() {
            Name = "module";
            Abbreviation = "md";
            Prefix = "M";
        }

        public static ModuleDb Instance => _instance;

        public static MNumber NewMNumber(uint number) {
            return new MNumber(number);
        }

    }

}
