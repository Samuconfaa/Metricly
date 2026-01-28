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
    public class FrequencyMeasure(double baseValue)
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
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="FrequencyMeasure"/> values.
    /// </summary>
    public static class FrequencyExtensions
    {
        // -------------------------
        // Conversion factors 
        // -------------------------

        /// <summary>One yoctohertz (10^-24 Hz).</summary>
        private const double _YoctoHertz = 1e-24;

        /// <summary>One zeptohertz (10^-21 Hz).</summary>
        private const double _ZeptoHertz = 1e-21;

        /// <summary>One attohertz (10^-18 Hz).</summary>
        private const double _AttoHertz = 1e-18;

        /// <summary>One femtohertz (10^-15 Hz).</summary>
        private const double _FemtoHertz = 1e-15;

        /// <summary>One picohertz (10^-12 Hz).</summary>
        private const double _PicoHertz = 1e-12;

        /// <summary>One nanohertz (10^-9 Hz).</summary>
        private const double _NanoHertz = 1e-9;

        /// <summary>One microhertz (10^-6 Hz).</summary>
        private const double _MicroHertz = 1e-6;

        /// <summary>One millihertz (10^-3 Hz).</summary>
        private const double _MilliHertz = 1e-3;

        /// <summary>One centihertz (10^-2 Hz).</summary>
        private const double _CentiHertz = 1e-2;

        /// <summary>One decihertz (10^-1 Hz).</summary>
        private const double _DeciHertz = 1e-1;

        /// <summary>One hertz (Hz).</summary>
        private const double _Hertz = 1.0;

        /// <summary>One dekahertz (10^1 Hz).</summary>
        private const double _DecaHertz = 10.0;

        /// <summary>One hectohertz (10^2 Hz).</summary>
        private const double _HectoHertz = 100.0;

        /// <summary>One kilohertz (10^3 Hz).</summary>
        private const double _KiloHertz = 1_000.0;

        /// <summary>One megahertz (10^6 Hz).</summary>
        private const double _MegaHertz = 1_000_000.0;

        /// <summary>One gigahertz (10^9 Hz).</summary>
        private const double _GigaHertz = 1_000_000_000.0;

        /// <summary>One terahertz (10^12 Hz).</summary>
        private const double _TeraHertz = 1_000_000_000_000.0;

        /// <summary>One petahertz (10^15 Hz).</summary>
        private const double _PetaHertz = 1_000_000_000_000_000.0;

        /// <summary>One exahertz (10^18 Hz).</summary>
        private const double _ExaHertz = 1_000_000_000_000_000_000.0;

        /// <summary>One zettahertz (10^21 Hz).</summary>
        private const double _ZettaHertz = 1_000_000_000_000_000_000_000.0;

        /// <summary>One yottahertz (10^24 Hz).</summary>
        private const double _YottaHertz = 1_000_000_000_000_000_000_000_000.0;

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a frequency value expressed in yoctohertz.</summary>
        public static FrequencyMeasure YoctoHertz(this double value) => new(value * _YoctoHertz);

        /// <summary>Creates a frequency value expressed in zeptohertz.</summary>
        public static FrequencyMeasure ZeptoHertz(this double value) => new(value * _ZeptoHertz);

        /// <summary>Creates a frequency value expressed in attohertz.</summary>
        public static FrequencyMeasure AttoHertz(this double value) => new(value * _AttoHertz);

        /// <summary>Creates a frequency value expressed in femtohertz.</summary>
        public static FrequencyMeasure FemtoHertz(this double value) => new(value * _FemtoHertz);

        /// <summary>Creates a frequency value expressed in picohertz.</summary>
        public static FrequencyMeasure PicoHertz(this double value) => new(value * _PicoHertz);

        /// <summary>Creates a frequency value expressed in nanohertz.</summary>
        public static FrequencyMeasure NanoHertz(this double value) => new(value * _NanoHertz);

        /// <summary>Creates a frequency value expressed in microhertz.</summary>
        public static FrequencyMeasure MicroHertz(this double value) => new(value * _MicroHertz);

        /// <summary>Creates a frequency value expressed in millihertz.</summary>
        public static FrequencyMeasure MilliHertz(this double value) => new(value * _MilliHertz);

        /// <summary>Creates a frequency value expressed in centihertz.</summary>
        public static FrequencyMeasure CentiHertz(this double value) => new(value * _CentiHertz);

        /// <summary>Creates a frequency value expressed in decihertz.</summary>
        public static FrequencyMeasure DeciHertz(this double value) => new(value * _DeciHertz);

        /// <summary>Creates a frequency value expressed in hertz.</summary>
        public static FrequencyMeasure Hertz(this double value) => new(value * _Hertz);

        /// <summary>Creates a frequency value expressed in dekahertz.</summary>
        public static FrequencyMeasure DecaHertz(this double value) => new(value * _DecaHertz);

        /// <summary>Creates a frequency value expressed in hectohertz.</summary>
        public static FrequencyMeasure HectoHertz(this double value) => new(value * _HectoHertz);

        /// <summary>Creates a frequency value expressed in kilohertz.</summary>
        public static FrequencyMeasure KiloHertz(this double value) => new(value * _KiloHertz);

        /// <summary>Creates a frequency value expressed in megahertz.</summary>
        public static FrequencyMeasure MegaHertz(this double value) => new(value * _MegaHertz);

        /// <summary>Creates a frequency value expressed in gigahertz.</summary>
        public static FrequencyMeasure GigaHertz(this double value) => new(value * _GigaHertz);

        /// <summary>Creates a frequency value expressed in terahertz.</summary>
        public static FrequencyMeasure TeraHertz(this double value) => new(value * _TeraHertz);

        /// <summary>Creates a frequency value expressed in petahertz.</summary>
        public static FrequencyMeasure PetaHertz(this double value) => new(value * _PetaHertz);

        /// <summary>Creates a frequency value expressed in exahertz.</summary>
        public static FrequencyMeasure ExaHertz(this double value) => new(value * _ExaHertz);

        /// <summary>Creates a frequency value expressed in zettahertz.</summary>
        public static FrequencyMeasure ZettaHertz(this double value) => new(value * _ZettaHertz);

        /// <summary>Creates a frequency value expressed in yottahertz.</summary>
        public static FrequencyMeasure YottaHertz(this double value) => new(value * _YottaHertz);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the frequency to yoctohertz.</summary>
        public static double ToYoctoHertz(this FrequencyMeasure f) => f.To(_YoctoHertz);

        /// <summary>Converts the frequency to zeptohertz.</summary>
        public static double ToZeptoHertz(this FrequencyMeasure f) => f.To(_ZeptoHertz);

        /// <summary>Converts the frequency to attohertz.</summary>
        public static double ToAttoHertz(this FrequencyMeasure f) => f.To(_AttoHertz);

        /// <summary>Converts the frequency to femtohertz.</summary>
        public static double ToFemtoHertz(this FrequencyMeasure f) => f.To(_FemtoHertz);

        /// <summary>Converts the frequency to picohertz.</summary>
        public static double ToPicoHertz(this FrequencyMeasure f) => f.To(_PicoHertz);

        /// <summary>Converts the frequency to nanohertz.</summary>
        public static double ToNanoHertz(this FrequencyMeasure f) => f.To(_NanoHertz);

        /// <summary>Converts the frequency to microhertz.</summary>
        public static double ToMicroHertz(this FrequencyMeasure f) => f.To(_MicroHertz);

        /// <summary>Converts the frequency to millihertz.</summary>
        public static double ToMilliHertz(this FrequencyMeasure f) => f.To(_MilliHertz);

        /// <summary>Converts the frequency to centihertz.</summary>
        public static double ToCentiHertz(this FrequencyMeasure f) => f.To(_CentiHertz);

        /// <summary>Converts the frequency to decihertz.</summary>
        public static double ToDeciHertz(this FrequencyMeasure f) => f.To(_DeciHertz);

        /// <summary>Converts the frequency to hertz.</summary>
        public static double ToHertz(this FrequencyMeasure f) => f.To(_Hertz);

        /// <summary>Converts the frequency to dekahertz.</summary>
        public static double ToDecaHertz(this FrequencyMeasure f) => f.To(_DecaHertz);

        /// <summary>Converts the frequency to hectohertz.</summary>
        public static double ToHectoHertz(this FrequencyMeasure f) => f.To(_HectoHertz);

        /// <summary>Converts the frequency to kilohertz.</summary>
        public static double ToKiloHertz(this FrequencyMeasure f) => f.To(_KiloHertz);

        /// <summary>Converts the frequency to megahertz.</summary>
        public static double ToMegaHertz(this FrequencyMeasure f) => f.To(_MegaHertz);

        /// <summary>Converts the frequency to gigahertz.</summary>
        public static double ToGigaHertz(this FrequencyMeasure f) => f.To(_GigaHertz);

        /// <summary>Converts the frequency to terahertz.</summary>
        public static double ToTeraHertz(this FrequencyMeasure f) => f.To(_TeraHertz);

        /// <summary>Converts the frequency to petahertz.</summary>
        public static double ToPetaHertz(this FrequencyMeasure f) => f.To(_PetaHertz);

        /// <summary>Converts the frequency to exahertz.</summary>
        public static double ToExaHertz(this FrequencyMeasure f) => f.To(_ExaHertz);

        /// <summary>Converts the frequency to zettahertz.</summary>
        public static double ToZettaHertz(this FrequencyMeasure f) => f.To(_ZettaHertz);

        /// <summary>Converts the frequency to yottahertz.</summary>
        public static double ToYottaHertz(this FrequencyMeasure f) => f.To(_YottaHertz);
    }
}
