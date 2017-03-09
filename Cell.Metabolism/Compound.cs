using System.Linq;
using System.Collections.Generic;

using Cell.Metabolism.Data;

namespace Cell.Metabolism {

    public class Compound : Entity {

        protected Compound() { }

        public string[] Names { get; protected set; }
        public string[] Types { get; protected set; }

        public static Compound Load(string name) {
            CompoundData data = CompoundData.Load(name);
            return doLoad(data);
        }
        public static IEnumerable<Compound> LoadAll() {
            return CompoundData.LoadAll().Select(data => doLoad(data));
        }

        private static Compound doLoad(CompoundData data) {
            return new Compound() {
                ID = data.ID,
                Names = data.Names,
                Types = data.Types,
            };
        }

    }

}
