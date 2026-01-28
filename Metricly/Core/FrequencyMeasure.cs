using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a frequency value expressed in a base unit (Hertz).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FrequencyMeasure"/> class
    /// using a value expressed in Hertz.
    /// </remarks>
    /// <param name="baseValue">The frequency value in Hertz.</param>
    public class FrequencyMeasure(double baseValue) : IMeasure<FrequencyMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in Hertz.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of Hertz corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new frequency measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in Hertz.</param>
        /// <returns>A new <see cref="FrequencyMeasure"/> instance.</returns>
        public FrequencyMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two frequency measurements.
        /// </summary>
        /// <param name="other">The frequency to add.</param>
        /// <returns>A new <see cref="FrequencyMeasure"/> representing the sum.</returns>
        public FrequencyMeasure Add(FrequencyMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another frequency measurement from this one.
        /// </summary>
        /// <param name="other">The frequency to subtract.</param>
        /// <returns>A new <see cref="FrequencyMeasure"/> representing the difference.</returns>
        public FrequencyMeasure Subtract(FrequencyMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the frequency by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="FrequencyMeasure"/> representing the product.</returns>
        public FrequencyMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the frequency by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="FrequencyMeasure"/> representing the quotient.</returns>
        public FrequencyMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this frequency by another frequency to get a ratio.
        /// </summary>
        /// <param name="other">The frequency to divide by.</param>
        /// <returns>The ratio between the two frequencies.</returns>
        public double DivideBy(FrequencyMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two frequency measurements.
        /// </summary>
        /// <param name="left">The first frequency.</param>
        /// <param name="right">The second frequency.</param>
        /// <returns>The sum of the two frequencies.</returns>
        public static FrequencyMeasure operator +(FrequencyMeasure left, FrequencyMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one frequency measurement from another.
        /// </summary>
        /// <param name="left">The frequency to subtract from.</param>
        /// <param name="right">The frequency to subtract.</param>
        /// <returns>The difference between the two frequencies.</returns>
        public static FrequencyMeasure operator -(FrequencyMeasure left, FrequencyMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a frequency measurement by a scalar.
        /// </summary>
        /// <param name="left">The frequency.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the frequency and scalar.</returns>
        public static FrequencyMeasure operator *(FrequencyMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a frequency measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The frequency.</param>
        /// <returns>The product of the scalar and frequency.</returns>
        public static FrequencyMeasure operator *(double scalar, FrequencyMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a frequency measurement by a scalar.
        /// </summary>
        /// <param name="left">The frequency.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the frequency and scalar.</returns>
        public static FrequencyMeasure operator /(FrequencyMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one frequency measurement by another.
        /// </summary>
        /// <param name="left">The dividend frequency.</param>
        /// <param name="right">The divisor frequency.</param>
        /// <returns>The ratio between the two frequencies.</returns>
        public static double operator /(FrequencyMeasure left, FrequencyMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two frequency measurements are equal.
        /// </summary>
        /// <param name="left">The first frequency.</param>
        /// <param name="right">The second frequency.</param>
        /// <returns><c>true</c> if the frequencies are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(FrequencyMeasure left, FrequencyMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two frequency measurements are not equal.
        /// </summary>
        /// <param name="left">The first frequency.</param>
        /// <param name="right">The second frequency.</param>
        /// <returns><c>true</c> if the frequencies are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(FrequencyMeasure left, FrequencyMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one frequency measurement is greater than another.
        /// </summary>
        /// <param name="left">The first frequency.</param>
        /// <param name="right">The second frequency.</param>
        /// <returns><c>true</c> if the first frequency is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(FrequencyMeasure left, FrequencyMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one frequency measurement is less than another.
        /// </summary>
        /// <param name="left">The first frequency.</param>
        /// <param name="right">The second frequency.</param>
        /// <returns><c>true</c> if the first frequency is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(FrequencyMeasure left, FrequencyMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one frequency measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first frequency.</param>
        /// <param name="right">The second frequency.</param>
        /// <returns><c>true</c> if the first frequency is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(FrequencyMeasure left, FrequencyMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one frequency measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first frequency.</param>
        /// <param name="right">The second frequency.</param>
        /// <returns><c>true</c> if the first frequency is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(FrequencyMeasure left, FrequencyMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current frequency measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current frequency measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current frequency measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this frequency measurement.
        /// </summary>
        /// <returns>A hash code for the current frequency measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the frequency measurement.
        /// </summary>
        /// <returns>A string representing the frequency in Hertz.</returns>
        public override string ToString() => $"{BaseValue} Hz";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="FrequencyMeasure"/> values.
    /// </summary>
    public static class FrequencyExtensions
    {
        private const double _YoctoHertz = 1e-24;
        private const double _ZeptoHertz = 1e-21;
        private const double _AttoHertz = 1e-18;
        private const double _FemtoHertz = 1e-15;
        private const double _PicoHertz = 1e-12;
        private const double _NanoHertz = 1e-9;
        private const double _MicroHertz = 1e-6;
        private const double _MilliHertz = 1e-3;
        private const double _CentiHertz = 1e-2;
        private const double _DeciHertz = 1e-1;
        private const double _Hertz = 1.0;
        private const double _DecaHertz = 10.0;
        private const double _HectoHertz = 100.0;
        private const double _KiloHertz = 1_000.0;
        private const double _MegaHertz = 1_000_000.0;
        private const double _GigaHertz = 1_000_000_000.0;
        private const double _TeraHertz = 1_000_000_000_000.0;
        private const double _PetaHertz = 1_000_000_000_000_000.0;
        private const double _ExaHertz = 1_000_000_000_000_000_000.0;
        private const double _ZettaHertz = 1_000_000_000_000_000_000_000.0;
        private const double _YottaHertz = 1_000_000_000_000_000_000_000_000.0;

        /// <summary>Creates a frequency value expressed in yoctohertz.</summary>
        /// <param name="value">The value in yoctohertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure YoctoHertz(this double value) => new(value * _YoctoHertz);

        /// <summary>Creates a frequency value expressed in zeptohertz.</summary>
        /// <param name="value">The value in zeptohertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure ZeptoHertz(this double value) => new(value * _ZeptoHertz);

        /// <summary>Creates a frequency value expressed in attohertz.</summary>
        /// <param name="value">The value in attohertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure AttoHertz(this double value) => new(value * _AttoHertz);

        /// <summary>Creates a frequency value expressed in femtohertz.</summary>
        /// <param name="value">The value in femtohertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure FemtoHertz(this double value) => new(value * _FemtoHertz);

        /// <summary>Creates a frequency value expressed in picohertz.</summary>
        /// <param name="value">The value in picohertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure PicoHertz(this double value) => new(value * _PicoHertz);

        /// <summary>Creates a frequency value expressed in nanohertz.</summary>
        /// <param name="value">The value in nanohertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure NanoHertz(this double value) => new(value * _NanoHertz);

        /// <summary>Creates a frequency value expressed in microhertz.</summary>
        /// <param name="value">The value in microhertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure MicroHertz(this double value) => new(value * _MicroHertz);

        /// <summary>Creates a frequency value expressed in millihertz.</summary>
        /// <param name="value">The value in millihertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure MilliHertz(this double value) => new(value * _MilliHertz);

        /// <summary>Creates a frequency value expressed in centihertz.</summary>
        /// <param name="value">The value in centihertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure CentiHertz(this double value) => new(value * _CentiHertz);

        /// <summary>Creates a frequency value expressed in decihertz.</summary>
        /// <param name="value">The value in decihertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure DeciHertz(this double value) => new(value * _DeciHertz);

        /// <summary>Creates a frequency value expressed in hertz.</summary>
        /// <param name="value">The value in hertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure Hertz(this double value) => new(value * _Hertz);

        /// <summary>Creates a frequency value expressed in dekahertz.</summary>
        /// <param name="value">The value in dekahertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure DecaHertz(this double value) => new(value * _DecaHertz);

        /// <summary>Creates a frequency value expressed in hectohertz.</summary>
        /// <param name="value">The value in hectohertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure HectoHertz(this double value) => new(value * _HectoHertz);

        /// <summary>Creates a frequency value expressed in kilohertz.</summary>
        /// <param name="value">The value in kilohertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure KiloHertz(this double value) => new(value * _KiloHertz);

        /// <summary>Creates a frequency value expressed in megahertz.</summary>
        /// <param name="value">The value in megahertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure MegaHertz(this double value) => new(value * _MegaHertz);

        /// <summary>Creates a frequency value expressed in gigahertz.</summary>
        /// <param name="value">The value in gigahertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure GigaHertz(this double value) => new(value * _GigaHertz);

        /// <summary>Creates a frequency value expressed in terahertz.</summary>
        /// <param name="value">The value in terahertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure TeraHertz(this double value) => new(value * _TeraHertz);

        /// <summary>Creates a frequency value expressed in petahertz.</summary>
        /// <param name="value">The value in petahertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure PetaHertz(this double value) => new(value * _PetaHertz);

        /// <summary>Creates a frequency value expressed in exahertz.</summary>
        /// <param name="value">The value in exahertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure ExaHertz(this double value) => new(value * _ExaHertz);

        /// <summary>Creates a frequency value expressed in zettahertz.</summary>
        /// <param name="value">The value in zettahertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure ZettaHertz(this double value) => new(value * _ZettaHertz);

        /// <summary>Creates a frequency value expressed in yottahertz.</summary>
        /// <param name="value">The value in yottahertz.</param>
        /// <returns>A <see cref="FrequencyMeasure"/> representing the frequency.</returns>
        public static FrequencyMeasure YottaHertz(this double value) => new(value * _YottaHertz);

        /// <summary>Converts the frequency to yoctohertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in yoctohertz.</returns>
        public static double ToYoctoHertz(this FrequencyMeasure f) => f.To(_YoctoHertz);

        /// <summary>Converts the frequency to zeptohertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in zeptohertz.</returns>
        public static double ToZeptoHertz(this FrequencyMeasure f) => f.To(_ZeptoHertz);

        /// <summary>Converts the frequency to attohertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in attohertz.</returns>
        public static double ToAttoHertz(this FrequencyMeasure f) => f.To(_AttoHertz);

        /// <summary>Converts the frequency to femtohertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in femtohertz.</returns>
        public static double ToFemtoHertz(this FrequencyMeasure f) => f.To(_FemtoHertz);

        /// <summary>Converts the frequency to picohertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in picohertz.</returns>
        public static double ToPicoHertz(this FrequencyMeasure f) => f.To(_PicoHertz);

        /// <summary>Converts the frequency to nanohertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in nanohertz.</returns>
        public static double ToNanoHertz(this FrequencyMeasure f) => f.To(_NanoHertz);

        /// <summary>Converts the frequency to microhertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in microhertz.</returns>
        public static double ToMicroHertz(this FrequencyMeasure f) => f.To(_MicroHertz);

        /// <summary>Converts the frequency to millihertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in millihertz.</returns>
        public static double ToMilliHertz(this FrequencyMeasure f) => f.To(_MilliHertz);

        /// <summary>Converts the frequency to centihertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in centihertz.</returns>
        public static double ToCentiHertz(this FrequencyMeasure f) => f.To(_CentiHertz);

        /// <summary>Converts the frequency to decihertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in decihertz.</returns>
        public static double ToDeciHertz(this FrequencyMeasure f) => f.To(_DeciHertz);

        /// <summary>Converts the frequency to hertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in hertz.</returns>
        public static double ToHertz(this FrequencyMeasure f) => f.To(_Hertz);

        /// <summary>Converts the frequency to dekahertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in dekahertz.</returns>
        public static double ToDecaHertz(this FrequencyMeasure f) => f.To(_DecaHertz);

        /// <summary>Converts the frequency to hectohertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in hectohertz.</returns>
        public static double ToHectoHertz(this FrequencyMeasure f) => f.To(_HectoHertz);

        /// <summary>Converts the frequency to kilohertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in kilohertz.</returns>
        public static double ToKiloHertz(this FrequencyMeasure f) => f.To(_KiloHertz);

        /// <summary>Converts the frequency to megahertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in megahertz.</returns>
        public static double ToMegaHertz(this FrequencyMeasure f) => f.To(_MegaHertz);

        /// <summary>Converts the frequency to gigahertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in gigahertz.</returns>
        public static double ToGigaHertz(this FrequencyMeasure f) => f.To(_GigaHertz);

        /// <summary>Converts the frequency to terahertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in terahertz.</returns>
        public static double ToTeraHertz(this FrequencyMeasure f) => f.To(_TeraHertz);

        /// <summary>Converts the frequency to petahertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in petahertz.</returns>
        public static double ToPetaHertz(this FrequencyMeasure f) => f.To(_PetaHertz);

        /// <summary>Converts the frequency to exahertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in exahertz.</returns>
        public static double ToExaHertz(this FrequencyMeasure f) => f.To(_ExaHertz);

        /// <summary>Converts the frequency to zettahertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in zettahertz.</returns>
        public static double ToZettaHertz(this FrequencyMeasure f) => f.To(_ZettaHertz);

        /// <summary>Converts the frequency to yottahertz.</summary>
        /// <param name="f">The frequency measurement.</param>
        /// <returns>The frequency in yottahertz.</returns>
        public static double ToYottaHertz(this FrequencyMeasure f) => f.To(_YottaHertz);
    }
}
