namespace DotKegg {

    public sealed class MNumber : KeggId {

        public MNumber(uint number) {
            Number = number;
        }

        public ModuleDb Database => _db as ModuleDb;

    }

}
