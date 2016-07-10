using System.Collections.Generic;

namespace Cell.Compartments.Organelles {

    class SimpleCompartment : ICompartment {
        // CONSTRUCTORS
        public SimpleCompartment(string membraneName, string solnName) {
            // Define the inner Compartment
            Boundaries.Add(new PhospholipidBilayer(membraneName));

            Solution = new Solution(solnName);
        }

        // INTERFACE
        public IList<IBoundary> Boundaries { get; private set; } = new List<IBoundary>();
        public Solution Solution { get; private set; }
        public HashSet<IEntity> Entities { get; private set; } = new HashSet<IEntity>();
        public HashSet<ICompartment> Compartments { get; private set; } = new HashSet<ICompartment>();
        public ICompartment Parent { get; set; }
    }

}
