using System;
using System.Net;

namespace DotKEGG {

    /// <summary>
    /// Provides static methods for invoking the KEGG API info operation for various KEGG databases.
    /// </summary>
    /// <example>
    /// <include file='../DotKEGG.Docs/IncludeFiles/Operations/Info.xml' path='content/item[@name="InfoExamples"]/*'/>
    /// </example>
    public static class KeggInfo {

        /// <summary>
        /// Returns the current info for the given KEGG database.
        /// </summary>
        /// <param name="db">The KEGG database being queried.</param>
        /// <returns>Current info for the given KEGG database.</returns>
        /// <example>
        /// <token>InfoDbExample</token>
        /// </example>
        public static InfoResults ForDatabase(KeggDb db) => KeggRestApi.GetInfo(db.Name);

        /// <summary>
        /// Returns the current info for the given KEGG composite database.
        /// </summary>
        /// <param name="db">The KEGG composite database being queried.</param>
        /// <returns>Current info for the given KEGG composite database.</returns>
        /// <remarks>
        /// A composite database is actually a wrapper for several "auxiliary" databases.
        /// For example, the KEGG <token>GenomesDbLink</token> database is actually made up of the genome, egenome, and mgenome databases.
        /// Getting info for a composite database like <token>GenomesDbLink</token> will return info about 
        /// all of that database's auxiliary databases.
        /// </remarks>
        /// <example>
        /// <token>InfoCompositeDbExample</token>
        /// </example>
        public static InfoResults ForDatabase(KeggCompositeDb db) => KeggRestApi.GetInfo(db.Name);

        /// <summary>
        /// Returns the current info for the KEGG genes database whose organism has the given code.
        /// </summary>
        /// <param name="organism">The organism code of the organism.</param>
        /// <returns>Current info for the given KEGG genes database.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="organism"/> is <see langword="null"/>.</exception>
        /// <example>
        /// <token>InfoHumanDbExample</token>
        /// </example>
        public static InfoResults ForOrganism(OrganismCode organism) {
            // If the provided organism code is null or empty then throw an Exception
            if (organism == null)
                throw new ArgumentNullException(nameof(organism), $"Cannot invoke the KEGG info operation for a genes database without an organism code!");

            // Try to get KEGG info
            try {
                return KeggRestApi.GetInfo(organism.Code);
            }
            catch (WebException) {
                throw new ArgumentException($"{organism} is not a valid organism code!", nameof(organism));
            }
        }

        /// <summary>
        /// Returns the current info for the KEGG genes database whose genome has the given T Number.
        /// </summary>
        /// <param name="keggId">The KEGG ID of the genome</param>
        /// <returns>Current info for the given KEGG genes database.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keggId"/> is <see langword="null"/>.</exception>
        /// <example>
        /// <token>InfoHumanDbExample</token>
        /// </example>
        public static InfoResults ForGenome(TNumber keggId) {
            if (keggId == null)
                throw new ArgumentNullException(nameof(keggId), $"Cannot invoke the KEGG info operation for a genes database without a genome ID!");

            // Try to get KEGG info
            try {
                return KeggRestApi.GetInfo(keggId.ShortForm());
            }
            catch (WebException) {
                throw new ArgumentException($"'{keggId.ShortForm()}' is not a valid T number!", nameof(keggId));
            }
        }

        /// <summary>
        /// Returns the current info for the entire KEGG database.
        /// </summary>
        /// <returns>Current info for the entire KEGG database.</returns>
        /// <example>
        /// <token>InfoKeggDbExample</token>
        /// </example>
        public static InfoResults ForKegg() => KeggRestApi.GetInfo(Strings.Kegg);

    }

}
