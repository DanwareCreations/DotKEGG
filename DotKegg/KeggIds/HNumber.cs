namespace DotKEGG {

    public sealed class HNumber : KeggId {

        public HNumber(uint number) {
            Number = number;
            _db = DiseaseDb.Instance;
        }

        public DiseaseDb Database => (DiseaseDb)_db;

    }

}
