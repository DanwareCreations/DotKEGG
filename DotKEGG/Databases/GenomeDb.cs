using System;

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

        private GenomeDb() {
            Name = "genome";
            Abbreviation = "genome";
            Prefix = "T";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static GenomeDb Instance => s_instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GenomeDbEntryComments"]/*'/>
        public static TNumber Genome(uint number) => new TNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new TNumber(number);

    }

}
