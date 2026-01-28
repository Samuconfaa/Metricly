using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a plane angle value expressed in a base unit (degrees).
    /// </summary>
    public class AngleMeasure
    {
        /// <summary>
        /// Gets the internal value expressed in degrees.
        /// </summary>
        public double BaseValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AngleMeasure"/> class
        /// using a value expressed in degrees.
        /// </summary>
        /// <param name="baseValue">The angle value in degrees.</param>
        public AngleMeasure(double baseValue)
        {
            BaseValue = baseValue;
        }

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="AngleMeasure"/> values.
    /// </summary>
    public static class AngleExtensions
    {
        // -------------------------
        // Conversion factors
        // -------------------------
        private const double _Degree = 1.0;
        private const double _Radian = 180.0 / Math.PI; 
        private const double _Grad = 0.9;                
        private const double _Minute = 1.0 / 60.0;       
        private const double _Second = 1.0 / 3600.0;    

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates an angle value expressed in degrees (°).</summary>
        public static AngleMeasure Degrees(this double value) => new(value * _Degree);

        /// <summary>Creates an angle value expressed in radians (rad).</summary>
        public static AngleMeasure Radians(this double value) => new(value * _Radian);

        /// <summary>Creates an angle value expressed in gradians (gon).</summary>
        public static AngleMeasure Grads(this double value) => new(value * _Grad);

        /// <summary>Creates an angle value expressed in arcminutes (').</summary>
        public static AngleMeasure ArcMinutes(this double value) => new(value * _Minute);

        /// <summary>Creates an angle value expressed in arcseconds (").</summary>
        public static AngleMeasure ArcSeconds(this double value) => new(value * _Second);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the angle to degrees (°).</summary>
        public static double ToDegrees(this AngleMeasure a) => a.To(_Degree);

        /// <summary>Converts the angle to radians (rad).</summary>
        public static double ToRadians(this AngleMeasure a) => a.To(_Radian);

        /// <summary>Converts the angle to gradians (gon).</summary>
        public static double ToGrads(this AngleMeasure a) => a.To(_Grad);

        /// <summary>Converts the angle to arcminutes (').</summary>
        public static double ToArcMinutes(this AngleMeasure a) => a.To(_Minute);

        /// <summary>Converts the angle to arcseconds (").</summary>
        public static double ToArcSeconds(this AngleMeasure a) => a.To(_Second);
    }
}
