using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a pressure value expressed in a base unit (Pascal).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="PressureMeasure"/> class
    /// using a value expressed in Pascals.
    /// </remarks>
    /// <param name="baseValue">The pressure value in Pascals.</param>
    public class PressureMeasure(double baseValue) : IMeasure<PressureMeasure>
    {
        /// <summary>
        /// Gets the internal pressure value expressed in Pascals.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal pressure value to a target unit using the specified factor.
        /// </summary>
        /// <param name="factor">
        /// The conversion factor representing how many Pascals correspond to one unit
        /// of the target measurement.
        /// </param>
        /// <returns>The converted pressure value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new pressure measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in Pascals.</param>
        /// <returns>A new <see cref="PressureMeasure"/> instance.</returns>
        public PressureMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two pressure measurements.
        /// </summary>
        /// <param name="other">The pressure to add.</param>
        /// <returns>A new <see cref="PressureMeasure"/> representing the sum.</returns>
        public PressureMeasure Add(PressureMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another pressure measurement from this one.
        /// </summary>
        /// <param name="other">The pressure to subtract.</param>
        /// <returns>A new <see cref="PressureMeasure"/> representing the difference.</returns>
        public PressureMeasure Subtract(PressureMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the pressure by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="PressureMeasure"/> representing the product.</returns>
        public PressureMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the pressure by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="PressureMeasure"/> representing the quotient.</returns>
        public PressureMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this pressure by another pressure to get a ratio.
        /// </summary>
        /// <param name="other">The pressure to divide by.</param>
        /// <returns>The ratio between the two pressures.</returns>
        public double DivideBy(PressureMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two pressure measurements.
        /// </summary>
        /// <param name="left">The first pressure.</param>
        /// <param name="right">The second pressure.</param>
        /// <returns>The sum of the two pressures.</returns>
        public static PressureMeasure operator +(PressureMeasure left, PressureMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one pressure measurement from another.
        /// </summary>
        /// <param name="left">The pressure to subtract from.</param>
        /// <param name="right">The pressure to subtract.</param>
        /// <returns>The difference between the two pressures.</returns>
        public static PressureMeasure operator -(PressureMeasure left, PressureMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a pressure measurement by a scalar.
        /// </summary>
        /// <param name="left">The pressure.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the pressure and scalar.</returns>
        public static PressureMeasure operator *(PressureMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a pressure measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The pressure.</param>
        /// <returns>The product of the scalar and pressure.</returns>
        public static PressureMeasure operator *(double scalar, PressureMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a pressure measurement by a scalar.
        /// </summary>
        /// <param name="left">The pressure.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the pressure and scalar.</returns>
        public static PressureMeasure operator /(PressureMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one pressure measurement by another.
        /// </summary>
        /// <param name="left">The dividend pressure.</param>
        /// <param name="right">The divisor pressure.</param>
        /// <returns>The ratio between the two pressures.</returns>
        public static double operator /(PressureMeasure left, PressureMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two pressure measurements are equal.
        /// </summary>
        /// <param name="left">The first pressure.</param>
        /// <param name="right">The second pressure.</param>
        /// <returns><c>true</c> if the pressures are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(PressureMeasure left, PressureMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two pressure measurements are not equal.
        /// </summary>
        /// <param name="left">The first pressure.</param>
        /// <param name="right">The second pressure.</param>
        /// <returns><c>true</c> if the pressures are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(PressureMeasure left, PressureMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one pressure measurement is greater than another.
        /// </summary>
        /// <param name="left">The first pressure.</param>
        /// <param name="right">The second pressure.</param>
        /// <returns><c>true</c> if the first pressure is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(PressureMeasure left, PressureMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one pressure measurement is less than another.
        /// </summary>
        /// <param name="left">The first pressure.</param>
        /// <param name="right">The second pressure.</param>
        /// <returns><c>true</c> if the first pressure is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(PressureMeasure left, PressureMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one pressure measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first pressure.</param>
        /// <param name="right">The second pressure.</param>
        /// <returns><c>true</c> if the first pressure is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(PressureMeasure left, PressureMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one pressure measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first pressure.</param>
        /// <param name="right">The second pressure.</param>
        /// <returns><c>true</c> if the first pressure is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(PressureMeasure left, PressureMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current pressure measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current pressure measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current pressure measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this pressure measurement.
        /// </summary>
        /// <returns>A hash code for the current pressure measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the pressure measurement.
        /// </summary>
        /// <returns>A string representing the pressure in Pascals.</returns>
        public override string ToString() => $"{BaseValue} Pa";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="PressureMeasure"/> values.
    /// </summary>
    public static class PressureExtension
    {
        private const double _Pascal = 1.0;
        private const double Atmosphere = 101_325.0;
        private const double _Psi = 6_894.757293168;
        private const double _Torr = 133.322387415;

        /// <summary>Creates a pressure value expressed in Pascals.</summary>
        /// <param name="value">The value in Pascals.</param>
        /// <returns>A <see cref="PressureMeasure"/> representing the pressure.</returns>
        public static PressureMeasure Pascal(this double value) => new(value * _Pascal);

        /// <summary>Creates a pressure value expressed in atmospheres.</summary>
        /// <param name="value">The value in atmospheres.</param>
        /// <returns>A <see cref="PressureMeasure"/> representing the pressure.</returns>
        public static PressureMeasure Atmospheres(this double value) => new(value * Atmosphere);

        /// <summary>Creates a pressure value expressed in psi (pounds per square inch).</summary>
        /// <param name="value">The value in psi.</param>
        /// <returns>A <see cref="PressureMeasure"/> representing the pressure.</returns>
        public static PressureMeasure Psi(this double value) => new(value * _Psi);

        /// <summary>Creates a pressure value expressed in Torr (mmHg).</summary>
        /// <param name="value">The value in Torr.</param>
        /// <returns>A <see cref="PressureMeasure"/> representing the pressure.</returns>
        public static PressureMeasure Torr(this double value) => new(value * _Torr);

        /// <summary>Converts the pressure value to Pascals.</summary>
        /// <param name="m">The pressure measurement.</param>
        /// <returns>The pressure in Pascals.</returns>
        public static double ToPascal(this PressureMeasure m) => m.To(_Pascal);

        /// <summary>Converts the pressure value to atmospheres.</summary>
        /// <param name="m">The pressure measurement.</param>
        /// <returns>The pressure in atmospheres.</returns>
        public static double ToAtmospheres(this PressureMeasure m) => m.To(Atmosphere);

        /// <summary>Converts the pressure value to psi.</summary>
        /// <param name="m">The pressure measurement.</param>
        /// <returns>The pressure in psi.</returns>
        public static double ToPsi(this PressureMeasure m) => m.To(_Psi);

        /// <summary>Converts the pressure value to Torr.</summary>
        /// <param name="m">The pressure measurement.</param>
        /// <returns>The pressure in Torr.</returns>
        public static double ToTorr(this PressureMeasure m) => m.To(_Torr);
    }
}
