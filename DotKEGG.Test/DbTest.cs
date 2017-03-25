using System.Collections;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf = typeof(KeggDb), Description = "Tests basic functionality of database classes")]
    internal class DbTest {

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggDb), Description = "Checks that all database Instances have appropriate values")]
        [TestCaseSource(nameof(DbInstanceTestCases))]
        public void DbInstanceTest(KeggDb db, string name, string abbrev, string prefix, uint entryNum) {
            Assert.AreEqual(name, db.Name);
            Assert.AreEqual(abbrev, db.Abbreviation);
            Assert.AreEqual(prefix, db.Prefix);
            Assert.AreEqual(db.Name, db.ToString());
            Assert.NotNull(db.Entry(entryNum));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggDb), Description = "Checks that all databases have unique HashCodes")]
        public void DbUniqueHashCodeTest() {
            var hashCodes = new List<int>(13) {
                 PathwayDb.Instance.GetHashCode(),
                 BriteDb.Instance.GetHashCode(),
                 ModuleDb.Instance.GetHashCode(),
                 OrthologyDb.Instance.GetHashCode(),
                 GenomeDb.Instance.GetHashCode(),
                 CompoundDb.Instance.GetHashCode(),
                 GlycanDb.Instance.GetHashCode(),
                 ReactionDb.Instance.GetHashCode(),
                 ReactionClassDb.Instance.GetHashCode(),
                 DrugDb.Instance.GetHashCode(),
                 DrugGroupDb.Instance.GetHashCode(),
                 DiseaseDb.Instance.GetHashCode(),
                 EnvironDb.Instance.GetHashCode(),
            };
            Assert.AreEqual(hashCodes.Count, hashCodes.Distinct().Count(), $"There is at least one duplicate {nameof(KeggDb)} hash code!");
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggDb), Description = "Checks that all databases can return strongly typed KEGG ID objects")]
        public void DbGetStrongTypedEntriesTest() {
            MapNumber map = PathwayDb.Pathway(00010u);
            BRNumber br = BriteDb.BriteHierarchy(08303u);
            MNumber m = ModuleDb.Module(00010u);
            KNumber k = OrthologyDb.Orthology(00873u);
            TNumber t = GenomeDb.Genome(01001u);
            CNumber c = CompoundDb.Compound(00031u);
            GNumber g = GlycanDb.Glycan(00197u);
            RNumber r = ReactionDb.Reaction(00259u);
            RCNumber rc = ReactionClassDb.ReactionClass(00064u);
            HNumber h = DiseaseDb.Disease(00118u);
            DNumber d = DrugDb.Drug(01441u);
            DGNumber dg = DrugGroupDb.DrugGroup(01918u);
            ENumber e = EnvironDb.Environ(00270u);
            
            Assert.NotNull(map);
            Assert.NotNull(br);
            Assert.NotNull(m);
            Assert.NotNull(k);
            Assert.NotNull(t);
            Assert.NotNull(c);
            Assert.NotNull(g);
            Assert.NotNull(r);
            Assert.NotNull(rc);
            Assert.NotNull(h);
            Assert.NotNull(d);
            Assert.NotNull(dg);
            Assert.NotNull(e);
        }

        public static IEnumerable DbInstanceTestCases() {
            yield return new TestCaseData(
                PathwayDb.Instance, "pathway", "path", "map", 00010u);

            yield return new TestCaseData(
                BriteDb.Instance, "brite", "br", "BR", 08303u);

            yield return new TestCaseData(
                ModuleDb.Instance, "module", "md", "M", 00010u);

            yield return new TestCaseData(
                OrthologyDb.Instance, "orthology", "ko", "K", 00873u);

            yield return new TestCaseData(
                GenomeDb.Instance, "genome", "genome", "T", 01001u);

            yield return new TestCaseData(
                CompoundDb.Instance, "compound", "cpd", "C", 00031u);

            yield return new TestCaseData(
                GlycanDb.Instance, "glycan", "gl", "G", 00197u);

            yield return new TestCaseData(
                ReactionDb.Instance, "reaction", "rn", "R", 00259u);

            yield return new TestCaseData(
                ReactionClassDb.Instance, "rclass", "rc", "RC", 00064u);

            yield return new TestCaseData(
                DiseaseDb.Instance, "disease", "ds", "H", 00118u);

            yield return new TestCaseData(
                DrugDb.Instance, "drug", "dr", "D", 01441u);

            yield return new TestCaseData(
                DrugGroupDb.Instance, "dgroup", "dg", "DG", 01918u);

            yield return new TestCaseData(
                EnvironDb.Instance, "environ", "ev", "E", 00270u);
        }

    }

}
