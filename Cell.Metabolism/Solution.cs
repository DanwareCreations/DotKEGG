using System;
using System.Linq;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public class Solution : ISolution {
        
        private float _pH;
        private IDictionary<Compound, Concentration> _compounds;

        public Solution(float pH, Temperature temperature) {
            _pH = pH;
            Temperature = temperature;
            _compounds = new Dictionary<Compound, Concentration>();
        }
        public Solution(IDictionary<Compound, Concentration> compounds, float pH, Temperature temperature) {
            _pH = pH;
            Temperature = temperature;
            _compounds = compounds;
        }

        public Concentration this[Compound compound] {
            get {
                Concentration conc;
                bool exists = _compounds.TryGetValue(compound, out conc);
                if (!exists)
                    conc = Concentration.Zero;

                return conc;
            }
            set {
                _compounds[compound] = value;
            }
        }
        public void Add(Compound compound, Concentration concentration) {
            if (_compounds.ContainsKey(compound))
                throw new InvalidOperationException("Cannot add a Compound to a Solution that is already in that Solution.");

            _compounds.Add(compound, concentration);
        }
        public void Remove(Compound compound) {
            _compounds.Remove(compound);
        }
        public ICollection<Compound> ListCompounds() {
            return _compounds.Keys;
        }

        public object Clone() {
            Solution soln = new Solution(_pH, Temperature);
            soln._compounds = this._compounds.ToDictionary(pair => pair.Key, pair => pair.Value);

            return soln;
        }

        public Temperature Temperature { get; set; }        
        public float pH {
            get { return _pH; }
            set { _pH = value; }
        }

    }

}
