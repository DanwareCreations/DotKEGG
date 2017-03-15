namespace DotKegg {

    public static class KeggFind {
        public static string[] Pathway(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Pathway, string.Join("+", keywords));
        }
        public static string[] Module(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Module, string.Join("+", keywords));
        }
        public static string[] Orthology(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Orthology, string.Join("+", keywords));
        }
        public static string[] Genome(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Genome, string.Join("+", keywords));
        }
        public static string[] Organism(string organismId, params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, organismId, string.Join("+", keywords));
        }
        public static string[] Compound(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Compound, string.Join("+", keywords));
        }
        public static string[] Glycan(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Glycan, string.Join("+", keywords));
        }
        public static string[] Reaction(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Reaction, string.Join("+", keywords));
        }
        public static string[] ReactionClass(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.ReactionClass, string.Join("+", keywords));
        }
        public static string[] Enzyme(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Enzyme, string.Join("+", keywords));
        }
        public static string[] Disease(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Disease, string.Join("+", keywords));
        }
        public static string[] Drug(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Drug, string.Join("+", keywords));
        }
        public static string[] DrugGroup(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.DrugGroup, string.Join("+", keywords));
        }
        public static string[] Environ(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Environ, string.Join("+", keywords));
        }

        public static string[] Genes(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, CompositeDbStrings.Genes, string.Join("+", keywords));
        }
        public static string[] Genomes(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, CompositeDbStrings.Genomes, string.Join("+", keywords));
        }
        public static string[] Ligand(params string[] keywords) {
            return KeggRestApi.Post(OpStrings.Find, CompositeDbStrings.Ligand, string.Join("+", keywords));
        }

        public static string[] Database(Database db) {
            return KeggRestApi.Post(OpStrings.Find, StringFrom.Enum(db));
        }
        public static string[] CompositeDatabase(CompositeDb db) {
            return KeggRestApi.Post(OpStrings.Find, StringFrom.Enum(db));
        }

        public static string[] CompoundByFormula(string formula) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Compound, formula, FindOptStrings.Formula);
        }
        public static string[] DrugByFormula(string formula) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Drug, formula, FindOptStrings.Formula);
        }
        public static string[] CompoundByExactMass(double mass) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Compound, mass.ToString(), FindOptStrings.ExactMass);
        }
        public static string[] DrugByExactMass(double mass) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Drug, mass.ToString(), FindOptStrings.ExactMass);
        }
        public static string[] CompoundByMolWeight(double weight) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Compound, weight.ToString(), FindOptStrings.MolWeight);
        }
        public static string[] DrugByMolWeight(double weight) {
            return KeggRestApi.Post(OpStrings.Find, DbStrings.Drug, weight.ToString(), FindOptStrings.MolWeight);
        }

    }

}
