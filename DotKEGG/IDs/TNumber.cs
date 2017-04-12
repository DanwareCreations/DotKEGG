using System;

namespace DotKEGG {

    /// <summary>
    /// Represents an identifier in the GENOME database.
    /// </summary>
    /// <inheritdoc/>
    public sealed class TNumber : KeggId {

        private OrganismCode _orgCode;

        /// <summary>
        /// Creates a new KEGG Genome identifier (a.k.a., TNumber) with the provided number.
        /// </summary>
        /// <param name="number">The identifier's 5-digit number.</param>
        public TNumber(uint number) {
            Number = number;
            _db = GenomeDb.Instance;
        }

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
