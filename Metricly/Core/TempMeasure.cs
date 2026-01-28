using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a temperature value expressed in a base unit (Kelvin).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="TempMeasure"/> class
    /// using a value expressed in Kelvin.
    /// </remarks>
    /// <param name="kelvinValue">The temperature value in Kelvin.</param>
    public class TempMeasure(double kelvinValue) : IMeasure<TempMeasure>
    {
        /// <summary>
        /// Gets the internal temperature value expressed in Kelvin.
        /// </summary>
        public double KelvinValue { get; } = kelvinValue;

        /// <summary>
        /// Gets the base value for IMeasure compatibility (returns KelvinValue).
        /// </summary>
        public double BaseValue => KelvinValue;

        /// <summary>
        /// Converts the internal Kelvin value to a target temperature scale
        /// using the specified ratio and offset.
        /// </summary>
        /// <param name="ratio">
        /// The conversion ratio between the target scale and Kelvin.
        /// </param>
        /// <param name="offset">
        /// The offset applied to the Kelvin value before conversion.
        /// </param>
        /// <returns>The converted temperature value.</returns>
        public double To(double ratio, double offset) => (KelvinValue - offset) / ratio;

        /// <summary>
        /// Returns the temperature value expressed in Kelvin.
        /// </summary>
        /// <returns>The temperature value in Kelvin.</returns>
        public double To() => KelvinValue;

        /// <summary>
        /// Creates a new temperature measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in Kelvin.</param>
        /// <returns>A new <see cref="TempMeasure"/> instance.</returns>
        public TempMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two temperature measurements.
        /// </summary>
        /// <param name="other">The temperature to add.</param>
        /// <returns>A new <see cref="TempMeasure"/> representing the sum.</returns>
        public TempMeasure Add(TempMeasure other) => new(KelvinValue + other.KelvinValue);

        /// <summary>
        /// Subtracts another temperature measurement from this one.
        /// </summary>
        /// <param name="other">The temperature to subtract.</param>
        /// <returns>A new <see cref="TempMeasure"/> representing the difference.</returns>
        public TempMeasure Subtract(TempMeasure other) => new(KelvinValue - other.KelvinValue);

        /// <summary>
        /// Multiplies the temperature by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="TempMeasure"/> representing the product.</returns>
        public TempMeasure Multiply(double scalar) => new(KelvinValue * scalar);

        /// <summary>
        /// Divides the temperature by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="TempMeasure"/> representing the quotient.</returns>
        public TempMeasure Divide(double scalar) => new(KelvinValue / scalar);

        /// <summary>
        /// Divides this temperature by another temperature to get a ratio.
        /// </summary>
        /// <param name="other">The temperature to divide by.</param>
        /// <returns>The ratio between the two temperatures.</returns>
        public double DivideBy(TempMeasure other) => KelvinValue / other.KelvinValue;

        /// <summary>
        /// Adds two temperature measurements.
        /// </summary>
        /// <param name="left">The first temperature.</param>
        /// <param name="right">The second temperature.</param>
        /// <returns>The sum of the two temperatures.</returns>
        public static TempMeasure operator +(TempMeasure left, TempMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one temperature measurement from another.
        /// </summary>
        /// <param name="left">The temperature to subtract from.</param>
        /// <param name="right">The temperature to subtract.</param>
        /// <returns>The difference between the two temperatures.</returns>
        public static TempMeasure operator -(TempMeasure left, TempMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a temperature measurement by a scalar.
        /// </summary>
        /// <param name="left">The temperature.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the temperature and scalar.</returns>
        public static TempMeasure operator *(TempMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a temperature measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The temperature.</param>
        /// <returns>The product of the scalar and temperature.</returns>
        public static TempMeasure operator *(double scalar, TempMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a temperature measurement by a scalar.
        /// </summary>
        /// <param name="left">The temperature.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the temperature and scalar.</returns>
        public static TempMeasure operator /(TempMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one temperature measurement by another.
        /// </summary>
        /// <param name="left">The dividend temperature.</param>
        /// <param name="right">The divisor temperature.</param>
        /// <returns>The ratio between the two temperatures.</returns>
        public static double operator /(TempMeasure left, TempMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two temperature measurements are equal.
        /// </summary>
        /// <param name="left">The first temperature.</param>
        /// <param name="right">The second temperature.</param>
        /// <returns><c>true</c> if the temperatures are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(TempMeasure left, TempMeasure right)
            => Math.Abs(left.KelvinValue - right.KelvinValue) < 1e-10;

        /// <summary>
        /// Determines whether two temperature measurements are not equal.
        /// </summary>
        /// <param name="left">The first temperature.</param>
        /// <param name="right">The second temperature.</param>
        /// <returns><c>true</c> if the temperatures are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(TempMeasure left, TempMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one temperature measurement is greater than another.
        /// </summary>
        /// <param name="left">The first temperature.</param>
        /// <param name="right">The second temperature.</param>
        /// <returns><c>true</c> if the first temperature is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(TempMeasure left, TempMeasure right)
            => left.KelvinValue > right.KelvinValue;

        /// <summary>
        /// Determines whether one temperature measurement is less than another.
        /// </summary>
        /// <param name="left">The first temperature.</param>
        /// <param name="right">The second temperature.</param>
        /// <returns><c>true</c> if the first temperature is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(TempMeasure left, TempMeasure right)
            => left.KelvinValue < right.KelvinValue;

        /// <summary>
        /// Determines whether one temperature measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first temperature.</param>
        /// <param name="right">The second temperature.</param>
        /// <returns><c>true</c> if the first temperature is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(TempMeasure left, TempMeasure right)
            => left.KelvinValue >= right.KelvinValue;

        /// <summary>
        /// Determines whether one temperature measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first temperature.</param>
        /// <param name="right">The second temperature.</param>
        /// <returns><c>true</c> if the first temperature is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(TempMeasure left, TempMeasure right)
            => left.KelvinValue <= right.KelvinValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current temperature measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current temperature measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current temperature measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this temperature measurement.
        /// </summary>
        /// <returns>A hash code for the current temperature measurement.</returns>
        public override int GetHashCode() => KelvinValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the temperature measurement.
        /// </summary>
        /// <returns>A string representing the temperature in Kelvin.</returns>
        public override string ToString() => $"{KelvinValue} K";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="TempMeasure"/> values.
    /// </summary>
    public static class TemperatureExtensions
    {
        private const double KelvinOffset = 0.0;
        private const double CelsiusOffset = 273.15;
        private const double FahrenheitOffset = 459.67;
        private const double FahrenheitRatio = 5.0 / 9.0;

        /// <summary>
        /// Creates a temperature value expressed in Celsius.
        /// </summary>
        /// <param name="value">The temperature value in Celsius.</param>
        /// <returns>A <see cref="TempMeasure"/> representing the value in Kelvin.</returns>
        public static TempMeasure Celsius(this double value)
            => new(value + CelsiusOffset);

        /// <summary>
        /// Creates a temperature value expressed in Fahrenheit.
        /// </summary>
        /// <param name="value">The temperature value in Fahrenheit.</param>
        /// <returns>A <see cref="TempMeasure"/> representing the value in Kelvin.</returns>
        public static TempMeasure Fahrenheit(this double value)
            => new((value + FahrenheitOffset) * FahrenheitRatio);

        /// <summary>
        /// Creates a temperature value expressed in Kelvin.
        /// </summary>
        /// <param name="value">The temperature value in Kelvin.</param>
        /// <returns>A <see cref="TempMeasure"/> representing the value.</returns>
        public static TempMeasure Kelvin(this double value)
            => new(value);

        /// <summary>
        /// Converts the temperature value to Celsius.
        /// </summary>
        /// <param name="m">The temperature measure.</param>
        /// <returns>The temperature value in Celsius.</returns>
        public static double ToCelsius(this TempMeasure m)
            => m.KelvinValue - CelsiusOffset;

        /// <summary>
        /// Converts the temperature value to Fahrenheit.
        /// </summary>
        /// <param name="m">The temperature measure.</param>
        /// <returns>The temperature value in Fahrenheit.</returns>
        public static double ToFahrenheit(this TempMeasure m)
            => (m.KelvinValue / FahrenheitRatio) - FahrenheitOffset;

        /// <summary>
        /// Converts the temperature value to Kelvin.
        /// </summary>
        /// <param name="m">The temperature measure.</param>
        /// <returns>The temperature value in Kelvin.</returns>
        public static double ToKelvin(this TempMeasure m) => m.KelvinValue;
    }
}
