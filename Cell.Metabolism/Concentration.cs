using System;

namespace Cell.Metabolism {

    public struct Concentration : IEquatable<Concentration> {

        private float _value;

        public Concentration(ICompound compound, float value) {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), $"Concentrations cannot be negative!");

            Compound = compound;
            _value = value;
        }

        public ICompound Compound { get; }
        public float Value {
            get { return _value; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"Concentrations cannot be negative!");
                _value = value;
            }
        }

        public bool Equals(Concentration other) {
            throw new NotImplementedException();
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }
        public override string ToString() {
            return $"{Compound} ({_value})";
        }
    }

}