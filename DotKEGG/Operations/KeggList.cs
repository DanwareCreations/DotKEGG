using System.Linq;

namespace DotKEGG {

    /// <seealso cref="KeggConvert"/>
    /// <seealso cref="KeggFind"/>
    /// <seealso cref="KeggGet"/>
    /// <seealso cref="KeggInfo"/>
    /// <seealso cref="KeggLink"/>
    public static class KeggList {

        public static string[] Pathway() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Pathway);
        }
        public static string[] Brite() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Brite);
        }
        public static string[] Module() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Module);
        }
        public static string[] Orthology() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Orthology);
        }
        public static string[] Genome() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Genome);
        }
        public static string[] Organism(string organismCode) {
            return KeggRestApi.GetText(OpStrings.List, organismCode);
        }
        public static string[] Compound() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Compound);
        }
        public static string[] Glycan() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Glycan);
        }
        public static string[] Reaction() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Reaction);
        }
        public static string[] ReactionClass() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.ReactionClass);
        }
        public static string[] Enzyme() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Enzyme);
        }
        public static string[] Disease() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Disease);
        }
        public static string[] Drug() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Drug);
        }
        public static string[] DrugGroup() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.DrugGroup);
        }
        public static string[] Environ() {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Environ);
        }

        public static string[] Database(Database db) {
            return KeggRestApi.GetText(OpStrings.List, StringFrom.Enum(db));
        }

        public static string[] Organism() {
            return KeggRestApi.GetText(OpStrings.List, Strings.Organism);
        }

        public static string[] OrganismPathways(string organismCode) {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Pathway, organismCode);
        }
        public static string[] OrganismModules(string organismCode) {
            return KeggRestApi.GetText(OpStrings.List, DbStrings.Module, organismCode);
        }

        public static string[] DbEntries(params KeggId[] entries) {
            var dbEntries = entries.Select(kid => kid.DBGETForm());
            string joined = string.Join("+", dbEntries.ToArray());
            return KeggRestApi.GetText(OpStrings.List, joined);
        }

    }

}
