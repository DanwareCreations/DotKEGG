using System.Collections.Generic;

namespace Cell.Compartments {

    class Eukaryote : ICompartment {
        // CONSTRUCTORS
        public Eukaryote() {
            Boundaries.Add(new PhospholipidBilayer("plasma membrane"));

            Solution = new Solution("cytosol");
        }

        // INTERFACE
        public IList<IBoundary> Boundaries { get; private set; } = new List<IBoundary>();
        public Solution Solution { get; private set; }
        public HashSet<IEntity> Entities { get; private set; } = new HashSet<IEntity>();
        public HashSet<ICompartment> Compartments { get; private set; } = new HashSet<ICompartment>();
        public ICompartment Parent { get; set; }
    }

}
