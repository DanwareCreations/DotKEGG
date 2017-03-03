using System;
using System.Linq;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public class Metabolism {

        public static float MinMetaboliteConcentration { get; set; } = 0.0001f;
        public static float MinProteinConcentration { get; set; } = 0.0001f;

        public static void Run(ISolution solution) {
            // Associate all current Enzymes with their current reaction velocity
            // Only keep Enzymes with non-zero concentrations
            IDictionary<IEnzyme, float> enzymeVels = solution.ListCompounds()
                                                             .Select(c => c as IEnzyme)
                                                             .Where(e => e != null && solution.ConcentrationOf(e) > Concentration.Zero)
                                                             .ToDictionary(e => e, e => e.VelocityIn(solution));

            // Run metabolism for the duration of one reaction cycle of the slowest enzyme
            float minVel = enzymeVels.Min(pair => pair.Value);
            float duration = 1f / minVel;
            foreach (IEnzyme enzyme in enzymeVels.Keys)
                runEnzyme(solution, enzyme, enzymeVels[enzyme], duration);
        }
        private static void runEnzyme(ISolution soln, IEnzyme enzyme, float velocity, float duration) {
            int reacDir = (velocity > 0 ? -1 : 1);
            int prodDir = (velocity < 0 ? -1 : 1);

            // For each reaction that the enzyme can catalyze,
            // Adjust reactant/product concentrations depending on the current reaction direction
            foreach (IReaction rxn in enzyme.Reactions) {
                ICompound[] reactants = rxn.GetReactants();
                foreach (ICompound r in reactants) {
                    float delta = reacDir * rxn.StoichiometryOf(r) * velocity * duration;
                    changeConcentration(soln, r, delta);
                }

                ICompound[] products = rxn.GetProducts();
                foreach (ICompound p in products) {
                    float delta = prodDir * rxn.StoichiometryOf(p) * velocity * duration;
                    changeConcentration(soln, p, delta);
                }
            }
        }
        private static void changeConcentration(ISolution soln, ICompound compound, float delta) {
            Concentration old;
            bool exists = soln.TryGetConcentration(compound, out old);

            // New compound concentrations are just set equal to the delta
            if (!exists && delta > 0)
                soln.Add(compound, new Concentration(delta));

            // Increment existing compound concentrations by the delta
            else if (exists && delta > 0f)
                soln.ConcentrationOf(compound).Change(delta);

            // Decrement existing compound concentrations by the delta
            // If the new concentration is below the minimum, then set it to zero
            else if (exists && delta < 0f) {
                float minVal = (compound is IProtein ? MinProteinConcentration : MinMetaboliteConcentration);
                if (old.Value + delta < minVal)
                    old.SetToZero();
                else
                    old.Change(delta);
            }
        }

    }

}
