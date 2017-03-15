namespace DotKEGG {

    public sealed class HNumber : KeggId {

        public HNumber(uint number) {
            Number = number;
        }

        public DiseaseDb Database => _db as DiseaseDb;

    }

}
