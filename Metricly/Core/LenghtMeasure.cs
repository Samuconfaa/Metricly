namespace Metricly.Core
{
    /// <summary>
    /// Represents a length value expressed in a base unit (meters).
    /// </summary>
    /// <remarks>
    /// The internal value is always stored in meters.
    /// Conversions to other units are performed using predefined conversion factors.
    /// </remarks>
    public class LenghtMeasure
    {
        /// <summary>
        /// Gets the internal length value expressed in meters.
        /// </summary>
        public double BaseValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LenghtMeasure"/> class
        /// using a value expressed in meters.
        /// </summary>
        /// <param name="baseValue">The length value in meters.</param>
        public LenghtMeasure(double baseValue)
        {
            BaseValue = baseValue;
        }

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
        private const double Meter = 1.0;

        /// <summary>Represents one kilometer (1,000 meters).</summary>
        private const double Kilometer = 1000.0;

        /// <summary>Represents one centimeter (0.01 meters).</summary>
        private const double Centimeter = 0.01;

        /// <summary>Represents one millimeter (0.001 meters).</summary>
        private const double Millimeter = 0.001;

        /// <summary>Represents one micrometer (0.000001 meters).</summary>
        private const double Micrometer = 0.000001;

        // -------------------------
        // Imperial / nautical units
        // -------------------------

        /// <summary>Represents one inch (0.0254 meters).</summary>
        private const double Inch = 0.0254;

        /// <summary>Represents one mile (1,609.344 meters).</summary>
        private const double Mile = 1609.344;

        /// <summary>Represents one yard (0.9144 meters).</summary>
        private const double Yard = 0.9144;

        /// <summary>Represents one foot (0.3048 meters).</summary>
        private const double Foot = 0.3048;

        /// <summary>Represents one nautical mile (1,852 meters).</summary>
        private const double NauticalMile = 1852;

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a length value expressed in meters.</summary>
        public static LenghtMeasure Meters(this double value) => new(value * Meter);

        /// <summary>Creates a length value expressed in kilometers.</summary>
        public static LenghtMeasure Kilometers(this double value) => new(value * Kilometer);

        /// <summary>Creates a length value expressed in centimeters.</summary>
        public static LenghtMeasure Centimetres(this double value) => new(value * Centimeter);

        /// <summary>Creates a length value expressed in millimeters.</summary>
        public static LenghtMeasure Millimetres(this double value) => new(value * Millimeter);

        /// <summary>Creates a length value expressed in micrometers.</summary>
        public static LenghtMeasure Micrometres(this double value) => new(value * Micrometer);

        /// <summary>Creates a length value expressed in inches.</summary>
        public static LenghtMeasure Inches(this double value) => new(value * Inch);

        /// <summary>Creates a length value expressed in miles.</summary>
        public static LenghtMeasure Miles(this double value) => new(value * Mile);

        /// <summary>Creates a length value expressed in yards.</summary>
        public static LenghtMeasure Yards(this double value) => new(value * Yard);

        /// <summary>Creates a length value expressed in feet.</summary>
        public static LenghtMeasure Feet(this double value) => new(value * Foot);

        /// <summary>Creates a length value expressed in nautical miles.</summary>
        public static LenghtMeasure NauticalMiles(this double value) => new(value * NauticalMile);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the length value to meters.</summary>
        public static double ToMeters(this LenghtMeasure m) => m.To(Meter);

        /// <summary>Converts the length value to kilometers.</summary>
        public static double ToKilometers(this LenghtMeasure m) => m.To(Kilometer);

        /// <summary>Converts the length value to centimeters.</summary>
        public static double ToCentimetres(this LenghtMeasure m) => m.To(Centimeter);

        /// <summary>Converts the length value to millimeters.</summary>
        public static double ToMillimetres(this LenghtMeasure m) => m.To(Millimeter);

        /// <summary>Converts the length value to micrometers.</summary>
        public static double ToMicrometres(this LenghtMeasure m) => m.To(Micrometer);

        /// <summary>Converts the length value to inches.</summary>
        public static double ToInches(this LenghtMeasure m) => m.To(Inch);

        /// <summary>Converts the length value to miles.</summary>
        public static double ToMiles(this LenghtMeasure m) => m.To(Mile);

        /// <summary>Converts the length value to yards.</summary>
        public static double ToYards(this LenghtMeasure m) => m.To(Yard);

        /// <summary>Converts the length value to feet.</summary>
        public static double ToFeet(this LenghtMeasure m) => m.To(Foot);

        /// <summary>Converts the length value to nautical miles.</summary>
        public static double ToNauticalMiles(this LenghtMeasure m) => m.To(NauticalMile);
    }
}
