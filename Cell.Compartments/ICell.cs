using System.Collections.Generic;

using Cell.Metabolism;
using Cell.Compartments.Organelles;

namespace Cell.Compartments {

    public interface ICell {
        ISolution Cytosol { get; set; }

        IOrganelle[] GetOrganelles();
        IList<IBoundary> GetBoundaries();
        ICompartment[] GetCompartments();

        void AddOrganelle(IOrganelle child);
        void AddCompartment(ICompartment child);
    }

}
