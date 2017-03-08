using System;

namespace Cell.Data {
    
    public struct DbWrapper : IEquatable<DbWrapper> {
        public DbWrapper(string connectionString) {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString), $"You must provide a non-empty connection string for this {nameof(DbWrapper)}!");
            if (connectionString == string.Empty)
                throw new ArgumentException($"You must provide a non-empty connection string for this {nameof(DbWrapper)}!", nameof(connectionString));

            ConnectionString = connectionString;
        }
        public string ConnectionString { get; }

        public bool Equals(DbWrapper other) {
            return (other.ConnectionString == this.ConnectionString);
        }
        public override bool Equals(object obj) {
            if (obj is DbWrapper)
                return false;
            else {
                var that = (DbWrapper)obj;
                return (that.ConnectionString == this.ConnectionString);
            }
        }
        public override int GetHashCode() {
            return ConnectionString.GetHashCode();
        }
        public override string ToString() {
            return ConnectionString;
        }
    }
    
}
