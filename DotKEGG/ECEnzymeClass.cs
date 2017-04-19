namespace DotKEGG {

    /// <summary>
    /// Specifies the Enzyme Commission class of an enzyme, i.e., the first number in its EC Number.
    /// </summary>
    /// <seealso cref="ECNumber"/>
    /// <seealso cref="EnzymeDb"/>
    public enum ECEnzymeClass {
        /// <summary>
        /// Catalyze oxidation/reduction reactions; transfer of H and O atoms or electrons from one substance to another.
        /// </summary>
        OxidoReductase = 1,

        /// <summary>
        /// Catalyze transfer of methyl-, acyl- amino-, or phosphate groups from one substance to another.
        /// </summary>
        Transferase = 2,

        /// <summary>
        /// Catalyze formation of two products from a substrate by hydrolysis.
        /// </summary>
        Hydrolase = 3,

        /// <summary>
        /// Catalyze non-hydrolytic addition or removal of groups from substrates.  C-C, C-N, C-O, or C-S bonds may be cleaved.
        /// </summary>
        Lyase = 4,

        /// <summary>
        /// Catalyze intramolecular rearrangements, i.e., isomerization changes within a single molecule.
        /// </summary>
        Isomerase = 5,

        /// <summary>
        /// Join together two molecules by synthesis of new C-O, C-S, C-N, or C-C bonds with simultaneous breakdown of ATP.
        /// </summary>
        Ligase = 6,
    }

}
