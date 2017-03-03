using System;
using System.Linq;
using System.Collections.Generic;

namespace Cell.Compartments.Organelles {

    public class Organelle : IOrganelle {

        protected HashSet<ICompartment> _compartments = new HashSet<ICompartment>();
        protected List<IBoundary> _boundaries = new List<IBoundary>();

        // INTERFACE
        public IList<IBoundary> GetBoundaries() {
            return _boundaries.ToList();
        }
        public ICompartment[] GetCompartments() {
            return _compartments.ToArray();
        }
        public ICompartment Parent { get; set; }
        public void AddCompartment(ICompartment child) {
            _compartments.Add(child);
        }

    }

}
