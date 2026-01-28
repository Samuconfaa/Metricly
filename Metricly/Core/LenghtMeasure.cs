using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a length value expressed in a base unit (meters).
    /// </summary>
    /// <remarks>
    /// The internal value is always stored in meters.
    /// Conversions to other units are performed using predefined conversion factors.
    /// </remarks>
    /// <remarks>
    /// Initializes a new instance of the <see cref="LenghtMeasure"/> class
    /// using a value expressed in meters.
    /// </remarks>
    /// <param name="baseValue">The length value in meters.</param>
    public class LenghtMeasure(double baseValue)
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
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="LenghtMeasure"/> values.
    /// </summary>
    /// <remarks>
    /// All conversion factors are defined as the equivalent number of meters
    /// for one unit of the corresponding measurement.
    /// </remarks>
    public static class LenghtExtension
    {
        // -------------------------
        // Metric units
        // -------------------------

        /// <summary>Represents one meter.</summary>
        private const double _Meter = 1.0;

        /// <summary>Represents one kilometer (1,000 meters).</summary>
        private const double _Kilometer = 1_000.0;

        /// <summary>Represents one centimeter (0.01 meters).</summary>
        private const double _Centimeter = 0.01;

        /// <summary>Represents one millimeter (0.001 meters).</summary>
        private const double _Millimeter = 0.001;

        /// <summary>Represents one micrometer (0.000001 meters).</summary>
        private const double _Micrometer = 0.000001;

        /// <summary>Represents one nanometer (1e-9 meters).</summary>
        private const double _Nanometer = 1e-9;

        /// <summary>Represents one picometer (1e-12 meters).</summary>
        private const double _Picometer = 1e-12;

        /// <summary>Represents one megameter (1,000,000 meters).</summary>
        private const double _Megameter = 1_000_000.0;

        /// <summary>Represents one gigameter (1,000,000,000 meters).</summary>
        private const double _Gigameter = 1_000_000_000.0;

        // -------------------------
        // Imperial / nautical units
        // -------------------------

        /// <summary>Represents one inch (0.0254 meters).</summary>
        private const double _Inch = 0.0254;

        /// <summary>Represents one foot (0.3048 meters).</summary>
        private const double _Foot = 0.3048;

        /// <summary>Represents one yard (0.9144 meters).</summary>
        private const double _Yard = 0.9144;

        /// <summary>Represents one mile (1,609.344 meters).</summary>
        private const double _Mile = 1_609.344;

        /// <summary>Represents one nautical mile (1,852 meters).</summary>
        private const double _NauticalMile = 1_852.0;

        /// <summary>Represents one mil (0.0000254 meters, 1/1000 inch).</summary>
        private const double _Mil = 0.0000254;

        /// <summary>Represents one furlong (201.168 meters).</summary>
        private const double _Furlong = 201.168;

        /// <summary>Represents one chain (20.1168 meters).</summary>
        private const double _Chain = 20.1168;

        // -------------------------
        // Astronomical units
        // -------------------------

        /// <summary>Represents one astronomical unit (149,597,870,700 meters).</summary>
        private const double _AstronomicalUnit = 149_597_870_700.0;

        /// <summary>Represents one light year (9.4607×10¹⁵ meters).</summary>
        private const double _LightYear = 9.4607e15;

        /// <summary>Represents one parsec (3.0857×10¹⁶ meters).</summary>
        private const double _Parsec = 3.0857e16;

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a length value expressed in meters.</summary>
        public static LenghtMeasure Meters(this double value) => new(value * _Meter);

        /// <summary>Creates a length value expressed in kilometers.</summary>
        public static LenghtMeasure Kilometers(this double value) => new(value * _Kilometer);

        /// <summary>Creates a length value expressed in centimeters.</summary>
        public static LenghtMeasure Centimetres(this double value) => new(value * _Centimeter);

        /// <summary>Creates a length value expressed in millimeters.</summary>
        public static LenghtMeasure Millimetres(this double value) => new(value * _Millimeter);

        /// <summary>Creates a length value expressed in micrometers.</summary>
        public static LenghtMeasure Micrometres(this double value) => new(value * _Micrometer);

        /// <summary>Creates a length value expressed in nanometers.</summary>
        public static LenghtMeasure Nanometres(this double value) => new(value * _Nanometer);

        /// <summary>Creates a length value expressed in picometers.</summary>
        public static LenghtMeasure Picometres(this double value) => new(value * _Picometer);

        /// <summary>Creates a length value expressed in megameters.</summary>
        public static LenghtMeasure Megametres(this double value) => new(value * _Megameter);

        /// <summary>Creates a length value expressed in gigameters.</summary>
        public static LenghtMeasure Gigametres(this double value) => new(value * _Gigameter);

        /// <summary>Creates a length value expressed in inches.</summary>
        public static LenghtMeasure Inches(this double value) => new(value * _Inch);

        /// <summary>Creates a length value expressed in feet.</summary>
        public static LenghtMeasure Feet(this double value) => new(value * _Foot);

        /// <summary>Creates a length value expressed in yards.</summary>
        public static LenghtMeasure Yards(this double value) => new(value * _Yard);

        /// <summary>Creates a length value expressed in miles.</summary>
        public static LenghtMeasure Miles(this double value) => new(value * _Mile);

        /// <summary>Creates a length value expressed in nautical miles.</summary>
        public static LenghtMeasure NauticalMiles(this double value) => new(value * _NauticalMile);

        /// <summary>Creates a length value expressed in mils (1/1000 inch).</summary>
        public static LenghtMeasure Mils(this double value) => new(value * _Mil);

        /// <summary>Creates a length value expressed in furlongs.</summary>
        public static LenghtMeasure Furlongs(this double value) => new(value * _Furlong);

        /// <summary>Creates a length value expressed in chains.</summary>
        public static LenghtMeasure Chains(this double value) => new(value * _Chain);

        /// <summary>Creates a length value expressed in astronomical units (AU).</summary>
        public static LenghtMeasure AstronomicalUnits(this double value) => new(value * _AstronomicalUnit);

        /// <summary>Creates a length value expressed in light years.</summary>
        public static LenghtMeasure LightYears(this double value) => new(value * _LightYear);

        /// <summary>Creates a length value expressed in parsecs.</summary>
        public static LenghtMeasure Parsecs(this double value) => new(value * _Parsec);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the length value to meters.</summary>
        public static double ToMeters(this LenghtMeasure m) => m.To(_Meter);

        /// <summary>Converts the length value to kilometers.</summary>
        public static double ToKilometers(this LenghtMeasure m) => m.To(_Kilometer);

        /// <summary>Converts the length value to centimeters.</summary>
        public static double ToCentimetres(this LenghtMeasure m) => m.To(_Centimeter);

        /// <summary>Converts the length value to millimeters.</summary>
        public static double ToMillimetres(this LenghtMeasure m) => m.To(_Millimeter);

        /// <summary>Converts the length value to micrometers.</summary>
        public static double ToMicrometres(this LenghtMeasure m) => m.To(_Micrometer);

        /// <summary>Converts the length value to nanometers.</summary>
        public static double ToNanometres(this LenghtMeasure m) => m.To(_Nanometer);

        /// <summary>Converts the length value to picometers.</summary>
        public static double ToPicometres(this LenghtMeasure m) => m.To(_Picometer);

        /// <summary>Converts the length value to megameters.</summary>
        public static double ToMegametres(this LenghtMeasure m) => m.To(_Megameter);

        /// <summary>Converts the length value to gigameters.</summary>
        public static double ToGigametres(this LenghtMeasure m) => m.To(_Gigameter);

        /// <summary>Converts the length value to inches.</summary>
        public static double ToInches(this LenghtMeasure m) => m.To(_Inch);

        /// <summary>Converts the length value to feet.</summary>
        public static double ToFeet(this LenghtMeasure m) => m.To(_Foot);

        /// <summary>Converts the length value to yards.</summary>
        public static double ToYards(this LenghtMeasure m) => m.To(_Yard);

        /// <summary>Converts the length value to miles.</summary>
        public static double ToMiles(this LenghtMeasure m) => m.To(_Mile);

        /// <summary>Converts the length value to nautical miles.</summary>
        public static double ToNauticalMiles(this LenghtMeasure m) => m.To(_NauticalMile);

        /// <summary>Converts the length value to mils.</summary>
        public static double ToMils(this LenghtMeasure m) => m.To(_Mil);

        /// <summary>Converts the length value to furlongs.</summary>
        public static double ToFurlongs(this LenghtMeasure m) => m.To(_Furlong);

        /// <summary>Converts the length value to chains.</summary>
        public static double ToChains(this LenghtMeasure m) => m.To(_Chain);

        /// <summary>Converts the length value to astronomical units (AU).</summary>
        public static double ToAstronomicalUnits(this LenghtMeasure m) => m.To(_AstronomicalUnit);

        /// <summary>Converts the length value to light years.</summary>
        public static double ToLightYears(this LenghtMeasure m) => m.To(_LightYear);

        /// <summary>Converts the length value to parsecs.</summary>
        public static double ToParsecs(this LenghtMeasure m) => m.To(_Parsec);
    }
}
