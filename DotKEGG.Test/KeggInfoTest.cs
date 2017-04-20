using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", Description = "Checks that correct values are returned from the info operation")]
    internal class KeggInfoTest {

        private static string s_versionStr = "Release";
        private static string s_org = "Kanehisa Laboratories";
        private static uint s_minEntries = 500;

        [Test(Author = "Dan Vicarel", Description = "Checks that correct values are returned from the info operation for simple databases")]
        [TestCaseSource(nameof(SimpleDbTestCases))]
        [TestCaseSource(nameof(OrganismDbTestCases))]
        [TestCaseSource(nameof(OtherDbTestCase))]
        public void InfoSimpleDbTest(InfoResults info, string fullName, string name, string abbrev) {
            baseInfoTest(info, fullName, name, abbrev);

            Assert.AreEqual(1, info.NumEntries.Count);
            Assert.AreEqual(info.Name, info.NumEntries[0].Key);
            Assert.GreaterOrEqual(info.NumEntries[0].Value, s_minEntries);
        }

        [Test(Author = "Dan Vicarel", Description = "Checks that correct values are returned from the info operation for composite databases")]
        [TestCaseSource(nameof(CompositeDbTestCases))]
        public void InfoCompositeDbTest(InfoResults info, string fullName, string name, string abbrev) {
            baseInfoTest(info, fullName, name, abbrev);

            Assert.GreaterOrEqual(info.NumEntries.Count, 1);
            foreach (KeyValuePair<string, uint> pair in info.NumEntries) {
                Assert.AreNotEqual(info.Name, pair.Key);
                Assert.GreaterOrEqual(pair.Value, s_minEntries);
            }
        }

        public static IEnumerable<TestCaseData> CompositeDbTestCases() {
            yield return new TestCaseData(GenomesDb.Instance.Info(), "KEGG Genomes Database", "genomes", "gn");
            yield return new TestCaseData(LigandDb.Instance.Info(), "KEGG Ligand Database", "ligand", "ligand");
        }
        public static IEnumerable<TestCaseData> SimpleDbTestCases() {
            yield return new TestCaseData(PathwayDb.Instance.Info(), "KEGG Pathway Database", "pathway", "path");
            yield return new TestCaseData(BriteDb.Instance.Info(), "KEGG Brite Database", "brite", "br");
            yield return new TestCaseData(ModuleDb.Instance.Info(), "KEGG Module Database", "module", "md");
            yield return new TestCaseData(OrthologyDb.Instance.Info(), "KEGG Orthology Database", "orthology", "ko");
            yield return new TestCaseData(GenomeDb.Instance.Info(), "KEGG Genome Database", "genome", "genome");
            yield return new TestCaseData(CompoundDb.Instance.Info(), "KEGG Compound Database", "compound", "cpd");
            yield return new TestCaseData(GlycanDb.Instance.Info(), "KEGG Glycan Database", "glycan", "gl");
            yield return new TestCaseData(ReactionDb.Instance.Info(), "KEGG Reaction Database", "reaction", "rn");
            yield return new TestCaseData(ReactionClassDb.Instance.Info(), "KEGG Reaction Class Database", "rclass", "rc");
            yield return new TestCaseData(DiseaseDb.Instance.Info(), "KEGG Disease Database", "disease", "ds");
            yield return new TestCaseData(DrugDb.Instance.Info(), "KEGG Drug Database", "drug", "dr");
            yield return new TestCaseData(DrugGroupDb.Instance.Info(), "KEGG Drug Group Database", "dgroup", "dg");
            yield return new TestCaseData(EnvironDb.Instance.Info(), "KEGG Environ Database", "environ", "ev");
        }
        public static IEnumerable<TestCaseData> OrganismDbTestCases() {
            yield return new TestCaseData(GenomeDb.GeneInfo(new OrganismCode("hsa")), "Homo sapiens (human) KEGG Genes Database", "T01001", "hsa");
            yield return new TestCaseData(GenomeDb.GeneInfo(new OrganismCode("eco")), "Escherichia coli K-12 MG1655 KEGG Genes Database", "T00007", "eco");
            yield return new TestCaseData(GenomeDb.GeneInfo(new TNumber(01001)), "Homo sapiens (human) KEGG Genes Database", "T01001", "hsa");
            yield return new TestCaseData(GenomeDb.GeneInfo(new TNumber(00007)), "Escherichia coli K-12 MG1655 KEGG Genes Database", "T00007", "eco");
        }
        public static IEnumerable<TestCaseData> OtherDbTestCase() {
            yield return new TestCaseData(GenesDb.Instance.Info(), "KEGG Genes Database", "genes", "genes");
            yield return new TestCaseData(EnzymeDb.Instance.Info(), "KEGG Enzyme Database", "enzyme", "ec");
        }

        [Test(Author = "Dan Vicarel", Description = "Checks that the info operation fails for null/empty organism codes")]
        public void InfoNoOrganismCodeTest() {
            // Null strings should throw an Exception
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() =>
                GenomeDb.GeneInfo(new OrganismCode(nullStr)));
        }

        [Test(Author = "Dan Vicarel", Description = "Checks that the info operation fails for an invalid organism code")]
        public void InfoInvalidOrganismCodeTest() {
            Assert.Throws<ArgumentException>(() =>
                GenomeDb.GeneInfo(new OrganismCode("derp")));
        }

        [Test(Author = "Dan Vicarel", Description = "Checks that the info operation fails for null T numbers")]
        public void InfoNoTNumberTest() {
            TNumber nullT = null;
            Assert.Throws<ArgumentNullException>(() =>
                GenomeDb.GeneInfo(nullT));
        }

        [Test(Author = "Dan Vicarel", Description = "Checks that the info operation fails for an invalid T number")]
        public void InfoInvalidTNumberTest() {
            var t = new TNumber(uint.MaxValue);
            Assert.Throws<ArgumentException>(() =>
                GenomeDb.GeneInfo(t));
        }

        private static void baseInfoTest(InfoResults info, string fullName, string name, string abbrev) {
            Assert.AreEqual(info.FullName, fullName);
            Assert.AreEqual(info.Name, name);
            Assert.AreEqual(info.Abbreviation, abbrev);
            Assert.AreEqual(s_versionStr, info.Version.Substring(0, s_versionStr.Length));
            Assert.True(info.Organization.Contains(s_org), $"The database's organization did not contain the string \"{s_org}\"");
        }

    }

}
