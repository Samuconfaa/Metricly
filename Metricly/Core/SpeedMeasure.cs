using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a speed value expressed in a base unit (meters per second).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="SpeedMeasure"/> class
    /// using a value expressed in meters per second.
    /// </remarks>
    /// <param name="baseValue">The speed value in meters per second.</param>
    public class SpeedMeasure(double baseValue) : IMeasure<SpeedMeasure>
    {
        /// <summary>
        /// Gets the internal speed value expressed in meters per second.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal speed value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">How many meters per second correspond to one unit of the target measurement.</param>
        /// <returns>The converted speed value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new speed measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in meters per second.</param>
        /// <returns>A new <see cref="SpeedMeasure"/> instance.</returns>
        public SpeedMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two speed measurements.
        /// </summary>
        /// <param name="other">The speed to add.</param>
        /// <returns>A new <see cref="SpeedMeasure"/> representing the sum.</returns>
        public SpeedMeasure Add(SpeedMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another speed measurement from this one.
        /// </summary>
        /// <param name="other">The speed to subtract.</param>
        /// <returns>A new <see cref="SpeedMeasure"/> representing the difference.</returns>
        public SpeedMeasure Subtract(SpeedMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the speed by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="SpeedMeasure"/> representing the product.</returns>
        public SpeedMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the speed by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="SpeedMeasure"/> representing the quotient.</returns>
        public SpeedMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this speed by another speed to get a ratio.
        /// </summary>
        /// <param name="other">The speed to divide by.</param>
        /// <returns>The ratio between the two speeds.</returns>
        public double DivideBy(SpeedMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two speed measurements.
        /// </summary>
        /// <param name="left">The first speed.</param>
        /// <param name="right">The second speed.</param>
        /// <returns>The sum of the two speeds.</returns>
        public static SpeedMeasure operator +(SpeedMeasure left, SpeedMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one speed measurement from another.
        /// </summary>
        /// <param name="left">The speed to subtract from.</param>
        /// <param name="right">The speed to subtract.</param>
        /// <returns>The difference between the two speeds.</returns>
        public static SpeedMeasure operator -(SpeedMeasure left, SpeedMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a speed measurement by a scalar.
        /// </summary>
        /// <param name="left">The speed.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the speed and scalar.</returns>
        public static SpeedMeasure operator *(SpeedMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a speed measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The speed.</param>
        /// <returns>The product of the scalar and speed.</returns>
        public static SpeedMeasure operator *(double scalar, SpeedMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a speed measurement by a scalar.
        /// </summary>
        /// <param name="left">The speed.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the speed and scalar.</returns>
        public static SpeedMeasure operator /(SpeedMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one speed measurement by another.
        /// </summary>
        /// <param name="left">The dividend speed.</param>
        /// <param name="right">The divisor speed.</param>
        /// <returns>The ratio between the two speeds.</returns>
        public static double operator /(SpeedMeasure left, SpeedMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two speed measurements are equal.
        /// </summary>
        /// <param name="left">The first speed.</param>
        /// <param name="right">The second speed.</param>
        /// <returns><c>true</c> if the speeds are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(SpeedMeasure left, SpeedMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two speed measurements are not equal.
        /// </summary>
        /// <param name="left">The first speed.</param>
        /// <param name="right">The second speed.</param>
        /// <returns><c>true</c> if the speeds are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(SpeedMeasure left, SpeedMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one speed measurement is greater than another.
        /// </summary>
        /// <param name="left">The first speed.</param>
        /// <param name="right">The second speed.</param>
        /// <returns><c>true</c> if the first speed is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(SpeedMeasure left, SpeedMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one speed measurement is less than another.
        /// </summary>
        /// <param name="left">The first speed.</param>
        /// <param name="right">The second speed.</param>
        /// <returns><c>true</c> if the first speed is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(SpeedMeasure left, SpeedMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one speed measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first speed.</param>
        /// <param name="right">The second speed.</param>
        /// <returns><c>true</c> if the first speed is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(SpeedMeasure left, SpeedMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one speed measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first speed.</param>
        /// <param name="right">The second speed.</param>
        /// <returns><c>true</c> if the first speed is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(SpeedMeasure left, SpeedMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current speed measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current speed measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current speed measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this speed measurement.
        /// </summary>
        /// <returns>A hash code for the current speed measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the speed measurement.
        /// </summary>
        /// <returns>A string representing the speed in meters per second.</returns>
        public override string ToString() => $"{BaseValue} m/s";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="SpeedMeasure"/> values.
    /// </summary>
    public static class SpeedExtensions
    {
        private const double MeterPerSecond = 1.0;
        private const double KilometerPerHour = 1000.0 / 3600.0;
        private const double MilePerHour = 1609.344 / 3600.0;
        private const double FootPerSecond = 0.3048;
        private const double Knot = 1852.0 / 3600.0;

        /// <summary>Creates a speed value expressed in meters per second.</summary>
        /// <param name="value">The value in meters per second.</param>
        /// <returns>A <see cref="SpeedMeasure"/> representing the speed.</returns>
        public static SpeedMeasure MetersPerSecond(this double value) => new(value * MeterPerSecond);

        /// <summary>Creates a speed value expressed in kilometers per hour.</summary>
        /// <param name="value">The value in kilometers per hour.</param>
        /// <returns>A <see cref="SpeedMeasure"/> representing the speed.</returns>
        public static SpeedMeasure KilometersPerHour(this double value) => new(value * KilometerPerHour);

        /// <summary>Creates a speed value expressed in miles per hour.</summary>
        /// <param name="value">The value in miles per hour.</param>
        /// <returns>A <see cref="SpeedMeasure"/> representing the speed.</returns>
        public static SpeedMeasure MilesPerHour(this double value) => new(value * MilePerHour);

        /// <summary>Creates a speed value expressed in feet per second.</summary>
        /// <param name="value">The value in feet per second.</param>
        /// <returns>A <see cref="SpeedMeasure"/> representing the speed.</returns>
        public static SpeedMeasure FeetPerSecond(this double value) => new(value * FootPerSecond);

        /// <summary>Creates a speed value expressed in knots.</summary>
        /// <param name="value">The value in knots.</param>
        /// <returns>A <see cref="SpeedMeasure"/> representing the speed.</returns>
        public static SpeedMeasure Knots(this double value) => new(value * Knot);

        /// <summary>Converts the speed value to meters per second.</summary>
        /// <param name="s">The speed measurement.</param>
        /// <returns>The speed in meters per second.</returns>
        public static double ToMetersPerSecond(this SpeedMeasure s) => s.To(MeterPerSecond);

        /// <summary>Converts the speed value to kilometers per hour.</summary>
        /// <param name="s">The speed measurement.</param>
        /// <returns>The speed in kilometers per hour.</returns>
        public static double ToKilometersPerHour(this SpeedMeasure s) => s.To(KilometerPerHour);

        /// <summary>Converts the speed value to miles per hour.</summary>
        /// <param name="s">The speed measurement.</param>
        /// <returns>The speed in miles per hour.</returns>
        public static double ToMilesPerHour(this SpeedMeasure s) => s.To(MilePerHour);

        /// <summary>Converts the speed value to feet per second.</summary>
        /// <param name="s">The speed measurement.</param>
        /// <returns>The speed in feet per second.</returns>
        public static double ToFeetPerSecond(this SpeedMeasure s) => s.To(FootPerSecond);

        /// <summary>Converts the speed value to knots.</summary>
        /// <param name="s">The speed measurement.</param>
        /// <returns>The speed in knots.</returns>
        public static double ToKnots(this SpeedMeasure s) => s.To(Knot);
    }
}
