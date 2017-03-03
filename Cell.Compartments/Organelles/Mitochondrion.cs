using Cell.Metabolism;

namespace Cell.Compartments.Organelles {

    class Mitochondrion : Organelle {

        // CONSTRUCTORS
        public Mitochondrion() {
            // Define the outer Membrane
            OuterMembrane = new PhospholipidBilayer();
            _boundaries.Add(OuterMembrane);

            // Define the inner Compartment
            IOrganelle inner = new Organelle();
            _compartments.Add(inner);
            inner.Parent = this;
        }

        public PhospholipidBilayer OuterMembrane { get; }
        public Solution InterMembraneSpace { get; set; }
        public Organelle InnerCompartment { get; }

    }

}
