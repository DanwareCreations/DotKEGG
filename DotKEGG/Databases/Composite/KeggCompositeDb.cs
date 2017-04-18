using System;

namespace DotKEGG {

    /// <summary>
    /// Represents a composite KEGG database.  This is an <see langword="abstract"/> class.
    /// </summary>
    /// <remarks>
    /// <include file='../../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="CompoundVsComposite"]/*'/>
    /// </remarks>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <threadsafety static="true" instance="true"/>
    public abstract class KeggCompositeDb : IEquatable<KeggCompositeDb> {

        protected KeggCompositeDb(string name, string abbrev) {
            Name = name;
            Abbreviation = abbrev;
        }

        /// <summary>
        /// The name of the composite database.
        /// </summary>
        /// <remarks>
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Operations/Info.xml' path='content/item[@name="KeggDbTable"]'/>
        /// </remarks>
        public string Name { get; protected set; }
        /// <summary>
        /// The abbreviation for the composite database.
        /// </summary>
        /// <remarks>
        /// <include file='../../../DotKEGG.Docs/IncludeFiles/Operations/Info.xml' path='content/item[@name="KeggDbTable"]'/>
        /// </remarks>
        public string Abbreviation { get; protected set; }

        /// <summary>
        /// Returns current info for the KEGG composite database.
        /// </summary>
        /// <returns>Current info for the KEGG composite database.</returns>
        /// <remarks>
        /// A composite database is actually a wrapper for several "auxiliary" databases.
        /// For example, the KEGG <token>GenomesDbLink</token> database is actually made up of the genome, egenome, and mgenome databases.
        /// Getting info for a composite database like <token>GenomesDbLink</token> will return info about 
        /// all of that database's auxiliary databases.
        /// </remarks>
        /// <example>
        /// <token>InfoCompositeDbExample</token>
        /// </example>
        public InfoResults Info() => KeggRestApi.GetInfo(Name);

        /// <summary>
        /// Determines whether this instance and another specified <see cref="KeggCompositeDb"/> represent the same KEGG composite database.
        /// </summary>
        /// <param name="other">The composite database to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="other"/> is a <see cref="KeggCompositeDb"/> and it represents the same composite database as this instance; 
        /// otherwise, <see langword="false"/>.  If <paramref name="other"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public bool Equals(KeggCompositeDb other) {
            if (ReferenceEquals(other, null))
                return false;
            return base.Equals(other);
        }
        /// <inheritdoc/>
        public override bool Equals(object obj) {
            var kdb = obj as KeggCompositeDb;
            if (kdb == null)
                return false;

            return kdb.Name == this.Name;
        }
        /// <summary>
        /// Determines whether two <see cref="KeggCompositeDb"/>s represent the same KEGG composite database.
        /// </summary>
        /// <param name="a">The first composite database to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first composite database to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents the same composite database as <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(KeggCompositeDb a, KeggCompositeDb b) {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }
        /// <summary>
        /// Determines whether two <see cref="KeggCompositeDb"/>s represent different KEGG composite databases.
        /// </summary>
        /// <param name="a">The first composite database to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first composite database to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents a different composite database than <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(KeggCompositeDb a, KeggCompositeDb b) {
            if (ReferenceEquals(a, null))
                return !ReferenceEquals(b, null);
            return !a.Equals(b);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => Name.GetHashCode();
        /// <inheritdoc/>
        public override string ToString() => Name;

    }

}
