namespace Cell.Compartments {

    class Capsid : IBoundary {
        public Capsid(string name) {
            Name = name;
        }

        public string Name { get; private set; }
    }

}
