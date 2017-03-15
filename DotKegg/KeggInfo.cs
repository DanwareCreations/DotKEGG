namespace DotKegg {

    public static class KeggInfo {

        public static string[] Pathway() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Pathway);
        }
        public static string[] Brite() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Brite);
        }
        public static string[] Module() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Module);
        }
        public static string[] Orthology() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Orthology);
        }
        public static string[] Genome() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Genome);
        }
        public static string[] Organism(string organismCode) {
            return KeggRestApi.Post(OpStrings.Info, organismCode);
        }
        public static string[] Compound() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Compound);
        }
        public static string[] Glycan() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Glycan);
        }
        public static string[] Reaction() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Reaction);
        }
        public static string[] ReactionClass() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.ReactionClass);
        }
        public static string[] Enzyme() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Enzyme);
        }
        public static string[] Disease() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Disease);
        }
        public static string[] Drug() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Drug);
        }
        public static string[] DrugGroup() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.DrugGroup);
        }
        public static string[] Environ() {
            return KeggRestApi.Post(OpStrings.Info, DbStrings.Environ);
        }

        public static string[] Genomes() {
            return KeggRestApi.Post(OpStrings.Info, CompositeDbStrings.Genomes);
        }
        public static string[] Genes() {
            return KeggRestApi.Post(OpStrings.Info, CompositeDbStrings.Genes);
        }
        public static string[] Ligand() {
            return KeggRestApi.Post(OpStrings.Info, CompositeDbStrings.Ligand);
        }
        public static string[] Kegg() {
            return KeggRestApi.Post(OpStrings.Info, Strings.Kegg);
        }

        public static string[] Database(Database db) {
            return KeggRestApi.Post(OpStrings.Info, StringFrom.Enum(db));
        }
        public static string[] CompositeDatabase(CompositeDb db) {
            return KeggRestApi.Post(OpStrings.Info, StringFrom.Enum(db));
        }

    }

}
