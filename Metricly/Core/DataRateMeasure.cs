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
    public class DataRateMeasure(double baseValue) : IMeasure<DataRateMeasure>
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

        /// <summary>
        /// Creates a new data rate measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in bits per second.</param>
        /// <returns>A new <see cref="DataRateMeasure"/> instance.</returns>
        public DataRateMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two data rate measurements.
        /// </summary>
        /// <param name="other">The data rate to add.</param>
        /// <returns>A new <see cref="DataRateMeasure"/> representing the sum.</returns>
        public DataRateMeasure Add(DataRateMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another data rate measurement from this one.
        /// </summary>
        /// <param name="other">The data rate to subtract.</param>
        /// <returns>A new <see cref="DataRateMeasure"/> representing the difference.</returns>
        public DataRateMeasure Subtract(DataRateMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the data rate by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="DataRateMeasure"/> representing the product.</returns>
        public DataRateMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the data rate by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="DataRateMeasure"/> representing the quotient.</returns>
        public DataRateMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this data rate by another data rate to get a ratio.
        /// </summary>
        /// <param name="other">The data rate to divide by.</param>
        /// <returns>The ratio between the two data rates.</returns>
        public double DivideBy(DataRateMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two data rate measurements.
        /// </summary>
        /// <param name="left">The first data rate.</param>
        /// <param name="right">The second data rate.</param>
        /// <returns>The sum of the two data rates.</returns>
        public static DataRateMeasure operator +(DataRateMeasure left, DataRateMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one data rate measurement from another.
        /// </summary>
        /// <param name="left">The data rate to subtract from.</param>
        /// <param name="right">The data rate to subtract.</param>
        /// <returns>The difference between the two data rates.</returns>
        public static DataRateMeasure operator -(DataRateMeasure left, DataRateMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a data rate measurement by a scalar.
        /// </summary>
        /// <param name="left">The data rate.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the data rate and scalar.</returns>
        public static DataRateMeasure operator *(DataRateMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a data rate measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The data rate.</param>
        /// <returns>The product of the scalar and data rate.</returns>
        public static DataRateMeasure operator *(double scalar, DataRateMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a data rate measurement by a scalar.
        /// </summary>
        /// <param name="left">The data rate.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the data rate and scalar.</returns>
        public static DataRateMeasure operator /(DataRateMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one data rate measurement by another.
        /// </summary>
        /// <param name="left">The dividend data rate.</param>
        /// <param name="right">The divisor data rate.</param>
        /// <returns>The ratio between the two data rates.</returns>
        public static double operator /(DataRateMeasure left, DataRateMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two data rate measurements are equal.
        /// </summary>
        /// <param name="left">The first data rate.</param>
        /// <param name="right">The second data rate.</param>
        /// <returns><c>true</c> if the data rates are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(DataRateMeasure left, DataRateMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two data rate measurements are not equal.
        /// </summary>
        /// <param name="left">The first data rate.</param>
        /// <param name="right">The second data rate.</param>
        /// <returns><c>true</c> if the data rates are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(DataRateMeasure left, DataRateMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one data rate measurement is greater than another.
        /// </summary>
        /// <param name="left">The first data rate.</param>
        /// <param name="right">The second data rate.</param>
        /// <returns><c>true</c> if the first data rate is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(DataRateMeasure left, DataRateMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one data rate measurement is less than another.
        /// </summary>
        /// <param name="left">The first data rate.</param>
        /// <param name="right">The second data rate.</param>
        /// <returns><c>true</c> if the first data rate is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(DataRateMeasure left, DataRateMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one data rate measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first data rate.</param>
        /// <param name="right">The second data rate.</param>
        /// <returns><c>true</c> if the first data rate is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(DataRateMeasure left, DataRateMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one data rate measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first data rate.</param>
        /// <param name="right">The second data rate.</param>
        /// <returns><c>true</c> if the first data rate is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(DataRateMeasure left, DataRateMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current data rate measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current data rate measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current data rate measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this data rate measurement.
        /// </summary>
        /// <returns>A hash code for the current data rate measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the data rate measurement.
        /// </summary>
        /// <returns>A string representing the data rate in bits per second.</returns>
        public override string ToString() => $"{BaseValue} b/s";
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

        /// <summary>Creates a data rate value expressed in bits per second.</summary>
        /// <param name="value">The value in bits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure BitsPerSecond(this double value) => new(value * BitPerSecond);

        /// <summary>Creates a data rate value expressed in kilobits per second.</summary>
        /// <param name="value">The value in kilobits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure KilobitsPerSecond(this double value) => new(value * KilobitPerSecond);

        /// <summary>Creates a data rate value expressed in kilobytes per second.</summary>
        /// <param name="value">The value in kilobytes per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure KilobytesPerSecond(this double value) => new(value * KilobytePerSecond);

        /// <summary>Creates a data rate value expressed in kibibits per second.</summary>
        /// <param name="value">The value in kibibits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure KibibitsPerSecond(this double value) => new(value * KibibitPerSecond);

        /// <summary>Creates a data rate value expressed in megabits per second.</summary>
        /// <param name="value">The value in megabits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure MegabitsPerSecond(this double value) => new(value * MegabitPerSecond);

        /// <summary>Creates a data rate value expressed in megabytes per second.</summary>
        /// <param name="value">The value in megabytes per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure MegabytesPerSecond(this double value) => new(value * MegabytePerSecond);

        /// <summary>Creates a data rate value expressed in mebibits per second.</summary>
        /// <param name="value">The value in mebibits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure MebibitsPerSecond(this double value) => new(value * MebibitPerSecond);

        /// <summary>Creates a data rate value expressed in gigabits per second.</summary>
        /// <param name="value">The value in gigabits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure GigabitsPerSecond(this double value) => new(value * GigabitPerSecond);

        /// <summary>Creates a data rate value expressed in gigabytes per second.</summary>
        /// <param name="value">The value in gigabytes per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure GigabytesPerSecond(this double value) => new(value * GigabytePerSecond);

        /// <summary>Creates a data rate value expressed in gibibits per second.</summary>
        /// <param name="value">The value in gibibits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure GibibitsPerSecond(this double value) => new(value * GibibitPerSecond);

        /// <summary>Creates a data rate value expressed in terabits per second.</summary>
        /// <param name="value">The value in terabits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure TerabitsPerSecond(this double value) => new(value * TerabitPerSecond);

        /// <summary>Creates a data rate value expressed in terabytes per second.</summary>
        /// <param name="value">The value in terabytes per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure TerabytesPerSecond(this double value) => new(value * TerabytePerSecond);

        /// <summary>Creates a data rate value expressed in tebibits per second.</summary>
        /// <param name="value">The value in tebibits per second.</param>
        /// <returns>A <see cref="DataRateMeasure"/> representing the data rate.</returns>
        public static DataRateMeasure TebibitsPerSecond(this double value) => new(value * TebibitPerSecond);

        /// <summary>Converts the data rate to bits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in bits per second.</returns>
        public static double ToBitsPerSecond(this DataRateMeasure m) => m.To(BitPerSecond);

        /// <summary>Converts the data rate to kilobits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in kilobits per second.</returns>
        public static double ToKilobitsPerSecond(this DataRateMeasure m) => m.To(KilobitPerSecond);

        /// <summary>Converts the data rate to kilobytes per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in kilobytes per second.</returns>
        public static double ToKilobytesPerSecond(this DataRateMeasure m) => m.To(KilobytePerSecond);

        /// <summary>Converts the data rate to kibibits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in kibibits per second.</returns>
        public static double ToKibibitsPerSecond(this DataRateMeasure m) => m.To(KibibitPerSecond);

        /// <summary>Converts the data rate to megabits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in megabits per second.</returns>
        public static double ToMegabitsPerSecond(this DataRateMeasure m) => m.To(MegabitPerSecond);

        /// <summary>Converts the data rate to megabytes per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in megabytes per second.</returns>
        public static double ToMegabytesPerSecond(this DataRateMeasure m) => m.To(MegabytePerSecond);

        /// <summary>Converts the data rate to mebibits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in mebibits per second.</returns>
        public static double ToMebibitsPerSecond(this DataRateMeasure m) => m.To(MebibitPerSecond);

        /// <summary>Converts the data rate to gigabits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in gigabits per second.</returns>
        public static double ToGigabitsPerSecond(this DataRateMeasure m) => m.To(GigabitPerSecond);

        /// <summary>Converts the data rate to gigabytes per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in gigabytes per second.</returns>
        public static double ToGigabytesPerSecond(this DataRateMeasure m) => m.To(GigabytePerSecond);

        /// <summary>Converts the data rate to gibibits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in gibibits per second.</returns>
        public static double ToGibibitsPerSecond(this DataRateMeasure m) => m.To(GibibitPerSecond);

        /// <summary>Converts the data rate to terabits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in terabits per second.</returns>
        public static double ToTerabitsPerSecond(this DataRateMeasure m) => m.To(TerabitPerSecond);

        /// <summary>Converts the data rate to terabytes per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in terabytes per second.</returns>
        public static double ToTerabytesPerSecond(this DataRateMeasure m) => m.To(TerabytePerSecond);

        /// <summary>Converts the data rate to tebibits per second.</summary>
        /// <param name="m">The data rate measurement.</param>
        /// <returns>The data rate in tebibits per second.</returns>
        public static double ToTebibitsPerSecond(this DataRateMeasure m) => m.To(TebibitPerSecond);
    }
}
