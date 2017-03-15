namespace DotKEGG {

    public static class KeggInfo {

        public static KeggDbInfo Pathway() {
            return KeggRestApi.GetInfo(DbStrings.Pathway);
        }
        public static KeggDbInfo Brite() {
            return KeggRestApi.GetInfo(DbStrings.Brite);
        }
        public static KeggDbInfo Module() {
            return KeggRestApi.GetInfo(DbStrings.Module);
        }
        public static KeggDbInfo Orthology() {
            return KeggRestApi.GetInfo(DbStrings.Orthology);
        }
        public static KeggDbInfo Genome() {
            return KeggRestApi.GetInfo(DbStrings.Genome);
        }
        public static KeggDbInfo Organism(string organismCode) {
            return KeggRestApi.GetInfo(organismCode);
        }
        public static KeggDbInfo Compound() {
            return KeggRestApi.GetInfo(DbStrings.Compound);
        }
        public static KeggDbInfo Glycan() {
            return KeggRestApi.GetInfo(DbStrings.Glycan);
        }
        public static KeggDbInfo Reaction() {
            return KeggRestApi.GetInfo(DbStrings.Reaction);
        }
        public static KeggDbInfo ReactionClass() {
            return KeggRestApi.GetInfo(DbStrings.ReactionClass);
        }
        public static KeggDbInfo Enzyme() {
            return KeggRestApi.GetInfo(DbStrings.Enzyme);
        }
        public static KeggDbInfo Disease() {
            return KeggRestApi.GetInfo(DbStrings.Disease);
        }
        public static KeggDbInfo Drug() {
            return KeggRestApi.GetInfo(DbStrings.Drug);
        }
        public static KeggDbInfo DrugGroup() {
            return KeggRestApi.GetInfo(DbStrings.DrugGroup);
        }
        public static KeggDbInfo Environ() {
            return KeggRestApi.GetInfo(DbStrings.Environ);
        }

        public static KeggDbInfo Genomes() {
            return KeggRestApi.GetInfo(CompositeDbStrings.Genomes);
        }
        public static KeggDbInfo Genes() {
            return KeggRestApi.GetInfo(CompositeDbStrings.Genes);
        }
        public static KeggDbInfo Ligand() {
            return KeggRestApi.GetInfo(CompositeDbStrings.Ligand);
        }
        public static KeggDbInfo Kegg() {
            return KeggRestApi.GetInfo(Strings.Kegg);
        }

        public static KeggDbInfo Database(Database db) {
            return KeggRestApi.GetInfo(StringFrom.Enum(db));
        }
        public static KeggDbInfo CompositeDatabase(CompositeDb db) {
            return KeggRestApi.GetInfo(StringFrom.Enum(db));
        }

    }

}
