namespace Cell.Metabolism {

    public partial class Compound {

        private static ICompound _hydronium;
        public static ICompound Hydronium {
            get {
                if (_hydronium == null)
                    _hydronium = new Compound("Hydronium");
                return _hydronium;
            }
        }

    }

}
