using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a fuel consumption value expressed in a base unit (kilometers per liter).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FuelMeasure"/> class
    /// using a value expressed in kilometers per liter.
    /// </remarks>
    /// <param name="baseValue">The fuel consumption value in km/L.</param>
    public class FuelMeasure(double baseValue) : IMeasure<FuelMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in kilometers per liter (km/L).
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new fuel consumption measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in kilometers per liter.</param>
        /// <returns>A new <see cref="FuelMeasure"/> instance.</returns>
        public FuelMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two fuel consumption measurements.
        /// </summary>
        /// <param name="other">The fuel consumption to add.</param>
        /// <returns>A new <see cref="FuelMeasure"/> representing the sum.</returns>
        public FuelMeasure Add(FuelMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another fuel consumption measurement from this one.
        /// </summary>
        /// <param name="other">The fuel consumption to subtract.</param>
        /// <returns>A new <see cref="FuelMeasure"/> representing the difference.</returns>
        public FuelMeasure Subtract(FuelMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the fuel consumption by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="FuelMeasure"/> representing the product.</returns>
        public FuelMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the fuel consumption by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="FuelMeasure"/> representing the quotient.</returns>
        public FuelMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this fuel consumption by another fuel consumption to get a ratio.
        /// </summary>
        /// <param name="other">The fuel consumption to divide by.</param>
        /// <returns>The ratio between the two fuel consumptions.</returns>
        public double DivideBy(FuelMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two fuel consumption measurements.
        /// </summary>
        /// <param name="left">The first fuel consumption.</param>
        /// <param name="right">The second fuel consumption.</param>
        /// <returns>The sum of the two fuel consumptions.</returns>
        public static FuelMeasure operator +(FuelMeasure left, FuelMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one fuel consumption measurement from another.
        /// </summary>
        /// <param name="left">The fuel consumption to subtract from.</param>
        /// <param name="right">The fuel consumption to subtract.</param>
        /// <returns>The difference between the two fuel consumptions.</returns>
        public static FuelMeasure operator -(FuelMeasure left, FuelMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a fuel consumption measurement by a scalar.
        /// </summary>
        /// <param name="left">The fuel consumption.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the fuel consumption and scalar.</returns>
        public static FuelMeasure operator *(FuelMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a fuel consumption measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The fuel consumption.</param>
        /// <returns>The product of the scalar and fuel consumption.</returns>
        public static FuelMeasure operator *(double scalar, FuelMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a fuel consumption measurement by a scalar.
        /// </summary>
        /// <param name="left">The fuel consumption.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the fuel consumption and scalar.</returns>
        public static FuelMeasure operator /(FuelMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one fuel consumption measurement by another.
        /// </summary>
        /// <param name="left">The dividend fuel consumption.</param>
        /// <param name="right">The divisor fuel consumption.</param>
        /// <returns>The ratio between the two fuel consumptions.</returns>
        public static double operator /(FuelMeasure left, FuelMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two fuel consumption measurements are equal.
        /// </summary>
        /// <param name="left">The first fuel consumption.</param>
        /// <param name="right">The second fuel consumption.</param>
        /// <returns><c>true</c> if the fuel consumptions are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(FuelMeasure left, FuelMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two fuel consumption measurements are not equal.
        /// </summary>
        /// <param name="left">The first fuel consumption.</param>
        /// <param name="right">The second fuel consumption.</param>
        /// <returns><c>true</c> if the fuel consumptions are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(FuelMeasure left, FuelMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one fuel consumption measurement is greater than another.
        /// </summary>
        /// <param name="left">The first fuel consumption.</param>
        /// <param name="right">The second fuel consumption.</param>
        /// <returns><c>true</c> if the first fuel consumption is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(FuelMeasure left, FuelMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one fuel consumption measurement is less than another.
        /// </summary>
        /// <param name="left">The first fuel consumption.</param>
        /// <param name="right">The second fuel consumption.</param>
        /// <returns><c>true</c> if the first fuel consumption is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(FuelMeasure left, FuelMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one fuel consumption measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first fuel consumption.</param>
        /// <param name="right">The second fuel consumption.</param>
        /// <returns><c>true</c> if the first fuel consumption is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(FuelMeasure left, FuelMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one fuel consumption measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first fuel consumption.</param>
        /// <param name="right">The second fuel consumption.</param>
        /// <returns><c>true</c> if the first fuel consumption is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(FuelMeasure left, FuelMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current fuel consumption measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current fuel consumption measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current fuel consumption measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this fuel consumption measurement.
        /// </summary>
        /// <returns>A hash code for the current fuel consumption measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the fuel consumption measurement.
        /// </summary>
        /// <returns>A string representing the fuel consumption in kilometers per liter.</returns>
        public override string ToString() => $"{BaseValue} km/L";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="FuelMeasure"/> values.
    /// </summary>
    public static class FuelConsumptionExtensions
    {
        private const double _KmPerLiter = 1.0;
        private const double _MilePerUSGallon = 2.352145833;
        private const double _MilePerUKGallon = 2.824809363;

        /// <summary>Creates a fuel consumption value expressed in kilometers per liter (km/L).</summary>
        /// <param name="value">The value in km/L.</param>
        /// <returns>A <see cref="FuelMeasure"/> representing the given value in km/L.</returns>
        public static FuelMeasure KmPerLiter(this double value) => new(value * _KmPerLiter);

        /// <summary>Creates a fuel consumption value expressed in liters per 100 kilometers (L/100km).</summary>
        /// <param name="value">The value in liters per 100 km.</param>
        /// <returns>A <see cref="FuelMeasure"/> representing the equivalent km/L value.</returns>
        public static FuelMeasure LiterPer100Km(this double value) => new(100.0 / value);

        /// <summary>Creates a fuel consumption value expressed in miles per US gallon (MPG US).</summary>
        /// <param name="value">The value in MPG US.</param>
        /// <returns>A <see cref="FuelMeasure"/> representing the equivalent km/L value.</returns>
        public static FuelMeasure MpgUS(this double value) => new(value / _MilePerUSGallon);

        /// <summary>Creates a fuel consumption value expressed in miles per Imperial gallon (MPG UK).</summary>
        /// <param name="value">The value in MPG UK.</param>
        /// <returns>A <see cref="FuelMeasure"/> representing the equivalent km/L value.</returns>
        public static FuelMeasure MpgUK(this double value) => new(value / _MilePerUKGallon);

        /// <summary>Converts the fuel consumption to kilometers per liter (km/L).</summary>
        /// <param name="f">The fuel consumption measurement.</param>
        /// <returns>The fuel consumption in kilometers per liter.</returns>
        public static double ToKmPerLiter(this FuelMeasure f) => f.BaseValue;

        /// <summary>Converts the fuel consumption to liters per 100 kilometers (L/100km).</summary>
        /// <param name="f">The fuel consumption measurement.</param>
        /// <returns>The fuel consumption in liters per 100 kilometers.</returns>
        public static double ToLiterPer100Km(this FuelMeasure f) => 100.0 / f.BaseValue;

        /// <summary>Converts the fuel consumption to miles per US gallon (MPG US).</summary>
        /// <param name="f">The fuel consumption measurement.</param>
        /// <returns>The fuel consumption in miles per US gallon.</returns>
        public static double ToMpgUS(this FuelMeasure f) => f.BaseValue * _MilePerUSGallon;

        /// <summary>Converts the fuel consumption to miles per Imperial gallon (MPG UK).</summary>
        /// <param name="f">The fuel consumption measurement.</param>
        /// <returns>The fuel consumption in miles per Imperial gallon.</returns>
        public static double ToMpgUK(this FuelMeasure f) => f.BaseValue * _MilePerUKGallon;
    }
}
