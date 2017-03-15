namespace DotKEGG {

    public sealed class MapNumber : KeggId {

        public MapNumber(uint number) {
            Number = number;
        }

        public PathwayDb Database => _db as PathwayDb;

    }

}
