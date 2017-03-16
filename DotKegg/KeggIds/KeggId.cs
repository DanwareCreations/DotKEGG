using System;

namespace DotKEGG {

    public abstract class KeggId : IEquatable<KeggId> {

        protected KeggDb _db;

        public uint Number { get; protected set; }
        
        public string ShortForm() {
            return $"{_db.Prefix}{Number.ToString("00000")}";
        }
        public string DBGETForm() {
            return $"{_db.Abbreviation}:{_db.Prefix}{Number.ToString("00000")}";
        }

        public override bool Equals(object obj) {
            KeggId kid = obj as KeggId;
            if (kid == null)
                return false;
            return (kid.Number == Number && kid._db == this._db);
        }
        public bool Equals(KeggId other) {
            if (ReferenceEquals(other, null))
                return false;
            return (other.Number == Number && other._db == this._db);
        }
        public static bool operator ==(KeggId left, KeggId right) {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }
        public static bool operator !=(KeggId left, KeggId right) {
            if (ReferenceEquals(left, null))
                return !ReferenceEquals(right, null);
            return !left.Equals(right);
        }

        public override int GetHashCode() {
            int hash = 17;

            unchecked {
                hash = (hash * 23) + Number.GetHashCode();
                hash = (hash * 23) + _db.GetHashCode();
            }

            return hash;
        }
        public override string ToString() {
            return DBGETForm();
        }

    }

}
