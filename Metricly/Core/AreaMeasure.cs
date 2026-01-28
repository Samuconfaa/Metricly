using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents an area value expressed in a base unit (square meters).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AreaMeasure"/> class
    /// using a value expressed in square meters.
    /// </remarks>
    /// <param name="baseValue">The area value in square meters.</param>
    public class AreaMeasure(double baseValue) : IMeasure<AreaMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in square meters.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of square meters corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new area measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in square meters.</param>
        /// <returns>A new <see cref="AreaMeasure"/> instance.</returns>
        public AreaMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two area measurements.
        /// </summary>
        /// <param name="other">The area to add.</param>
        /// <returns>A new <see cref="AreaMeasure"/> representing the sum.</returns>
        public AreaMeasure Add(AreaMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another area measurement from this one.
        /// </summary>
        /// <param name="other">The area to subtract.</param>
        /// <returns>A new <see cref="AreaMeasure"/> representing the difference.</returns>
        public AreaMeasure Subtract(AreaMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the area by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="AreaMeasure"/> representing the product.</returns>
        public AreaMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the area by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="AreaMeasure"/> representing the quotient.</returns>
        public AreaMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this area by another area to get a ratio.
        /// </summary>
        /// <param name="other">The area to divide by.</param>
        /// <returns>The ratio between the two areas.</returns>
        public double DivideBy(AreaMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two area measurements.
        /// </summary>
        /// <param name="left">The first area.</param>
        /// <param name="right">The second area.</param>
        /// <returns>The sum of the two areas.</returns>
        public static AreaMeasure operator +(AreaMeasure left, AreaMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one area measurement from another.
        /// </summary>
        /// <param name="left">The area to subtract from.</param>
        /// <param name="right">The area to subtract.</param>
        /// <returns>The difference between the two areas.</returns>
        public static AreaMeasure operator -(AreaMeasure left, AreaMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies an area measurement by a scalar.
        /// </summary>
        /// <param name="left">The area.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the area and scalar.</returns>
        public static AreaMeasure operator *(AreaMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies an area measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The area.</param>
        /// <returns>The product of the scalar and area.</returns>
        public static AreaMeasure operator *(double scalar, AreaMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides an area measurement by a scalar.
        /// </summary>
        /// <param name="left">The area.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the area and scalar.</returns>
        public static AreaMeasure operator /(AreaMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one area measurement by another.
        /// </summary>
        /// <param name="left">The dividend area.</param>
        /// <param name="right">The divisor area.</param>
        /// <returns>The ratio between the two areas.</returns>
        public static double operator /(AreaMeasure left, AreaMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two area measurements are equal.
        /// </summary>
        /// <param name="left">The first area.</param>
        /// <param name="right">The second area.</param>
        /// <returns><c>true</c> if the areas are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(AreaMeasure left, AreaMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two area measurements are not equal.
        /// </summary>
        /// <param name="left">The first area.</param>
        /// <param name="right">The second area.</param>
        /// <returns><c>true</c> if the areas are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(AreaMeasure left, AreaMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one area measurement is greater than another.
        /// </summary>
        /// <param name="left">The first area.</param>
        /// <param name="right">The second area.</param>
        /// <returns><c>true</c> if the first area is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(AreaMeasure left, AreaMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one area measurement is less than another.
        /// </summary>
        /// <param name="left">The first area.</param>
        /// <param name="right">The second area.</param>
        /// <returns><c>true</c> if the first area is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(AreaMeasure left, AreaMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one area measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first area.</param>
        /// <param name="right">The second area.</param>
        /// <returns><c>true</c> if the first area is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(AreaMeasure left, AreaMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one area measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first area.</param>
        /// <param name="right">The second area.</param>
        /// <returns><c>true</c> if the first area is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(AreaMeasure left, AreaMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current area measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current area measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current area measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this area measurement.
        /// </summary>
        /// <returns>A hash code for the current area measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the area measurement.
        /// </summary>
        /// <returns>A string representing the area in square meters.</returns>
        public override string ToString() => $"{BaseValue} m²";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="AreaMeasure"/> values.
    /// </summary>
    public static class AreaExtensions
    {
        private const double _SquareMeter = 1.0;
        private const double _SquareKilometer = 1_000_000.0;
        private const double _Hectare = 10_000.0;
        private const double _Are = 100.0;
        private const double _SquareDecimeter = 0.01;
        private const double _SquareCentimeter = 0.0001;
        private const double _SquareMillimeter = 0.000001;
        private const double _SquareInch = 0.00064516;
        private const double _SquareFoot = 0.092903;
        private const double _SquareYard = 0.836127;
        private const double _Acre = 4046.8564224;
        private const double _SquareMile = 2_589_988.110336;

        /// <summary>Creates an area value expressed in square meters (m²).</summary>
        /// <param name="value">The value in square meters.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareMeters(this double value) => new(value * _SquareMeter);

        /// <summary>Creates an area value expressed in square kilometers (km²).</summary>
        /// <param name="value">The value in square kilometers.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareKilometers(this double value) => new(value * _SquareKilometer);

        /// <summary>Creates an area value expressed in hectares (ha).</summary>
        /// <param name="value">The value in hectares.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure Hectares(this double value) => new(value * _Hectare);

        /// <summary>Creates an area value expressed in ares (a).</summary>
        /// <param name="value">The value in ares.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure Ares(this double value) => new(value * _Are);

        /// <summary>Creates an area value expressed in square decimeters (dm²).</summary>
        /// <param name="value">The value in square decimeters.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareDecimeters(this double value) => new(value * _SquareDecimeter);

        /// <summary>Creates an area value expressed in square centimeters (cm²).</summary>
        /// <param name="value">The value in square centimeters.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareCentimeters(this double value) => new(value * _SquareCentimeter);

        /// <summary>Creates an area value expressed in square millimeters (mm²).</summary>
        /// <param name="value">The value in square millimeters.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareMillimeters(this double value) => new(value * _SquareMillimeter);

        /// <summary>Creates an area value expressed in square inches (in²).</summary>
        /// <param name="value">The value in square inches.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareInches(this double value) => new(value * _SquareInch);

        /// <summary>Creates an area value expressed in square feet (ft²).</summary>
        /// <param name="value">The value in square feet.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareFeet(this double value) => new(value * _SquareFoot);

        /// <summary>Creates an area value expressed in square yards (yd²).</summary>
        /// <param name="value">The value in square yards.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareYards(this double value) => new(value * _SquareYard);

        /// <summary>Creates an area value expressed in acres (ac).</summary>
        /// <param name="value">The value in acres.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure Acres(this double value) => new(value * _Acre);

        /// <summary>Creates an area value expressed in square miles (mi²).</summary>
        /// <param name="value">The value in square miles.</param>
        /// <returns>An <see cref="AreaMeasure"/> representing the area.</returns>
        public static AreaMeasure SquareMiles(this double value) => new(value * _SquareMile);

        /// <summary>Converts the area to square meters (m²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square meters.</returns>
        public static double ToSquareMeters(this AreaMeasure a) => a.To(_SquareMeter);

        /// <summary>Converts the area to square kilometers (km²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square kilometers.</returns>
        public static double ToSquareKilometers(this AreaMeasure a) => a.To(_SquareKilometer);

        /// <summary>Converts the area to hectares (ha).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in hectares.</returns>
        public static double ToHectares(this AreaMeasure a) => a.To(_Hectare);

        /// <summary>Converts the area to ares (a).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in ares.</returns>
        public static double ToAres(this AreaMeasure a) => a.To(_Are);

        /// <summary>Converts the area to square decimeters (dm²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square decimeters.</returns>
        public static double ToSquareDecimeters(this AreaMeasure a) => a.To(_SquareDecimeter);

        /// <summary>Converts the area to square centimeters (cm²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square centimeters.</returns>
        public static double ToSquareCentimeters(this AreaMeasure a) => a.To(_SquareCentimeter);

        /// <summary>Converts the area to square millimeters (mm²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square millimeters.</returns>
        public static double ToSquareMillimeters(this AreaMeasure a) => a.To(_SquareMillimeter);

        /// <summary>Converts the area to square inches (in²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square inches.</returns>
        public static double ToSquareInches(this AreaMeasure a) => a.To(_SquareInch);

        /// <summary>Converts the area to square feet (ft²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square feet.</returns>
        public static double ToSquareFeet(this AreaMeasure a) => a.To(_SquareFoot);

        /// <summary>Converts the area to square yards (yd²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square yards.</returns>
        public static double ToSquareYards(this AreaMeasure a) => a.To(_SquareYard);

        /// <summary>Converts the area to acres (ac).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in acres.</returns>
        public static double ToAcres(this AreaMeasure a) => a.To(_Acre);

        /// <summary>Converts the area to square miles (mi²).</summary>
        /// <param name="a">The area measurement.</param>
        /// <returns>The area in square miles.</returns>
        public static double ToSquareMiles(this AreaMeasure a) => a.To(_SquareMile);
    }
}
