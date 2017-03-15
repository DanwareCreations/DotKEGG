namespace DotKegg {

    public static class KeggGet {

        public static string[] Pathway(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Brite(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Module(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Orthology(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Genome(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Organism(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Compound(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Glycan(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Reaction(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] ReactionClass(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Enzyme(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Disease(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Drug(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] DrugGroup(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Environ(params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }

        public static string[] Pathway(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Brite(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Module(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Orthology(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Genome(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Organism(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Compound(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Glycan(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Reaction(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] ReactionClass(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Enzyme(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Disease(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Drug(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] DrugGroup(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }
        public static string[] Environ(GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }

        public static string[] Database(Database db, params string[] dbEntries) {
            return doPost(GetOption.None, dbEntries);
        }
        public static string[] Database(Database db, GetOption option, params string[] dbEntries) {
            return doPost(option, dbEntries);
        }

        private static string[] doPost(GetOption option = GetOption.None, params string[] dbEntries) {
            string[] results = (
                option == GetOption.None ?
                KeggRestApi.Post(OpStrings.Get, string.Join("+", dbEntries)) :
                KeggRestApi.Post(OpStrings.Get, string.Join("+", dbEntries), StringFrom.Enum(option))
            );

            return results;
        }

    }

}
