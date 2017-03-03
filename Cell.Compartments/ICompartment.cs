using System.Collections.Generic;

namespace Cell.Compartments {

    public interface ICompartment {
        IList<IBoundary> GetBoundaries();
        ICompartment[] GetCompartments();
        ICompartment Parent { get; set; }

        void AddCompartment(ICompartment child);

    }

}
