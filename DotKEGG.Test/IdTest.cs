using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf = typeof(KeggId), Description = "Tests basic functionality of ID classes")]
    internal class IdTest {

        private static MapNumber s_path = new MapNumber(00010u);
        private static BRNumber s_brite = new BRNumber(08303u);
        private static MNumber s_module = new MNumber(00010u);
        private static KNumber s_ortho = new KNumber(00873u);
        private static TNumber s_genome = new TNumber(01001u);
        private static CNumber s_compound = new CNumber(00031u);
        private static GNumber s_glycan = new GNumber(00197u);
        private static RNumber s_rxn = new RNumber(00259u);
        private static RCNumber s_rclass = new RCNumber(00064u);
        private static HNumber s_disease = new HNumber(00118u);
        private static DNumber s_drug = new DNumber(01441u);
        private static DGNumber s_dgroup = new DGNumber(01918u);
        private static ENumber s_environ = new ENumber(00270u);

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggId), Description = "Checks that ID Instances have appropriate values")]
        [TestCaseSource(nameof(idInstanceTestCases))]
        public void IdInstanceTest(KeggId kid, uint number, string shortForm, string dbgetForm, KeggDb db) {
            Assert.AreEqual(number, kid.Number);
            Assert.AreEqual(shortForm, kid.ShortForm());
            Assert.AreEqual(dbgetForm, kid.DBGETForm());
            Assert.AreEqual(dbgetForm, kid.ToString());
            Assert.AreEqual(db, kid.Database);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggId), Description = "Checks that ID Instances can be compared for equality.")]
        public void IdEqualityTest() {
            KeggId a = s_brite;
            KeggId b = s_brite;

            Assert.True(a.Equals(b));
            Assert.True(b.Equals(a));
            Assert.True(a == b);
            Assert.False(a != b);
            Assert.True(Equals(a, b));

            object objA = a;
            object objB = b;
            Assert.True(objA.Equals(b));
            Assert.True(b.Equals(objA));
            Assert.True(Equals(objA, b));
            Assert.True(objB.Equals(a));
            Assert.True(a.Equals(objB));
            Assert.True(Equals(objB, a));
            Assert.True(objB.Equals(objA));
            Assert.True(objA.Equals(objB));
            Assert.True(Equals(objB, objA));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggId), Description = "Checks that ID Instances can be compared for inequality.")]
        public void IdInequalityTest() {
            KeggId a = s_brite;
            KeggId b = s_glycan;

            Assert.False(a.Equals(b));
            Assert.False(b.Equals(a));
            Assert.False(a == b);
            Assert.True(a != b);
            Assert.False(Equals(a, b));

            object objA = a;
            object objB = b;
            Assert.False(objA.Equals(b));
            Assert.False(b.Equals(objA));
            Assert.False(Equals(objA, b));
            Assert.False(objB.Equals(a));
            Assert.False(a.Equals(objB));
            Assert.False(Equals(objB, a));
            Assert.False(objB.Equals(objA));
            Assert.False(objA.Equals(objB));
            Assert.False(Equals(objB, objA));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggId), Description = "Checks that ID Instances are not equal to null.")]
        public void IdNullInequalityTest() {
            KeggId a = s_disease;

            Assert.False(a.Equals(null));
            Assert.False(a == null);
            Assert.True(a != null);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggId), Description = "Checks that all IDs have unique HashCodes")]
        public void IdUniqueHashCodeTest() {
            int[] hashCodes = new int[13] {
                 s_path.GetHashCode(),
                 s_brite.GetHashCode(),
                 s_module.GetHashCode(),
                 s_ortho.GetHashCode(),
                 s_genome.GetHashCode(),
                 s_compound.GetHashCode(),
                 s_glycan.GetHashCode(),
                 s_rxn.GetHashCode(),
                 s_rclass.GetHashCode(),
                 s_drug.GetHashCode(),
                 s_dgroup.GetHashCode(),
                 s_disease.GetHashCode(),
                 s_environ.GetHashCode(),
            };
            Assert.AreEqual(hashCodes.Length, hashCodes.Distinct().Count(), $"There is at least one duplicate {nameof(KeggId)} hash code!");
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggId), Description = "Checks that we can get the organism code associated with a genome")]
        [Ignore("The GetOrganismCode() function has not been implemented yet.")]
        public void GetOrganismCodeTest() {
            OrganismCode code = s_genome.GetOrganismCode();
            Assert.AreEqual("hsa", code.Code);
        }

        private static IEnumerable<TestCaseData> idInstanceTestCases() {
            yield return new TestCaseData(s_path, 00010u, "map00010", "path:map00010", PathwayDb.Instance);
            yield return new TestCaseData(s_brite, 08303u, "BR08303", "br:BR08303", BriteDb.Instance);
            yield return new TestCaseData(s_module, 00010u, "M00010", "md:M00010", ModuleDb.Instance);
            yield return new TestCaseData(s_ortho, 00873u, "K00873", "ko:K00873", OrthologyDb.Instance);
            yield return new TestCaseData(s_genome, 01001u, "T01001", "genome:T01001", GenomeDb.Instance);
            yield return new TestCaseData(s_compound, 00031u, "C00031", "cpd:C00031", CompoundDb.Instance);
            yield return new TestCaseData(s_glycan, 00197u, "G00197", "gl:G00197", GlycanDb.Instance);
            yield return new TestCaseData(s_rxn, 00259u, "R00259", "rn:R00259", ReactionDb.Instance);
            yield return new TestCaseData(s_rclass, 00064u, "RC00064", "rc:RC00064", ReactionClassDb.Instance);
            yield return new TestCaseData(s_disease, 00118u, "H00118", "ds:H00118", DiseaseDb.Instance);
            yield return new TestCaseData(s_drug, 01441u, "D01441", "dr:D01441", DrugDb.Instance);
            yield return new TestCaseData(s_dgroup, 01918u, "DG01918", "dg:DG01918", DrugGroupDb.Instance);
            yield return new TestCaseData(s_environ, 00270u, "E00270", "ev:E00270", EnvironDb.Instance);
        }

    }

}
