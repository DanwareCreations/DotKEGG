using System;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public enum Degrees {
        Celsius,
        Fahrenheit,
        Kelvin,
    }
    
    public struct Temperature : IEquatable<Temperature>, IComparable, IComparable<Temperature> {

        private float _value;
        private Degrees _origDegrees;

        private static Temperature _zero = new Temperature(0f, Degrees.Kelvin);
        private static Temperature _standard = new Temperature(0f, Degrees.Celsius);
        private static Temperature _waterBoil = new Temperature(100f, Degrees.Celsius);
        private static Temperature _humanBody = new Temperature(37f, Degrees.Celsius);

        #region Conversion Constants

        private static IDictionary<Degrees, Func<float, float>> _toKelvinFrom = new Dictionary<Degrees, Func<float, float>>() {
            { Degrees.Celsius, (celsius) => celsius + 273.15f },
            { Degrees.Fahrenheit, (fahr) => (fahr + 459.67f) * 5f/9f },
            { Degrees.Kelvin, (kelvin) => kelvin },
        };
        private static IDictionary<Degrees, Func<float, float>> _fromKelvinTo = new Dictionary<Degrees, Func<float, float>>() {
            { Degrees.Celsius, (kelvin) => kelvin - 273.15f },
            { Degrees.Fahrenheit, (kelvin) => kelvin * 9f/5f - 459.67f },
            { Degrees.Kelvin, (kelvin) => kelvin },
        };
        private static IDictionary<Degrees, string> _symbols = new Dictionary<Degrees, string>() {
            { Degrees.Celsius, "°C" },
            { Degrees.Fahrenheit, "°F" },
            { Degrees.Kelvin, "K" },
        };

        #endregion

        #region Constructors + Factory Methods

        public Temperature(float value, Degrees degrees) {
            float kelvin = _toKelvinFrom[degrees](value);
            if (kelvin < 0)
                throw new ArgumentOutOfRangeException("", "Termperatures below absolute zero are invalid!");

            _value = kelvin;
            _origDegrees = degrees;
        }

        public static Temperature FromCelsius(float degrees) {
            return new Temperature(degrees, Degrees.Celsius);
        }
        public static Temperature FromFahrenheit(float degrees) {
            return new Temperature(degrees, Degrees.Fahrenheit);
        }
        public static Temperature FromKelvin(float degrees) {
            return new Temperature(degrees, Degrees.Kelvin);
        }

        public static Temperature AbsoluteZero => _zero;
        public static Temperature StandardTemperature => _standard;
        public static Temperature HumanBodyTemperature => _humanBody;
        public static Temperature WaterFreezesAtSeaLevel => _standard;
        public static Temperature WaterBoilsAtSeaLevel => _waterBoil;

        #endregion

        #region Accessors

        public float InCelsius() {
            return _fromKelvinTo[Degrees.Celsius](_value);
        }
        public float InFahrenheit() {
            return _fromKelvinTo[Degrees.Fahrenheit](_value);
        }
        public float InKelvin() {
            return _value;
        }
        public float InDegrees(Degrees degrees) {
            return _fromKelvinTo[Degrees.Kelvin](_value);
        }
        
        public void Change(float delta, Degrees degrees) {
            float kelvin = _toKelvinFrom[degrees](delta);
            if (kelvin > _value)
                throw new InvalidOperationException($"Temperatures cannot be lowered below absolute zero!");

            _value -= kelvin;
        }

        #endregion

        #region Equality

        public bool Equals(Temperature other) {
            return (other._value == this._value);
        }
        public override bool Equals(object obj) {
            bool eq = false;
            if (obj is Temperature)
                eq = Equals((Temperature)obj);

            return eq;
        }
        public static bool operator ==(Temperature left, Temperature right) {
            return left._value == right._value;
        }
        public static bool operator !=(Temperature left, Temperature right) {
            return left._value != right._value;
        }

        #endregion

        #region Comparison

        public int CompareTo(Temperature other) {
            return _value.CompareTo(other._value);
        }
        public int CompareTo(object obj) {
            if (obj is Temperature) {
                Temperature t = (Temperature)obj;
                return _value.CompareTo(t._value);
            }
            else
                throw new ArgumentException("Object is not a Temperature", nameof(obj));
        }
        public static bool operator >(Temperature left, Temperature right) {
            return left._value > right._value;
        }
        public static bool operator >=(Temperature left, Temperature right) {
            return left._value >= right._value;
        }
        public static bool operator <(Temperature left, Temperature right) {
            return left._value < right._value;
        }
        public static bool operator <=(Temperature left, Temperature right) {
            return left._value <= right._value;
        }

        #endregion

        public override int GetHashCode() {
            return _value.GetHashCode();
        }
        public override string ToString() {
            double val = Math.Round(_value, 2);
            string symbol = _symbols[_origDegrees];
            return $"{val} {symbol}";
        }

    }

}