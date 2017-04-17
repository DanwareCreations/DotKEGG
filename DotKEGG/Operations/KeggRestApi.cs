using System;
using System.Net;
using System.Linq;

namespace DotKEGG {

    internal static class KeggRestApi {

        private static WebClient s_web = new WebClient() { BaseAddress = "http://rest.kegg.jp/" };

        public static string[] GetText(params string[] parameters) {
            string uri = string.Join("/", parameters);

            try {
                string response = s_web.DownloadString(uri);
                string[] ids = response.Split('\n').Select(row => row.Split('\t')[0]).ToArray();
                return ids;
            }
            catch (Exception e) {
                throw new ArgumentException($"KEGG operation could not be completed!  This may be due to Internet connectivity issues, or to invalid query parameters.", e);
            }
        }

        /// <summary>
        /// Gets current info for the provided database
        /// </summary>
        /// <param name="database">The name of the database to get info for.</param>
        /// <returns></returns>
        public static InfoResults GetInfo(string database) {
            string uri = $"info/{database}";

            try {
                string response = s_web.DownloadString(uri);
                return new InfoResults(response);
            }
            catch (Exception e) {
                throw new ArgumentException($"KEGG Info operation could not be completed!  This may be due to Internet connectivity issues, or to invalid query parameters.", e);
            }
        }

    }

}
