using System;

namespace Cell.Metabolism {

    public struct Concentration : IEquatable<Concentration>, IComparable, IComparable<Concentration> {

        private float _value;

        private static Concentration _zero = new Concentration(0f);

        public Concentration(float value) {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), $"Concentrations cannot be negative!");
            
            _value = value;
        }
        public static Concentration Zero => _zero;
        
        public float Value {
            get { return _value; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"Concentrations cannot be negative!");
                _value = value;
            }
        }
        public void Change(float delta) {
            if (delta > _value)
                throw new InvalidOperationException($"Concentrations cannot be lowered below zero!");

            _value -= delta;
        }
        public void SetToZero() {
            _value = 0f;
        }

        #region Equality

        public bool Equals(Concentration other) {
            return (other._value == this._value);
        }
        public override bool Equals(object obj) {
            bool eq = false;
            if (obj is Concentration)
                eq = Equals((Concentration)obj);

            return eq;
        }
        public static bool operator ==(Concentration left, Concentration right) {
            return left._value == right._value;
        }
        public static bool operator !=(Concentration left, Concentration right) {
            return left._value != right._value;
        }

        #endregion

        #region Comparison

        public int CompareTo(Concentration other) {
            return _value.CompareTo(other._value);
        }
        public int CompareTo(object obj) {
            if (obj is Concentration) {
                Concentration t = (Concentration)obj;
                return _value.CompareTo(t._value);
            }
            else
                throw new ArgumentException("Object is not a Concentration", nameof(obj));
        }
        public static bool operator >(Concentration left, Concentration right) {
            return left._value > right._value;
        }
        public static bool operator >=(Concentration left, Concentration right) {
            return left._value >= right._value;
        }
        public static bool operator <(Concentration left, Concentration right) {
            return left._value < right._value;
        }
        public static bool operator <=(Concentration left, Concentration right) {
            return left._value <= right._value;
        }

        #endregion
        public override int GetHashCode() {
            return Value.GetHashCode();
        }
        public override string ToString() {
            return _value.ToString();
        }
    }

}