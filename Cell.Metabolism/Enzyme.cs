using System;

namespace Cell.Metabolism {

    public class Enzyme : Protein {

        public Compound[] Cofactors { get; }
        public Reaction[] Reactions { get; }
        public float RateMultiplier(ISolution solution) {
            throw new NotImplementedException();
        }

    }

}
