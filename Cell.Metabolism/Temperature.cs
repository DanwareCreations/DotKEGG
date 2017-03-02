using System;
using System.Collections.Generic;

namespace Cell.Metabolism {

    public enum Degrees {
        Celsius,
        Fahrenheit,
        Kelvin,
    }
    
    public struct Temperature : IEquatable<Temperature> {

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

        private float _value;
        private Degrees _origDegrees;

        #region Constructors + Factory Methods

        public Temperature(float value, Degrees degrees) {
            _value = _toKelvinFrom[degrees](value);
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
        public float InDegrees(Degrees units) {
            return _fromKelvinTo[Degrees.Kelvin](_value);
        }

        #endregion

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
            return left.Equals(right);
        }
        public static bool operator !=(Temperature left, Temperature right) {
            return !left.Equals(right);
        }
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