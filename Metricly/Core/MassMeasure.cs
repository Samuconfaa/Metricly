using System;
using System.Runtime.CompilerServices;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a mass value expressed in a base unit (grams).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MassMeasure"/> class
    /// using a value expressed in grams.
    /// </remarks>
    /// <param name="baseValue">The mass value in grams.</param>
    public class MassMeasure(double baseValue) : IMeasure<MassMeasure>
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

        /// <summary>
        /// Creates a new mass measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in grams.</param>
        /// <returns>A new <see cref="MassMeasure"/> instance.</returns>
        public MassMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two mass measurements.
        /// </summary>
        /// <param name="other">The mass to add.</param>
        /// <returns>A new <see cref="MassMeasure"/> representing the sum.</returns>
        public MassMeasure Add(MassMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another mass measurement from this one.
        /// </summary>
        /// <param name="other">The mass to subtract.</param>
        /// <returns>A new <see cref="MassMeasure"/> representing the difference.</returns>
        public MassMeasure Subtract(MassMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the mass by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="MassMeasure"/> representing the product.</returns>
        public MassMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the mass by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="MassMeasure"/> representing the quotient.</returns>
        public MassMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this mass by another mass to get a ratio.
        /// </summary>
        /// <param name="other">The mass to divide by.</param>
        /// <returns>The ratio between the two masses.</returns>
        public double DivideBy(MassMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two mass measurements.
        /// </summary>
        /// <param name="left">The first mass.</param>
        /// <param name="right">The second mass.</param>
        /// <returns>The sum of the two masses.</returns>
        public static MassMeasure operator +(MassMeasure left, MassMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one mass measurement from another.
        /// </summary>
        /// <param name="left">The mass to subtract from.</param>
        /// <param name="right">The mass to subtract.</param>
        /// <returns>The difference between the two masses.</returns>
        public static MassMeasure operator -(MassMeasure left, MassMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a mass measurement by a scalar.
        /// </summary>
        /// <param name="left">The mass.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the mass and scalar.</returns>
        public static MassMeasure operator *(MassMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a mass measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The mass.</param>
        /// <returns>The product of the scalar and mass.</returns>
        public static MassMeasure operator *(double scalar, MassMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a mass measurement by a scalar.
        /// </summary>
        /// <param name="left">The mass.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the mass and scalar.</returns>
        public static MassMeasure operator /(MassMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one mass measurement by another.
        /// </summary>
        /// <param name="left">The dividend mass.</param>
        /// <param name="right">The divisor mass.</param>
        /// <returns>The ratio between the two masses.</returns>
        public static double operator /(MassMeasure left, MassMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two mass measurements are equal.
        /// </summary>
        /// <param name="left">The first mass.</param>
        /// <param name="right">The second mass.</param>
        /// <returns><c>true</c> if the masses are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(MassMeasure left, MassMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two mass measurements are not equal.
        /// </summary>
        /// <param name="left">The first mass.</param>
        /// <param name="right">The second mass.</param>
        /// <returns><c>true</c> if the masses are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(MassMeasure left, MassMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one mass measurement is greater than another.
        /// </summary>
        /// <param name="left">The first mass.</param>
        /// <param name="right">The second mass.</param>
        /// <returns><c>true</c> if the first mass is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(MassMeasure left, MassMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one mass measurement is less than another.
        /// </summary>
        /// <param name="left">The first mass.</param>
        /// <param name="right">The second mass.</param>
        /// <returns><c>true</c> if the first mass is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(MassMeasure left, MassMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one mass measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first mass.</param>
        /// <param name="right">The second mass.</param>
        /// <returns><c>true</c> if the first mass is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(MassMeasure left, MassMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one mass measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first mass.</param>
        /// <param name="right">The second mass.</param>
        /// <returns><c>true</c> if the first mass is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(MassMeasure left, MassMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current mass measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current mass measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current mass measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this mass measurement.
        /// </summary>
        /// <returns>A hash code for the current mass measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the mass measurement.
        /// </summary>
        /// <returns>A string representing the mass in grams.</returns>
        public override string ToString() => $"{BaseValue} g";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="MassMeasure"/> values.
    /// </summary>
    public static class MassExtension
    {
        private const double Gram = 1.0;
        private const double MetricTon = 1_000_000.0;
        private const double Kilogram = 1_000.0;
        private const double Milligram = 0.001;
        private const double Microgram = 0.000001;
        private const double Ounce = 28.349523125;
        private const double Pound = 453.59237;
        private const double _Stone = 6350.29318;
        private const double ShortTon = 907_184.74;
        private const double LongTon = 1_016_046.9088;

        /// <summary>Creates a mass value expressed in grams.</summary>
        /// <param name="value">The value in grams.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure Grams(this double value) => new(value * Gram);

        /// <summary>Creates a mass value expressed in metric tons.</summary>
        /// <param name="value">The value in metric tons.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure MetricTons(this double value) => new(value * MetricTon);

        /// <summary>Creates a mass value expressed in kilograms.</summary>
        /// <param name="value">The value in kilograms.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure Kilograms(this double value) => new(value * Kilogram);

        /// <summary>Creates a mass value expressed in milligrams.</summary>
        /// <param name="value">The value in milligrams.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure Milligrams(this double value) => new(value * Milligram);

        /// <summary>Creates a mass value expressed in micrograms.</summary>
        /// <param name="value">The value in micrograms.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure Micrograms(this double value) => new(value * Microgram);

        /// <summary>Creates a mass value expressed in ounces.</summary>
        /// <param name="value">The value in ounces.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure Ounces(this double value) => new(value * Ounce);

        /// <summary>Creates a mass value expressed in pounds.</summary>
        /// <param name="value">The value in pounds.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure Pounds(this double value) => new(value * Pound);

        /// <summary>Creates a mass value expressed in stones.</summary>
        /// <param name="value">The value in stones.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure Stone(this double value) => new(value * _Stone);

        /// <summary>Creates a mass value expressed in US short tons.</summary>
        /// <param name="value">The value in short tons.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure ShortTons(this double value) => new(value * ShortTon);

        /// <summary>Creates a mass value expressed in imperial long tons.</summary>
        /// <param name="value">The value in long tons.</param>
        /// <returns>A <see cref="MassMeasure"/> representing the mass.</returns>
        public static MassMeasure LongTons(this double value) => new(value * LongTon);

        /// <summary>Converts the mass value to grams.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in grams.</returns>
        public static double ToGrams(this MassMeasure m) => m.To(Gram);

        /// <summary>Converts the mass value to metric tons.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in metric tons.</returns>
        public static double ToMetricTons(this MassMeasure m) => m.To(MetricTon);

        /// <summary>Converts the mass value to kilograms.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in kilograms.</returns>
        public static double ToKilograms(this MassMeasure m) => m.To(Kilogram);

        /// <summary>Converts the mass value to milligrams.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in milligrams.</returns>
        public static double ToMilligrams(this MassMeasure m) => m.To(Milligram);

        /// <summary>Converts the mass value to micrograms.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in micrograms.</returns>
        public static double ToMicrograms(this MassMeasure m) => m.To(Microgram);

        /// <summary>Converts the mass value to ounces.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in ounces.</returns>
        public static double ToOunces(this MassMeasure m) => m.To(Ounce);

        /// <summary>Converts the mass value to pounds.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in pounds.</returns>
        public static double ToPounds(this MassMeasure m) => m.To(Pound);

        /// <summary>Converts the mass value to stones.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in stones.</returns>
        public static double ToStone(this MassMeasure m) => m.To(_Stone);

        /// <summary>Converts the mass value to US short tons.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in short tons.</returns>
        public static double ToShortTons(this MassMeasure m) => m.To(ShortTon);

        /// <summary>Converts the mass value to imperial long tons.</summary>
        /// <param name="m">The mass measurement.</param>
        /// <returns>The mass in long tons.</returns>
        public static double ToLongTons(this MassMeasure m) => m.To(LongTon);
    }
}
