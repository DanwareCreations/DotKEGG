using System;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public interface ISolution : ICloneable {

        void Add(ICompound compound,  Concentration concentration);
        void Remove(ICompound compound);
        Concentration this[ICompound compound] { get; set; }
        ICollection<ICompound> ListCompounds();

        Temperature Temperature { get; set; }
        float pH { get; set; }

    }

}
