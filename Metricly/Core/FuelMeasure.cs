using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a fuel consumption value expressed in a base unit (kilometers per liter).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FuelMeasure"/> class
    /// using a value expressed in kilometers per liter.
    /// </remarks>
    /// <param name="baseValue">The fuel consumption value in km/L.</param>
    public class FuelMeasure(double baseValue)
    {
        /// <summary>
        /// Gets the internal value expressed in kilometers per liter (km/L).
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="FuelMeasure"/> values.
    /// </summary>
    public static class FuelConsumptionExtensions
    {
        // -------------------------
        // Constants 
        // -------------------------

        /// <summary>Base unit: kilometers per liter.</summary>
        private const double _KmPerLiter = 1.0;

        /// <summary>Conversion factor for liters per 100 kilometers (L/100km).</summary>
        private const double _LiterPer100Km = 1.0; 

        /// <summary>Conversion factor for miles per US gallon (MPG US).</summary>
        private const double _MilePerUSGallon = 2.352145833;

        /// <summary>Conversion factor for miles per Imperial gallon (MPG UK).</summary>
        private const double _MilePerUKGallon = 2.824809363; 

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a fuel consumption value expressed in kilometers per liter (km/L).</summary>
        /// <param name="value">The value in km/L.</param>
        /// <returns>A <see cref="FuelMeasure"/> representing the given value in km/L.</returns>
        public static FuelMeasure KmPerLiter(this double value) => new(value * _KmPerLiter);

        /// <summary>Creates a fuel consumption value expressed in liters per 100 kilometers (L/100km).</summary>
        /// <param name="value">The value in liters per 100 km.</param>
        /// <returns>A <see cref="FuelMeasure"/> representing the equivalent km/L value.</returns>
        public static FuelMeasure LiterPer100Km(this double value) => new(100.0 / value);

        /// <summary>Creates a fuel consumption value expressed in miles per US gallon (MPG US).</summary>
        /// <param name="value">The value in MPG US.</param>
        /// <returns>A <see cref="FuelMeasure"/> representing the equivalent km/L value.</returns>
        public static FuelMeasure MpgUS(this double value) => new(value / _MilePerUSGallon);

        /// <summary>Creates a fuel consumption value expressed in miles per Imperial gallon (MPG UK).</summary>
        /// <param name="value">The value in MPG UK.</param>
        /// <returns>A <see cref="FuelMeasure"/> representing the equivalent km/L value.</returns>
        public static FuelMeasure MpgUK(this double value) => new(value / _MilePerUKGallon);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the fuel consumption to kilometers per liter (km/L).</summary>
        public static double ToKmPerLiter(this FuelMeasure f) => f.BaseValue;

        /// <summary>Converts the fuel consumption to liters per 100 kilometers (L/100km).</summary>
        public static double ToLiterPer100Km(this FuelMeasure f) => 100.0 / f.BaseValue;

        /// <summary>Converts the fuel consumption to miles per US gallon (MPG US).</summary>
        public static double ToMpgUS(this FuelMeasure f) => f.BaseValue * _MilePerUSGallon;

        /// <summary>Converts the fuel consumption to miles per Imperial gallon (MPG UK).</summary>
        public static double ToMpgUK(this FuelMeasure f) => f.BaseValue * _MilePerUKGallon;
    }
}
