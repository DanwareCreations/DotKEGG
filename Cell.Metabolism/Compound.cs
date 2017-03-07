using System;

namespace Cell.Metabolism {

    public class Compound {

        private string[] _names;
        private Guid _id = Guid.NewGuid();

        public Guid Id => _id;

        public string[] Names => _names;
    }

}
