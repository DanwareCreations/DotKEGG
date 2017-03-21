using System;

namespace DotKEGG {

    public abstract class KeggCompositeDb : IEquatable<KeggCompositeDb> {

        public string Name { get; protected set; }
        public string Abbreviation { get; protected set; }

        public bool Equals(KeggCompositeDb other) {
            if (ReferenceEquals(other, null))
                return false;
            return base.Equals(other);
        }
        public override bool Equals(object obj) {
            KeggCompositeDb kdb = obj as KeggCompositeDb;
            if (kdb == null)
                return false;

            return kdb.Name == this.Name;
        }
        public static bool operator ==(KeggCompositeDb left, KeggCompositeDb right) {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Name == right.Name;
        }
        public static bool operator !=(KeggCompositeDb left, KeggCompositeDb right) {
            if (ReferenceEquals(left, null))
                return !ReferenceEquals(right, null);
            return left.Name != right.Name;
        }

        public override int GetHashCode() {
            return Name.GetHashCode();
        }
        public override string ToString() {
            return Name;
        }

    }

}
