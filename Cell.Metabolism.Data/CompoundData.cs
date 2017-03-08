using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

using Cell.Data;

namespace Cell.Metabolism.Data {

    public class CompoundData : EntityData {
        private CompoundData() { }

        public string[] Names { get; protected set; }
        public double MolarMass { get; protected set; }

        public static CompoundData Load(string name) {
            CompoundData data = null;

            SQLiteConnection conn = SQLiteConnectionFactory.GetConnection(Database);
            using (var comm = conn.CreateCommand()) {
                // Create SQLite command
                comm.CommandType = CommandType.Text;
                comm.CommandText = $@"
                    SELECT * FROM compounds
                    WHERE Names LIKE @CompoundName
                ";
                comm.Parameters.AddWithValue("@CompoundName", $"%{name}%");

                // Return the record returned by the command
                using (SQLiteDataReader reader = comm.ExecuteReader(CommandBehavior.SingleResult & CommandBehavior.SingleRow)) {
                    reader.Read();
                    data = doLoad(reader);
                }
            }

            return data;
        }
        public static IEnumerable<CompoundData> LoadAll() {

            SQLiteConnection conn = SQLiteConnectionFactory.GetConnection(Database);
            using (var comm = conn.CreateCommand()) {
                // Create SQLite command
                comm.CommandType = CommandType.Text;
                comm.CommandText = $@"
                    SELECT * FROM compounds
                ";
                
                // Enumerate the records returned by the command
                using (SQLiteDataReader reader = comm.ExecuteReader(CommandBehavior.SingleResult)) {
                    while (reader.Read())
                        yield return doLoad(reader);
                }
            }
        }

        private static CompoundData doLoad(SQLiteDataReader reader) {
            return new CompoundData() {
                ID = Convert.ToInt32(reader["ID"]),
                Names = reader["Names"].ToString().Split('\t'),
                MolarMass = Convert.ToDouble(reader["MolarMass"]),
            };
        }

    }

}
