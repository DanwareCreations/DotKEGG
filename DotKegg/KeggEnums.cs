using System;

namespace DotKEGG {

    public enum Database {
        Pathway,
        Brite,
        Module,
        Orthology,
        Genome,
        Compound,
        Glycan,
        Reaction,
        ReactionClass,
        Enzyme,
        Disease,
        Drug,
        DrugGroup,
        Environ,
    }
    public enum CompositeDb {
        Genes,
        Genomes,
        Ligand,
    }

    public enum GetOption {
        None,
        AaSeq,
        NtSeq,
        Mol,
        Kcf,
        Image,
        Kgml,
    }

    public enum OutsideGeneDb {
        NcbiProtein,
        NcbiGene,
        UniProt,
    }
    public enum OutsideChemDb {
        PubChem,
        ChEBI,
    }

    internal static class StringFrom {

        public static string Enum(Database db) {
            switch (db) {
                case Database.Pathway:
                    return DbStrings.Pathway;

                case Database.Brite:
                    return DbStrings.Brite;

                case Database.Module:
                    return DbStrings.Module;

                case Database.Orthology:
                    return DbStrings.Orthology;

                case Database.Genome:
                    return DbStrings.Genome;

                case Database.Compound:
                    return DbStrings.Compound;

                case Database.Glycan:
                    return DbStrings.Glycan;

                case Database.Reaction:
                    return DbStrings.Reaction;

                case Database.ReactionClass:
                    return DbStrings.ReactionClass;

                case Database.Enzyme:
                    return DbStrings.Enzyme;

                case Database.Disease:
                    return DbStrings.Disease;

                case Database.Drug:
                    return DbStrings.Drug;

                case Database.DrugGroup:
                    return DbStrings.DrugGroup;

                case Database.Environ:
                    return DbStrings.Environ;

                default:
                    throw new ArgumentOutOfRangeException(nameof(db), db, $"Could not find a string matching {nameof(Database)} enum value {db}");
            }
        }
        public static string Enum(CompositeDb db) {
            switch (db) {
                case CompositeDb.Genes:
                    return CompositeDbStrings.Genes;

                case CompositeDb.Genomes:
                    return CompositeDbStrings.Genomes;

                case CompositeDb.Ligand:
                    return CompositeDbStrings.Ligand;

                default:
                    throw new ArgumentOutOfRangeException(nameof(db), db, $"Could not find a string matching {nameof(CompositeDb)} enum value {db}");
            }
        }

        public static string Enum(GetOption option) {
            switch (option) {
                case GetOption.None:
                    return "none";

                case GetOption.AaSeq:
                    return "aaseq";

                case GetOption.NtSeq:
                    return "ntseq";

                case GetOption.Mol:
                    return "mol";

                case GetOption.Kcf:
                    return "kcf";

                case GetOption.Image:
                    return "image";

                case GetOption.Kgml:
                    return "kgml";

                default:
                    throw new ArgumentOutOfRangeException(nameof(option), option, $"Could not find a string matching {nameof(GetOption)} enum value {option}");
            }
        }
        public static string Enum(OutsideGeneDb geneDb) {
            switch (geneDb) {
                case OutsideGeneDb.NcbiProtein:
                    return "ncbi-proteinid";

                case OutsideGeneDb.NcbiGene:
                    return "ncbi-geneid";

                case OutsideGeneDb.UniProt:
                    return "uniprot";

                default:
                    throw new ArgumentOutOfRangeException(nameof(geneDb), geneDb, $"Could not find a string matching {nameof(OutsideGeneDb)} enum value {geneDb}");
            }
        }
        public static string Enum(OutsideChemDb chemDb) {
            switch (chemDb) {
                case OutsideChemDb.PubChem:
                    return "pubchem";

                case OutsideChemDb.ChEBI:
                    return "chebi";

                default:
                    throw new ArgumentOutOfRangeException(nameof(chemDb), chemDb, $"Could not find a string matching {nameof(OutsideChemDb)} enum value {chemDb}");
            }
        }

    }

}
