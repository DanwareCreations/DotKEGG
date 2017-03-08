using System;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Cell.Data {

    public class SQLiteConnectionFactory {

        private static IDictionary<DbWrapper, SQLiteConnection> _conns = new Dictionary<DbWrapper, SQLiteConnection>();

        public static void AddDatabase(DbWrapper db) {
            _conns.Add(db, null);
        }
        public static void RemoveDatabase(DbWrapper db) {
            _conns.Remove(db);
        }

        public static SQLiteConnection GetConnection(DbWrapper db) {
            // Make sure this connection string has already been added
            SQLiteConnection conn;
            bool exists = _conns.TryGetValue(db, out conn);
            if (!exists)
                throw new InvalidOperationException($"Provided SQLite connection string has not been associated with this ConnectionFactory!");

            // If so, then return the Connection associated with that database
            // If a Connection has not yet been defined, or was previously disposed, then create a new one first
            if (conn == null) {
                conn = new SQLiteConnection(db.ConnectionString);
                _conns[db] = conn;
                conn.Disposed += (sender, e) => _conns[db] = null;
            }
            return conn;
        }        
        public static void DisposeConnection(DbWrapper db) {
            // Make sure this connection string has already been added
            SQLiteConnection conn;
            bool exists = _conns.TryGetValue(db, out conn);
            if (!exists)
                throw new InvalidOperationException($"Provided SQLite connection string has not been associated with this ConnectionFactory!");

            // If so, then dispose of the associated Connection
            conn.Dispose();
        }

    }

}
