using System.Runtime.CompilerServices;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a mass value expressed in a base unit (grams).
    /// </summary>
    /// <remarks>
    /// The internal value is always stored in grams.
    /// Conversions to other units are performed using predefined conversion factors.
    /// </remarks>
    public class MassMeasure(double baseValue)
    {
        /// <summary>
        /// Gets the internal mass value expressed in grams.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal mass value to a target unit.
        /// </summary>
        /// <param name="factor">
        /// The conversion factor representing how many grams correspond to one unit
        /// of the target measurement.
        /// </param>
        /// <returns>The converted mass value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double To(double factor) => BaseValue / factor;
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="MassMeasure"/> values.
    /// </summary>
    /// <remarks>
    /// All conversion factors are defined as the equivalent number of grams
    /// for one unit of the corresponding measurement.
    /// </remarks>
    public static class MassExtension
    {
        // -------------------------
        // Metric units
        // -------------------------

        /// <summary>Represents one gram.</summary>
        private const double Gram = 1.0;

        /// <summary>Represents one metric ton (1,000,000 grams).</summary>
        private const double MetricTon = 1_000_000.0;

        /// <summary>Represents one kilogram (1,000 grams).</summary>
        private const double Kilogram = 1_000.0;

        /// <summary>Represents one milligram (0.001 grams).</summary>
        private const double Milligram = 0.001;

        /// <summary>Represents one microgram (0.000001 grams).</summary>
        private const double Microgram = 0.000001;

        // -------------------------
        // Imperial units
        // -------------------------

        /// <summary>Represents one ounce (28.349523125 grams).</summary>
        private const double Ounce = 28.349523125;

        /// <summary>Represents one pound (453.59237 grams).</summary>
        private const double Pound = 453.59237;

        /// <summary>Represents one stone (6,350.29318 grams).</summary>
        private const double _Stone = 6350.29318;

        /// <summary>Represents one US short ton (907,184.74 grams).</summary>
        private const double ShortTon = 907_184.74;

        /// <summary>Represents one imperial long ton (1,016,046.9088 grams).</summary>
        private const double LongTon = 1_016_046.9088;

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a mass value expressed in grams.</summary>
        public static MassMeasure Grams(this double value) => new(value * Gram);

        /// <summary>Creates a mass value expressed in metric tons.</summary>
        public static MassMeasure MetricTons(this double value) => new(value * MetricTon);

        /// <summary>Creates a mass value expressed in kilograms.</summary>
        public static MassMeasure Kilograms(this double value) => new(value * Kilogram);

        /// <summary>Creates a mass value expressed in milligrams.</summary>
        public static MassMeasure Milligrams(this double value) => new(value * Milligram);

        /// <summary>Creates a mass value expressed in micrograms.</summary>
        public static MassMeasure Micrograms(this double value) => new(value * Microgram);

        /// <summary>Creates a mass value expressed in ounces.</summary>
        public static MassMeasure Ounces(this double value) => new(value * Ounce);

        /// <summary>Creates a mass value expressed in pounds.</summary>
        public static MassMeasure Pounds(this double value) => new(value * Pound);

        /// <summary>Creates a mass value expressed in stones.</summary>
        public static MassMeasure Stone(this double value) => new(value * _Stone);

        /// <summary>Creates a mass value expressed in US short tons.</summary>
        public static MassMeasure ShortTons(this double value) => new(value * ShortTon);

        /// <summary>Creates a mass value expressed in imperial long tons.</summary>
        public static MassMeasure LongTons(this double value) => new(value * LongTon);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the mass value to grams.</summary>
        public static double ToGrams(this MassMeasure m) => m.To(Gram);

        /// <summary>Converts the mass value to metric tons.</summary>
        public static double ToMetricTons(this MassMeasure m) => m.To(MetricTon);

        /// <summary>Converts the mass value to kilograms.</summary>
        public static double ToKilograms(this MassMeasure m) => m.To(Kilogram);

        /// <summary>Converts the mass value to milligrams.</summary>
        public static double ToMilligrams(this MassMeasure m) => m.To(Milligram);

        /// <summary>Converts the mass value to micrograms.</summary>
        public static double ToMicrograms(this MassMeasure m) => m.To(Microgram);

        /// <summary>Converts the mass value to ounces.</summary>
        public static double ToOunces(this MassMeasure m) => m.To(Ounce);

        /// <summary>Converts the mass value to pounds.</summary>
        public static double ToPounds(this MassMeasure m) => m.To(Pound);

        /// <summary>Converts the mass value to stones.</summary>
        public static double ToStone(this MassMeasure m) => m.To(_Stone);

        /// <summary>Converts the mass value to US short tons.</summary>
        public static double ToShortTons(this MassMeasure m) => m.To(ShortTon);

        /// <summary>Converts the mass value to imperial long tons.</summary>
        public static double ToLongTons(this MassMeasure m) => m.To(LongTon);
    }
}
