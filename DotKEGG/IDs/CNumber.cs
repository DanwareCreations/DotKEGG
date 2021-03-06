﻿namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the COMPOUND database.
    /// </summary>
    /// <seealso cref="CompoundDb"/>
    /// <seealso cref="LigandDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class CNumber : KeggId {

        /// <summary>
        /// Creates a new KEGG Compound identifier (a.k.a., CNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public CNumber(uint number) : base(CompoundDb.Instance, number) { }

    }

}
