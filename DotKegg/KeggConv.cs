namespace DotKegg {

    public static class KeggConv {
        
        public static string[] FromKeggOrganism(string organismCode, OutsideGeneDb geneDb) {
            return KeggRestApi.Post(OpStrings.Conv, StringFrom.Enum(geneDb), organismCode);
        }
        public static string[] FromKeggDrug(string keggId, OutsideChemDb chemDb) {
            return KeggRestApi.Post(OpStrings.Conv, StringFrom.Enum(chemDb), keggId);
        }
        public static string[] FromKeggCompound(string keggId, OutsideChemDb chemDb) {
            return KeggRestApi.Post(OpStrings.Conv, StringFrom.Enum(chemDb), keggId);
        }
        public static string[] FromKeggGlycan(string keggId, OutsideChemDb chemDb) {
            return KeggRestApi.Post(OpStrings.Conv, StringFrom.Enum(chemDb), keggId);
        }

        public static string[] ToKeggOrganism(OutsideGeneDb geneDb, string organismCode) {
            return KeggRestApi.Post(OpStrings.Conv, organismCode, StringFrom.Enum(geneDb));
        }
        public static string[] ToKeggDrug(OutsideChemDb chemDb, string chemId) {
            return KeggRestApi.Post(OpStrings.Conv, chemId, StringFrom.Enum(chemDb));
        }
        public static string[] ToKeggCompound(OutsideChemDb chemDb, string chemId) {
            return KeggRestApi.Post(OpStrings.Conv, chemId, StringFrom.Enum(chemDb));
        }
        public static string[] ToKeggGlycan(OutsideChemDb chemDb, string chemId) {
            return KeggRestApi.Post(OpStrings.Conv, chemId, StringFrom.Enum(chemDb));
        }
        
    }

}
