﻿namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the DISEASE database.
    /// </summary>
    /// <seealso cref="DiseaseDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <inheritdoc/>
    public sealed class HNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Disease identifier (a.k.a., HNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public HNumber(uint number) : base(DiseaseDb.Instance, number) { }

    }

}
