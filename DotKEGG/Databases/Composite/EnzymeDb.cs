namespace DotKEGG {
    
    public sealed class EnzymeDb : KeggCompositeDb {

        private static EnzymeDb _instance = new EnzymeDb();

        private EnzymeDb() {
            Name = "enzyme";
            Abbreviation = "ec";
        }

        public static EnzymeDb Instance => _instance;

        public static RNumber Reaction(uint number) {
            return new RNumber(number);
        }
        public static KNumber Orthology(uint number) {
            return new KNumber(number);
        }
        public static ECNumber Enzyme(uint ecClassId, uint id2, uint id3, uint serialId) {
            return new ECNumber(ecClassId, id2, id3, serialId);
        }

    }

}
