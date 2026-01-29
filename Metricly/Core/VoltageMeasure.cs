using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents an electric voltage value expressed in a base unit (volt).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="VoltageMeasure"/> class
    /// using a value expressed in volts.
    /// </remarks>
    /// <param name="baseValue">The voltage value in volts.</param>
    public class VoltageMeasure(double baseValue) : IMeasure<VoltageMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in volts.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of volts corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new voltage measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in volts.</param>
        /// <returns>A new <see cref="VoltageMeasure"/> instance.</returns>
        public VoltageMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two voltage measurements.
        /// </summary>
        public VoltageMeasure Add(VoltageMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another voltage measurement from this one.
        /// </summary>
        public VoltageMeasure Subtract(VoltageMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the voltage by a scalar value.
        /// </summary>
        public VoltageMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the voltage by a scalar value.
        /// </summary>
        public VoltageMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this voltage by another voltage to get a ratio.
        /// </summary>
        public double DivideBy(VoltageMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two voltage measures.
        /// </summary>
        /// <param name="left">The first voltage operand.</param>
        /// <param name="right">The second voltage operand.</param>
        /// <returns>A new <see cref="VoltageMeasure"/> representing the sum.</returns>
        public static VoltageMeasure operator +(VoltageMeasure left, VoltageMeasure right) => left.Add(right);

        /// <summary>
        /// Subtracts one voltage measure from another.
        /// </summary>
        /// <param name="left">The voltage to subtract from.</param>
        /// <param name="right">The voltage to subtract.</param>
        /// <returns>A new <see cref="VoltageMeasure"/> representing the difference.</returns>
        public static VoltageMeasure operator -(VoltageMeasure left, VoltageMeasure right) => left.Subtract(right);

        /// <summary>
        /// Multiplies a voltage measure by a scalar value.
        /// </summary>
        /// <param name="left">The voltage measure.</param>
        /// <param name="scalar">The multiplier.</param>
        /// <returns>A new scaled <see cref="VoltageMeasure"/>.</returns>
        public static VoltageMeasure operator *(VoltageMeasure left, double scalar) => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a scalar value by a voltage measure.
        /// </summary>
        /// <param name="scalar">The multiplier.</param>
        /// <param name="right">The voltage measure.</param>
        /// <returns>A new scaled <see cref="VoltageMeasure"/>.</returns>
        public static VoltageMeasure operator *(double scalar, VoltageMeasure right) => right.Multiply(scalar);

        /// <summary>
        /// Divides a voltage measure by a scalar value.
        /// </summary>
        /// <param name="left">The voltage measure.</param>
        /// <param name="scalar">The divisor.</param>
        /// <returns>A new <see cref="VoltageMeasure"/> divided by the scalar.</returns>
        public static VoltageMeasure operator /(VoltageMeasure left, double scalar) => left.Divide(scalar);

        /// <summary>
        /// Calculates the ratio between two voltage measures.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The dimensionless ratio as a <see cref="double"/>.</returns>
        public static double operator /(VoltageMeasure left, VoltageMeasure right) => left.DivideBy(right);

        /// <summary>
        /// Compares two <see cref="VoltageMeasure"/> instances for equality within a tolerance of 1e-10.
        /// </summary>
        /// <param name="left">The first voltage to compare.</param>
        /// <param name="right">The second voltage to compare.</param>
        /// <returns><c>true</c> if the values are considered equal; otherwise <c>false</c>.</returns>
        public static bool operator ==(VoltageMeasure left, VoltageMeasure right) => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Compares two <see cref="VoltageMeasure"/> instances for inequality.
        /// </summary>
        public static bool operator !=(VoltageMeasure left, VoltageMeasure right) => !(left == right);

        /// <summary>
        /// Determines if the first voltage is greater than the second.
        /// </summary>
        public static bool operator >(VoltageMeasure left, VoltageMeasure right) => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines if the first voltage is less than the second.
        /// </summary>
        public static bool operator <(VoltageMeasure left, VoltageMeasure right) => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines if the first voltage is greater than or equal to the second.
        /// </summary>
        public static bool operator >=(VoltageMeasure left, VoltageMeasure right) => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines if the first voltage is less than or equal to the second.
        /// </summary>
        public static bool operator <=(VoltageMeasure left, VoltageMeasure right) => left.BaseValue <= right.BaseValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is VoltageMeasure other && BaseValue.Equals(other.BaseValue);

        /// <inheritdoc />
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the voltage in Volts (V).
        /// </summary>
        /// <returns>A string formatted as "value V".</returns>
        public override string ToString() => $"{BaseValue} V";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="VoltageMeasure"/> values.
    /// </summary>
    public static class VoltageExtensions
    {
        private const double Volt = 1.0;
        private const double Millivolt = 0.001;
        private const double Microvolt = 1e-6;
        private const double Kilovolt = 1_000.0;
        private const double Megavolt = 1_000_000.0;

        /// <summary>Creates a voltage value expressed in volts (V).</summary>
        public static VoltageMeasure Volts(this double value) => new(value * Volt);

        /// <summary>Creates a voltage value expressed in millivolts (mV).</summary>
        public static VoltageMeasure Millivolts(this double value) => new(value * Millivolt);

        /// <summary>Creates a voltage value expressed in microvolts (μV).</summary>
        public static VoltageMeasure Microvolts(this double value) => new(value * Microvolt);

        /// <summary>Creates a voltage value expressed in kilovolts (kV).</summary>
        public static VoltageMeasure Kilovolts(this double value) => new(value * Kilovolt);

        /// <summary>Creates a voltage value expressed in megavolts (MV).</summary>
        public static VoltageMeasure Megavolts(this double value) => new(value * Megavolt);

        /// <summary>Converts the voltage to volts (V).</summary>
        public static double ToVolts(this VoltageMeasure v) => v.To(Volt);

        /// <summary>Converts the voltage to millivolts (mV).</summary>
        public static double ToMillivolts(this VoltageMeasure v) => v.To(Millivolt);

        /// <summary>Converts the voltage to microvolts (μV).</summary>
        public static double ToMicrovolts(this VoltageMeasure v) => v.To(Microvolt);

        /// <summary>Converts the voltage to kilovolts (kV).</summary>
        public static double ToKilovolts(this VoltageMeasure v) => v.To(Kilovolt);

        /// <summary>Converts the voltage to megavolts (MV).</summary>
        public static double ToMegavolts(this VoltageMeasure v) => v.To(Megavolt);
    }
}