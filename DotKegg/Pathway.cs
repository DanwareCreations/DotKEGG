using System;
using System.Collections.Generic;
using System.Linq;

namespace DotKEGG {

    public class Pathway {
        public MapNumber Entry { get; }
        public string Name { get; }
        public string Description { get; }
        public object Class { get; }
        public MNumber[] Modules { get; }
        public HNumber[] Diseases { get; }
        public DNumber[] Drugs { get; }
        public object[] OtherDBs { get; }
        public object[] Organisms { get; }
        public object Orthology { get; }
        public object Gene { get; }
        public object Enzyme { get; }
        public object Reaction { get; }
        public object Compound { get; }
        public Reference[] References { get; }
        public object RelatedPathway { get; }
        public object KOPathway { get; }

    }

}
