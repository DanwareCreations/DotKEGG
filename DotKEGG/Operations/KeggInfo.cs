using System;
using System.Net;

namespace DotKEGG {

    /// <summary>
    /// Provides static methods for invoking the KEGG API info operation for various KEGG databases.
    /// </summary>
    public static class KeggInfo {

        /// <summary>
        /// Returns the current statistics of the KEGG Organism database with the given organism code.
        /// </summary>
        /// <param name="organismCode">The organism code of the KEGG organism</param>
        /// <returns>Current statistics for the given KEGG Organism database.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="organismCode"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="organismCode"/> is empty or not a valid KEGG Organism code.</exception>
        public static InfoResults Organism(string organismCode) {
            // If the provided organism code is null or empty then throw an Exception
            if (organismCode == null)
                throw new ArgumentNullException(nameof(organismCode), $"Cannot invoke the KEGG info operation without a database name!");
            if (organismCode == string.Empty)
                throw new ArgumentException($"Cannot invoke the KEGG info operation without a database name!", nameof(organismCode));

            // Try to get KEGG info
            try {
                return KeggRestApi.GetInfo(organismCode);
            }
            catch (WebException) {
                throw new ArgumentException($"{organismCode} is not a valid organism code!", nameof(organismCode));
            }
        }

        /// <summary>
        /// Returns the current statistics of the KEGG Organism database whose genome has the given T number.
        /// </summary>
        /// <param name="keggId">The T number of the KEGG Organism's genome</param>
        /// <returns>Current statistics for the given KEGG Organism database.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keggId"/> is <see langword="null"/>.</exception>
        public static InfoResults Organism(TNumber keggId) {
            if (keggId == null)
                throw new ArgumentNullException(nameof(keggId), $"Cannot invoke the KEGG info operation without a database name!");

            // Try to get KEGG info
            try {
                return KeggRestApi.GetInfo(keggId.ShortForm());
            }
            catch (WebException) {
                throw new ArgumentException($"{keggId} is not a valid T number!", nameof(keggId));
            }
        }

        /// <summary>
        /// Returns the current statistics of the entire KEGG database.
        /// </summary>
        /// <returns>Current statistics for the entire KEGG database.</returns>
        public static InfoResults Kegg() {
            return KeggRestApi.GetInfo(Strings.Kegg);
        }

        /// <summary>
        /// Returns the current statistics of the given KEGG database.
        /// </summary>
        /// <param name="db">The KEGG database being queried.</param>
        /// <returns>Current statistics for the given KEGG database.</returns>
        public static InfoResults Database(KeggDb db) {
            return KeggRestApi.GetInfo(db.Name);
        }

        /// <summary>
        /// Returns the current statistics of the given KEGG composite database.
        /// </summary>
        /// <param name="db">The KEGG composite database being queried.</param>
        /// <returns>Current statistics for the given KEGG composite database.</returns>
        /// <remarks>
        /// A composite database is actually a wrapper for several "auxiliary" databases.
        /// For example, the KEGG <token>GenomesDbLink</token> database is actually made up of the genome, egenome, and mgenome databases.
        /// Getting info for a composite database like <token>GenomesDbLink</token> will return info about 
        /// all of that database's auxiliary databases.
        /// </remarks>
        public static InfoResults Database(KeggCompositeDb db) {
            return KeggRestApi.GetInfo(db.Name);
        }

    }

}
