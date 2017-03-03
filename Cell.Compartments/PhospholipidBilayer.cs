using System.Linq;
using System.Collections.Generic;

using Cell.Metabolism;

namespace Cell.Compartments {

    class PhospholipidBilayer : IBoundary {

        private HashSet<ICompound> _compounds = new HashSet<ICompound>();

        public ICompound[] GetCompounds() {
            return _compounds.ToArray();
        }

    }

}
