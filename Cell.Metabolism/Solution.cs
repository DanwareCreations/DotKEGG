using System;
using System.Linq;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public class Solution : ISolution {
        
        private float _pH;
        private IDictionary<ICompound, Concentration> _compounds;

        public Solution(float pH, Temperature temperature) {
            _pH = pH;
            Temperature = temperature;
            _compounds = new Dictionary<ICompound, Concentration>();
        }
        public Solution(IDictionary<ICompound, Concentration> compounds, float pH, Temperature temperature) {
            _pH = pH;
            Temperature = temperature;
            _compounds = compounds;
        }

        public Concentration this[ICompound compound] {
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
        public void Add(ICompound compound, Concentration concentration) {
            if (_compounds.ContainsKey(compound))
                throw new InvalidOperationException("Cannot add a Compound to a Solution that is already in that Solution.");

            _compounds.Add(compound, concentration);
        }
        public void Remove(ICompound compound) {
            _compounds.Remove(compound);
        }
        public ICollection<ICompound> ListCompounds() {
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
