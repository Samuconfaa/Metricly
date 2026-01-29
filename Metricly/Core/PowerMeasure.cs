using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents an electric power value expressed in a base unit (watt).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="PowerMeasure"/> class
    /// using a value expressed in watts.
    /// </remarks>
    /// <param name="baseValue">The power value in watts.</param>
    public class PowerMeasure(double baseValue) : IMeasure<PowerMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in watts.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of watts corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new power measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in watts.</param>
        /// <returns>A new <see cref="PowerMeasure"/> instance.</returns>
        public PowerMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two power measurements.
        /// </summary>
        public PowerMeasure Add(PowerMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another power measurement from this one.
        /// </summary>
        public PowerMeasure Subtract(PowerMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the power by a scalar value.
        /// </summary>
        public PowerMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the power by a scalar value.
        /// </summary>
        public PowerMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this power by another power to get a ratio.
        /// </summary>
        public double DivideBy(PowerMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Somma due misure di potenza.
        /// </summary>
        /// <param name="left">Il primo addendo.</param>
        /// <param name="right">Il secondo addendo.</param>
        /// <returns>Una nuova istanza di <see cref="PowerMeasure"/> che rappresenta la somma.</returns>
        public static PowerMeasure operator +(PowerMeasure left, PowerMeasure right) => left.Add(right);

        /// <summary>
        /// Sottrae una misura di potenza da un'altra.
        /// </summary>
        /// <param name="left">Il valore da cui sottrarre.</param>
        /// <param name="right">Il valore da sottrarre.</param>
        /// <returns>Una nuova istanza di <see cref="PowerMeasure"/> che rappresenta la differenza.</returns>
        public static PowerMeasure operator -(PowerMeasure left, PowerMeasure right) => left.Subtract(right);

        /// <summary>
        /// Moltiplica una misura di potenza per uno scalare.
        /// </summary>
        /// <param name="left">La misura di potenza.</param>
        /// <param name="scalar">Il fattore di moltiplicazione.</param>
        /// <returns>Una nuova istanza di <see cref="PowerMeasure"/> scalata.</returns>
        public static PowerMeasure operator *(PowerMeasure left, double scalar) => left.Multiply(scalar);

        /// <summary>
        /// Moltiplica uno scalare per una misura di potenza.
        /// </summary>
        /// <param name="scalar">Il fattore di moltiplicazione.</param>
        /// <param name="right">La misura di potenza.</param>
        /// <returns>Una nuova istanza di <see cref="PowerMeasure"/> scalata.</returns>
        public static PowerMeasure operator *(double scalar, PowerMeasure right) => right.Multiply(scalar);

        /// <summary>
        /// Divide una misura di potenza per uno scalare.
        /// </summary>
        /// <param name="left">La misura di potenza.</param>
        /// <param name="scalar">Il divisore.</param>
        /// <returns>Una nuova istanza di <see cref="PowerMeasure"/> divisa.</returns>
        public static PowerMeasure operator /(PowerMeasure left, double scalar) => left.Divide(scalar);

        /// <summary>
        /// Calcola il rapporto tra due misure di potenza.
        /// </summary>
        /// <param name="left">Il dividendo.</param>
        /// <param name="right">Il divisore.</param>
        /// <returns>Il rapporto numerico (adimensionale) tra le due potenze.</returns>
        public static double operator /(PowerMeasure left, PowerMeasure right) => left.DivideBy(right);

        /// <summary>
        /// Determina se due istanze di <see cref="PowerMeasure"/> sono uguali entro una tolleranza di 1e-10.
        /// </summary>
        /// <param name="left">La prima misura da confrontare.</param>
        /// <param name="right">La seconda misura da confrontare.</param>
        /// <returns><c>true</c> se i valori sono considerati equivalenti; altrimenti <c>false</c>.</returns>
        public static bool operator ==(PowerMeasure left, PowerMeasure right) => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determina se due istanze di <see cref="PowerMeasure"/> sono diverse.
        /// </summary>
        public static bool operator !=(PowerMeasure left, PowerMeasure right) => !(left == right);

        /// <summary>
        /// Determina se la prima potenza è maggiore della seconda.
        /// </summary>
        public static bool operator >(PowerMeasure left, PowerMeasure right) => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determina se la prima potenza è minore della seconda.
        /// </summary>
        public static bool operator <(PowerMeasure left, PowerMeasure right) => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determina se la prima potenza è maggiore o uguale alla seconda.
        /// </summary>
        public static bool operator >=(PowerMeasure left, PowerMeasure right) => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determina se la prima potenza è minore o uguale alla seconda.
        /// </summary>
        public static bool operator <=(PowerMeasure left, PowerMeasure right) => left.BaseValue <= right.BaseValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is PowerMeasure other && BaseValue.Equals(other.BaseValue);

        /// <inheritdoc />
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Restituisce una stringa che rappresenta la potenza espressa in Watt (W).
        /// </summary>
        /// <returns>Una stringa nel formato "valore W".</returns>
        public override string ToString() => $"{BaseValue} W";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="PowerMeasure"/> values.
    /// </summary>
    public static class PowerExtensions
    {
        private const double Watt = 1.0;
        private const double Milliwatt = 0.001;
        private const double Kilowatt = 1_000.0;
        private const double Megawatt = 1_000_000.0;
        private const double Gigawatt = 1_000_000_000.0;
        private const double _Horsepower = 745.699872; // Mechanical horsepower

        /// <summary>Creates a power value expressed in watts (W).</summary>
        public static PowerMeasure Watts(this double value) => new(value * Watt);

        /// <summary>Creates a power value expressed in milliwatts (mW).</summary>
        public static PowerMeasure Milliwatts(this double value) => new(value * Milliwatt);

        /// <summary>Creates a power value expressed in kilowatts (kW).</summary>
        public static PowerMeasure Kilowatts(this double value) => new(value * Kilowatt);

        /// <summary>Creates a power value expressed in megawatts (MW).</summary>
        public static PowerMeasure Megawatts(this double value) => new(value * Megawatt);

        /// <summary>Creates a power value expressed in gigawatts (GW).</summary>
        public static PowerMeasure Gigawatts(this double value) => new(value * Gigawatt);

        /// <summary>Creates a power value expressed in horsepower (hp).</summary>
        public static PowerMeasure Horsepower(this double value) => new(value * _Horsepower);

        /// <summary>Converts the power to watts (W).</summary>
        public static double ToWatts(this PowerMeasure p) => p.To(Watt);

        /// <summary>Converts the power to milliwatts (mW).</summary>
        public static double ToMilliwatts(this PowerMeasure p) => p.To(Milliwatt);

        /// <summary>Converts the power to kilowatts (kW).</summary>
        public static double ToKilowatts(this PowerMeasure p) => p.To(Kilowatt);

        /// <summary>Converts the power to megawatts (MW).</summary>
        public static double ToMegawatts(this PowerMeasure p) => p.To(Megawatt);

        /// <summary>Converts the power to gigawatts (GW).</summary>
        public static double ToGigawatts(this PowerMeasure p) => p.To(Gigawatt);

        /// <summary>Converts the power to horsepower (hp).</summary>
        public static double ToHorsepower(this PowerMeasure p) => p.To(_Horsepower);
    }
}