using System.Collections;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf = typeof(KeggCompositeDb), Description = "Tests basic functionality of composite database classes")]
    internal class CompositeDbTest {

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggCompositeDb), Description = "Checks that all composite database Instances have appropriate values")]
        [TestCaseSource(nameof(CompositeDbInstanceTestCases))]
        public void CompositeDbInstanceTest(KeggCompositeDb db, string name, string abbrev) {
            Assert.AreEqual(name, db.Name);
            Assert.AreEqual(abbrev, db.Abbreviation);
            Assert.AreEqual(db.Name, db.ToString());
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggCompositeDb), Description = "Checks that all composite databases have unique HashCodes")]
        public void CompositeDbUniqueHashCodeTest() {
            var hashCodes = new List<int>(4) {
                 GenomesDb.Instance.GetHashCode(),
                 GenesDb.Instance.GetHashCode(),
                 LigandDb.Instance.GetHashCode(),
                 EnzymeDb.Instance.GetHashCode(),
            };
            Assert.AreEqual(hashCodes.Count, hashCodes.Distinct().Count(), $"There is at least one duplicate {nameof(KeggCompositeDb)} hash code!");
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggDb), Description = "Checks that all composite databases can return strongly typed KEGG ID objects")]
        public void CompositeDbGetStrongTypedEntriesTest() {
            // Create KEGG ID objects for each auxiliary database of each composite database
            TNumber t1 = GenomesDb.Genome(01001u);

            TNumber t2 = GenesDb.Genome(01001u);

            CNumber c = LigandDb.Compound(00031u);
            GNumber g = LigandDb.Glycan(00197u);
            RNumber r1 = LigandDb.Reaction(00259u);
            RCNumber rc = LigandDb.ReactionClass(00064u);
            ECNumber ec1 = LigandDb.Enzyme(ECNumber.Class.Hydrolase, 4u, 11u, 4u);

            ECNumber ec2 = EnzymeDb.Enzyme(ECNumber.Class.Hydrolase, 4u, 11u, 4u);
            RNumber r2 = EnzymeDb.Reaction(00259u);
            KNumber k = EnzymeDb.Orthology(00873u);

            // Assert that they're all non-null
            Assert.NotNull(t1);

            Assert.NotNull(t2);
            
            Assert.NotNull(c);
            Assert.NotNull(g);
            Assert.NotNull(r1);
            Assert.NotNull(rc);
            Assert.NotNull(ec1);

            Assert.NotNull(ec2);
            Assert.NotNull(r2);
            Assert.NotNull(k);
        }

        public static IEnumerable CompositeDbInstanceTestCases() {
            yield return new TestCaseData(
                GenomesDb.Instance, "genomes", "gn");

            yield return new TestCaseData(
                GenesDb.Instance, "genes", "genes");

            yield return new TestCaseData(
                LigandDb.Instance, "ligand", "ligand");

            yield return new TestCaseData(
                EnzymeDb.Instance, "enzyme", "ec");
        }

    }

}
