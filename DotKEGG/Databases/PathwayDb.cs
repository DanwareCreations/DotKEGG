using System.Collections.Generic;

namespace DotKEGG {

    /// <summary>
    /// Represents the <token>PathwayDbLink</token> database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class PathwayDb : KeggDb {

        private static PathwayDb s_instance = new PathwayDb();

        private PathwayDb() {
            Name = "pathway";
            Abbreviation = "path";
            Prefix = "map";
        }

        /// <summary>
        /// <token>DbInstanceSummary</token>
        /// </summary>
        public static PathwayDb Instance => s_instance;

        /// <summary>
        /// Returns the <token>PathwayDbLink</token> database entry with the given <token>PathwayDbPrefix</token> number.
        /// </summary>
        /// <param name="number">The <token>PathwayDbPrefix</token> number of the <token>PathwayDbLink</token> database entry.</param>
        /// <returns>A lightweight object representing the <token>PathwayDbLink</token> database entry with the given <token>PathwayDbPrefix</token> number.</returns>
        public static MapNumber Pathway(uint number) => new MapNumber(number);

        /// <inheritdoc/>
        public override KeggId Entry(uint number) => new MapNumber(number);

    }

}
