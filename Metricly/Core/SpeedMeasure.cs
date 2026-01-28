using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a speed value expressed in a base unit (meters per second).
    /// </summary>
    /// <remarks>
    /// The internal value is always stored in meters per second.
    /// Conversions to other speed units are performed using predefined factors.
    /// </remarks>
    /// <remarks>
    /// Initializes a new instance of the <see cref="SpeedMeasure"/> class
    /// using a value expressed in meters per second.
    /// </remarks>
    /// <param name="baseValue">The speed value in meters per second.</param>
    public class SpeedMeasure(double baseValue)
    {
        /// <summary>
        /// Gets the internal speed value expressed in meters per second.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal speed value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">How many meters per second correspond to one unit of the target measurement.</param>
        /// <returns>The converted speed value.</returns>
        public double To(double factor) => BaseValue / factor;
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="SpeedMeasure"/> values.
    /// </summary>
    public static class SpeedExtensions
    {
        // -------------------------
        // Speed constants 
        // -------------------------
        private const double MeterPerSecond = 1.0;                
        private const double KilometerPerHour = 1000.0 / 3600.0; 
        private const double MilePerHour = 1609.344 / 3600.0;    
        private const double FootPerSecond = 0.3048;             
        private const double Knot = 1852.0 / 3600.0;             

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a speed value expressed in meters per second.</summary>
        public static SpeedMeasure MetersPerSecond(this double value) => new(value * MeterPerSecond);

        /// <summary>Creates a speed value expressed in kilometers per hour.</summary>
        public static SpeedMeasure KilometersPerHour(this double value) => new(value * KilometerPerHour);

        /// <summary>Creates a speed value expressed in miles per hour.</summary>
        public static SpeedMeasure MilesPerHour(this double value) => new(value * MilePerHour);

        /// <summary>Creates a speed value expressed in feet per second.</summary>
        public static SpeedMeasure FeetPerSecond(this double value) => new(value * FootPerSecond);

        /// <summary>Creates a speed value expressed in knots.</summary>
        public static SpeedMeasure Knots(this double value) => new(value * Knot);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the speed value to meters per second.</summary>
        public static double ToMetersPerSecond(this SpeedMeasure s) => s.To(MeterPerSecond);

        /// <summary>Converts the speed value to kilometers per hour.</summary>
        public static double ToKilometersPerHour(this SpeedMeasure s) => s.To(KilometerPerHour);

        /// <summary>Converts the speed value to miles per hour.</summary>
        public static double ToMilesPerHour(this SpeedMeasure s) => s.To(MilePerHour);

        /// <summary>Converts the speed value to feet per second.</summary>
        public static double ToFeetPerSecond(this SpeedMeasure s) => s.To(FootPerSecond);

        /// <summary>Converts the speed value to knots.</summary>
        public static double ToKnots(this SpeedMeasure s) => s.To(Knot);
    }
}
