using System;

namespace Cell.Metabolism {

    public partial class Compound : ICompound {

        private string[] _names;
        private Guid _id = Guid.NewGuid();

        public Compound(string name) {
            _names = new string[1] { name };
        }

        public Guid Id => _id;

        public string[] Names => _names;
    }

}
