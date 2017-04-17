namespace DotKEGG {

    /// <summary>
    /// Represents the <token>GlycanDbLink</token> database.
    /// </summary>
    /// <seealso cref="GNumber"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class GlycanDb: KeggDb {

        private static GlycanDb s_instance = new GlycanDb();

        private GlycanDb() {
            Name = "glycan";
            Abbreviation = "gl";
            Prefix = "G";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static GlycanDb Instance => s_instance;

        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="GlycanDbEntryComments"]/*'/>
        public static GNumber Glycan(uint number) => new GNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new GNumber(number);

    }

}
