using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a data transfer rate value expressed in a base unit (bit per second).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="DataRateMeasure"/> class
    /// using a value expressed in bits per second.
    /// </remarks>
    /// <param name="baseValue">The data rate value in bits per second.</param>
    public class DataRateMeasure(double baseValue)
    {
        /// <summary>
        /// Gets the internal value expressed in bits per second.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of bits per second corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="DataRateMeasure"/> values.
    /// </summary>
    public static class DataRateExtensions
    {
        private const double BitPerSecond = 1.0;
        private const double KilobitPerSecond = 1_000.0;
        private const double KilobytePerSecond = 8_000.0;
        private const double KibibitPerSecond = 1_024.0;
        private const double MegabitPerSecond = 1_000_000.0;
        private const double MegabytePerSecond = 8_000_000.0;
        private const double MebibitPerSecond = 1_048_576.0;
        private const double GigabitPerSecond = 1_000_000_000.0;
        private const double GigabytePerSecond = 8_000_000_000.0;
        private const double GibibitPerSecond = 1_073_741_824.0;
        private const double TerabitPerSecond = 1_000_000_000_000.0;
        private const double TerabytePerSecond = 8_000_000_000_000.0;
        private const double TebibitPerSecond = 1_099_511_627_776.0;

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a data rate value expressed in bits per second.</summary>
        public static DataRateMeasure BitsPerSecond(this double value) => new(value * BitPerSecond);

        /// <summary>Creates a data rate value expressed in kilobits per second.</summary>
        public static DataRateMeasure KilobitsPerSecond(this double value) => new(value * KilobitPerSecond);

        /// <summary>Creates a data rate value expressed in kilobytes per second.</summary>
        public static DataRateMeasure KilobytesPerSecond(this double value) => new(value * KilobytePerSecond);

        /// <summary>Creates a data rate value expressed in kibibits per second.</summary>
        public static DataRateMeasure KibibitsPerSecond(this double value) => new(value * KibibitPerSecond);

        /// <summary>Creates a data rate value expressed in megabits per second.</summary>
        public static DataRateMeasure MegabitsPerSecond(this double value) => new(value * MegabitPerSecond);

        /// <summary>Creates a data rate value expressed in megabytes per second.</summary>
        public static DataRateMeasure MegabytesPerSecond(this double value) => new(value * MegabytePerSecond);

        /// <summary>Creates a data rate value expressed in mebibits per second.</summary>
        public static DataRateMeasure MebibitsPerSecond(this double value) => new(value * MebibitPerSecond);

        /// <summary>Creates a data rate value expressed in gigabits per second.</summary>
        public static DataRateMeasure GigabitsPerSecond(this double value) => new(value * GigabitPerSecond);

        /// <summary>Creates a data rate value expressed in gigabytes per second.</summary>
        public static DataRateMeasure GigabytesPerSecond(this double value) => new(value * GigabytePerSecond);

        /// <summary>Creates a data rate value expressed in gibibits per second.</summary>
        public static DataRateMeasure GibibitsPerSecond(this double value) => new(value * GibibitPerSecond);

        /// <summary>Creates a data rate value expressed in terabits per second.</summary>
        public static DataRateMeasure TerabitsPerSecond(this double value) => new(value * TerabitPerSecond);

        /// <summary>Creates a data rate value expressed in terabytes per second.</summary>
        public static DataRateMeasure TerabytesPerSecond(this double value) => new(value * TerabytePerSecond);

        /// <summary>Creates a data rate value expressed in tebibits per second.</summary>
        public static DataRateMeasure TebibitsPerSecond(this double value) => new(value * TebibitPerSecond);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the data rate to bits per second.</summary>
        public static double ToBitsPerSecond(this DataRateMeasure m) => m.To(BitPerSecond);

        /// <summary>Converts the data rate to kilobits per second.</summary>
        public static double ToKilobitsPerSecond(this DataRateMeasure m) => m.To(KilobitPerSecond);

        /// <summary>Converts the data rate to kilobytes per second.</summary>
        public static double ToKilobytesPerSecond(this DataRateMeasure m) => m.To(KilobytePerSecond);

        /// <summary>Converts the data rate to kibibits per second.</summary>
        public static double ToKibibitsPerSecond(this DataRateMeasure m) => m.To(KibibitPerSecond);

        /// <summary>Converts the data rate to megabits per second.</summary>
        public static double ToMegabitsPerSecond(this DataRateMeasure m) => m.To(MegabitPerSecond);

        /// <summary>Converts the data rate to megabytes per second.</summary>
        public static double ToMegabytesPerSecond(this DataRateMeasure m) => m.To(MegabytePerSecond);

        /// <summary>Converts the data rate to mebibits per second.</summary>
        public static double ToMebibitsPerSecond(this DataRateMeasure m) => m.To(MebibitPerSecond);

        /// <summary>Converts the data rate to gigabits per second.</summary>
        public static double ToGigabitsPerSecond(this DataRateMeasure m) => m.To(GigabitPerSecond);

        /// <summary>Converts the data rate to gigabytes per second.</summary>
        public static double ToGigabytesPerSecond(this DataRateMeasure m) => m.To(GigabytePerSecond);

        /// <summary>Converts the data rate to gibibits per second.</summary>
        public static double ToGibibitsPerSecond(this DataRateMeasure m) => m.To(GibibitPerSecond);

        /// <summary>Converts the data rate to terabits per second.</summary>
        public static double ToTerabitsPerSecond(this DataRateMeasure m) => m.To(TerabitPerSecond);

        /// <summary>Converts the data rate to terabytes per second.</summary>
        public static double ToTerabytesPerSecond(this DataRateMeasure m) => m.To(TerabytePerSecond);

        /// <summary>Converts the data rate to tebibits per second.</summary>
        public static double ToTebibitsPerSecond(this DataRateMeasure m) => m.To(TebibitPerSecond);
    }
}
