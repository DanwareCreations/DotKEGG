using System.Linq;
using System.Collections.Generic;

using Cell.Metabolism;

namespace Cell.Compartments {

    class Membrane : IBoundary {

        private HashSet<Compound> _compounds = new HashSet<Compound>();

        public Compound[] GetCompounds() {
            return _compounds.ToArray();
        }

    }

}
