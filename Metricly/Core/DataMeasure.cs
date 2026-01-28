using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a data size value expressed in a base unit (byte).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="DataMeasure"/> class
    /// using a value expressed in bytes.
    /// </remarks>
    /// <param name="baseValue">The data size value in bytes.</param>
    public class DataMeasure(double baseValue) : IMeasure<DataMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in bytes.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of bytes corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new data size measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in bytes.</param>
        /// <returns>A new <see cref="DataMeasure"/> instance.</returns>
        public DataMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two data size measurements.
        /// </summary>
        /// <param name="other">The data size to add.</param>
        /// <returns>A new <see cref="DataMeasure"/> representing the sum.</returns>
        public DataMeasure Add(DataMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another data size measurement from this one.
        /// </summary>
        /// <param name="other">The data size to subtract.</param>
        /// <returns>A new <see cref="DataMeasure"/> representing the difference.</returns>
        public DataMeasure Subtract(DataMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the data size by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="DataMeasure"/> representing the product.</returns>
        public DataMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the data size by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="DataMeasure"/> representing the quotient.</returns>
        public DataMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this data size by another data size to get a ratio.
        /// </summary>
        /// <param name="other">The data size to divide by.</param>
        /// <returns>The ratio between the two data sizes.</returns>
        public double DivideBy(DataMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two data size measurements.
        /// </summary>
        /// <param name="left">The first data size.</param>
        /// <param name="right">The second data size.</param>
        /// <returns>The sum of the two data sizes.</returns>
        public static DataMeasure operator +(DataMeasure left, DataMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one data size measurement from another.
        /// </summary>
        /// <param name="left">The data size to subtract from.</param>
        /// <param name="right">The data size to subtract.</param>
        /// <returns>The difference between the two data sizes.</returns>
        public static DataMeasure operator -(DataMeasure left, DataMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a data size measurement by a scalar.
        /// </summary>
        /// <param name="left">The data size.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the data size and scalar.</returns>
        public static DataMeasure operator *(DataMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a data size measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The data size.</param>
        /// <returns>The product of the scalar and data size.</returns>
        public static DataMeasure operator *(double scalar, DataMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a data size measurement by a scalar.
        /// </summary>
        /// <param name="left">The data size.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the data size and scalar.</returns>
        public static DataMeasure operator /(DataMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one data size measurement by another.
        /// </summary>
        /// <param name="left">The dividend data size.</param>
        /// <param name="right">The divisor data size.</param>
        /// <returns>The ratio between the two data sizes.</returns>
        public static double operator /(DataMeasure left, DataMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two data size measurements are equal.
        /// </summary>
        /// <param name="left">The first data size.</param>
        /// <param name="right">The second data size.</param>
        /// <returns><c>true</c> if the data sizes are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(DataMeasure left, DataMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two data size measurements are not equal.
        /// </summary>
        /// <param name="left">The first data size.</param>
        /// <param name="right">The second data size.</param>
        /// <returns><c>true</c> if the data sizes are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(DataMeasure left, DataMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one data size measurement is greater than another.
        /// </summary>
        /// <param name="left">The first data size.</param>
        /// <param name="right">The second data size.</param>
        /// <returns><c>true</c> if the first data size is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(DataMeasure left, DataMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one data size measurement is less than another.
        /// </summary>
        /// <param name="left">The first data size.</param>
        /// <param name="right">The second data size.</param>
        /// <returns><c>true</c> if the first data size is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(DataMeasure left, DataMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one data size measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first data size.</param>
        /// <param name="right">The second data size.</param>
        /// <returns><c>true</c> if the first data size is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(DataMeasure left, DataMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one data size measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first data size.</param>
        /// <param name="right">The second data size.</param>
        /// <returns><c>true</c> if the first data size is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(DataMeasure left, DataMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current data size measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current data size measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current data size measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this data size measurement.
        /// </summary>
        /// <returns>A hash code for the current data size measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the data size measurement.
        /// </summary>
        /// <returns>A string representing the data size in bytes.</returns>
        public override string ToString() => $"{BaseValue} B";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="DataMeasure"/> values.
    /// </summary>
    public static class DataSizeExtensions
    {
        private const double _Byte = 1.0;
        private const double _KB = 1_000.0;
        private const double _MB = 1_000_000.0;
        private const double _GB = 1_000_000_000.0;
        private const double _TB = 1_000_000_000_000.0;
        private const double _PB = 1_000_000_000_000_000.0;
        private const double _EB = 1_000_000_000_000_000_000.0;
        private const double _ZB = 1_000_000_000_000_000_000_000.0;
        private const double _YB = 1_000_000_000_000_000_000_000_000.0;
        private const double _KiB = 1_024.0;
        private const double _MiB = 1_048_576.0;
        private const double _GiB = 1_073_741_824.0;
        private const double _TiB = 1_099_511_627_776.0;
        private const double _PiB = 1_125_899_906_842_624.0;
        private const double _EiB = 1_152_921_504_606_846_976.0;
        private const double _ZiB = 1.1805916207174113e21;
        private const double _YiB = 1.2089258196146292e24;

        /// <summary>Creates a data size value expressed in bytes (B).</summary>
        /// <param name="value">The value in bytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the given number of bytes.</returns>
        public static DataMeasure B(this double value) => new(value * _Byte);

        /// <summary>Creates a data size value expressed in kilobytes (KB, decimal).</summary>
        /// <param name="value">The value in kilobytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure KB(this double value) => new(value * _KB);

        /// <summary>Creates a data size value expressed in megabytes (MB, decimal).</summary>
        /// <param name="value">The value in megabytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure MB(this double value) => new(value * _MB);

        /// <summary>Creates a data size value expressed in gigabytes (GB, decimal).</summary>
        /// <param name="value">The value in gigabytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure GB(this double value) => new(value * _GB);

        /// <summary>Creates a data size value expressed in terabytes (TB, decimal).</summary>
        /// <param name="value">The value in terabytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure TB(this double value) => new(value * _TB);

        /// <summary>Creates a data size value expressed in petabytes (PB, decimal).</summary>
        /// <param name="value">The value in petabytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure PB(this double value) => new(value * _PB);

        /// <summary>Creates a data size value expressed in exabytes (EB, decimal).</summary>
        /// <param name="value">The value in exabytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure EB(this double value) => new(value * _EB);

        /// <summary>Creates a data size value expressed in zettabytes (ZB, decimal).</summary>
        /// <param name="value">The value in zettabytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure ZB(this double value) => new(value * _ZB);

        /// <summary>Creates a data size value expressed in yottabytes (YB, decimal).</summary>
        /// <param name="value">The value in yottabytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure YB(this double value) => new(value * _YB);

        /// <summary>Creates a data size value expressed in kibibytes (KiB, binary).</summary>
        /// <param name="value">The value in kibibytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure KiB(this double value) => new(value * _KiB);

        /// <summary>Creates a data size value expressed in mebibytes (MiB, binary).</summary>
        /// <param name="value">The value in mebibytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure MiB(this double value) => new(value * _MiB);

        /// <summary>Creates a data size value expressed in gibibytes (GiB, binary).</summary>
        /// <param name="value">The value in gibibytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure GiB(this double value) => new(value * _GiB);

        /// <summary>Creates a data size value expressed in tebibytes (TiB, binary).</summary>
        /// <param name="value">The value in tebibytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure TiB(this double value) => new(value * _TiB);

        /// <summary>Creates a data size value expressed in pebibytes (PiB, binary).</summary>
        /// <param name="value">The value in pebibytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure PiB(this double value) => new(value * _PiB);

        /// <summary>Creates a data size value expressed in exbibytes (EiB, binary).</summary>
        /// <param name="value">The value in exbibytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure EiB(this double value) => new(value * _EiB);

        /// <summary>Creates a data size value expressed in zebibytes (ZiB, binary).</summary>
        /// <param name="value">The value in zebibytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure ZiB(this double value) => new(value * _ZiB);

        /// <summary>Creates a data size value expressed in yobibytes (YiB, binary).</summary>
        /// <param name="value">The value in yobibytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the data size.</returns>
        public static DataMeasure YiB(this double value) => new(value * _YiB);

        /// <summary>Converts the data size to bytes (B).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in bytes.</returns>
        public static double ToB(this DataMeasure d) => d.To(_Byte);

        /// <summary>Converts the data size to kilobytes (KB, decimal).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in kilobytes.</returns>
        public static double ToKB(this DataMeasure d) => d.To(_KB);

        /// <summary>Converts the data size to megabytes (MB, decimal).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in megabytes.</returns>
        public static double ToMB(this DataMeasure d) => d.To(_MB);

        /// <summary>Converts the data size to gigabytes (GB, decimal).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in gigabytes.</returns>
        public static double ToGB(this DataMeasure d) => d.To(_GB);

        /// <summary>Converts the data size to terabytes (TB, decimal).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in terabytes.</returns>
        public static double ToTB(this DataMeasure d) => d.To(_TB);

        /// <summary>Converts the data size to petabytes (PB, decimal).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in petabytes.</returns>
        public static double ToPB(this DataMeasure d) => d.To(_PB);

        /// <summary>Converts the data size to exabytes (EB, decimal).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in exabytes.</returns>
        public static double ToEB(this DataMeasure d) => d.To(_EB);

        /// <summary>Converts the data size to zettabytes (ZB, decimal).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in zettabytes.</returns>
        public static double ToZB(this DataMeasure d) => d.To(_ZB);

        /// <summary>Converts the data size to yottabytes (YB, decimal).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in yottabytes.</returns>
        public static double ToYB(this DataMeasure d) => d.To(_YB);

        /// <summary>Converts the data size to kibibytes (KiB, binary).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in kibibytes.</returns>
        public static double ToKiB(this DataMeasure d) => d.To(_KiB);

        /// <summary>Converts the data size to mebibytes (MiB, binary).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in mebibytes.</returns>
        public static double ToMiB(this DataMeasure d) => d.To(_MiB);

        /// <summary>Converts the data size to gibibytes (GiB, binary).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in gibibytes.</returns>
        public static double ToGiB(this DataMeasure d) => d.To(_GiB);

        /// <summary>Converts the data size to tebibytes (TiB, binary).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in tebibytes.</returns>
        public static double ToTiB(this DataMeasure d) => d.To(_TiB);

        /// <summary>Converts the data size to pebibytes (PiB, binary).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in pebibytes.</returns>
        public static double ToPiB(this DataMeasure d) => d.To(_PiB);

        /// <summary>Converts the data size to exbibytes (EiB, binary).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in exbibytes.</returns>
        public static double ToEiB(this DataMeasure d) => d.To(_EiB);

        /// <summary>Converts the data size to zebibytes (ZiB, binary).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in zebibytes.</returns>
        public static double ToZiB(this DataMeasure d) => d.To(_ZiB);

        /// <summary>Converts the data size to yobibytes (YiB, binary).</summary>
        /// <param name="d">The data size measurement.</param>
        /// <returns>The data size in yobibytes.</returns>
        public static double ToYiB(this DataMeasure d) => d.To(_YiB);
    }
}
