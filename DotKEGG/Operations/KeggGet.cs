using System.Linq;

namespace DotKEGG {

    /// <seealso cref="KeggConvert"/>
    /// <seealso cref="KeggFind"/>
    /// <seealso cref="KeggInfo"/>
    /// <seealso cref="KeggLink"/>
    /// <seealso cref="KeggList"/>
    public static class KeggGet {

        public static string[] Get(params KeggId[] entries) {
            string[] dbEntries = entries.Select(kid => kid.DBGETForm()).ToArray();
            return KeggRestApi.GetDBGET(string.Join("+", dbEntries));
        }
        public static string[] Get(GetOption option, params KeggId[] entries) {
            string[] dbEntries = entries.Select(kid => kid.DBGETForm()).ToArray();
            return KeggRestApi.GetDBGET(string.Join("+", dbEntries), StringFrom.Enum(option));
        }

    }

}
