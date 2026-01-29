using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents an electric current value expressed in a base unit (ampere).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CurrentMeasure"/> class
    /// using a value expressed in amperes.
    /// </remarks>
    /// <param name="baseValue">The current value in amperes.</param>
    public class CurrentMeasure(double baseValue) : IMeasure<CurrentMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in amperes.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of amperes corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new current measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in amperes.</param>
        /// <returns>A new <see cref="CurrentMeasure"/> instance.</returns>
        public CurrentMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two current measurements.
        /// </summary>
        public CurrentMeasure Add(CurrentMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another current measurement from this one.
        /// </summary>
        public CurrentMeasure Subtract(CurrentMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the current by a scalar value.
        /// </summary>
        public CurrentMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the current by a scalar value.
        /// </summary>
        public CurrentMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this current by another current to get a ratio.
        /// </summary>
        public double DivideBy(CurrentMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Somma due misure di corrente.
        /// </summary>
        /// <param name="left">Il primo addendo.</param>
        /// <param name="right">Il secondo addendo.</param>
        /// <returns>Una nuova istanza di <see cref="CurrentMeasure"/> che rappresenta la somma.</returns>
        public static CurrentMeasure operator +(CurrentMeasure left, CurrentMeasure right) => left.Add(right);

        /// <summary>
        /// Sottrae una misura di corrente da un'altra.
        /// </summary>
        /// <param name="left">Il valore da cui sottrarre.</param>
        /// <param name="right">Il valore da sottrarre.</param>
        /// <returns>Una nuova istanza di <see cref="CurrentMeasure"/> che rappresenta la differenza.</returns>
        public static CurrentMeasure operator -(CurrentMeasure left, CurrentMeasure right) => left.Subtract(right);

        /// <summary>
        /// Moltiplica una misura di corrente per uno scalare.
        /// </summary>
        /// <param name="left">La misura di corrente.</param>
        /// <param name="scalar">Il fattore di moltiplicazione.</param>
        /// <returns>Una nuova istanza di <see cref="CurrentMeasure"/> scalata.</returns>
        public static CurrentMeasure operator *(CurrentMeasure left, double scalar) => left.Multiply(scalar);

        /// <summary>
        /// Moltiplica uno scalare per una misura di corrente.
        /// </summary>
        /// <param name="scalar">Il fattore di moltiplicazione.</param>
        /// <param name="right">La misura di corrente.</param>
        /// <returns>Una nuova istanza di <see cref="CurrentMeasure"/> scalata.</returns>
        public static CurrentMeasure operator *(double scalar, CurrentMeasure right) => right.Multiply(scalar);

        /// <summary>
        /// Divide una misura di corrente per uno scalare.
        /// </summary>
        /// <param name="left">La misura di corrente.</param>
        /// <param name="scalar">Il divisore.</param>
        /// <returns>Una nuova istanza di <see cref="CurrentMeasure"/> divisa.</returns>
        public static CurrentMeasure operator /(CurrentMeasure left, double scalar) => left.Divide(scalar);

        /// <summary>
        /// Calcola il rapporto tra due misure di corrente.
        /// </summary>
        /// <param name="left">Il dividendo.</param>
        /// <param name="right">Il divisore.</param>
        /// <returns>Il rapporto numerico (adimensionale) tra le due correnti.</returns>
        public static double operator /(CurrentMeasure left, CurrentMeasure right) => left.DivideBy(right);

        /// <summary>
        /// Determina se due istanze di <see cref="CurrentMeasure"/> sono uguali entro una tolleranza di 1e-10.
        /// </summary>
        /// <param name="left">La prima misura da confrontare.</param>
        /// <param name="right">La seconda misura da confrontare.</param>
        /// <returns><c>true</c> se la differenza tra i valori è trascurabile; altrimenti <c>false</c>.</returns>
        public static bool operator ==(CurrentMeasure left, CurrentMeasure right) => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determina se due istanze di <see cref="CurrentMeasure"/> sono diverse.
        /// </summary>
        public static bool operator !=(CurrentMeasure left, CurrentMeasure right) => !(left == right);

        /// <summary>
        /// Determina se la prima corrente è maggiore della seconda.
        /// </summary>
        public static bool operator >(CurrentMeasure left, CurrentMeasure right) => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determina se la prima corrente è minore della seconda.
        /// </summary>
        public static bool operator <(CurrentMeasure left, CurrentMeasure right) => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determina se la prima corrente è maggiore o uguale alla seconda.
        /// </summary>
        public static bool operator >=(CurrentMeasure left, CurrentMeasure right) => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determina se la prima corrente è minore o uguale alla seconda.
        /// </summary>
        public static bool operator <=(CurrentMeasure left, CurrentMeasure right) => left.BaseValue <= right.BaseValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is CurrentMeasure other && BaseValue.Equals(other.BaseValue);

        /// <inheritdoc />
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Restituisce una stringa che rappresenta la corrente corrente espressa in Ampere (A).
        /// </summary>
        /// <returns>Una stringa nel formato "valore A".</returns>
        public override string ToString() => $"{BaseValue} A";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="CurrentMeasure"/> values.
    /// </summary>
    public static class CurrentExtensions
    {
        private const double Ampere = 1.0;
        private const double Milliampere = 0.001;
        private const double Microampere = 1e-6;
        private const double Kiloampere = 1_000.0;

        /// <summary>Creates a current value expressed in amperes (A).</summary>
        public static CurrentMeasure Amperes(this double value) => new(value * Ampere);

        /// <summary>Creates a current value expressed in milliamperes (mA).</summary>
        public static CurrentMeasure Milliamperes(this double value) => new(value * Milliampere);

        /// <summary>Creates a current value expressed in microamperes (μA).</summary>
        public static CurrentMeasure Microamperes(this double value) => new(value * Microampere);

        /// <summary>Creates a current value expressed in kiloamperes (kA).</summary>
        public static CurrentMeasure Kiloamperes(this double value) => new(value * Kiloampere);

        /// <summary>Converts the current to amperes (A).</summary>
        public static double ToAmperes(this CurrentMeasure c) => c.To(Ampere);

        /// <summary>Converts the current to milliamperes (mA).</summary>
        public static double ToMilliamperes(this CurrentMeasure c) => c.To(Milliampere);

        /// <summary>Converts the current to microamperes (μA).</summary>
        public static double ToMicroamperes(this CurrentMeasure c) => c.To(Microampere);

        /// <summary>Converts the current to kiloamperes (kA).</summary>
        public static double ToKiloamperes(this CurrentMeasure c) => c.To(Kiloampere);
    }
}