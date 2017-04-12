using System;

namespace DotKEGG {

    /// <summary>
    /// Represents a simple KEGG database.  This is an <see langword="abstract"/> class.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public abstract class KeggDb : IEquatable<KeggDb> {

        /// <summary>
        /// The name of the database.
        /// </summary>
        /// <remarks>
        /// <include file='../../DotKEGG.Docs/IncludeFiles/Operations/Info.xml' path='content/item[@name="KeggDbTable"]'/>
        /// </remarks>
        public string Name { get; protected set; }
        /// <summary>
        /// The abbreviation for the database.
        /// </summary>
        /// <remarks>
        /// <include file='../../DotKEGG.Docs/IncludeFiles/Operations/Info.xml' path='content/item[@name="KeggDbTable"]'/>
        /// </remarks>
        public string Abbreviation { get; protected set; }
        /// <summary>
        /// The prefix on KEGG IDs in this database.
        /// </summary>
        /// <remarks>
        /// <include file='../../DotKEGG.Docs/IncludeFiles/Operations/Info.xml' path='content/item[@name="KeggDbTable"]'/>
        /// </remarks>
        public string Prefix { get; protected set; }

        /// <summary>
        /// Returns a <see cref="KeggId"/> wrapping the entry in the database with the provided KEGG ID number.
        /// </summary>
        /// <param name="number">The unique number in the entry's KEGG ID.</param>
        /// <returns>A lightweight object representing the entry in the database with the provided KEGG ID number.</returns>
        /// <remarks>
        /// <include file='../../DotKEGG.Docs/IncludeFiles/Databases/KeggDb.xml' path='content/item[@name="DbEntryComparison"]'/>
        /// </remarks>
        public abstract KeggId Entry(uint number);
        
        /// <inheritdoc/>
        public override bool Equals(object obj) {
            var kdb = obj as KeggDb;
            if (kdb == null)
                return false;

            return kdb.Name == this.Name;
        }
        /// <summary>
        /// Determines whether this instance and another specified <see cref="KeggDb"/> represent the same KEGG database.
        /// </summary>
        /// <param name="other">The database to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="other"/> is a <see cref="KeggDb"/> and it represents the same database as this instance; 
        /// otherwise, <see langword="false"/>.  If <paramref name="other"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public bool Equals(KeggDb other) {
            if (ReferenceEquals(other, null))
                return false;
            return other.Name == this.Name;
        }
        /// <summary>
        /// Determines whether two <see cref="KeggDb"/>s represent the same KEGG database.
        /// </summary>
        /// <param name="a">The first database to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first database to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents the same database as <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(KeggDb a, KeggDb b) {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Name == b.Name;
        }
        /// <summary>
        /// Determines whether two <see cref="KeggDb"/>s represent different KEGG databases.
        /// </summary>
        /// <param name="a">The first database to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first database to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents a different database than <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(KeggDb a, KeggDb b) {
            if (ReferenceEquals(a, null))
                return !ReferenceEquals(b, null);
            return a.Name != b.Name;
        }
        
        /// <inheritdoc/>
        public override int GetHashCode() {
            return Name.GetHashCode();
        }
        /// <inheritdoc/>
        public override string ToString() {
            return Name;
        }

    }

}