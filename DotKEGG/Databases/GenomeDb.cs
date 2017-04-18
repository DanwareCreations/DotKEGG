using System;
using System.Net;

namespace DotKEGG {

    /// <summary>
    /// Represents the <token>GenomeDbLink</token> database.
    /// </summary>
    /// <seealso cref="TNumber"/>
    /// <seealso cref="OrganismCode"/>
    /// <seealso cref="GenesDb"/>
    /// <seealso cref="GenomesDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    public sealed class GenomeDb: KeggDb {

        private static GenomeDb s_instance = new GenomeDb();

        private GenomeDb() : base("genome", "genome", "T") { }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static GenomeDb Instance => s_instance;

        /// <summary>
        /// Returns the current info for the KEGG genes database with the given organism code.
        /// </summary>
        /// <param name="code">The organism code of the organism.</param>
        /// <returns>Current info for the given KEGG genes database.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="code"/> is <see langword="null"/>.</exception>
        /// <example>
        /// <token>InfoHumanDbExample</token>
        /// </example>
        public static InfoResults GeneInfo(OrganismCode code) {
            if (code == null)
                throw new ArgumentNullException(nameof(code), $"Cannot invoke the KEGG info operation for a genes database without an organism code!");
            return KeggRestApi.GetInfo(code.Code);
        }
        /// <summary>
        /// Returns the current info for the KEGG genes database for the given genome.
        /// </summary>
        /// <param name="genomeId">The KEGG ID of the genome</param>
        /// <returns>Current info for the given KEGG genes database.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="genomeId"/> is <see langword="null"/>.</exception>
        /// <example>
        /// <token>InfoHumanDbExample</token>
        /// </example>
        public static InfoResults GeneInfo(TNumber genomeId) {
            if (genomeId == null)
                throw new ArgumentNullException(nameof(genomeId), $"Cannot invoke the KEGG info operation for a genes database without a genome ID!");
            return KeggRestApi.GetInfo(genomeId.ShortForm());
        }

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GenomeDbEntryComments"]/*'/>
        public static TNumber Genome(uint number) => new TNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new TNumber(number);

    }

}
