using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents an electric resistance value expressed in a base unit (ohm).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ResistanceMeasure"/> class
    /// using a value expressed in ohms.
    /// </remarks>
    /// <param name="baseValue">The resistance value in ohms.</param>
    public class ResistanceMeasure(double baseValue) : IMeasure<ResistanceMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in ohms.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of ohms corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new resistance measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in ohms.</param>
        /// <returns>A new <see cref="ResistanceMeasure"/> instance.</returns>
        public ResistanceMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two resistance measurements (resistances in series).
        /// </summary>
        public ResistanceMeasure Add(ResistanceMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another resistance measurement from this one.
        /// </summary>
        public ResistanceMeasure Subtract(ResistanceMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the resistance by a scalar value.
        /// </summary>
        public ResistanceMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the resistance by a scalar value.
        /// </summary>
        public ResistanceMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this resistance by another resistance to get a ratio.
        /// </summary>
        public double DivideBy(ResistanceMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two resistance measures.
        /// </summary>
        /// <param name="left">The first resistance operand.</param>
        /// <param name="right">The second resistance operand.</param>
        /// <returns>A new <see cref="ResistanceMeasure"/> representing the sum.</returns>
        public static ResistanceMeasure operator +(ResistanceMeasure left, ResistanceMeasure right) => left.Add(right);

        /// <summary>
        /// Subtracts one resistance measure from another.
        /// </summary>
        /// <param name="left">The resistance to subtract from.</param>
        /// <param name="right">The resistance to subtract.</param>
        /// <returns>A new <see cref="ResistanceMeasure"/> representing the difference.</returns>
        public static ResistanceMeasure operator -(ResistanceMeasure left, ResistanceMeasure right) => left.Subtract(right);

        /// <summary>
        /// Multiplies a resistance measure by a scalar value.
        /// </summary>
        /// <param name="left">The resistance measure.</param>
        /// <param name="scalar">The multiplier.</param>
        /// <returns>A new scaled <see cref="ResistanceMeasure"/>.</returns>
        public static ResistanceMeasure operator *(ResistanceMeasure left, double scalar) => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a scalar value by a resistance measure.
        /// </summary>
        /// <param name="scalar">The multiplier.</param>
        /// <param name="right">The resistance measure.</param>
        /// <returns>A new scaled <see cref="ResistanceMeasure"/>.</returns>
        public static ResistanceMeasure operator *(double scalar, ResistanceMeasure right) => right.Multiply(scalar);

        /// <summary>
        /// Divides a resistance measure by a scalar value.
        /// </summary>
        /// <param name="left">The resistance measure.</param>
        /// <param name="scalar">The divisor.</param>
        /// <returns>A new <see cref="ResistanceMeasure"/> divided by the scalar.</returns>
        public static ResistanceMeasure operator /(ResistanceMeasure left, double scalar) => left.Divide(scalar);

        /// <summary>
        /// Calculates the ratio between two resistance measures.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The dimensionless ratio as a <see cref="double"/>.</returns>
        public static double operator /(ResistanceMeasure left, ResistanceMeasure right) => left.DivideBy(right);

        /// <summary>
        /// Compares two <see cref="ResistanceMeasure"/> instances for equality within a tolerance of 1e-10.
        /// </summary>
        /// <param name="left">The first resistance to compare.</param>
        /// <param name="right">The second resistance to compare.</param>
        /// <returns><c>true</c> if the values are considered equal; otherwise <c>false</c>.</returns>
        public static bool operator ==(ResistanceMeasure left, ResistanceMeasure right) => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Compares two <see cref="ResistanceMeasure"/> instances for inequality.
        /// </summary>
        public static bool operator !=(ResistanceMeasure left, ResistanceMeasure right) => !(left == right);

        /// <summary>
        /// Determines if the first resistance is greater than the second.
        /// </summary>
        public static bool operator >(ResistanceMeasure left, ResistanceMeasure right) => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines if the first resistance is less than the second.
        /// </summary>
        public static bool operator <(ResistanceMeasure left, ResistanceMeasure right) => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines if the first resistance is greater than or equal to the second.
        /// </summary>
        public static bool operator >=(ResistanceMeasure left, ResistanceMeasure right) => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines if the first resistance is less than or equal to the second.
        /// </summary>
        public static bool operator <=(ResistanceMeasure left, ResistanceMeasure right) => left.BaseValue <= right.BaseValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is ResistanceMeasure other && BaseValue.Equals(other.BaseValue);

        /// <inheritdoc />
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the resistance in Ohms (Ω).
        /// </summary>
        /// <returns>A string formatted as "value Ω".</returns>
        public override string ToString() => $"{BaseValue} Ω";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="ResistanceMeasure"/> values.
    /// </summary>
    public static class ResistanceExtensions
    {
        private const double Ohm = 1.0;
        private const double Milliohm = 0.001;
        private const double Kiloohm = 1_000.0;
        private const double Megaohm = 1_000_000.0;

        /// <summary>Creates a resistance value expressed in ohms (Ω).</summary>
        public static ResistanceMeasure Ohms(this double value) => new(value * Ohm);

        /// <summary>Creates a resistance value expressed in milliohms (mΩ).</summary>
        public static ResistanceMeasure Milliohms(this double value) => new(value * Milliohm);

        /// <summary>Creates a resistance value expressed in kiloohms (kΩ).</summary>
        public static ResistanceMeasure Kiloohms(this double value) => new(value * Kiloohm);

        /// <summary>Creates a resistance value expressed in megaohms (MΩ).</summary>
        public static ResistanceMeasure Megaohms(this double value) => new(value * Megaohm);

        /// <summary>Converts the resistance to ohms (Ω).</summary>
        public static double ToOhms(this ResistanceMeasure r) => r.To(Ohm);

        /// <summary>Converts the resistance to milliohms (mΩ).</summary>
        public static double ToMilliohms(this ResistanceMeasure r) => r.To(Milliohm);

        /// <summary>Converts the resistance to kiloohms (kΩ).</summary>
        public static double ToKiloohms(this ResistanceMeasure r) => r.To(Kiloohm);

        /// <summary>Converts the resistance to megaohms (MΩ).</summary>
        public static double ToMegaohms(this ResistanceMeasure r) => r.To(Megaohm);
    }
}