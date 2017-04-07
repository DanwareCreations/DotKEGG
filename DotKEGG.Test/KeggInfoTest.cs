using System;
using System.Collections;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf =typeof(KeggInfo), Description = "Checks that correct values are returned from the info operation")]
    internal class KeggInfoTest {

        private static string _versionStr = "Release";
        private static string _org = "Kanehisa Laboratories";
        private static uint _minEntries = 500;

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that correct values are returned from the info operation for simple databases")]
        [TestCaseSource(nameof(SimpleDbTestCases))]
        [TestCaseSource(nameof(OrganismDbTestCases))]
        [TestCaseSource(nameof(OtherDbTestCase))]
        public void InfoSimpleDbTest(InfoResults info, string fullName, string name, string abbrev) {
            baseInfoTest(info, fullName, name, abbrev);

            Assert.AreEqual(1, info.NumEntries.Count);
            Assert.AreEqual(info.Name, info.NumEntries[0].Key);
            Assert.GreaterOrEqual(info.NumEntries[0].Value, _minEntries);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that correct values are returned from the info operation for composite databases")]
        [TestCaseSource(nameof(CompositeDbTestCases))]
        [TestCaseSource(nameof(KeggDbTestCase))]
        public void InfoCompositeDbTest(InfoResults info, string fullName, string name, string abbrev) {
            baseInfoTest(info, fullName, name, abbrev);

            Assert.GreaterOrEqual(info.NumEntries.Count, 1);
            foreach (var pair in info.NumEntries) {
                Assert.AreNotEqual(info.Name, pair.Key);
                Assert.GreaterOrEqual(pair.Value, _minEntries);
            }
        }

        public static IEnumerable CompositeDbTestCases() {
            yield return new TestCaseData(
                KeggInfo.ForDatabase(GenomesDb.Instance), "KEGG Genomes Database", "genomes", "gn");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(LigandDb.Instance), "KEGG Ligand Database", "ligand", "ligand");
        }
        public static IEnumerable SimpleDbTestCases() {
            yield return new TestCaseData(
                KeggInfo.ForDatabase(PathwayDb.Instance), "KEGG Pathway Database", "pathway", "path");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(BriteDb.Instance), "KEGG Brite Database", "brite", "br");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(ModuleDb.Instance), "KEGG Module Database", "module", "md");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(OrthologyDb.Instance), "KEGG Orthology Database", "orthology", "ko");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(GenomeDb.Instance), "KEGG Genome Database", "genome", "genome");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(CompoundDb.Instance), "KEGG Compound Database", "compound", "cpd");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(GlycanDb.Instance), "KEGG Glycan Database", "glycan", "gl");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(ReactionDb.Instance), "KEGG Reaction Database", "reaction", "rn");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(ReactionClassDb.Instance), "KEGG Reaction Class Database", "rclass", "rc");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(DiseaseDb.Instance), "KEGG Disease Database", "disease", "ds");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(DrugDb.Instance), "KEGG Drug Database", "drug", "dr");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(DrugGroupDb.Instance), "KEGG Drug Group Database", "dgroup", "dg");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(EnvironDb.Instance), "KEGG Environ Database", "environ", "ev");
        }
        public static IEnumerable OrganismDbTestCases() {
            yield return new TestCaseData(
                KeggInfo.ForOrganism("hsa"), "Homo sapiens (human) KEGG Genes Database", "T01001", "hsa");

            yield return new TestCaseData(
                KeggInfo.ForOrganism("eco"), "Escherichia coli K-12 MG1655 KEGG Genes Database", "T00007", "eco");

            yield return new TestCaseData(
                KeggInfo.ForOrganism(new TNumber(01001)), "Homo sapiens (human) KEGG Genes Database", "T01001", "hsa");

            yield return new TestCaseData(
                KeggInfo.ForOrganism(new TNumber(00007)), "Escherichia coli K-12 MG1655 KEGG Genes Database", "T00007", "eco");
        }
        public static IEnumerable KeggDbTestCase() {
            var herp = new[] { new string('h', 'i') };
            yield return new TestCaseData(
                KeggInfo.ForKegg(), "Kyoto Encyclopedia of Genes and Genomes", "kegg", "kegg" );
        }
        public static IEnumerable OtherDbTestCase() {
            var herp = new[] { new string('h', 'i') };
            yield return new TestCaseData(
                KeggInfo.ForDatabase(GenesDb.Instance), "KEGG Genes Database", "genes", "genes");

            yield return new TestCaseData(
                KeggInfo.ForDatabase(EnzymeDb.Instance), "KEGG Enzyme Database", "enzyme", "ec");
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that the info operation fails for null/empty organism codes")]
        public void InfoNoOrganismCodeTest() {
            // Null strings should throw an Exception
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() =>
                KeggInfo.ForOrganism(nullStr));

            // Empty strings should throw an Exception also
            Assert.Throws<ArgumentException>(() =>
                KeggInfo.ForOrganism(string.Empty));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that the info operation fails for an invalid organism code")]
        public void InfoInvalidOrganismCodeTest() {
            Assert.Throws<ArgumentException>(() =>
                KeggInfo.ForOrganism("derp"));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that the info operation fails for null T numbers")]
        public void InfoNoTNumberTest() {
            TNumber nullT = null;
            Assert.Throws<ArgumentNullException>(() =>
                KeggInfo.ForOrganism(nullT));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that the info operation fails for an invalid T number")]
        public void InfoInvalidTNumberTest() {
            TNumber t = new TNumber(uint.MaxValue);
            Assert.Throws<ArgumentException>(() =>
                KeggInfo.ForOrganism(t));
        }

        private static void baseInfoTest(InfoResults info, string fullName, string name, string abbrev) {
            Assert.AreEqual(info.FullName, fullName);
            Assert.AreEqual(info.Name, name);
            Assert.AreEqual(info.Abbreviation, abbrev);
            Assert.AreEqual(_versionStr, info.Version.Substring(0, _versionStr.Length));
            Assert.True(info.Organization.Contains(_org), $"The database's organization did not contain the string \"{_org}\"");
        }

    }

}
