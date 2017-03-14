namespace DotKegg {

    public sealed class ModuleDb : KeggDb {

        public ModuleDb() {
            Name = "module";
            Abbreviation = "md";
            Prefix = "M";
        }

        public static MNumber NewMNumber(uint number) {
            return new MNumber(number);
        }

    }

}
