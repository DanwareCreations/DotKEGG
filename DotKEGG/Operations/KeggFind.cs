namespace DotKEGG {

    public static class KeggFind {
        public static string[] Pathway(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Pathway, string.Join("+", keywords));
        public static string[] Module(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Module, string.Join("+", keywords));
        public static string[] Orthology(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Orthology, string.Join("+", keywords));
        public static string[] Genome(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Genome, string.Join("+", keywords));
        public static string[] Organism(string organismId, params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, organismId, string.Join("+", keywords));
        public static string[] Compound(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Compound, string.Join("+", keywords));
        public static string[] Glycan(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Glycan, string.Join("+", keywords));
        public static string[] Reaction(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Reaction, string.Join("+", keywords));
        public static string[] ReactionClass(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.ReactionClass, string.Join("+", keywords));
        public static string[] Enzyme(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Enzyme, string.Join("+", keywords));
        public static string[] Disease(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Disease, string.Join("+", keywords));
        public static string[] Drug(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Drug, string.Join("+", keywords));
        public static string[] DrugGroup(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.DrugGroup, string.Join("+", keywords));
        public static string[] Environ(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Environ, string.Join("+", keywords));

        public static string[] Genes(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, CompositeDbStrings.Genes, string.Join("+", keywords));
        public static string[] Genomes(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, CompositeDbStrings.Genomes, string.Join("+", keywords));
        public static string[] Ligand(params string[] keywords) =>
            KeggRestApi.GetText(OpStrings.Find, CompositeDbStrings.Ligand, string.Join("+", keywords));

        public static string[] Database(Database db) =>
            KeggRestApi.GetText(OpStrings.Find, StringFrom.Enum(db));
        public static string[] CompositeDatabase(CompositeDb db) =>
            KeggRestApi.GetText(OpStrings.Find, StringFrom.Enum(db));

        public static string[] CompoundByFormula(string formula) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Compound, formula, FindOptStrings.Formula);
        public static string[] DrugByFormula(string formula) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Drug, formula, FindOptStrings.Formula);
        public static string[] CompoundByExactMass(double mass) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Compound, mass.ToString(), FindOptStrings.ExactMass);
        public static string[] DrugByExactMass(double mass) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Drug, mass.ToString(), FindOptStrings.ExactMass);
        public static string[] CompoundByMolWeight(double weight) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Compound, weight.ToString(), FindOptStrings.MolWeight);
        public static string[] DrugByMolWeight(double weight) =>
            KeggRestApi.GetText(OpStrings.Find, DbStrings.Drug, weight.ToString(), FindOptStrings.MolWeight);

    }

}
