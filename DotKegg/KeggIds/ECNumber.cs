namespace DotKEGG {

    public sealed class ECNumber {

        public ECNumber(uint ecClassId, uint id2, uint id3, uint serialId) {
            EcClassId = ecClassId;
            Id2 = id2;
            Id3 = id3;
            SerialId = serialId;
        }

        public uint EcClassId { get; }
        public uint Id2 { get; }
        public uint Id3 { get; }
        public uint SerialId { get; }

        public static ECNumber OxidoReductase(uint id2, uint id3, uint serialId) {
            return new ECNumber(1, id2, id3, serialId);
        }
        public static ECNumber Transferase(uint id2, uint id3, uint serialId) {
            return new ECNumber(2, id2, id3, serialId);
        }
        public static ECNumber Hydrolase(uint id2, uint id3, uint serialId) {
            return new ECNumber(3, id2, id3, serialId);
        }
        public static ECNumber Lyase(uint id2, uint id3, uint serialId) {
            return new ECNumber(4, id2, id3, serialId);
        }
        public static ECNumber Isomerase(uint id2, uint id3, uint serialId) {
            return new ECNumber(5, id2, id3, serialId);
        }
        public static ECNumber Ligase(uint id2, uint id3, uint serialId) {
            return new ECNumber(6, id2, id3, serialId);
        }

        public override bool Equals(object obj) {
            ECNumber ec = obj as ECNumber;
            if (ec == null)
                return false;
            return (
                ec.EcClassId == EcClassId &&
                ec.Id2 == Id2 &&
                ec.Id3 == Id3 &&
                ec.SerialId == SerialId
            );
        }
        public bool Equals(ECNumber other) {
            if (ReferenceEquals(other, null))
                return false;
            return (
                other.EcClassId == EcClassId &&
                other.Id2 == Id2 &&
                other.Id3 == Id3 &&
                other.SerialId == SerialId
            );
        }
        public static bool operator ==(ECNumber left, ECNumber right) {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }
        public static bool operator !=(ECNumber left, ECNumber right) {
            if (ReferenceEquals(left, null))
                return !ReferenceEquals(right, null);
            return !left.Equals(right);
        }

        public override int GetHashCode() {
            int hash = 17;

            unchecked {
                hash = hash * 23 + EcClassId.GetHashCode();
                hash = hash * 23 + Id2.GetHashCode();
                hash = hash * 23 + Id3.GetHashCode();
                hash = hash * 23 + SerialId.GetHashCode();
            }

            return hash;
        }
        public override string ToString() {
            return $"{EcClassId}.{Id2}.{Id3}.{SerialId}";
        }

    }

}
