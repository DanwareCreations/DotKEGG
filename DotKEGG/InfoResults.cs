using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DotKEGG {

    /// <summary>
    /// Represents the current statistics of a given database, as returned by the KEGG API info operation.
    /// </summary>
    public struct InfoResults {

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoResults"/> struct from the HTTP response returned by the KEGG API info operation.
        /// </summary>
        /// <param name="httpResponse">The HTTP response returned by the KEGG API info operation</param>
        /// <remarks>
        /// The HTTP response is expected to be in the following format:
        /// 
        ///     &lt;name&gt;          &lt;Title&gt;
        ///     [&lt;name2&gt;]        &lt;Version&gt;
        ///     [&lt;...&gt;]          &lt;Organization&gt;
        ///                      [&lt;dbname1&gt;] &lt;num&gt; entries
        ///                      [&lt;dbname2&gt; &lt;num&gt; entries]
        ///                      [&lt;dbname3&gt; &lt;num&gt; entries]
        ///                      [&lt;...&gt;]
        ///                       
        /// The number of names in the left column is variable, but usually there are 2 names (one full name like "module", and one abbreviation like "md").
        /// Title, Version, and Organization are always present.
        /// For individual KEGG databases, there is usually only one number-of-entries line.
        /// Composite databases like GENES or GENOMES will typically have multiple lines, one per auxiliary database.
        /// For example, here is the response returned by http://rest.kegg.jp/info/genomes:
        /// 
        ///     genomes          KEGG Genomes Database
        ///     gn               Release 81.0+/03-16, Mar 17
        ///                      Kanehisa Laboratories
        ///                      genome        5,038 entries
        ///                      egenome             entries
        ///                      mgenome       1,189 entries
        /// 
        /// </remarks>
        internal InfoResults(string httpResponse) {

            // Initialize properties (compiler complains if we don't do this)
            FullName = "";
            Name = "";
            Abbreviation = "";
            Version = "";
            Organization = "";

            // For each line...
            string[] lines = httpResponse.Split('\n');
            var numEntries = new List<KeyValuePair<string, uint>>();
            for (int ln = 0; ln < lines.Length; ++ln) {

                // Make sure there are tokens on this line
                string[] tokens = lines[ln].Split(new string[1] { "   " }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(t => t.Trim())
                                           .ToArray();
                if (tokens.Length == 0)
                    continue;

                // Set the value from the right column
                switch (ln) {
                    case 0:
                        Name = tokens[0];
                        FullName = tokens[1];
                        break;

                    case 1:
                        Abbreviation = tokens[0];
                        Version = tokens[1];
                        break;

                    case 2:
                        Organization = tokens[0];
                        break;

                    default:
                        // The first number-of-entries line may or may not have a database name on it
                        string name = (tokens.Length == 1 ? Name : tokens[0]);
                        string numStr = (tokens.Length == 1 ? tokens[0] : tokens[1]).Split(' ')[0];
                        uint num;
                        if (uint.TryParse(numStr, NumberStyles.AllowThousands, NumberFormatInfo.InvariantInfo, out num))
                            numEntries.Add(new KeyValuePair<string, uint>(name, num));
                        break;
                }
            }
            
            NumEntries = new ReadOnlyCollection<KeyValuePair<string, uint>>(numEntries);
        }

        /// <summary>
        /// Gets the name of the queried KEGG database.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets the full name of the queried KEGG database.
        /// </summary>
        public string FullName { get; }
        /// <summary>
        /// Gets the abbreviation of the queried KEGG database.
        /// </summary>
        /// <remarks>
        /// For some databases, this property will have the same value as <see cref="Name"/>.
        /// </remarks>
        public string Abbreviation { get; }
        /// <summary>
        /// Gets the version of the queried KEGG database.
        /// </summary>
        public string Version { get; }
        /// <summary>
        /// Gets the name of the organization that maintains the queried KEGG database.
        /// </summary>
        public string Organization { get; }
        /// <summary>
        /// Gets the number of entries in the queried KEGG database.
        /// For composite databases like GENOMES or LIGAND, returns the number of entries in each auxiliary database.
        /// </summary>
        /// <remarks>
        /// This property is a read-only collection of key-value pairs.
        /// For simple databases like KEGG PATHWAY, there is only one pair.  The key is set to the first Name of the database, and the value holds its number of entries.
        /// For composite databases like GENOMES or LIGAND, there is one key-value pair per auxiliary database.  Each key holds the name of that auxiliary database, and the value holds its number of entries.  For example, querying the GENOMES composite database, there will be one key-value pair each for the genome, egenome, and mgenome auxiliary databases.
        /// </remarks>
        public ReadOnlyCollection<KeyValuePair<string, uint>> NumEntries { get; }

    }

}
