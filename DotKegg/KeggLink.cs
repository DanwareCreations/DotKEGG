namespace DotKegg {

    public static class KeggLink {

        public static string[] Link(Database targetDb, Database sourceDb) {
            return KeggRestApi.Post(OpStrings.Link, StringFrom.Enum(targetDb), StringFrom.Enum(sourceDb));
        }
        public static string[] Link(Database targetDb, params string[] sourceDbEntries) {
            return KeggRestApi.Post(OpStrings.Link, StringFrom.Enum(targetDb), string.Join("+", sourceDbEntries));
        }
        public static string[] LinkGenes(params string[] sourceDbEntries) {
            return KeggRestApi.Post(OpStrings.Link, CompositeDbStrings.Genes, string.Join("+", sourceDbEntries));
        }

    }

}
