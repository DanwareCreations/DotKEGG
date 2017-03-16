using System;
using System.Collections;

using DotKEGG;

using NUnit.Framework;

namespace Cell.Metabolism.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf =typeof(KeggInfo), Description = "Checks that correct values are returned from the info operation")]
    internal class KeggInfoTest {

        private static string _versionStr = "Release";
        private static string _org = "Kanehisa Laboratories";
        private static uint _minEntries = 500;

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that correct values are returned from the info operation for simple databases")]
        [TestCaseSource(nameof(SimpleDbTestCases))]
        [TestCaseSource(nameof(OrganismDbTestCases))]
        [TestCaseSource(nameof(GenesDbTestCase))]
        public void InfoSimpleDbTest(KeggDbInfo info, string fullName, string name, string abbrev) {
            baseInfoTest(info, fullName, name, abbrev);

            Assert.AreEqual(1, info.NumEntries.Count);
            Assert.AreEqual(info.Name, info.NumEntries[0].Key);
            Assert.GreaterOrEqual(info.NumEntries[0].Value, _minEntries);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that correct values are returned from the info operation for composite databases")]
        [TestCaseSource(nameof(CompositeDbTestCases))]
        [TestCaseSource(nameof(KeggDbTestCase))]
        public void InfoCompositeDbTest(KeggDbInfo info, string fullName, string name, string abbrev) {
            baseInfoTest(info, fullName, name, abbrev);

            Assert.GreaterOrEqual(info.NumEntries.Count, 1);
            foreach (var pair in info.NumEntries) {
                Assert.AreNotEqual(info.Name, pair.Key);
                Assert.GreaterOrEqual(pair.Value, _minEntries);
            }
        }

        public static IEnumerable CompositeDbTestCases {
            get {
                yield return new TestCaseData(
                    KeggInfo.CompositeDatabase(CompositeDb.Genomes), "KEGG Genomes Database", "genomes", "gn" );

                yield return new TestCaseData(
                    KeggInfo.CompositeDatabase(CompositeDb.Ligand), "KEGG Ligand Database",  "ligand", "ligand");
            }
        }
        public static IEnumerable SimpleDbTestCases {
            get {
                yield return new TestCaseData(
                    KeggInfo.Database(Database.Pathway), "KEGG Pathway Database",  "pathway", "path" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Brite), "KEGG Brite Database",  "brite", "br" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Module), "KEGG Module Database",  "module", "md" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Orthology), "KEGG Orthology Database",  "orthology", "ko" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Genome), "KEGG Genome Database",  "genome", "genome" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Compound), "KEGG Compound Database",  "compound", "cpd" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Glycan), "KEGG Glycan Database",  "glycan", "gl" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Reaction), "KEGG Reaction Database",  "reaction", "rn" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.ReactionClass), "KEGG Reaction Class Database",  "rclass", "rc" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Enzyme), "KEGG Enzyme Database",  "enzyme", "ec" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Disease), "KEGG Disease Database",  "disease", "ds" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Drug), "KEGG Drug Database",  "drug", "dr" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.DrugGroup), "KEGG Drug Group Database",  "dgroup", "dg" );

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Environ), "KEGG Environ Database",  "environ", "ev" );
                
            }
        }
        public static IEnumerable OrganismDbTestCases {
            get {
                yield return new TestCaseData(
                    KeggInfo.Organism("hsa"), "Homo sapiens (human) KEGG Genes Database", "T01001", "hsa" );

                yield return new TestCaseData(
                    KeggInfo.Organism("eco"), "Escherichia coli K-12 MG1655 KEGG Genes Database", "T00007", "eco" );
            }
        }
        public static IEnumerable KeggDbTestCase {
            get {
                var herp = new[] { new string('h', 'i') };
                yield return new TestCaseData(
                    KeggInfo.Kegg(), "Kyoto Encyclopedia of Genes and Genomes", "kegg", "kegg" );
            }
        }
        public static IEnumerable GenesDbTestCase {
            get {
                var herp = new[] { new string('h', 'i') };
                yield return new TestCaseData(
                    KeggInfo.CompositeDatabase(CompositeDb.Genes), "KEGG Genes Database", "genes", "genes");
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that the info operation fails for null/empty organism codes")]
        public void InfoNoOrganismCodeTest() {
            // Null strings should throw an Exception
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() =>
                KeggInfo.Organism(nullStr));

            // Empty strings should throw an Exception also
            Assert.Throws<ArgumentException>(() =>
                KeggInfo.Organism(string.Empty));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that the info operation fails for an invalid organism code")]
        public void InfoInvalidOrganismCodeTest() {
            Assert.Throws<ArgumentException>(() =>
                KeggInfo.Organism("derp"));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that the info operation fails for null T numbers")]
        public void InfoNoTNumberTest() {
            TNumber nullT = null;
            Assert.Throws<ArgumentNullException>(() =>
                KeggInfo.Organism(nullT));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggInfo), Description = "Checks that the info operation fails for an invalid T number")]
        public void InfoInvalidTNumberTest() {
            TNumber t = new TNumber(uint.MaxValue);
            Assert.Throws<ArgumentException>(() =>
                KeggInfo.Organism(t));
        }

        private static void baseInfoTest(KeggDbInfo info, string fullName, string name, string abbrev) {
            Assert.AreEqual(info.FullName, fullName);
            Assert.AreEqual(info.Name, name);
            Assert.AreEqual(info.Abbreviation, abbrev);
            Assert.AreEqual(_versionStr, info.Version.Substring(0, _versionStr.Length));
            Assert.True(info.Organization.Contains(_org), $"The database's organization did not contain the string \"{_org}\"");
        }

    }

}
