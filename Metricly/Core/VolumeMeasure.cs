using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a volume value expressed in a base unit (liter).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="VolumeMeasure"/> class
    /// using a value expressed in liters.
    /// </remarks>
    /// <param name="baseValue">The volume value in liters.</param>
    public class VolumeMeasure(double baseValue)
    {
        /// <summary>
        /// Gets the internal value expressed in liters.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of liters corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="VolumeMeasure"/> values.
    /// </summary>
    public static class VolumeExtensions
    {
        // -------------------------
        // Conversion factors 
        // -------------------------

        /// <summary>One cubic kilometer expressed in liters.</summary>
        private const double CubicKilometer = 1e12;

        /// <summary>One cubic meter expressed in liters.</summary>
        private const double CubicMeter = 1_000.0;

        /// <summary>One cubic decimeter (liter) expressed in liters.</summary>
        private const double CubicDecimeter = 1.0;

        /// <summary>One cubic centimeter expressed in liters.</summary>
        private const double CubicCentimeter = 0.001;

        /// <summary>One cubic millimeter expressed in liters.</summary>
        private const double CubicMillimeter = 1e-6;

        /// <summary>One liter.</summary>
        private const double Liter = 1.0;

        /// <summary>One deciliter expressed in liters.</summary>
        private const double Deciliter = 0.1;

        /// <summary>One centiliter expressed in liters.</summary>
        private const double Centiliter = 0.01;

        /// <summary>One milliliter expressed in liters.</summary>
        private const double Milliliter = 0.001;

        /// <summary>One microliter expressed in liters.</summary>
        private const double Microliter = 1e-6;

        /// <summary>One US gallon expressed in liters.</summary>
        private const double GallonUS = 3.785411784;

        /// <summary>One US quart expressed in liters.</summary>
        private const double QuartUS = 0.946352946;

        /// <summary>One US pint expressed in liters.</summary>
        private const double PintUS = 0.473176473;

        /// <summary>One US cup expressed in liters.</summary>
        private const double CupUS = 0.24;

        /// <summary>One US fluid ounce expressed in liters.</summary>
        private const double FluidOunceUS = 0.0295735295625;

        /// <summary>One US tablespoon expressed in liters.</summary>
        private const double TablespoonUS = 0.01478676478125;

        /// <summary>One US teaspoon expressed in liters.</summary>
        private const double TeaspoonUS = 0.00492892159375;

        /// <summary>One cubic foot expressed in liters.</summary>
        private const double CubicFoot = 28.316846592;

        /// <summary>One cubic inch expressed in liters.</summary>
        private const double CubicInch = 0.016387064;

        /// <summary>One cubic yard expressed in liters.</summary>
        private const double CubicYard = 764.554857984;

        /// <summary>One imperial gallon expressed in liters.</summary>
        private const double GallonImperial = 4.54609;

        /// <summary>One imperial quart expressed in liters.</summary>
        private const double QuartImperial = 1.1365225;

        /// <summary>One imperial pint expressed in liters.</summary>
        private const double PintImperial = 0.56826125;

        /// <summary>One imperial cup expressed in liters.</summary>
        private const double CupImperial = 0.284130625;

        /// <summary>One imperial fluid ounce expressed in liters.</summary>
        private const double FluidOunceImperial = 0.0284130625;

        /// <summary>One imperial tablespoon expressed in liters.</summary>
        private const double TablespoonImperial = 0.0177582;

        /// <summary>One imperial teaspoon expressed in liters.</summary>
        private const double TeaspoonImperial = 0.00591939;

        /// <summary>One barrel of oil expressed in liters.</summary>
        private const double BarrelOil = 158.987294928;

        /// <summary>One US dry quart expressed in liters.</summary>
        private const double QuartDryUS = 1.10122;

        /// <summary>One US dry pint expressed in liters.</summary>
        private const double PintDryUS = 0.55061;

        /// <summary>One bushel expressed in liters.</summary>
        private const double Bushel = 35.2391;

        /// <summary>One peck expressed in liters.</summary>
        private const double Peck = 8.80977;

        /// <summary>One gill expressed in liters.</summary>
        private const double Gill = 0.118294118;

        /// <summary>One dram expressed in liters.</summary>
        private const double Dram = 0.0036966912;

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a volume value expressed in cubic kilometers.</summary>
        public static VolumeMeasure CubicKilometers(this double value) => new(value * CubicKilometer);

        /// <summary>Creates a volume value expressed in cubic meters.</summary>
        public static VolumeMeasure CubicMeters(this double value) => new(value * CubicMeter);

        /// <summary>Creates a volume value expressed in cubic decimeters (liters).</summary>
        public static VolumeMeasure CubicDecimeters(this double value) => new(value * CubicDecimeter);

        /// <summary>Creates a volume value expressed in cubic centimeters.</summary>
        public static VolumeMeasure CubicCentimeters(this double value) => new(value * CubicCentimeter);

        /// <summary>Creates a volume value expressed in cubic millimeters.</summary>
        public static VolumeMeasure CubicMillimeters(this double value) => new(value * CubicMillimeter);

        /// <summary>Creates a volume value expressed in liters.</summary>
        public static VolumeMeasure Liters(this double value) => new(value * Liter);

        /// <summary>Creates a volume value expressed in deciliters.</summary>
        public static VolumeMeasure Deciliters(this double value) => new(value * Deciliter);

        /// <summary>Creates a volume value expressed in centiliters.</summary>
        public static VolumeMeasure Centiliters(this double value) => new(value * Centiliter);

        /// <summary>Creates a volume value expressed in milliliters.</summary>
        public static VolumeMeasure Milliliters(this double value) => new(value * Milliliter);

        /// <summary>Creates a volume value expressed in microliters.</summary>
        public static VolumeMeasure Microliters(this double value) => new(value * Microliter);

        /// <summary>Creates a volume value expressed in US gallons.</summary>
        public static VolumeMeasure GallonsUS(this double value) => new(value * GallonUS);

        /// <summary>Creates a volume value expressed in US quarts.</summary>
        public static VolumeMeasure QuartsUS(this double value) => new(value * QuartUS);

        /// <summary>Creates a volume value expressed in US pints.</summary>
        public static VolumeMeasure PintsUS(this double value) => new(value * PintUS);

        /// <summary>Creates a volume value expressed in US cups.</summary>
        public static VolumeMeasure CupsUS(this double value) => new(value * CupUS);

        /// <summary>Creates a volume value expressed in US fluid ounces.</summary>
        public static VolumeMeasure FluidOuncesUS(this double value) => new(value * FluidOunceUS);

        /// <summary>Creates a volume value expressed in US tablespoons.</summary>
        public static VolumeMeasure TablespoonsUS(this double value) => new(value * TablespoonUS);

        /// <summary>Creates a volume value expressed in US teaspoons.</summary>
        public static VolumeMeasure TeaspoonsUS(this double value) => new(value * TeaspoonUS);

        /// <summary>Creates a volume value expressed in cubic feet.</summary>
        public static VolumeMeasure CubicFeet(this double value) => new(value * CubicFoot);

        /// <summary>Creates a volume value expressed in cubic inches.</summary>
        public static VolumeMeasure CubicInches(this double value) => new(value * CubicInch);

        /// <summary>Creates a volume value expressed in cubic yards.</summary>
        public static VolumeMeasure CubicYards(this double value) => new(value * CubicYard);

        /// <summary>Creates a volume value expressed in imperial gallons.</summary>
        public static VolumeMeasure GallonsImperial(this double value) => new(value * GallonImperial);

        /// <summary>Creates a volume value expressed in imperial quarts.</summary>
        public static VolumeMeasure QuartsImperial(this double value) => new(value * QuartImperial);

        /// <summary>Creates a volume value expressed in imperial pints.</summary>
        public static VolumeMeasure PintsImperial(this double value) => new(value * PintImperial);

        /// <summary>Creates a volume value expressed in imperial cups.</summary>
        public static VolumeMeasure CupsImperial(this double value) => new(value * CupImperial);

        /// <summary>Creates a volume value expressed in imperial fluid ounces.</summary>
        public static VolumeMeasure FluidOuncesImperial(this double value) => new(value * FluidOunceImperial);

        /// <summary>Creates a volume value expressed in imperial tablespoons.</summary>
        public static VolumeMeasure TablespoonsImperial(this double value) => new(value * TablespoonImperial);

        /// <summary>Creates a volume value expressed in imperial teaspoons.</summary>
        public static VolumeMeasure TeaspoonsImperial(this double value) => new(value * TeaspoonImperial);

        /// <summary>Creates a volume value expressed in barrels of oil.</summary>
        public static VolumeMeasure BarrelsOil(this double value) => new(value * BarrelOil);

        /// <summary>Creates a volume value expressed in US dry quarts.</summary>
        public static VolumeMeasure QuartsDryUS(this double value) => new(value * QuartDryUS);

        /// <summary>Creates a volume value expressed in US dry pints.</summary>
        public static VolumeMeasure PintsDryUS(this double value) => new(value * PintDryUS);

        /// <summary>Creates a volume value expressed in bushels.</summary>
        public static VolumeMeasure Bushels(this double value) => new(value * Bushel);

        /// <summary>Creates a volume value expressed in pecks.</summary>
        public static VolumeMeasure Pecks(this double value) => new(value * Peck);

        /// <summary>Creates a volume value expressed in gills.</summary>
        public static VolumeMeasure Gills(this double value) => new(value * Gill);

        /// <summary>Creates a volume value expressed in drams.</summary>
        public static VolumeMeasure Drams(this double value) => new(value * Dram);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the volume to cubic kilometers.</summary>
        public static double ToCubicKilometers(this VolumeMeasure m) => m.To(CubicKilometer);

        /// <summary>Converts the volume to cubic meters.</summary>
        public static double ToCubicMeters(this VolumeMeasure m) => m.To(CubicMeter);

        /// <summary>Converts the volume to cubic decimeters (liters).</summary>
        public static double ToCubicDecimeters(this VolumeMeasure m) => m.To(CubicDecimeter);

        /// <summary>Converts the volume to cubic centimeters.</summary>
        public static double ToCubicCentimeters(this VolumeMeasure m) => m.To(CubicCentimeter);

        /// <summary>Converts the volume to cubic millimeters.</summary>
        public static double ToCubicMillimeters(this VolumeMeasure m) => m.To(CubicMillimeter);

        /// <summary>Converts the volume to liters.</summary>
        public static double ToLiters(this VolumeMeasure m) => m.To(Liter);

        /// <summary>Converts the volume to deciliters.</summary>
        public static double ToDeciliters(this VolumeMeasure m) => m.To(Deciliter);

        /// <summary>Converts the volume to centiliters.</summary>
        public static double ToCentiliters(this VolumeMeasure m) => m.To(Centiliter);

        /// <summary>Converts the volume to milliliters.</summary>
        public static double ToMilliliters(this VolumeMeasure m) => m.To(Milliliter);

        /// <summary>Converts the volume to microliters.</summary>
        public static double ToMicroliters(this VolumeMeasure m) => m.To(Microliter);

        /// <summary>Converts the volume to US gallons.</summary>
        public static double ToGallonsUS(this VolumeMeasure m) => m.To(GallonUS);

        /// <summary>Converts the volume to US quarts.</summary>
        public static double ToQuartsUS(this VolumeMeasure m) => m.To(QuartUS);

        /// <summary>Converts the volume to US pints.</summary>
        public static double ToPintsUS(this VolumeMeasure m) => m.To(PintUS);

        /// <summary>Converts the volume to US cups.</summary>
        public static double ToCupsUS(this VolumeMeasure m) => m.To(CupUS);

        /// <summary>Converts the volume to US fluid ounces.</summary>
        public static double ToFluidOuncesUS(this VolumeMeasure m) => m.To(FluidOunceUS);

        /// <summary>Converts the volume to US tablespoons.</summary>
        public static double ToTablespoonsUS(this VolumeMeasure m) => m.To(TablespoonUS);

        /// <summary>Converts the volume to US teaspoons.</summary>
        public static double ToTeaspoonsUS(this VolumeMeasure m) => m.To(TeaspoonUS);

        /// <summary>Converts the volume to cubic feet.</summary>
        public static double ToCubicFeet(this VolumeMeasure m) => m.To(CubicFoot);

        /// <summary>Converts the volume to cubic inches.</summary>
        public static double ToCubicInches(this VolumeMeasure m) => m.To(CubicInch);

        /// <summary>Converts the volume to cubic yards.</summary>
        public static double ToCubicYards(this VolumeMeasure m) => m.To(CubicYard);

        /// <summary>Converts the volume to imperial gallons.</summary>
        public static double ToGallonsImperial(this VolumeMeasure m) => m.To(GallonImperial);

        /// <summary>Converts the volume to imperial quarts.</summary>
        public static double ToQuartsImperial(this VolumeMeasure m) => m.To(QuartImperial);

        /// <summary>Converts the volume to imperial pints.</summary>
        public static double ToPintsImperial(this VolumeMeasure m) => m.To(PintImperial);

        /// <summary>Converts the volume to imperial cups.</summary>
        public static double ToCupsImperial(this VolumeMeasure m) => m.To(CupImperial);

        /// <summary>Converts the volume to imperial fluid ounces.</summary>
        public static double ToFluidOuncesImperial(this VolumeMeasure m) => m.To(FluidOunceImperial);

        /// <summary>Converts the volume to imperial tablespoons.</summary>
        public static double ToTablespoonsImperial(this VolumeMeasure m) => m.To(TablespoonImperial);

        /// <summary>Converts the volume to imperial teaspoons.</summary>
        public static double ToTeaspoonsImperial(this VolumeMeasure m) => m.To(TeaspoonImperial);

        /// <summary>Converts the volume to barrels of oil.</summary>
        public static double ToBarrelsOil(this VolumeMeasure m) => m.To(BarrelOil);

        /// <summary>Converts the volume to US dry quarts.</summary>
        public static double ToQuartsDryUS(this VolumeMeasure m) => m.To(QuartDryUS);

        /// <summary>Converts the volume to US dry pints.</summary>
        public static double ToPintsDryUS(this VolumeMeasure m) => m.To(PintDryUS);

        /// <summary>Converts the volume to bushels.</summary>
        public static double ToBushels(this VolumeMeasure m) => m.To(Bushel);

        /// <summary>Converts the volume to pecks.</summary>
        public static double ToPecks(this VolumeMeasure m) => m.To(Peck);

        /// <summary>Converts the volume to gills.</summary>
        public static double ToGills(this VolumeMeasure m) => m.To(Gill);

        /// <summary>Converts the volume to drams.</summary>
        public static double ToDrams(this VolumeMeasure m) => m.To(Dram);
    }
}
