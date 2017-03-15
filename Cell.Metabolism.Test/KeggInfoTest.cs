using System.Collections;

using DotKEGG;

using NUnit.Framework;

namespace Cell.Metabolism.Test {

    [TestFixture]
    public class KeggInfoTest {

        private static string _versionStr = "Release";
        private static string _org = "Kanehisa Laboratories";

        [Test]
        [TestCaseSource(nameof(ExplicitTestCases))]
        [TestCaseSource(nameof(EnumTestCases))]
        public void InfoTest(KeggDbInfo info, string title, string[] names) {
            Assert.AreEqual(info.Title, title);
            Assert.AreEqual(_versionStr, info.Version.Substring(0, _versionStr.Length));
            Assert.True(info.Organization.Contains(_org), $"The database's organization did not contain the string \"{_org}\"");
            Assert.GreaterOrEqual(info.NumEntries, 500);

            Assert.GreaterOrEqual(info.Names.Length, names.Length);
            foreach (string name in names)
                Assert.Contains(name, info.Names);
        }

        public static IEnumerable ExplicitTestCases {
            get {
                yield return new TestCaseData(
                    KeggInfo.Pathway(), "KEGG Pathway Database", new string[2] { "pathway", "path" });

                yield return new TestCaseData(
                    KeggInfo.Brite(), "KEGG Brite Database", new string[2] { "brite", "br" });

                yield return new TestCaseData(
                    KeggInfo.Module(), "KEGG Module Database", new string[2] { "module", "md" });

                yield return new TestCaseData(
                    KeggInfo.Orthology(), "KEGG Orthology Database", new string[2] { "orthology", "ko" });

                yield return new TestCaseData(
                    KeggInfo.Genome(), "KEGG Genome Database", new string[1] { "genome" });

                yield return new TestCaseData(
                    KeggInfo.Organism("hsa"), "Homo sapiens (human) KEGG Genes Database", new string[2] { "T01001", "hsa" });
                yield return new TestCaseData(
                    KeggInfo.Organism("eco"), "Escherichia coli K-12 MG1655 KEGG Genes Database", new string[2] { "T00007", "eco" });

                yield return new TestCaseData(
                    KeggInfo.Compound(), "KEGG Compound Database", new string[2] { "compound", "cpd" });

                yield return new TestCaseData(
                    KeggInfo.Glycan(), "KEGG Glycan Database", new string[2] { "glycan", "gl" });

                yield return new TestCaseData(
                    KeggInfo.Reaction(), "KEGG Reaction Database", new string[2] { "reaction", "rn" });

                yield return new TestCaseData(
                    KeggInfo.ReactionClass(), "KEGG Reaction Class Database", new string[2] { "rclass", "rc" });

                yield return new TestCaseData(
                    KeggInfo.Enzyme(), "KEGG Enzyme Database", new string[2] { "enzyme", "ec" });

                yield return new TestCaseData(
                    KeggInfo.Disease(), "KEGG Disease Database", new string[2] { "disease", "ds" });

                yield return new TestCaseData(
                    KeggInfo.Drug(), "KEGG Drug Database", new string[2] { "drug", "dr" });

                yield return new TestCaseData(
                    KeggInfo.DrugGroup(), "KEGG Drug Group Database", new string[2] { "dgroup", "dg" });

                yield return new TestCaseData(
                    KeggInfo.Environ(), "KEGG Environ Database", new string[2] { "environ", "ev" });

                yield return new TestCaseData(
                    KeggInfo.Genomes(), "KEGG Genomes Database", new string[2] { "genomes", "gn" });

                yield return new TestCaseData(
                    KeggInfo.Genes(), "KEGG Genes Database", new string[1] { "genes" });

                yield return new TestCaseData(
                    KeggInfo.Ligand(), "KEGG Ligand Database", new string[1] { "ligand" });

                yield return new TestCaseData(
                    KeggInfo.Kegg(), "Kyoto Encyclopedia of Genes and Genomes", new string[1] { "kegg" });
            }
        }

        public static IEnumerable EnumTestCases {
            get {
                yield return new TestCaseData(
                    KeggInfo.Database(Database.Pathway), "KEGG Pathway Database", new string[2] { "pathway", "path" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Brite), "KEGG Brite Database", new string[2] { "brite", "br" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Module), "KEGG Module Database", new string[2] { "module", "md" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Orthology), "KEGG Orthology Database", new string[2] { "orthology", "ko" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Genome), "KEGG Genome Database", new string[1] { "genome" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Compound), "KEGG Compound Database", new string[2] { "compound", "cpd" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Glycan), "KEGG Glycan Database", new string[2] { "glycan", "gl" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Reaction), "KEGG Reaction Database", new string[2] { "reaction", "rn" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.ReactionClass), "KEGG Reaction Class Database", new string[2] { "rclass", "rc" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Enzyme), "KEGG Enzyme Database", new string[2] { "enzyme", "ec" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Disease), "KEGG Disease Database", new string[2] { "disease", "ds" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Drug), "KEGG Drug Database", new string[2] { "drug", "dr" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.DrugGroup), "KEGG Drug Group Database", new string[2] { "dgroup", "dg" });

                yield return new TestCaseData(
                    KeggInfo.Database(Database.Environ), "KEGG Environ Database", new string[2] { "environ", "ev" });

                yield return new TestCaseData(
                    KeggInfo.CompositeDatabase(CompositeDb.Genomes), "KEGG Genomes Database", new string[2] { "genomes", "gn" });

                yield return new TestCaseData(
                    KeggInfo.CompositeDatabase(CompositeDb.Genes), "KEGG Genes Database", new string[1] { "genes" });

                yield return new TestCaseData(
                    KeggInfo.CompositeDatabase(CompositeDb.Ligand), "KEGG Ligand Database", new string[1] { "ligand" });
                
            }
        }

    }

}
