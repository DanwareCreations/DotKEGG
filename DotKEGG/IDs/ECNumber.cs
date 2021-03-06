﻿namespace DotKEGG {

    /// <summary>
    /// Represents the Enzyme Commission number for an entry in the KEGG Enzyme database.
    /// </summary>
    /// <seealso cref="KNumber"/>
    /// <seealso cref="RNumber"/>
    /// <seealso cref="ECEnzymeClass"/>
    /// <seealso cref="OrthologyDb"/>
    /// <seealso cref="ReactionDb"/>
    /// <seealso cref="EnzymeDb"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    public sealed class ECNumber {

        /// <summary>
        /// Initializes a new instance of the <see cref="ECNumber"/> class with the specified IDs.
        /// </summary>
        /// <param name="ecClass">The Enzyme Commission class of the enzyme, corresponding to the first number in its EC number.</param>
        /// <param name="id2">The second number in the enzyme's Enzyme Commission number.</param>
        /// <param name="id3">The third number in the enzyme's Enzyme Commission number.</param>
        /// <param name="serialId">The fourth number in the enzyme's Enzyme Commission number, also known as its serial ID.</param>
        public ECNumber(ECEnzymeClass ecClass, uint id2, uint id3, uint serialId) {
            EcClass = ecClass;
            Id2 = id2;
            Id3 = id3;
            SerialId = serialId;
        }

        /// <summary>
        /// The Enzyme Commission class of the enzyme, corresponding to the first number in its EC number.
        /// </summary>
        public ECEnzymeClass EcClass { get; }
        /// <summary>
        /// The second number in the enzyme's Enzyme Commission number.
        /// </summary>
        public uint Id2 { get; }
        /// <summary>
        /// The third number in the enzyme's Enzyme Commission number.
        /// </summary>
        public uint Id3 { get; }
        /// <summary>
        /// The fourth number in the enzyme's Enzyme Commission number, also known as its serial ID.
        /// </summary>
        public uint SerialId { get; }

        /// <summary>
        /// Initializes a new <see cref="ECNumber"/> instance, using <see cref="ECEnzymeClass.OxidoReductase"/> for the class ID.
        /// </summary>
        /// <param name="id2">The second number in the enzyme's Enzyme Commission number.</param>
        /// <param name="id3">The third number in the enzyme's Enzyme Commission number.</param>
        /// <param name="serialId">The fourth number in the enzyme's Enzyme Commission number, also known as its serial ID.</param>
        /// <returns>A new <see cref="ECNumber"/> object of the <see cref="ECEnzymeClass.OxidoReductase"/> EC class, with the specified ID numbers.</returns>
        public static ECNumber OxidoReductase(uint id2, uint id3, uint serialId) => new ECNumber(ECEnzymeClass.OxidoReductase, id2, id3, serialId);
        /// <summary>
        /// Initializes a new <see cref="ECNumber"/> instance, using <see cref="ECEnzymeClass.Transferase"/> for the class ID.
        /// </summary>
        /// <param name="id2">The second number in the enzyme's Enzyme Commission number.</param>
        /// <param name="id3">The third number in the enzyme's Enzyme Commission number.</param>
        /// <param name="serialId">The fourth number in the enzyme's Enzyme Commission number, also known as its serial ID.</param>
        /// <returns>A new <see cref="ECNumber"/> object of the <see cref="ECEnzymeClass.Transferase"/> EC class, with the specified ID numbers.</returns>
        public static ECNumber Transferase(uint id2, uint id3, uint serialId) => new ECNumber(ECEnzymeClass.Transferase, id2, id3, serialId);
        /// <summary>
        /// Initializes a new <see cref="ECNumber"/> instance, using <see cref="ECEnzymeClass.Hydrolase"/> for the class ID.
        /// </summary>
        /// <param name="id2">The second number in the enzyme's Enzyme Commission number.</param>
        /// <param name="id3">The third number in the enzyme's Enzyme Commission number.</param>
        /// <param name="serialId">The fourth number in the enzyme's Enzyme Commission number, also known as its serial ID.</param>
        /// <returns>A new <see cref="ECNumber"/> object of the <see cref="ECEnzymeClass.Hydrolase"/> EC class, with the specified ID numbers.</returns>
        public static ECNumber Hydrolase(uint id2, uint id3, uint serialId) => new ECNumber(ECEnzymeClass.Hydrolase, id2, id3, serialId);
        /// <summary>
        /// Initializes a new <see cref="ECNumber"/> instance, using <see cref="ECEnzymeClass.Lyase"/> for the class ID.
        /// </summary>
        /// <param name="id2">The second number in the enzyme's Enzyme Commission number.</param>
        /// <param name="id3">The third number in the enzyme's Enzyme Commission number.</param>
        /// <param name="serialId">The fourth number in the enzyme's Enzyme Commission number, also known as its serial ID.</param>
        /// <returns>A new <see cref="ECNumber"/> object of the <see cref="ECEnzymeClass.Lyase"/> EC class, with the specified ID numbers.</returns>
        public static ECNumber Lyase(uint id2, uint id3, uint serialId) => new ECNumber(ECEnzymeClass.Lyase, id2, id3, serialId);
        /// <summary>
        /// Initializes a new <see cref="ECNumber"/> instance, using <see cref="ECEnzymeClass.Isomerase"/> for the class ID.
        /// </summary>
        /// <param name="id2">The second number in the enzyme's Enzyme Commission number.</param>
        /// <param name="id3">The third number in the enzyme's Enzyme Commission number.</param>
        /// <param name="serialId">The fourth number in the enzyme's Enzyme Commission number, also known as its serial ID.</param>
        /// <returns>A new <see cref="ECNumber"/> object of the <see cref="ECEnzymeClass.Isomerase"/> EC class, with the specified ID numbers.</returns>
        public static ECNumber Isomerase(uint id2, uint id3, uint serialId) => new ECNumber(ECEnzymeClass.Isomerase, id2, id3, serialId);
        /// <summary>
        /// Initializes a new <see cref="ECNumber"/> instance, using <see cref="ECEnzymeClass.Ligase"/> for the class ID.
        /// </summary>
        /// <param name="id2">The second number in the enzyme's Enzyme Commission number.</param>
        /// <param name="id3">The third number in the enzyme's Enzyme Commission number.</param>
        /// <param name="serialId">The fourth number in the enzyme's Enzyme Commission number, also known as its serial ID.</param>
        /// <returns>A new <see cref="ECNumber"/> object of the <see cref="ECEnzymeClass.Ligase"/> EC class, with the specified ID numbers.</returns>
        public static ECNumber Ligase(uint id2, uint id3, uint serialId) => new ECNumber(ECEnzymeClass.Ligase, id2, id3, serialId);

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            var ec = obj as ECNumber;
            if (ec == null)
                return false;
            return (
                ec.EcClass == EcClass &&
                ec.Id2 == Id2 &&
                ec.Id3 == Id3 &&
                ec.SerialId == SerialId
            );
        }
        /// <summary>
        /// Determines whether this instance and another specified <see cref="ECNumber"/> represent the same Enzyme Commission number.
        /// </summary>
        /// <param name="other">The Enzyme Commission number to compare to this instance.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="other"/> is a <see cref="ECNumber"/> and it represents the same enzyme as this instance; 
        /// otherwise, <see langword="false"/>.  If <paramref name="other"/> is <see langword="null"/>, the method returns <see langword="false"/>.
        /// </returns>
        public bool Equals(ECNumber other) {
            if (ReferenceEquals(other, null))
                return false;
            return (
                other.EcClass == EcClass &&
                other.Id2 == Id2 &&
                other.Id3 == Id3 &&
                other.SerialId == SerialId
            );
        }
        /// <summary>
        /// Determines whether two <see cref="ECNumber"/>s represent the same Enzyme Commission number.
        /// </summary>
        /// <param name="a">The first Enzyme Commission number to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first Enzyme Commission number to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents the same Enzyme Commission number as <paramref name="b"/>; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(ECNumber a, ECNumber b) {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }
        /// <summary>
        /// Determines whether two <see cref="ECNumber"/>s represent different Enzyme Commission numbers.
        /// </summary>
        /// <param name="a">The first Enzyme Commission number to compare, or <see langword="null"/>.</param>
        /// <param name="b">The first Enzyme Commission number to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> represents a different Enzyme Commission number than <paramref name="b"/>; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(ECNumber a, ECNumber b) {
            if (ReferenceEquals(a, null))
                return !ReferenceEquals(b, null);
            return !a.Equals(b);
        }

        /// <inheritdoc/>
        public override int GetHashCode() {
            int hash = 17;

            unchecked {
                hash = hash * 23 + EcClass.GetHashCode();
                hash = hash * 23 + Id2.GetHashCode();
                hash = hash * 23 + Id3.GetHashCode();
                hash = hash * 23 + SerialId.GetHashCode();
            }

            return hash;
        }
        /// <inheritdoc/>
        public override string ToString() => $"{(int)EcClass}.{Id2}.{Id3}.{SerialId}";

    }

}
