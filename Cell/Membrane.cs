namespace Cell {

    class Membrane : IBoundary {
        public Membrane(string name) {
            Name = name;
        }

        public string Name { get; private set; }
    }

}
