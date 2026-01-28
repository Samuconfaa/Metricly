using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a length value expressed in a base unit (meters) with support for arithmetic operations.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="LengthMeasure"/> class
    /// using a value expressed in meters.
    /// </remarks>
    /// <param name="baseValue">The length value in meters.</param>
    public class LengthMeasure(double baseValue) : IMeasure<LengthMeasure>
    {
        /// <summary>
        /// Gets the internal length value expressed in meters.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal length value to a target unit.
        /// </summary>
        /// <param name="factor">
        /// The conversion factor representing how many meters correspond
        /// to one unit of the target measurement.
        /// </param>
        /// <returns>The converted length value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new length measurement from a base value.
        /// </summary>
        public LengthMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two length measurements.
        /// </summary>
        public LengthMeasure Add(LengthMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another length measurement from this one.
        /// </summary>
        public LengthMeasure Subtract(LengthMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the length by a scalar value.
        /// </summary>
        public LengthMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the length by a scalar value.
        /// </summary>
        public LengthMeasure Divide(double scalar) => new(BaseValue / scalar);
        /// <summary>
        /// Divides this length by another length and returns a dimensionless ratio.
        /// </summary>
        /// <param name="other">The length to divide by.</param>
        /// <returns>
        /// A double representing how many times the current length contains the specified length.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <c>null</c>.
        /// </exception>
        public double DivideBy(LengthMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two length values.
        /// </summary>
        /// <param name="left">The first length.</param>
        /// <param name="right">The second length.</param>
        /// <returns>A new <see cref="LengthMeasure"/> representing the sum.</returns>
        public static LengthMeasure operator +(LengthMeasure left, LengthMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one length value from another.
        /// </summary>
        /// <param name="left">The length to subtract from.</param>
        /// <param name="right">The length to subtract.</param>
        /// <returns>A new <see cref="LengthMeasure"/> representing the difference.</returns>
        public static LengthMeasure operator -(LengthMeasure left, LengthMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a length value by a scalar.
        /// </summary>
        /// <param name="left">The length value.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="LengthMeasure"/> representing the scaled length.</returns>
        public static LengthMeasure operator *(LengthMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a length value by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The length value.</param>
        /// <returns>A new <see cref="LengthMeasure"/> representing the scaled length.</returns>
        public static LengthMeasure operator *(double scalar, LengthMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a length value by a scalar.
        /// </summary>
        /// <param name="left">The length value.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="LengthMeasure"/> representing the scaled length.</returns>
        public static LengthMeasure operator /(LengthMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one length by another and returns a dimensionless ratio.
        /// </summary>
        /// <param name="left">The dividend length.</param>
        /// <param name="right">The divisor length.</param>
        /// <returns>
        /// A double representing the ratio between the two lengths.
        /// </returns>
        public static double operator /(LengthMeasure left, LengthMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two length values are equal within a small tolerance.
        /// </summary>
        /// <param name="left">The first length.</param>
        /// <param name="right">The second length.</param>
        /// <returns><c>true</c> if the lengths are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(LengthMeasure left, LengthMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two length values are not equal.
        /// </summary>
        /// <param name="left">The first length.</param>
        /// <param name="right">The second length.</param>
        /// <returns><c>true</c> if the lengths are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(LengthMeasure left, LengthMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one length is greater than another.
        /// </summary>
        /// <param name="left">The first length.</param>
        /// <param name="right">The second length.</param>
        /// <returns><c>true</c> if the first length is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(LengthMeasure left, LengthMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one length is less than another.
        /// </summary>
        /// <param name="left">The first length.</param>
        /// <param name="right">The second length.</param>
        /// <returns><c>true</c> if the first length is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(LengthMeasure left, LengthMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one length is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first length.</param>
        /// <param name="right">The second length.</param>
        /// <returns><c>true</c> if the first length is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(LengthMeasure left, LengthMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one length is less than or equal to another.
        /// </summary>
        /// <param name="left">The first length.</param>
        /// <param name="right">The second length.</param>
        /// <returns><c>true</c> if the first length is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(LengthMeasure left, LengthMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current length value.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>
        /// <c>true</c> if the specified object is a <see cref="LengthMeasure"/> and represents the same length;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns a hash code for the current length value.
        /// </summary>
        /// <returns>A hash code for the current instance.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the length expressed in meters.
        /// </summary>
        /// <returns>A string representing the length.</returns>
        public override string ToString() => $"{BaseValue} m";

    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="LengthMeasure"/> values.
    /// </summary>
    public static class LengthExtensions
    {
        // -------------------------
        // Metric units
        // -------------------------
        private const double _Meter = 1.0;
        private const double _Kilometer = 1_000.0;
        private const double _Centimeter = 0.01;
        private const double _Millimeter = 0.001;
        private const double _Micrometer = 0.000001;
        private const double _Nanometer = 1e-9;
        private const double _Picometer = 1e-12;
        private const double _Megameter = 1_000_000.0;
        private const double _Gigameter = 1_000_000_000.0;

        // -------------------------
        // Imperial / nautical units
        // -------------------------
        private const double _Inch = 0.0254;
        private const double _Foot = 0.3048;
        private const double _Yard = 0.9144;
        private const double _Mile = 1_609.344;
        private const double _NauticalMile = 1_852.0;
        private const double _Mil = 0.0000254;
        private const double _Furlong = 201.168;
        private const double _Chain = 20.1168;

        // -------------------------
        // Astronomical units
        // -------------------------
        private const double _AstronomicalUnit = 149_597_870_700.0;
        private const double _LightYear = 9.4607e15;
        private const double _Parsec = 3.0857e16;

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a length value expressed in meters.</summary>
        public static LengthMeasure Meters(this double value) => new(value * _Meter);

        /// <summary>Creates a length value expressed in kilometers.</summary>
        public static LengthMeasure Kilometers(this double value) => new(value * _Kilometer);

        /// <summary>Creates a length value expressed in centimeters.</summary>
        public static LengthMeasure Centimeters(this double value) => new(value * _Centimeter);

        /// <summary>Creates a length value expressed in millimeters.</summary>
        public static LengthMeasure Millimeters(this double value) => new(value * _Millimeter);

        /// <summary>Creates a length value expressed in micrometers.</summary>
        public static LengthMeasure Micrometers(this double value) => new(value * _Micrometer);

        /// <summary>Creates a length value expressed in nanometers.</summary>
        public static LengthMeasure Nanometers(this double value) => new(value * _Nanometer);

        /// <summary>Creates a length value expressed in picometers.</summary>
        public static LengthMeasure Picometers(this double value) => new(value * _Picometer);

        /// <summary>Creates a length value expressed in megameters.</summary>
        public static LengthMeasure Megameters(this double value) => new(value * _Megameter);

        /// <summary>Creates a length value expressed in gigameters.</summary>
        public static LengthMeasure Gigameters(this double value) => new(value * _Gigameter);

        /// <summary>Creates a length value expressed in inches.</summary>
        public static LengthMeasure Inches(this double value) => new(value * _Inch);

        /// <summary>Creates a length value expressed in feet.</summary>
        public static LengthMeasure Feet(this double value) => new(value * _Foot);

        /// <summary>Creates a length value expressed in yards.</summary>
        public static LengthMeasure Yards(this double value) => new(value * _Yard);

        /// <summary>Creates a length value expressed in miles.</summary>
        public static LengthMeasure Miles(this double value) => new(value * _Mile);

        /// <summary>Creates a length value expressed in nautical miles.</summary>
        public static LengthMeasure NauticalMiles(this double value) => new(value * _NauticalMile);

        /// <summary>Creates a length value expressed in mils (1/1000 inch).</summary>
        public static LengthMeasure Mils(this double value) => new(value * _Mil);

        /// <summary>Creates a length value expressed in furlongs.</summary>
        public static LengthMeasure Furlongs(this double value) => new(value * _Furlong);

        /// <summary>Creates a length value expressed in chains.</summary>
        public static LengthMeasure Chains(this double value) => new(value * _Chain);

        /// <summary>Creates a length value expressed in astronomical units (AU).</summary>
        public static LengthMeasure AstronomicalUnits(this double value) => new(value * _AstronomicalUnit);

        /// <summary>Creates a length value expressed in light years.</summary>
        public static LengthMeasure LightYears(this double value) => new(value * _LightYear);

        /// <summary>Creates a length value expressed in parsecs.</summary>
        public static LengthMeasure Parsecs(this double value) => new(value * _Parsec);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the length value to meters.</summary>
        public static double ToMeters(this LengthMeasure m) => m.To(_Meter);

        /// <summary>Converts the length value to kilometers.</summary>
        public static double ToKilometers(this LengthMeasure m) => m.To(_Kilometer);

        /// <summary>Converts the length value to centimeters.</summary>
        public static double ToCentimeters(this LengthMeasure m) => m.To(_Centimeter);

        /// <summary>Converts the length value to millimeters.</summary>
        public static double ToMillimeters(this LengthMeasure m) => m.To(_Millimeter);

        /// <summary>Converts the length value to micrometers.</summary>
        public static double ToMicrometers(this LengthMeasure m) => m.To(_Micrometer);

        /// <summary>Converts the length value to nanometers.</summary>
        public static double ToNanometers(this LengthMeasure m) => m.To(_Nanometer);

        /// <summary>Converts the length value to picometers.</summary>
        public static double ToPicometers(this LengthMeasure m) => m.To(_Picometer);

        /// <summary>Converts the length value to megameters.</summary>
        public static double ToMegameters(this LengthMeasure m) => m.To(_Megameter);

        /// <summary>Converts the length value to gigameters.</summary>
        public static double ToGigameters(this LengthMeasure m) => m.To(_Gigameter);

        /// <summary>Converts the length value to inches.</summary>
        public static double ToInches(this LengthMeasure m) => m.To(_Inch);

        /// <summary>Converts the length value to feet.</summary>
        public static double ToFeet(this LengthMeasure m) => m.To(_Foot);

        /// <summary>Converts the length value to yards.</summary>
        public static double ToYards(this LengthMeasure m) => m.To(_Yard);

        /// <summary>Converts the length value to miles.</summary>
        public static double ToMiles(this LengthMeasure m) => m.To(_Mile);

        /// <summary>Converts the length value to nautical miles.</summary>
        public static double ToNauticalMiles(this LengthMeasure m) => m.To(_NauticalMile);

        /// <summary>Converts the length value to mils.</summary>
        public static double ToMils(this LengthMeasure m) => m.To(_Mil);

        /// <summary>Converts the length value to furlongs.</summary>
        public static double ToFurlongs(this LengthMeasure m) => m.To(_Furlong);

        /// <summary>Converts the length value to chains.</summary>
        public static double ToChains(this LengthMeasure m) => m.To(_Chain);

        /// <summary>Converts the length value to astronomical units (AU).</summary>
        public static double ToAstronomicalUnits(this LengthMeasure m) => m.To(_AstronomicalUnit);

        /// <summary>Converts the length value to light years.</summary>
        public static double ToLightYears(this LengthMeasure m) => m.To(_LightYear);

        /// <summary>Converts the length value to parsecs.</summary>
        public static double ToParsecs(this LengthMeasure m) => m.To(_Parsec);
    }
}