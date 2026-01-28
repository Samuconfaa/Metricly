using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a pressure value expressed in a base unit (Pascal).
    /// </summary>
    /// <remarks>
    /// The internal value is always stored in Pascals.
    /// Conversions to other pressure units are performed using predefined factors.
    /// </remarks>
    public class PressureMeasure(double baseValue)
    {
        /// <summary>
        /// Gets the internal pressure value expressed in Pascals.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal pressure value to a target unit using the specified factor.
        /// </summary>
        /// <param name="factor">
        /// The conversion factor representing how many Pascals correspond to one unit
        /// of the target measurement.
        /// </param>
        /// <returns>The converted pressure value.</returns>
        public double To(double factor) => BaseValue / factor;
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="PressureMeasure"/> values.
    /// </summary>
    /// <remarks>
    /// All conversion factors are defined as the equivalent number of Pascals
    /// for one unit of the corresponding measurement.
    /// </remarks>
    public static class PressureExtension
    {
        /// <summary>Represents one Pascal.</summary>
        private const double _Pascal = 1.0;

        /// <summary>Represents one atmosphere (101,325 Pascals).</summary>
        private const double Atmosphere = 101_325.0;

        /// <summary>Represents one psi (6,894.757293168 Pascals).</summary>
        private const double _Psi = 6_894.757293168;

        /// <summary>Represents one Torr (133.322387415 Pascals).</summary>
        private const double _Torr = 133.322387415;

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a pressure value expressed in Pascals.</summary>
        public static PressureMeasure Pascal(this double value) => new(value * _Pascal);

        /// <summary>Creates a pressure value expressed in atmospheres.</summary>
        public static PressureMeasure Atmospheres(this double value) => new(value * Atmosphere);

        /// <summary>Creates a pressure value expressed in psi (pounds per square inch).</summary>
        public static PressureMeasure Psi(this double value) => new(value * _Psi);

        /// <summary>Creates a pressure value expressed in Torr (mmHg).</summary>
        public static PressureMeasure Torr(this double value) => new(value * _Torr);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the pressure value to Pascals.</summary>
        public static double ToPascal(this PressureMeasure m) => m.To(_Pascal);

        /// <summary>Converts the pressure value to atmospheres.</summary>
        public static double ToAtmospheres(this PressureMeasure m) => m.To(Atmosphere);

        /// <summary>Converts the pressure value to psi.</summary>
        public static double ToPsi(this PressureMeasure m) => m.To(_Psi);

        /// <summary>Converts the pressure value to Torr.</summary>
        public static double ToTorr(this PressureMeasure m) => m.To(_Torr);
    }
}
