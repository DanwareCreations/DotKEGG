using System;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public interface ISolution : ICloneable {

        void Add(Compound compound,  Concentration concentration);
        void Remove(Compound compound);
        Concentration this[Compound compound] { get; set; }
        ICollection<Compound> ListCompounds();

        Temperature Temperature { get; set; }
        float pH { get; set; }

    }

}
