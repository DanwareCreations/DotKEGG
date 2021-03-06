﻿using System;

namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the GENOME database.
    /// </summary>
    /// <seealso cref="OrganismCode"/>
    /// <seealso cref="GenomeDb"/>
    /// <seealso cref="GenesDb"/>
    /// <seealso cref="GenomesDb"/>
    /// <seealso cref="KeggId"/>
    /// <seealso cref="KeggDb"/>
    /// <seealso cref="KeggCompositeDb"/>
    /// <inheritdoc/>
    public sealed class TNumber : KeggId {

        private OrganismCode _orgCode;

        /// <summary>
        /// Creates a new KEGG Genome identifier (a.k.a., TNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public TNumber(uint number) : base(GenomeDb.Instance, number) { }

        /// <summary>
        /// Returns the <see cref="OrganismCode"/> of the KEGG Organism that is associated with this genome.
        /// </summary>
        /// <returns>The <see cref="OrganismCode"/> of the KEGG Organism that is associated with this genome.</returns>
        public OrganismCode GetOrganismCode() {
            _orgCode = _orgCode ?? throw new NotImplementedException($"{nameof(GetOrganismCode)} is not yet implemented.");
            return _orgCode;
        }

    }

}
