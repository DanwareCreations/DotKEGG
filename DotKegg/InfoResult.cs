using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace DotKEGG {

    public struct KeggDbInfo {

        public KeggDbInfo(string httpResponse) {

            // Initialize properties to defaults
            Title = "";
            Version = "";
            Organization = "";
            NumEntries = 0;

            IList<string> names = new List<string>();
            string[] tokens;

            // Try to set properties by parsing the HTTP response, which is expected to be in this format:
            //      <name1>          <Title>
            //      <name2>          <Version>
            //      <...>            <Organization>
            //                       <num> entries
            string[] lines = httpResponse.Split('\n');
            for (int ln = 0; ln < lines.Length; ++ln) {
                tokens = lines[ln].Split(new string[1] { "   " }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(t => t.Trim())
                                  .ToArray();
                if (tokens.Length == 0)
                    continue;

                string token = tokens[0];
                if (tokens.Length > 1) {
                    names.Add(tokens[0]);
                    token = tokens[1];
                }
                if (ln == 0)
                    Title = token;
                else if (ln == 1)
                    Version = token;
                else if (ln == 2)
                    Organization = token;
                else if (ln == 3)
                    NumEntries = uint.Parse(token.Split(' ')[0], NumberStyles.AllowThousands);
            }
            Names = names.ToArray();
        }

        public string Title { get; }
        public string Version { get; }
        public string Organization { get; }
        public uint NumEntries { get; }
        public string[] Names { get; }

    }

}
