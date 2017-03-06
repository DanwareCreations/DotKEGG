using System.Linq;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public class Metabolism {

        public static float MinMetaboliteConcentration { get; set; } = 0.0001f;
        public static float MinProteinConcentration { get; set; } = 0.0001f;

        public static ISolution Run(ISolution solution) {
            ISolution newSoln = solution.Clone() as ISolution;

            // Associate all current Enzymes with their current reaction velocity
            // Only keep Enzymes with non-zero concentrations
            IDictionary<IEnzyme, float> enzymeMults = solution.ListCompounds()
                                                             .Select(c => c as IEnzyme)
                                                             .Where(e => e != null && solution[e] > Concentration.Zero)
                                                             .ToDictionary(e => e, e => e.RateMultiplier(solution));

            // Run metabolism for the duration of one reaction cycle of the slowest enzyme
            float minVel = enzymeMults.Min(pair => pair.Value);
            float duration = 1f / minVel;
            foreach (IEnzyme enzyme in enzymeMults.Keys)
                runEnzyme(solution, newSoln, enzyme, enzymeMults[enzyme], duration);

            return newSoln;
        }
        private static void runEnzyme(ISolution oldSoln, ISolution newSoln, IEnzyme enzyme, float multiplier, float duration) {

            // For each reaction that the enzyme can catalyze,
            // Adjust reactant/product concentrations depending on the current reaction direction
            foreach (IReaction rxn in enzyme.Reactions) {
                float ratio = rxn.ReactionQuotient(oldSoln) / rxn.EquilibriumConstant(oldSoln.Temperature);
                float baseDelta = multiplier * ratio * duration;
                int reacDir = (ratio > 1 ? -1 : 1);
                int prodDir = (ratio < 1 ? -1 : 1);

                ICompound[] reactants = rxn.GetReactants();
                foreach (ICompound r in reactants) {
                    float delta = reacDir * rxn.StoichiometryOf(r) * baseDelta;
                    changeConcentration(newSoln, r, delta);
                }

                ICompound[] products = rxn.GetProducts();
                foreach (ICompound p in products) {
                    float delta = prodDir * rxn.StoichiometryOf(p) * baseDelta;
                    changeConcentration(newSoln, p, delta);
                }
            }
        }
        private static void changeConcentration(ISolution solution, ICompound compound, float delta) {            
            if (delta > 0f) {
                Concentration newConc = solution[compound];
                solution[compound] = new Concentration(newConc.Value + delta);
            }

            // Decrement existing compound concentrations by the delta
            // If the new concentration is below the minimum, then set it to zero
            else {
                Concentration newConc = solution[compound];
                float minVal = (compound is IProtein ? MinProteinConcentration : MinMetaboliteConcentration);
                float newVal = newConc.Value + delta;
                if (newVal < minVal)
                    solution[compound] = Concentration.Zero;
                else
                    solution[compound] = new Concentration(newVal);
            }
        }

    }

}
