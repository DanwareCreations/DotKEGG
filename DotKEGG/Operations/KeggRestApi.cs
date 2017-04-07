using System;
using System.Net;
using System.Linq;

namespace DotKEGG {

    internal static class KeggRestApi {

        private static WebClient s_web = new WebClient() { BaseAddress = "http://rest.kegg.jp/" };

        public static string[] GetText(params string[] parameters) {
            string uri = string.Join("/", parameters);
            string response = s_web.DownloadString(uri);
            string[] ids = response.Split('\n').Select(row => row.Split('\t')[0]).ToArray();
            return ids;
        }

        public static InfoResults GetInfo(params string[] parameters) {
            string uri = "info/" + string.Join("/", parameters);
            string response = s_web.DownloadString(uri);
            return new InfoResults(response);
        }

        public static string[] GetDBGET(params string[] parameters) {
            string uri = "get/" + string.Join("/", parameters);
            string response = s_web.DownloadString(uri);
            return response.Split(new string[1] { "///" }, StringSplitOptions.None);
        }

    }

}
