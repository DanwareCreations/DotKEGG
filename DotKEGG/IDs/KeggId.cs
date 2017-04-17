using System;

namespace DotKEGG {

    /// <summary>
    /// Represents a KEGG ID, the identifier for an entry in a KEGG database.  This is an <see langword="abstract"/> class.
    /// </summary>
    /// <remarks>
    /// <include file='../../DotKEGG.Docs/IncludeFiles/Ids/KeggId.xml' path='content/item[@name="KeggIdTerminology"]'/>
    /// </remarks>
    /// <threadsafety static="true" instance="true"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    public abstract class KeggId : IEquatable<KeggId> {

        /// <summary>
        /// The KEGG database to which this identifier belongs.
        /// </summary>
        protected KeggDb _db;

        /// <summary>
        /// The 5-digit number of the KEGG ID.
        /// </summary>
        public uint Number { get; protected set; }
        /// <summary>
        /// The KEGG database to which this identifier belongs.
        /// </summary>
        /// <remarks>
        /// <para>
        /// </para>
        /// The <see cref="KeggDb"/> returned by this property in derived classes actually boxes a more specific, derived <see cref= "KeggDb" />.
        /// For example, the <see cref="MNumber"/> class's <see cref="Database"/> property actually returns a <see cref="ModuleDb"/> boxed as a <see cref="KeggDb"/>,
        /// while the <see cref="HNumber"/> class's <see cref="Database"/> property actually returns a <see cref="DiseaseDb"/> boxed as a <see cref="KeggDb"/>.
        /// </remarks>
        public KeggDb Database => _db;

        /// <summary>
        /// Returns a short string representation of the KEGG ID.
        /// </summary>
        /// <returns>A string representation of the KEGG ID in the form of a prefix followed by a five-digit number.  For example, "C00031".</returns>
        public string ShortForm() => $"{_db.Prefix}{Number.ToString("00000")}";
        /// <summary>
        /// Returns a string representation of the KEGG ID in DBGET format.
        /// </summary>
        /// <returns>A DBGET string representation of the KEGG ID, which takes the form &lt;db&gt;:&lt;prefix&gt;&lt;number&gt;.  For example, "cpd:C00031".</returns>
        public string DBGETForm() => $"{_db.Abbreviation}:{_db.Prefix}{Number.ToString("00000")}";
        
        /// <inheritdoc/>
        public override bool Equals(object obj) {
            var kid = obj as KeggId;
            if (kid == null)
                return false;
            return (kid.Number == Number && kid._db == this._db);
        }
        /// <summary>
        /// Determines whether this instance and another specified <see cref="KeggId"/> represent the same KEGG identifier.
        /// </summary>
        /// <param name="other">The KEGG identifier to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="other"/> is a <see cref="KeggId"/> and it represents the same identifier as this instance; 
        /// otherwise, <see langword="false"/>.  If <paramref name="other"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public bool Equals(KeggId other) {
            if (ReferenceEquals(other, null))
                return false;
            return (other.Number == Number && other._db == this._db);
        }
        /// <summary>
        /// Determines whether two <see cref="KeggId"/>s represent the same KEGG identifier.
        /// </summary>
        /// <param name="a">The first identifier to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first identifier to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents the same identifier as <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(KeggId a, KeggId b) {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }
        /// <summary>
        /// Determines whether two <see cref="KeggDb"/>s represent different KEGG identifiers.
        /// </summary>
        /// <param name="a">The first identifier to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first identifier to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents a different identifier than <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(KeggId a, KeggId b) {
            if (ReferenceEquals(a, null))
                return !ReferenceEquals(b, null);
            return !a.Equals(b);
        }

        /// <inheritdoc/>
        public override int GetHashCode() {
            int hash = 17;

            unchecked {
                hash = (hash * 23) + Number.GetHashCode();
                hash = (hash * 23) + _db.GetHashCode();
            }

            return hash;
        }
        /// <inheritdoc/>
        public override string ToString() => DBGETForm();

    }

}
