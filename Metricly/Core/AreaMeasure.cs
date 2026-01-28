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
    public class AreaMeasure(double baseValue)
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
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="AreaMeasure"/> values.
    /// </summary>
    public static class AreaExtensions
    {
        // -------------------------
        // Conversion factors 
        // -------------------------
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

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates an area value expressed in square meters (m²).</summary>
        public static AreaMeasure SquareMeters(this double value) => new(value * _SquareMeter);

        /// <summary>Creates an area value expressed in square kilometers (km²).</summary>
        public static AreaMeasure SquareKilometers(this double value) => new(value * _SquareKilometer);

        /// <summary>Creates an area value expressed in hectares (ha).</summary>
        public static AreaMeasure Hectares(this double value) => new(value * _Hectare);

        /// <summary>Creates an area value expressed in ares (a).</summary>
        public static AreaMeasure Ares(this double value) => new(value * _Are);

        /// <summary>Creates an area value expressed in square decimeters (dm²).</summary>
        public static AreaMeasure SquareDecimeters(this double value) => new(value * _SquareDecimeter);

        /// <summary>Creates an area value expressed in square centimeters (cm²).</summary>
        public static AreaMeasure SquareCentimeters(this double value) => new(value * _SquareCentimeter);

        /// <summary>Creates an area value expressed in square millimeters (mm²).</summary>
        public static AreaMeasure SquareMillimeters(this double value) => new(value * _SquareMillimeter);

        /// <summary>Creates an area value expressed in square inches (in²).</summary>
        public static AreaMeasure SquareInches(this double value) => new(value * _SquareInch);

        /// <summary>Creates an area value expressed in square feet (ft²).</summary>
        public static AreaMeasure SquareFeet(this double value) => new(value * _SquareFoot);

        /// <summary>Creates an area value expressed in square yards (yd²).</summary>
        public static AreaMeasure SquareYards(this double value) => new(value * _SquareYard);

        /// <summary>Creates an area value expressed in acres (ac).</summary>
        public static AreaMeasure Acres(this double value) => new(value * _Acre);

        /// <summary>Creates an area value expressed in square miles (mi²).</summary>
        public static AreaMeasure SquareMiles(this double value) => new(value * _SquareMile);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the area to square meters (m²).</summary>
        public static double ToSquareMeters(this AreaMeasure a) => a.To(_SquareMeter);

        /// <summary>Converts the area to square kilometers (km²).</summary>
        public static double ToSquareKilometers(this AreaMeasure a) => a.To(_SquareKilometer);

        /// <summary>Converts the area to hectares (ha).</summary>
        public static double ToHectares(this AreaMeasure a) => a.To(_Hectare);

        /// <summary>Converts the area to ares (a).</summary>
        public static double ToAres(this AreaMeasure a) => a.To(_Are);

        /// <summary>Converts the area to square decimeters (dm²).</summary>
        public static double ToSquareDecimeters(this AreaMeasure a) => a.To(_SquareDecimeter);

        /// <summary>Converts the area to square centimeters (cm²).</summary>
        public static double ToSquareCentimeters(this AreaMeasure a) => a.To(_SquareCentimeter);

        /// <summary>Converts the area to square millimeters (mm²).</summary>
        public static double ToSquareMillimeters(this AreaMeasure a) => a.To(_SquareMillimeter);

        /// <summary>Converts the area to square inches (in²).</summary>
        public static double ToSquareInches(this AreaMeasure a) => a.To(_SquareInch);

        /// <summary>Converts the area to square feet (ft²).</summary>
        public static double ToSquareFeet(this AreaMeasure a) => a.To(_SquareFoot);

        /// <summary>Converts the area to square yards (yd²).</summary>
        public static double ToSquareYards(this AreaMeasure a) => a.To(_SquareYard);

        /// <summary>Converts the area to acres (ac).</summary>
        public static double ToAcres(this AreaMeasure a) => a.To(_Acre);

        /// <summary>Converts the area to square miles (mi²).</summary>
        public static double ToSquareMiles(this AreaMeasure a) => a.To(_SquareMile);
    }
}
