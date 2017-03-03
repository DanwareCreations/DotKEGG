using System;
using System.Linq;
using System.Collections.Generic;

using Cell.Compartments.Organelles;
using Cell.Metabolism;

namespace Cell.Compartments {

    class Cell : ICell, ICompartment {
        
        protected HashSet<ICompartment> _compartments = new HashSet<ICompartment>();
        protected HashSet<IOrganelle> _organelles = new HashSet<IOrganelle>();
        protected List<IBoundary> _boundaries = new List<IBoundary>();

        // CONSTRUCTORS
        public Cell() {
            PlasmaMembrane = new PhospholipidBilayer();
            _boundaries.Add(PlasmaMembrane);
        }

        // INTERFACE
        public PhospholipidBilayer PlasmaMembrane { get; }
        public ISolution Cytosol { get; set; }
        public ICompartment Parent {
            get { return null; }
            set { throw new InvalidOperationException("Cells cannot have parent Compartments!"); }
        }

        public IList<IBoundary> GetBoundaries() {
            return _boundaries.ToList();
        }
        public ICompartment[] GetCompartments() {
            return _compartments.ToArray();
        }
        public IOrganelle[] GetOrganelles() {
            return _organelles.ToArray();
        }

        public void AddCompartment(ICompartment child) {
            _compartments.Add(child);
            child.Parent = this;
        }
        public void AddOrganelle(IOrganelle child) {
            _organelles.Add(child);
            child.Parent = this;
        }
    }

}
