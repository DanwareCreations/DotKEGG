using System;
using System.Net;
using System.Linq;

namespace DotKEGG {

    internal static class KeggRestApi {

        private static WebClient _web = new WebClient();

        public static string[] GetText(params string[] parameters) {
            string post = "http://rest.kegg.jp/" + string.Join("/", parameters);
            string response = _web.DownloadString(post);
            string[] ids = response.Split('\n').Select(row => row.Split('\t')[0]).ToArray();
            return ids;
        }

        public static InfoResults GetInfo(params string[] parameters) {
            string post = "http://rest.kegg.jp/info/" + string.Join("/", parameters);
            string response = _web.DownloadString(post);
            return new InfoResults(response);
        }

        public static string[] GetDBGET(params string[] parameters) {
            string post = "http://rest.kegg.jp/get/" + string.Join("/", parameters);
            string response = _web.DownloadString(post);
            return response.Split(new string[1] { "///" }, StringSplitOptions.None);
        }

    }

}
