using System.Collections.Generic;

namespace DotKegg {

    public sealed class PathwayDb : KeggDb {

        public PathwayDb() {
            Name = "pathway";
            Abbreviation = "path";
            Prefix = "map";
        }

        public static MapNumber NewMapNumber(uint number) {
            return new MapNumber(number);
        }

    }

}
