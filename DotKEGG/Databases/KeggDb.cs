using System;

namespace DotKEGG {

    /// <summary>
    /// Represents a simple KEGG database.  This is an <see langword="abstract"/> class.
    /// </summary>
    /// <inheritdoc/>
    public abstract class KeggDb : IEquatable<KeggDb> {

        /// <summary>
        /// The name of the database
        /// </summary>
        /// <remarks>
        /// <include file='Documentation/InfoResults.xml' path='InfoResults/remarks[@id="KeggDbNames"]'/>
        /// </remarks>
        public string Name { get; protected set; }
        public string Abbreviation { get; protected set; }
        public string Prefix { get; protected set; }

        public abstract KeggId Entry(uint number);

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be a <see cref="KeggDb"/> object, have the same value.
        /// </summary>
        /// <param name="obj">The database to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="obj"/> is a <see cref="KeggDb"/> and its value is the same as this instance; otherwise, <see langword="false"/>.
        /// If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj) {
            KeggDb kdb = obj as KeggDb;
            if (kdb == null)
                return false;

            return kdb.Name == this.Name;
        }
        /// <summary>
        /// Determines whether this instance and another specified <see cref="KeggDb"/> object have the same value.
        /// </summary>
        /// <param name="other">The database to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="other"/> is a <see cref="KeggDb"/> and its value is the same as this instance; otherwise, <see langword="false"/>.
        /// If <paramref name="other"/> is <see langword="null"/>, the method returns <see langword="false"/>.
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
        /// <see langword="true"/> if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, <see langword="false"/>.
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
        /// <see langword="true"/> if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise, <see langword="false"/>.
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