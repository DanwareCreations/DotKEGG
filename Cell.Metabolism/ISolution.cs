using System.Collections.Generic;

namespace Cell.Metabolism {

    public interface ISolution {

        void Add(ICompound compound,  Concentration concentration);
        void Remove(ICompound compound);
        bool Contains(ICompound compound);
        Concentration ConcentrationOf(ICompound compound);
        bool TryGetConcentration(ICompound compound, out Concentration concentration);
        bool TryGetConcentration(ICompound compound, out float concentration);
        ICollection<ICompound> ListCompounds();

        Temperature Temperature { get; set; }
        float pH { get; set; }

    }

}
