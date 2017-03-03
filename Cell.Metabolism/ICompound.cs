using System;

namespace Cell.Metabolism {

    public interface ICompound {

        Guid Id { get; }
        string[] Names { get; }

    }

}
