using System.Collections.Generic;

namespace Cell.Compartments.Organelles {

    class Mitochondrion : ICompartment {
        // CONSTRUCTORS
        public Mitochondrion() {
            // Define the inner Compartment
            SimpleCompartment inner = new SimpleCompartment("inner mitochondrial membrane", "matrix");

            // Define remaining properties
            Boundaries.Add(new PhospholipidBilayer("outer mitochondrial membrane"));
            Solution = new Solution("intermembrane space");
            Compartments.Add(inner);
            inner.Parent = this;
        }

        // INTERFACE
        public IList<IBoundary> Boundaries { get; private set; } = new List<IBoundary>();
        public Solution Solution { get; private set; }
        public HashSet<IEntity> Entities { get; private set; } = new HashSet<IEntity>();
        public HashSet<ICompartment> Compartments { get; private set; } = new HashSet<ICompartment>();
        public ICompartment Parent { get; set; }

    }

}
