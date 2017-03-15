using System;

namespace DotKEGG {

    public abstract class KeggId : IEquatable<KeggId> {

        protected KeggDb _db;

        public uint Number { get; protected set; }
        
        public string ShortForm() {
            return $"{_db.Prefix}{Number}";
        }
        public string DBGETForm() {
            return $"{_db.Abbreviation}:{_db.Prefix}{Number}";
        }

        public override bool Equals(object obj) {
            KeggId kid = obj as KeggId;
            if (kid == null)
                return false;
            return (kid.Number == Number && kid._db == this._db);
        }
        public bool Equals(KeggId other) {
            return (other.Number == Number && other._db == this._db);
        }
        public static bool operator ==(KeggId left, KeggId right) {
            return (left.Number == right.Number && left._db == right._db);
        }
        public static bool operator !=(KeggId left, KeggId right) {
            return (left.Number != right.Number || left._db != right._db);
        }
        public override int GetHashCode() {
            int hash = 13;
            hash = (hash * 7) + Number.GetHashCode();
            hash = (hash * 7) + _db.GetHashCode();

            return hash;
        }
        public override string ToString() {
            return DBGETForm();
        }

    }

}
