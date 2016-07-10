using System.Collections.Generic;

namespace Cell.Compartments {

    public interface ICompartment {
        IList<IBoundary> Boundaries { get; }
        Solution Solution { get; }
        HashSet<IEntity> Entities { get; }
        HashSet<ICompartment> Compartments { get; }
        ICompartment Parent { get; set; }
    }

}
