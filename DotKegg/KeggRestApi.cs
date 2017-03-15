using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotKegg {

    internal static class KeggRestApi {

        public static string[] Post(params string[] parameters) {
            string post = "http://rest.kegg.jp/" + string.Join("/", parameters);
            throw new NotImplementedException();
        }

    }

}
