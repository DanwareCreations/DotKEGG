using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Cell.Data;
using Cell.Metabolism.Data;

using NUnit.Framework;

namespace Cell.Metabolism.Test {

    [TestFixture]
    public class CompoundTest {

        [OneTimeSetUp]
        public void SetUp() {
            // Create a wrapper for the Metabolism SQLite database
            string asmPath = Assembly.GetAssembly(typeof(EntityData)).Location;
            string asmDir = Path.GetDirectoryName(asmPath);
            DbWrapper cellDB = new DbWrapper($@"Data Source={asmDir}\metabolism.db;Version=3;");

            // Add it to the connection factory
            EntityData.Database = cellDB;
            SQLiteConnectionFactory.AddDatabase(cellDB);
            SQLiteConnectionFactory.GetConnection(cellDB).Open();
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(Compound), Description = "Loads a single, valid Compound")]
        public void Load() {
            Compound glucose = Compound.Load("glucose");

            Assert.NotNull(glucose);
            Assert.AreEqual(180.16, glucose.MolarMass);
            Assert.Contains("dextrose", glucose.Names);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(Compound), Description = "Loads all Compounds in the database")]
        public void LoadAll() {
            IEnumerable<Compound> compounds = Compound.LoadAll();
            var derp = compounds.ToArray();

            Assert.Greater(compounds.Count(), 1);
        }

    }

}
