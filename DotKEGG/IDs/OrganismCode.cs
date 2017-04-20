using System;

namespace DotKEGG {

    /// <summary>
    /// Represents the code for an organism in the GENOME database.
    /// </summary>
    /// <seealso cref="TNumber"/>
    /// <seealso cref="GenomeDb"/>
    /// <seealso cref="GenomesDb"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public class OrganismCode : IEquatable<OrganismCode> {

        private TNumber _genomeId;

        /// <summary>
        /// Creates a new organism code from the provided three- or four-letter KEGG organism code.
        /// </summary>
        /// <param name="code">The organism's three- or four-letter code.</param>
        /// <exception cref="ArgumentNullException"><paramref name="code"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="code"/> is an empty string.</exception>
        public OrganismCode(string code) {
            if (code == null)
                throw new ArgumentNullException(nameof(code), $"Cannot create an {nameof(OrganismCode)} from a null string!");
            if (code == string.Empty)
                throw new ArgumentException($"Cannot create an {nameof(OrganismCode)} from an empty string!");
            Code = code;
        }
        /// <summary>
        /// The three- or four-letter code of the KEGG organism.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Returns the KEGG ID (a.k.a., T Number) of the KEGG GENOME that is associated with this organism.
        /// </summary>
        /// <returns>The <see cref="TNumber"/> of the KEGG GENOME that is associated with this organism.</returns>
        public TNumber GetGenomeId() {
            _genomeId = _genomeId ?? throw new NotImplementedException($"{nameof(GetGenomeId)} is not yet implemented.");
            return _genomeId;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            var org = obj as OrganismCode;
            if (org == null)
                return false;
            return (org.Code == Code);
        }
        /// <summary>
        /// Determines whether this instance and another specified <see cref="OrganismCode"/> represent the same organism.
        /// </summary>
        /// <param name="other">The organism code to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="other"/> is an <see cref="OrganismCode"/> and it represents the same organism as this instance; 
        /// otherwise, <see langword="false"/>.  If <paramref name="other"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public bool Equals(OrganismCode other) {
            if (ReferenceEquals(other, null))
                return false;
            return (other.Code == Code);
        }
        /// <summary>
        /// Determines whether two <see cref="OrganismCode"/>s represent the same organism.
        /// </summary>
        /// <param name="a">The first organism code to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first organism code to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents the same organism as <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(OrganismCode a, OrganismCode b) {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }
        /// <summary>
        /// Determines whether two <see cref="OrganismCode"/>s represent different organisms.
        /// </summary>
        /// <param name="a">The first organism code to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first organism code to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents a different organism than <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(OrganismCode a, OrganismCode b) {
            if (ReferenceEquals(a, null))
                return !ReferenceEquals(b, null);
            return !a.Equals(b);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => Code.GetHashCode();
        /// <inheritdoc/>
        public override string ToString() => Code;

    }

}
