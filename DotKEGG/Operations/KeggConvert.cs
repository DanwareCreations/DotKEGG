using System.Linq;
using System.Collections.Generic;

namespace DotKEGG {
    
    /// <seealso cref="KeggFind"/>
    /// <seealso cref="KeggGet"/>
    /// <seealso cref="KeggInfo"/>
    /// <seealso cref="KeggLink"/>
    /// <seealso cref="KeggList"/>
    public static class KeggConvert {
        
        public static string[] FromKeggOrganism(string organismCode, OutsideGeneDb geneDb) =>
            KeggRestApi.GetText(OpStrings.Conv, StringFrom.Enum(geneDb), organismCode);
        public static string[] FromKeggDrug(DNumber keggId, OutsideChemDb chemDb) =>
            KeggRestApi.GetText(OpStrings.Conv, StringFrom.Enum(chemDb), keggId.DBGETForm());
        public static string[] FromKeggCompound(CNumber keggId, OutsideChemDb chemDb) =>
            KeggRestApi.GetText(OpStrings.Conv, StringFrom.Enum(chemDb), keggId.DBGETForm());
        public static string[] FromKeggGlycan(GNumber keggId, OutsideChemDb chemDb) =>
            KeggRestApi.GetText(OpStrings.Conv, StringFrom.Enum(chemDb), keggId.DBGETForm());
        public static string[] FromKeggDrugs(DNumber[] keggIds, OutsideChemDb chemDb) {
            IEnumerable<string> entries = keggIds.Select(kid => kid.DBGETForm());
            string joined = string.Join("+", entries.ToArray());
            return KeggRestApi.GetText(OpStrings.Conv, StringFrom.Enum(chemDb), joined);
        }
        public static string[] FromKeggCompounds(CNumber[] keggIds, OutsideChemDb chemDb) {
            IEnumerable<string> entries = keggIds.Select(kid => kid.DBGETForm());
            string joined = string.Join("+", entries.ToArray());
            return KeggRestApi.GetText(OpStrings.Conv, StringFrom.Enum(chemDb), joined);
        }
        public static string[] FromKeggGlycans(GNumber[] keggIds, OutsideChemDb chemDb) {
            IEnumerable<string> entries = keggIds.Select(kid => kid.DBGETForm());
            string joined = string.Join("+", entries.ToArray());
            return KeggRestApi.GetText(OpStrings.Conv, StringFrom.Enum(chemDb), joined);
        }

        public static string[] ToKeggOrganism(OutsideGeneDb geneDb, string organismCode) =>
            KeggRestApi.GetText(OpStrings.Conv, organismCode, StringFrom.Enum(geneDb));
        public static string[] ToKeggDrug(OutsideChemDb chemDb, string chemId) {
            string entry = $"{StringFrom.Enum(chemDb)}:{chemId}";
            return KeggRestApi.GetText(OpStrings.Conv, DbStrings.Drug, entry);
        }
        public static string[] ToKeggCompound(OutsideChemDb chemDb, string chemId) {
            string entry = $"{StringFrom.Enum(chemDb)}:{chemId}";
            return KeggRestApi.GetText(OpStrings.Conv, DbStrings.Compound, entry);
        }
        public static string[] ToKeggGlycan(OutsideChemDb chemDb, string chemId) {
            string entry = $"{StringFrom.Enum(chemDb)}:{chemId}";
            return KeggRestApi.GetText(OpStrings.Conv, DbStrings.Glycan, entry);
        }
        public static string[] ToKeggDrugs(OutsideChemDb chemDb, string[] chemIds) {
            IEnumerable<string> entries = chemIds.Select(id => $"{StringFrom.Enum(chemDb)}:{id}");
            string joined = string.Join("+", entries.ToArray());
            return KeggRestApi.GetText(OpStrings.Conv, DbStrings.Drug, joined);
        }
        public static string[] ToKeggCompounds(OutsideChemDb chemDb, string[] chemIds) {
            IEnumerable<string> entries = chemIds.Select(id => $"{StringFrom.Enum(chemDb)}:{id}");
            string joined = string.Join("+", entries.ToArray());
            return KeggRestApi.GetText(OpStrings.Conv, DbStrings.Compound, joined);
        }
        public static string[] ToKeggGlycans(OutsideChemDb chemDb, string[] chemIds) {
            IEnumerable<string> entries = chemIds.Select(id => $"{StringFrom.Enum(chemDb)}:{id}");
            string joined = string.Join("+", entries.ToArray());
            return KeggRestApi.GetText(OpStrings.Conv, DbStrings.Glycan, joined);
        }

    }

}
