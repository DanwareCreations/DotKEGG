using System.Linq;
using System.Collections.Generic;

using Cell.Metabolism;

namespace Cell.Compartments {

    class Virus : ICompartment {

        protected HashSet<ICompartment> _compartments = new HashSet<ICompartment>();
        protected List<IBoundary> _boundaries = new List<IBoundary>();

        // CONSTRUCTORS
        public Virus() {
            _boundaries.Add(new Capsid());
        }

        // INTERFACE
        public IList<IBoundary> GetBoundaries() {
            return _boundaries.ToList();
        }
        public ISolution Solution { get; set; }
        public ICompartment[] GetCompartments() {
            return _compartments.ToArray();
        }
        public ICompartment Parent { get; set; }

        public void AddCompartment(ICompartment child) {
            _compartments.Add(child);
        }
    }

}
