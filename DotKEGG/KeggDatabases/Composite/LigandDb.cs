namespace DotKEGG {

    public sealed class LigandDb : KeggCompositeDb {

        private static LigandDb _instance = new LigandDb();

        private LigandDb() {
            Name = "ligand";
            Abbreviation = "ligand";
        }

        public static LigandDb Instance => _instance;

        public static CNumber Compound(uint number) {
            return new CNumber(number);
        }
        public static GNumber Glycan(uint number) {
            return new GNumber(number);
        }
        public static RNumber Reaction(uint number) {
            return new RNumber(number);
        }
        public static RCNumber ReactionClass(uint number) {
            return new RCNumber(number);
        }
        public static ECNumber Enzyme(uint ecClassId, uint id2, uint id3, uint serialId) {
            return new ECNumber(ecClassId, id2, id3, serialId);
        }

    }

}
