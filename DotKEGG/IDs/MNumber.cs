namespace DotKEGG {

    public sealed class MNumber : KeggId {

        public MNumber(uint number) {
            Number = number;
            _db = ModuleDb.Instance;
        }

    }

}
