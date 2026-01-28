using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a temperature value expressed in a base unit (Kelvin).
    /// </summary>
    /// <remarks>
    /// The internal value is always stored in Kelvin.
    /// Conversions to other temperature scales are performed using
    /// scale-specific ratios and offsets.
    /// </remarks>
    public class TempMeasure
    {
        /// <summary>
        /// Gets the internal temperature value expressed in Kelvin.
        /// </summary>
        public double KelvinValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TempMeasure"/> class
        /// using a value expressed in Kelvin.
        /// </summary>
        /// <param name="kelvinValue">The temperature value in Kelvin.</param>
        public TempMeasure(double kelvinValue)
        {
            KelvinValue = kelvinValue;
        }

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
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="TempMeasure"/> values.
    /// </summary>
    /// <remarks>
    /// Kelvin is used as the base unit.
    /// Other temperature scales are converted using well-defined
    /// ratios and offsets.
    /// </remarks>
    public static class TemperatureExtensions
    {
        /// <summary>Offset used for Kelvin scale.</summary>
        private const double KelvinOffset = 0.0;

        /// <summary>Offset between Celsius and Kelvin.</summary>
        private const double CelsiusOffset = 273.15;

        /// <summary>Offset between Fahrenheit and absolute zero.</summary>
        private const double FahrenheitOffset = 459.67;

        /// <summary>Ratio used to convert Fahrenheit to Kelvin.</summary>
        private const double FahrenheitRatio = 5.0 / 9.0;

        // -------------------------
        // Factory methods
        // -------------------------

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

        // -------------------------
        // Conversion methods
        // -------------------------

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
