using System.Collections.Generic;

using Cell.Metabolism;

namespace Cell.Compartments {

    class Bacterium : Prokaryote {

        bool _gramPos;

        // CONSTRUCTORS
        public Bacterium(bool gramPos) {
            _gramPos = gramPos;
            if (_gramPos)
                return;
            
            OuterMembrane = new PhospholipidBilayer();
            Proteoglycan = new Membrane();
            _boundaries.InsertRange(0, new IBoundary[2] { OuterMembrane, Proteoglycan });
        }

        public bool GramPositive => _gramPos;
        public PhospholipidBilayer OuterMembrane { get; }
        public Membrane Proteoglycan { get; }

    }
}