using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a plane angle value expressed in a base unit (degrees).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AngleMeasure"/> class
    /// using a value expressed in degrees.
    /// </remarks>
    /// <param name="baseValue">The angle value in degrees.</param>
    public class AngleMeasure(double baseValue) : IMeasure<AngleMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in degrees.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new angle measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in degrees.</param>
        /// <returns>A new <see cref="AngleMeasure"/> instance.</returns>
        public AngleMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two angle measurements.
        /// </summary>
        /// <param name="other">The angle to add.</param>
        /// <returns>A new <see cref="AngleMeasure"/> representing the sum.</returns>
        public AngleMeasure Add(AngleMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another angle measurement from this one.
        /// </summary>
        /// <param name="other">The angle to subtract.</param>
        /// <returns>A new <see cref="AngleMeasure"/> representing the difference.</returns>
        public AngleMeasure Subtract(AngleMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the angle by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="AngleMeasure"/> representing the product.</returns>
        public AngleMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the angle by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="AngleMeasure"/> representing the quotient.</returns>
        public AngleMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this angle by another angle to get a ratio.
        /// </summary>
        /// <param name="other">The angle to divide by.</param>
        /// <returns>The ratio between the two angles.</returns>
        public double DivideBy(AngleMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two angle measurements.
        /// </summary>
        /// <param name="left">The first angle.</param>
        /// <param name="right">The second angle.</param>
        /// <returns>The sum of the two angles.</returns>
        public static AngleMeasure operator +(AngleMeasure left, AngleMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one angle measurement from another.
        /// </summary>
        /// <param name="left">The angle to subtract from.</param>
        /// <param name="right">The angle to subtract.</param>
        /// <returns>The difference between the two angles.</returns>
        public static AngleMeasure operator -(AngleMeasure left, AngleMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies an angle measurement by a scalar.
        /// </summary>
        /// <param name="left">The angle.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the angle and scalar.</returns>
        public static AngleMeasure operator *(AngleMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies an angle measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The angle.</param>
        /// <returns>The product of the scalar and angle.</returns>
        public static AngleMeasure operator *(double scalar, AngleMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides an angle measurement by a scalar.
        /// </summary>
        /// <param name="left">The angle.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the angle and scalar.</returns>
        public static AngleMeasure operator /(AngleMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one angle measurement by another.
        /// </summary>
        /// <param name="left">The dividend angle.</param>
        /// <param name="right">The divisor angle.</param>
        /// <returns>The ratio between the two angles.</returns>
        public static double operator /(AngleMeasure left, AngleMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two angle measurements are equal.
        /// </summary>
        /// <param name="left">The first angle.</param>
        /// <param name="right">The second angle.</param>
        /// <returns><c>true</c> if the angles are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(AngleMeasure left, AngleMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two angle measurements are not equal.
        /// </summary>
        /// <param name="left">The first angle.</param>
        /// <param name="right">The second angle.</param>
        /// <returns><c>true</c> if the angles are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(AngleMeasure left, AngleMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one angle measurement is greater than another.
        /// </summary>
        /// <param name="left">The first angle.</param>
        /// <param name="right">The second angle.</param>
        /// <returns><c>true</c> if the first angle is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(AngleMeasure left, AngleMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one angle measurement is less than another.
        /// </summary>
        /// <param name="left">The first angle.</param>
        /// <param name="right">The second angle.</param>
        /// <returns><c>true</c> if the first angle is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(AngleMeasure left, AngleMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one angle measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first angle.</param>
        /// <param name="right">The second angle.</param>
        /// <returns><c>true</c> if the first angle is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(AngleMeasure left, AngleMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one angle measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first angle.</param>
        /// <param name="right">The second angle.</param>
        /// <returns><c>true</c> if the first angle is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(AngleMeasure left, AngleMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current angle measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current angle measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current angle measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this angle measurement.
        /// </summary>
        /// <returns>A hash code for the current angle measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the angle measurement.
        /// </summary>
        /// <returns>A string representing the angle in degrees.</returns>
        public override string ToString() => $"{BaseValue}°";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="AngleMeasure"/> values.
    /// </summary>
    public static class AngleExtensions
    {
        private const double _Degree = 1.0;
        private const double _Radian = 180.0 / Math.PI;
        private const double _Grad = 0.9;
        private const double _Minute = 1.0 / 60.0;
        private const double _Second = 1.0 / 3600.0;

        /// <summary>Creates an angle value expressed in degrees (°).</summary>
        /// <param name="value">The value in degrees.</param>
        /// <returns>An <see cref="AngleMeasure"/> representing the angle.</returns>
        public static AngleMeasure Degrees(this double value) => new(value * _Degree);

        /// <summary>Creates an angle value expressed in radians (rad).</summary>
        /// <param name="value">The value in radians.</param>
        /// <returns>An <see cref="AngleMeasure"/> representing the angle.</returns>
        public static AngleMeasure Radians(this double value) => new(value * _Radian);

        /// <summary>Creates an angle value expressed in gradians (gon).</summary>
        /// <param name="value">The value in gradians.</param>
        /// <returns>An <see cref="AngleMeasure"/> representing the angle.</returns>
        public static AngleMeasure Grads(this double value) => new(value * _Grad);

        /// <summary>Creates an angle value expressed in arcminutes (').</summary>
        /// <param name="value">The value in arcminutes.</param>
        /// <returns>An <see cref="AngleMeasure"/> representing the angle.</returns>
        public static AngleMeasure ArcMinutes(this double value) => new(value * _Minute);

        /// <summary>Creates an angle value expressed in arcseconds (").</summary>
        /// <param name="value">The value in arcseconds.</param>
        /// <returns>An <see cref="AngleMeasure"/> representing the angle.</returns>
        public static AngleMeasure ArcSeconds(this double value) => new(value * _Second);

        /// <summary>Converts the angle to degrees (°).</summary>
        /// <param name="a">The angle measurement.</param>
        /// <returns>The angle in degrees.</returns>
        public static double ToDegrees(this AngleMeasure a) => a.To(_Degree);

        /// <summary>Converts the angle to radians (rad).</summary>
        /// <param name="a">The angle measurement.</param>
        /// <returns>The angle in radians.</returns>
        public static double ToRadians(this AngleMeasure a) => a.To(_Radian);

        /// <summary>Converts the angle to gradians (gon).</summary>
        /// <param name="a">The angle measurement.</param>
        /// <returns>The angle in gradians.</returns>
        public static double ToGrads(this AngleMeasure a) => a.To(_Grad);

        /// <summary>Converts the angle to arcminutes (').</summary>
        /// <param name="a">The angle measurement.</param>
        /// <returns>The angle in arcminutes.</returns>
        public static double ToArcMinutes(this AngleMeasure a) => a.To(_Minute);

        /// <summary>Converts the angle to arcseconds (").</summary>
        /// <param name="a">The angle measurement.</param>
        /// <returns>The angle in arcseconds.</returns>
        public static double ToArcSeconds(this AngleMeasure a) => a.To(_Second);
    }
}
