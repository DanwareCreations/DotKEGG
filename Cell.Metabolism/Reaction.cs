using System;

namespace Cell.Metabolism {

    public class Reaction {

        public Compound[] GetReactants() {
            throw new NotImplementedException();
        }
        public Compound[] GetProducts() {
            throw new NotImplementedException();
        }

        public uint StoichiometryOf(Compound compound) {
            throw new NotImplementedException();
        }
        public float EquilibriumConstant(Temperature temperature) {
            throw new NotImplementedException();
        }
        public float ReactionQuotient(ISolution solution) {
            throw new NotImplementedException();
        }

    }

}
