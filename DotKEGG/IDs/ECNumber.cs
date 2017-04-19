namespace DotKEGG {

    /// <seealso cref="KNumber"/>
    /// <seealso cref="RNumber"/>
    /// <seealso cref="OrthologyDb"/>
    /// <seealso cref="ReactionDb"/>
    /// <seealso cref="EnzymeDb"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    public sealed class ECNumber {

        public enum Class {
            OxidoReductase = 1,
            Transferase = 2,
            Hydrolase = 3,
            Lyase = 4,
            Isomerase = 5,
            Ligase = 6,
        }

        public ECNumber(Class ecClass, uint id2, uint id3, uint serialId) {
            EcClass = ecClass;
            Id2 = id2;
            Id3 = id3;
            SerialId = serialId;
        }

        public Class EcClass { get; }
        public uint Id2 { get; }
        public uint Id3 { get; }
        public uint SerialId { get; }

        public static ECNumber OxidoReductase(uint id2, uint id3, uint serialId) => new ECNumber(Class.OxidoReductase, id2, id3, serialId);
        public static ECNumber Transferase(uint id2, uint id3, uint serialId) => new ECNumber(Class.Transferase, id2, id3, serialId);
        public static ECNumber Hydrolase(uint id2, uint id3, uint serialId) => new ECNumber(Class.Hydrolase, id2, id3, serialId);
        public static ECNumber Lyase(uint id2, uint id3, uint serialId) => new ECNumber(Class.Lyase, id2, id3, serialId);
        public static ECNumber Isomerase(uint id2, uint id3, uint serialId) => new ECNumber(Class.Isomerase, id2, id3, serialId);
        public static ECNumber Ligase(uint id2, uint id3, uint serialId) => new ECNumber(Class.Ligase, id2, id3, serialId);

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
        public static bool operator ==(ECNumber a, ECNumber b) {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }
        public static bool operator !=(ECNumber a, ECNumber b) {
            if (ReferenceEquals(a, null))
                return !ReferenceEquals(b, null);
            return !a.Equals(b);
        }

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
        public override string ToString() => $"{(int)EcClass}.{Id2}.{Id3}.{SerialId}";

    }

}
