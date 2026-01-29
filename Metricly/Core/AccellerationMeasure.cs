using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents an acceleration value expressed in a base unit (meters per second squared).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AccelerationMeasure"/> class
    /// using a value expressed in meters per second squared.
    /// </remarks>
    /// <param name="baseValue">The acceleration value in m/s².</param>
    public class AccelerationMeasure(double baseValue) : IMeasure<AccelerationMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in meters per second squared.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of m/s² corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new acceleration measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in m/s².</param>
        /// <returns>A new <see cref="AccelerationMeasure"/> instance.</returns>
        public AccelerationMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two acceleration measurements.
        /// </summary>
        public AccelerationMeasure Add(AccelerationMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another acceleration measurement from this one.
        /// </summary>
        public AccelerationMeasure Subtract(AccelerationMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the acceleration by a scalar value.
        /// </summary>
        public AccelerationMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the acceleration by a scalar value.
        /// </summary>
        public AccelerationMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this acceleration by another acceleration to get a ratio.
        /// </summary>
        public double DivideBy(AccelerationMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Somma due misure di accelerazione.
        /// </summary>
        /// <param name="left">Il primo addendo.</param>
        /// <param name="right">Il secondo addendo.</param>
        /// <returns>Una nuova istanza di <see cref="AccelerationMeasure"/> che rappresenta la somma.</returns>
        public static AccelerationMeasure operator +(AccelerationMeasure left, AccelerationMeasure right) => left.Add(right);

        /// <summary>
        /// Sottrae una misura di accelerazione da un'altra.
        /// </summary>
        /// <param name="left">Il valore da cui sottrarre.</param>
        /// <param name="right">Il valore da sottrarre.</param>
        /// <returns>Una nuova istanza di <see cref="AccelerationMeasure"/> che rappresenta la differenza.</returns>
        public static AccelerationMeasure operator -(AccelerationMeasure left, AccelerationMeasure right) => left.Subtract(right);

        /// <summary>
        /// Moltiplica una misura di accelerazione per uno scalare.
        /// </summary>
        /// <param name="left">La misura di accelerazione.</param>
        /// <param name="scalar">Il fattore di moltiplicazione.</param>
        /// <returns>Una nuova istanza di <see cref="AccelerationMeasure"/> scalata.</returns>
        public static AccelerationMeasure operator *(AccelerationMeasure left, double scalar) => left.Multiply(scalar);

        /// <summary>
        /// Moltiplica uno scalare per una misura di accelerazione.
        /// </summary>
        /// <param name="scalar">Il fattore di moltiplicazione.</param>
        /// <param name="right">La misura di accelerazione.</param>
        /// <returns>Una nuova istanza di <see cref="AccelerationMeasure"/> scalata.</returns>
        public static AccelerationMeasure operator *(double scalar, AccelerationMeasure right) => right.Multiply(scalar);

        /// <summary>
        /// Divide una misura di accelerazione per uno scalare.
        /// </summary>
        /// <param name="left">La misura di accelerazione.</param>
        /// <param name="scalar">Il divisore.</param>
        /// <returns>Una nuova istanza di <see cref="AccelerationMeasure"/> divisa.</returns>
        public static AccelerationMeasure operator /(AccelerationMeasure left, double scalar) => left.Divide(scalar);

        /// <summary>
        /// Calcola il rapporto tra due misure di accelerazione.
        /// </summary>
        /// <param name="left">Il dividendo.</param>
        /// <param name="right">Il divisore.</param>
        /// <returns>Il rapporto numerico tra le due misure.</returns>
        public static double operator /(AccelerationMeasure left, AccelerationMeasure right) => left.DivideBy(right);

        /// <summary>
        /// Determina se due istanze di <see cref="AccelerationMeasure"/> sono uguali entro una tolleranza di 1e-10.
        /// </summary>
        public static bool operator ==(AccelerationMeasure left, AccelerationMeasure right) => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determina se due istanze di <see cref="AccelerationMeasure"/> sono diverse.
        /// </summary>
        public static bool operator !=(AccelerationMeasure left, AccelerationMeasure right) => !(left == right);

        /// <summary>
        /// Determina se la prima misura è maggiore della seconda.
        /// </summary>
        public static bool operator >(AccelerationMeasure left, AccelerationMeasure right) => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determina se la prima misura è minore della seconda.
        /// </summary>
        public static bool operator <(AccelerationMeasure left, AccelerationMeasure right) => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determina se la prima misura è maggiore o uguale alla seconda.
        /// </summary>
        public static bool operator >=(AccelerationMeasure left, AccelerationMeasure right) => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determina se la prima misura è minore o uguale alla seconda.
        /// </summary>
        public static bool operator <=(AccelerationMeasure left, AccelerationMeasure right) => left.BaseValue <= right.BaseValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is AccelerationMeasure other && BaseValue.Equals(other.BaseValue);

        /// <inheritdoc />
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Restituisce una stringa che rappresenta l'accelerazione corrente espressa in m/s².
        /// </summary>
        /// <returns>Una stringa nel formato "valore m/s²".</returns>
        public override string ToString() => $"{BaseValue} m/s²";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="AccelerationMeasure"/> values.
    /// </summary>
    public static class AccelerationExtensions
    {
        private const double MeterPerSecondSquared = 1.0;
        private const double _StandardGravity = 9.80665;
        private const double FootPerSecondSquared = 0.3048;
        private const double GalGalileo = 0.01;
        private const double KilometerPerHourPerSecond = 1000.0 / 3600.0;

        /// <summary>Creates an acceleration value expressed in meters per second squared (m/s²).</summary>
        public static AccelerationMeasure MetersPerSecondSquared(this double value) => new(value * MeterPerSecondSquared);

        /// <summary>Creates an acceleration value expressed in standard gravity (g).</summary>
        public static AccelerationMeasure StandardGravity(this double value) => new(value * _StandardGravity);

        /// <summary>Creates an acceleration value expressed in feet per second squared (ft/s²).</summary>
        public static AccelerationMeasure FeetPerSecondSquared(this double value) => new(value * FootPerSecondSquared);

        /// <summary>Creates an acceleration value expressed in gals (Gal).</summary>
        public static AccelerationMeasure Gals(this double value) => new(value * GalGalileo);

        /// <summary>Creates an acceleration value expressed in kilometers per hour per second (km/h/s).</summary>
        public static AccelerationMeasure KilometersPerHourPerSecond(this double value) => new(value * KilometerPerHourPerSecond);

        /// <summary>Converts the acceleration to meters per second squared (m/s²).</summary>
        public static double ToMetersPerSecondSquared(this AccelerationMeasure a) => a.To(MeterPerSecondSquared);

        /// <summary>Converts the acceleration to standard gravity (g).</summary>
        public static double ToStandardGravity(this AccelerationMeasure a) => a.To(_StandardGravity);

        /// <summary>Converts the acceleration to feet per second squared (ft/s²).</summary>
        public static double ToFeetPerSecondSquared(this AccelerationMeasure a) => a.To(FootPerSecondSquared);

        /// <summary>Converts the acceleration to gals (Gal).</summary>
        public static double ToGals(this AccelerationMeasure a) => a.To(GalGalileo);

        /// <summary>Converts the acceleration to kilometers per hour per second (km/h/s).</summary>
        public static double ToKilometersPerHourPerSecond(this AccelerationMeasure a) => a.To(KilometerPerHourPerSecond);
    }
}