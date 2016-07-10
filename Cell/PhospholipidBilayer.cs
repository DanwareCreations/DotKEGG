using System.Collections.Generic;

namespace Cell {

    class PhospholipidBilayer : IBoundary {
        // CONSTRUCTORS
        public PhospholipidBilayer(string name) {
            Name = name;
        }

        // INTERFACE
        public string Name { get; private set; }
        public IList<IEntity> LipidRafts { get; private set; } = new List<IEntity>();
    }

}
