using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a torque value expressed in a base unit (newton meter).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="TorqueMeasure"/> class
    /// using a value expressed in newton meters.
    /// </remarks>
    /// <param name="baseValue">The torque value in newton meters.</param>
    public class TorqueMeasure(double baseValue) : IMeasure<TorqueMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in newton meters.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of Nm corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new torque measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in newton meters.</param>
        /// <returns>A new <see cref="TorqueMeasure"/> instance.</returns>
        public TorqueMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two torque measurements.
        /// </summary>
        public TorqueMeasure Add(TorqueMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another torque measurement from this one.
        /// </summary>
        public TorqueMeasure Subtract(TorqueMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the torque by a scalar value.
        /// </summary>
        public TorqueMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the torque by a scalar value.
        /// </summary>
        public TorqueMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this torque by another torque to get a ratio.
        /// </summary>
        public double DivideBy(TorqueMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two torque measures.
        /// </summary>
        /// <param name="left">The first torque operand.</param>
        /// <param name="right">The second torque operand.</param>
        /// <returns>A new <see cref="TorqueMeasure"/> representing the sum.</returns>
        public static TorqueMeasure operator +(TorqueMeasure left, TorqueMeasure right) => left.Add(right);

        /// <summary>
        /// Subtracts one torque measure from another.
        /// </summary>
        /// <param name="left">The torque to subtract from.</param>
        /// <param name="right">The torque to subtract.</param>
        /// <returns>A new <see cref="TorqueMeasure"/> representing the difference.</returns>
        public static TorqueMeasure operator -(TorqueMeasure left, TorqueMeasure right) => left.Subtract(right);

        /// <summary>
        /// Multiplies a torque measure by a scalar value.
        /// </summary>
        /// <param name="left">The torque measure.</param>
        /// <param name="scalar">The multiplier.</param>
        /// <returns>A new scaled <see cref="TorqueMeasure"/>.</returns>
        public static TorqueMeasure operator *(TorqueMeasure left, double scalar) => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a scalar value by a torque measure.
        /// </summary>
        /// <param name="scalar">The multiplier.</param>
        /// <param name="right">The torque measure.</param>
        /// <returns>A new scaled <see cref="TorqueMeasure"/>.</returns>
        public static TorqueMeasure operator *(double scalar, TorqueMeasure right) => right.Multiply(scalar);

        /// <summary>
        /// Divides a torque measure by a scalar value.
        /// </summary>
        /// <param name="left">The torque measure.</param>
        /// <param name="scalar">The divisor.</param>
        /// <returns>A new <see cref="TorqueMeasure"/> divided by the scalar.</returns>
        public static TorqueMeasure operator /(TorqueMeasure left, double scalar) => left.Divide(scalar);

        /// <summary>
        /// Calculates the ratio between two torque measures.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The dimensionless ratio as a <see cref="double"/>.</returns>
        public static double operator /(TorqueMeasure left, TorqueMeasure right) => left.DivideBy(right);

        /// <summary>
        /// Compares two <see cref="TorqueMeasure"/> instances for equality within a tolerance of 1e-10.
        /// </summary>
        /// <param name="left">The first torque to compare.</param>
        /// <param name="right">The second torque to compare.</param>
        /// <returns><c>true</c> if the values are considered equal; otherwise <c>false</c>.</returns>
        public static bool operator ==(TorqueMeasure left, TorqueMeasure right) => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Compares two <see cref="TorqueMeasure"/> instances for inequality.
        /// </summary>
        public static bool operator !=(TorqueMeasure left, TorqueMeasure right) => !(left == right);

        /// <summary>
        /// Determines if the first torque is greater than the second.
        /// </summary>
        public static bool operator >(TorqueMeasure left, TorqueMeasure right) => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines if the first torque is less than the second.
        /// </summary>
        public static bool operator <(TorqueMeasure left, TorqueMeasure right) => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines if the first torque is greater than or equal to the second.
        /// </summary>
        public static bool operator >=(TorqueMeasure left, TorqueMeasure right) => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines if the first torque is less than or equal to the second.
        /// </summary>
        public static bool operator <=(TorqueMeasure left, TorqueMeasure right) => left.BaseValue <= right.BaseValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is TorqueMeasure other && BaseValue.Equals(other.BaseValue);

        /// <inheritdoc />
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the torque in Newton-meters (Nm).
        /// </summary>
        /// <returns>A string formatted as "value Nm".</returns>
        public override string ToString() => $"{BaseValue} Nm";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="TorqueMeasure"/> values.
    /// </summary>
    public static class TorqueExtensions
    {
        private const double NewtonMeter = 1.0;
        private const double FootPound = 1.3558179483314004;
        private const double InchPound = 0.1129848290276167;
        private const double KilogramForceMeter = 9.80665;
        private const double DynecentImeter = 1e-7;

        /// <summary>Creates a torque value expressed in newton meters (Nm).</summary>
        public static TorqueMeasure NewtonMeters(this double value) => new(value * NewtonMeter);

        /// <summary>Creates a torque value expressed in foot-pounds (ft·lb).</summary>
        public static TorqueMeasure FootPounds(this double value) => new(value * FootPound);

        /// <summary>Creates a torque value expressed in inch-pounds (in·lb).</summary>
        public static TorqueMeasure InchPounds(this double value) => new(value * InchPound);

        /// <summary>Creates a torque value expressed in kilogram-force meters (kgf·m).</summary>
        public static TorqueMeasure KilogramForceMeters(this double value) => new(value * KilogramForceMeter);

        /// <summary>Creates a torque value expressed in dyne centimeters (dyn·cm).</summary>
        public static TorqueMeasure DyneCentimeters(this double value) => new(value * DynecentImeter);

        /// <summary>Converts the torque to newton meters (Nm).</summary>
        public static double ToNewtonMeters(this TorqueMeasure t) => t.To(NewtonMeter);

        /// <summary>Converts the torque to foot-pounds (ft·lb).</summary>
        public static double ToFootPounds(this TorqueMeasure t) => t.To(FootPound);

        /// <summary>Converts the torque to inch-pounds (in·lb).</summary>
        public static double ToInchPounds(this TorqueMeasure t) => t.To(InchPound);

        /// <summary>Converts the torque to kilogram-force meters (kgf·m).</summary>
        public static double ToKilogramForceMeters(this TorqueMeasure t) => t.To(KilogramForceMeter);

        /// <summary>Converts the torque to dyne centimeters (dyn·cm).</summary>
        public static double ToDyneCentimeters(this TorqueMeasure t) => t.To(DynecentImeter);
    }
}