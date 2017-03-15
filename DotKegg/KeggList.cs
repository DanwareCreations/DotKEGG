namespace DotKegg {

    public static class KeggList {

        public static string[] Pathway() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Pathway);
        }
        public static string[] Brite() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Brite);
        }
        public static string[] Module() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Module);
        }
        public static string[] Orthology() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Orthology);
        }
        public static string[] Genome() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Genome);
        }
        public static string[] Organism(string organismId) {
            return KeggRestApi.Post(OpStrings.List, organismId);
        }
        public static string[] Compound() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Compound);
        }
        public static string[] Glycan() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Glycan);
        }
        public static string[] Reaction() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Reaction);
        }
        public static string[] ReactionClass() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.ReactionClass);
        }
        public static string[] Enzyme() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Enzyme);
        }
        public static string[] Disease() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Disease);
        }
        public static string[] Drug() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Drug);
        }
        public static string[] DrugGroup() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.DrugGroup);
        }
        public static string[] Environ() {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Environ);
        }

        public static string[] Database(Database db) {
            return KeggRestApi.Post(OpStrings.List, StringFrom.Enum(db));
        }

        public static string[] Organism() {
            return KeggRestApi.Post(OpStrings.List, Strings.Organism);
        }

        public static string[] OrganismPathways(string organismCode) {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Pathway, organismCode);
        }
        public static string[] OrganismModules(string organismCode) {
            return KeggRestApi.Post(OpStrings.List, DbStrings.Module, organismCode);
        }

        public static string[] DbEntries(params string[] entries) {
            return KeggRestApi.Post(OpStrings.List, string.Join("+", entries));
        }

    }

}
