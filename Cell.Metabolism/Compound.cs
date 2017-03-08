using System.Linq;
using System.Collections.Generic;

using Cell.Metabolism.Data;

namespace Cell.Metabolism {

    public class Compound : Entity {

        protected Compound() { }

        public static Compound Load(string name) {
            CompoundData data = CompoundData.Load(name);

            Compound obj = new Compound() {
                ID = data.ID,
                Names = data.Names,
                MolarMass = data.MolarMass,
            };

            return obj;
        }
        public static IEnumerable<Compound> LoadAll() {
            return CompoundData.LoadAll()
                               .Select(data =>
                                    new Compound() {
                                        ID = data.ID,
                                        Names = data.Names,
                                        MolarMass = data.MolarMass,
                                    }
                               );
        }

        public string[] Names { get; protected set; }
        public double MolarMass { get; protected set; }

    }

}
