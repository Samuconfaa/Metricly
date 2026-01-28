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
    public class DataMeasure(double baseValue)
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
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="DataMeasure"/> values.
    /// </summary>
    public static class DataSizeExtensions
    {
        // -------------------------
        // Decimal multiples 
        // -------------------------
        private const double _Byte = 1.0;
        private const double _KB = 1_000.0;
        private const double _MB = 1_000_000.0;
        private const double _GB = 1_000_000_000.0;
        private const double _TB = 1_000_000_000_000.0;
        private const double _PB = 1_000_000_000_000_000.0;
        private const double _EB = 1_000_000_000_000_000_000.0;
        private const double _ZB = 1_000_000_000_000_000_000_000.0;
        private const double _YB = 1_000_000_000_000_000_000_000_000.0;

        // -------------------------
        // Binary multiples 
        // -------------------------
        private const double _KiB = 1_024.0;
        private const double _MiB = 1_048_576.0;              // 1024^2
        private const double _GiB = 1_073_741_824.0;          // 1024^3
        private const double _TiB = 1_099_511_627_776.0;      // 1024^4
        private const double _PiB = 1_125_899_906_842_624.0;  // 1024^5
        private const double _EiB = 1_152_921_504_606_846_976.0; // 1024^6
        private const double _ZiB = 1.1805916207174113e21;        // 1024^7
        private const double _YiB = 1.2089258196146292e24;        // 1024^8

        // -------------------------
        // Factory methods 
        // -------------------------

        /// <summary>Creates a data size value expressed in bytes (B).</summary>
        /// <param name="value">The value in bytes.</param>
        /// <returns>A <see cref="DataMeasure"/> representing the given number of bytes.</returns>
        public static DataMeasure B(this double value) => new(value * _Byte);

        /// <summary>Creates a data size value expressed in kilobytes (KB, decimal).</summary>
        public static DataMeasure KB(this double value) => new(value * _KB);

        /// <summary>Creates a data size value expressed in megabytes (MB, decimal).</summary>
        public static DataMeasure MB(this double value) => new(value * _MB);

        /// <summary>Creates a data size value expressed in gigabytes (GB, decimal).</summary>
        public static DataMeasure GB(this double value) => new(value * _GB);

        /// <summary>Creates a data size value expressed in terabytes (TB, decimal).</summary>
        public static DataMeasure TB(this double value) => new(value * _TB);

        /// <summary>Creates a data size value expressed in petabytes (PB, decimal).</summary>
        public static DataMeasure PB(this double value) => new(value * _PB);

        /// <summary>Creates a data size value expressed in exabytes (EB, decimal).</summary>
        public static DataMeasure EB(this double value) => new(value * _EB);

        /// <summary>Creates a data size value expressed in zettabytes (ZB, decimal).</summary>
        public static DataMeasure ZB(this double value) => new(value * _ZB);

        /// <summary>Creates a data size value expressed in yottabytes (YB, decimal).</summary>
        public static DataMeasure YB(this double value) => new(value * _YB);

        // -------------------------
        // Factory methods 
        // -------------------------

        /// <summary>Creates a data size value expressed in kibibytes (KiB, binary).</summary>
        public static DataMeasure KiB(this double value) => new(value * _KiB);

        /// <summary>Creates a data size value expressed in mebibytes (MiB, binary).</summary>
        public static DataMeasure MiB(this double value) => new(value * _MiB);

        /// <summary>Creates a data size value expressed in gibibytes (GiB, binary).</summary>
        public static DataMeasure GiB(this double value) => new(value * _GiB);

        /// <summary>Creates a data size value expressed in tebibytes (TiB, binary).</summary>
        public static DataMeasure TiB(this double value) => new(value * _TiB);

        /// <summary>Creates a data size value expressed in pebibytes (PiB, binary).</summary>
        public static DataMeasure PiB(this double value) => new(value * _PiB);

        /// <summary>Creates a data size value expressed in exbibytes (EiB, binary).</summary>
        public static DataMeasure EiB(this double value) => new(value * _EiB);

        /// <summary>Creates a data size value expressed in zebibytes (ZiB, binary).</summary>
        public static DataMeasure ZiB(this double value) => new(value * _ZiB);

        /// <summary>Creates a data size value expressed in yobibytes (YiB, binary).</summary>
        public static DataMeasure YiB(this double value) => new(value * _YiB);

        // -------------------------
        // Conversion methods 
        // -------------------------

        /// <summary>Converts the data size to bytes (B).</summary>
        public static double ToB(this DataMeasure d) => d.To(_Byte);

        /// <summary>Converts the data size to kilobytes (KB, decimal).</summary>
        public static double ToKB(this DataMeasure d) => d.To(_KB);

        /// <summary>Converts the data size to megabytes (MB, decimal).</summary>
        public static double ToMB(this DataMeasure d) => d.To(_MB);

        /// <summary>Converts the data size to gigabytes (GB, decimal).</summary>
        public static double ToGB(this DataMeasure d) => d.To(_GB);

        /// <summary>Converts the data size to terabytes (TB, decimal).</summary>
        public static double ToTB(this DataMeasure d) => d.To(_TB);

        /// <summary>Converts the data size to petabytes (PB, decimal).</summary>
        public static double ToPB(this DataMeasure d) => d.To(_PB);

        /// <summary>Converts the data size to exabytes (EB, decimal).</summary>
        public static double ToEB(this DataMeasure d) => d.To(_EB);

        /// <summary>Converts the data size to zettabytes (ZB, decimal).</summary>
        public static double ToZB(this DataMeasure d) => d.To(_ZB);

        /// <summary>Converts the data size to yottabytes (YB, decimal).</summary>
        public static double ToYB(this DataMeasure d) => d.To(_YB);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the data size to kibibytes (KiB, binary).</summary>
        public static double ToKiB(this DataMeasure d) => d.To(_KiB);

        /// <summary>Converts the data size to mebibytes (MiB, binary).</summary>
        public static double ToMiB(this DataMeasure d) => d.To(_MiB);

        /// <summary>Converts the data size to gibibytes (GiB, binary).</summary>
        public static double ToGiB(this DataMeasure d) => d.To(_GiB);

        /// <summary>Converts the data size to tebibytes (TiB, binary).</summary>
        public static double ToTiB(this DataMeasure d) => d.To(_TiB);

        /// <summary>Converts the data size to pebibytes (PiB, binary).</summary>
        public static double ToPiB(this DataMeasure d) => d.To(_PiB);

        /// <summary>Converts the data size to exbibytes (EiB, binary).</summary>
        public static double ToEiB(this DataMeasure d) => d.To(_EiB);

        /// <summary>Converts the data size to zebibytes (ZiB, binary).</summary>
        public static double ToZiB(this DataMeasure d) => d.To(_ZiB);

        /// <summary>Converts the data size to yobibytes (YiB, binary).</summary>
        public static double ToYiB(this DataMeasure d) => d.To(_YiB);
    }
}
