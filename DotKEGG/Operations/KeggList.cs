using System.Linq;
using System.Collections.Generic;

namespace DotKEGG {

    public static class KeggList {

        public static string[] Pathway() => KeggRestApi.GetText(OpStrings.List, DbStrings.Pathway);
        public static string[] Brite() => KeggRestApi.GetText(OpStrings.List, DbStrings.Brite);
        public static string[] Module() => KeggRestApi.GetText(OpStrings.List, DbStrings.Module);
        public static string[] Orthology() => KeggRestApi.GetText(OpStrings.List, DbStrings.Orthology);
        public static string[] Genome() => KeggRestApi.GetText(OpStrings.List, DbStrings.Genome);
        public static string[] Organism(string organismCode) => KeggRestApi.GetText(OpStrings.List, organismCode);
        public static string[] Compound() => KeggRestApi.GetText(OpStrings.List, DbStrings.Compound);
        public static string[] Glycan() => KeggRestApi.GetText(OpStrings.List, DbStrings.Glycan);
        public static string[] Reaction() => KeggRestApi.GetText(OpStrings.List, DbStrings.Reaction);
        public static string[] ReactionClass() => KeggRestApi.GetText(OpStrings.List, DbStrings.ReactionClass);
        public static string[] Enzyme() => KeggRestApi.GetText(OpStrings.List, DbStrings.Enzyme);
        public static string[] Disease() => KeggRestApi.GetText(OpStrings.List, DbStrings.Disease);
        public static string[] Drug() => KeggRestApi.GetText(OpStrings.List, DbStrings.Drug);
        public static string[] DrugGroup() => KeggRestApi.GetText(OpStrings.List, DbStrings.DrugGroup);
        public static string[] Environ() => KeggRestApi.GetText(OpStrings.List, DbStrings.Environ);

        public static string[] Database(Database db) => KeggRestApi.GetText(OpStrings.List, StringFrom.Enum(db));

        public static string[] Organism() => KeggRestApi.GetText(OpStrings.List, Strings.Organism);

        public static string[] OrganismPathways(string organismCode) => 
            KeggRestApi.GetText(OpStrings.List, DbStrings.Pathway, organismCode);
        public static string[] OrganismModules(string organismCode) =>
            KeggRestApi.GetText(OpStrings.List, DbStrings.Module, organismCode);

        public static string[] DbEntries(params KeggId[] entries) {
            IEnumerable<string> dbEntries = entries.Select(kid => kid.DBGETForm());
            string joined = string.Join("+", dbEntries.ToArray());
            return KeggRestApi.GetText(OpStrings.List, joined);
        }

    }

}
