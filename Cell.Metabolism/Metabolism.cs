using System;
using System.Linq;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public struct Solution {

        private IDictionary<ICompound, Concentration> _compounds;

        public Solution(IEnumerable<Concentration> concentrations, Temperature temperature) {
            _compounds = concentrations.ToDictionary(c => c.Compound, c => c);
            Temperature = temperature;
        }


        public Concentration GetConcentration(ICompound compound) {
            return _compounds[compound];
        }
        public void Add(Concentration concentration) {
            _compounds.Add(concentration.Compound, concentration);
        }
        public bool Contains(ICompound compound) {
            return _compounds.ContainsKey(compound);
        }
        public bool TryGetConcentration(ICompound compound, out Concentration concentration) {
            return _compounds.TryGetValue(compound, out concentration);
        }
        public bool TryGetConcentration(ICompound compound, out float concentration) {
            Concentration conc;
            bool exists = _compounds.TryGetValue(compound, out conc);
            concentration = conc.Value;
            return exists;
        }
        public IEnumerable<Concentration> GetAllConcentrations() {
            return _compounds.Values;
        }
        public Temperature Temperature { get; }
    }

    public class Metabolism {

        public float MinMetaboliteConcentration { get; } = 0.0001f;
        public float MinProteinConcentration { get; } = 0.0001f;

        private Solution _soln;

        public Metabolism(Solution solution) {
            _soln = solution;
        }

        public void Metabolize() {
            // Associate all current Enzymes with their current reaction velocity
            // Only keep Enzymes with non-zero concentrations
            IDictionary<IEnzyme, float> enzymeVels = _soln.GetAllConcentrations()
                                                          .Select(c => c.Compound as IEnzyme)
                                                          .Where(e => e != null && _soln.GetConcentration(e).Value > 0f)
                                                          .ToDictionary(e => e, e => e.VelocityIn(_soln));

            // Run metabolism for the duration of one reaction cycle of the slowest enzyme
            float minVel = enzymeVels.Min(pair => pair.Value);
            float duration = 1f / minVel;
            foreach (IEnzyme enzyme in enzymeVels.Keys)
                runEnzyme(enzyme, enzymeVels[enzyme], duration);
        }
        private void runEnzyme(IEnzyme enzyme, float velocity, float duration) {
            float delta = velocity * duration;

            // Adjust reactant concentrations depending on the current reaction direction
            int reactantFac = (velocity > 0 ? -1 : 1);
            foreach (ICompound reactant in enzyme.Reaction.Reactants)
                deltaConcentration(reactant, reactantFac * delta);

            // Adjust product concentrations depending on the current reaction direction
            int productFac = (velocity < 0 ? -1 : 1);
            foreach (ICompound product in enzyme.Reaction.Products)
                deltaConcentration(product, productFac * delta);
        }
        private void deltaConcentration(ICompound compound, float delta) {
            float oldVal;
            bool exists = _soln.TryGetConcentration(compound, out oldVal);
            float newVal;

            // New compound concentrations are just set equal to the delta
            if (!exists && delta > 0f)
                newVal = delta;

            // Increment existing compound concentrations by the delta
            else if (exists && delta > 0f)
                newVal = oldVal + delta;


            // Decrement existing compound concentrations by the delta
            // If the new concentration is below the minimum, then set it to zero
            else if (exists && delta < 0f) {
                newVal = oldVal + delta;
                float minVal = (compound is IProtein ? MinProteinConcentration : MinMetaboliteConcentration);
                newVal = (newVal >= minVal ? newVal : 0);
            }

            else
                newVal = 0f;

            _soln.Add(new Concentration(compound, newVal));
        }

    }

}
