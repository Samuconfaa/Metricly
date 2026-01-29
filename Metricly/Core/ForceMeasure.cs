using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a force value expressed in a base unit (newton).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ForceMeasure"/> class
    /// using a value expressed in newtons.
    /// </remarks>
    /// <param name="baseValue">The force value in newtons.</param>
    public class ForceMeasure(double baseValue) : IMeasure<ForceMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in newtons.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of newtons corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new force measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in newtons.</param>
        /// <returns>A new <see cref="ForceMeasure"/> instance.</returns>
        public ForceMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two force measurements.
        /// </summary>
        public ForceMeasure Add(ForceMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another force measurement from this one.
        /// </summary>
        public ForceMeasure Subtract(ForceMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the force by a scalar value.
        /// </summary>
        public ForceMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the force by a scalar value.
        /// </summary>
        public ForceMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this force by another force to get a ratio.
        /// </summary>
        public double DivideBy(ForceMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Somma due misure di forza.
        /// </summary>
        /// <param name="left">Il primo addendo.</param>
        /// <param name="right">Il secondo addendo.</param>
        /// <returns>Una nuova istanza di <see cref="ForceMeasure"/> che rappresenta la somma risultante.</returns>
        public static ForceMeasure operator +(ForceMeasure left, ForceMeasure right) => left.Add(right);

        /// <summary>
        /// Sottrae una misura di forza da un'altra.
        /// </summary>
        /// <param name="left">La forza da cui sottrarre.</param>
        /// <param name="right">La forza da sottrarre.</param>
        /// <returns>Una nuova istanza di <see cref="ForceMeasure"/> che rappresenta la differenza.</returns>
        public static ForceMeasure operator -(ForceMeasure left, ForceMeasure right) => left.Subtract(right);

        /// <summary>
        /// Moltiplica una misura di forza per uno scalare.
        /// </summary>
        /// <param name="left">La misura di forza.</param>
        /// <param name="scalar">Il fattore di scala.</param>
        /// <returns>Una nuova istanza di <see cref="ForceMeasure"/> moltiplicata per lo scalare.</returns>
        public static ForceMeasure operator *(ForceMeasure left, double scalar) => left.Multiply(scalar);

        /// <summary>
        /// Moltiplica uno scalare per una misura di forza.
        /// </summary>
        /// <param name="scalar">Il fattore di scala.</param>
        /// <param name="right">La misura di forza.</param>
        /// <returns>Una nuova istanza di <see cref="ForceMeasure"/> moltiplicata per lo scalare.</returns>
        public static ForceMeasure operator *(double scalar, ForceMeasure right) => right.Multiply(scalar);

        /// <summary>
        /// Divide una misura di forza per uno scalare.
        /// </summary>
        /// <param name="left">La misura di forza.</param>
        /// <param name="scalar">Il divisore.</param>
        /// <returns>Una nuova istanza di <see cref="ForceMeasure"/> divisa per lo scalare.</returns>
        public static ForceMeasure operator /(ForceMeasure left, double scalar) => left.Divide(scalar);

        /// <summary>
        /// Calcola il rapporto tra due misure di forza.
        /// </summary>
        /// <param name="left">Il dividendo.</param>
        /// <param name="right">Il divisore.</param>
        /// <returns>Il rapporto numerico adimensionale tra le due forze.</returns>
        public static double operator /(ForceMeasure left, ForceMeasure right) => left.DivideBy(right);

        /// <summary>
        /// Determina se due istanze di <see cref="ForceMeasure"/> sono uguali entro una tolleranza di 1e-10.
        /// </summary>
        /// <param name="left">La prima forza da confrontare.</param>
        /// <param name="right">La seconda forza da confrontare.</param>
        /// <returns><c>true</c> se le forze sono considerate uguali; altrimenti <c>false</c>.</returns>
        public static bool operator ==(ForceMeasure left, ForceMeasure right) => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determina se due istanze di <see cref="ForceMeasure"/> sono diverse.
        /// </summary>
        public static bool operator !=(ForceMeasure left, ForceMeasure right) => !(left == right);

        /// <summary>
        /// Determina se la prima forza è maggiore della seconda.
        /// </summary>
        public static bool operator >(ForceMeasure left, ForceMeasure right) => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determina se la prima forza è minore della seconda.
        /// </summary>
        public static bool operator <(ForceMeasure left, ForceMeasure right) => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determina se la prima forza è maggiore o uguale alla seconda.
        /// </summary>
        public static bool operator >=(ForceMeasure left, ForceMeasure right) => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determina se la prima forza è minore o uguale alla seconda.
        /// </summary>
        public static bool operator <=(ForceMeasure left, ForceMeasure right) => left.BaseValue <= right.BaseValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is ForceMeasure other && BaseValue.Equals(other.BaseValue);

        /// <inheritdoc />
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Restituisce una rappresentazione testuale della forza in Newton (N).
        /// </summary>
        /// <returns>Una stringa che rappresenta il valore seguito dall'unità di misura "N".</returns>
        public override string ToString() => $"{BaseValue} N";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="ForceMeasure"/> values.
    /// </summary>
    public static class ForceExtensions
    {
        private const double Newton = 1.0;
        private const double Kilonewton = 1_000.0;
        private const double Meganewton = 1_000_000.0;
        private const double Dyne = 1e-5;
        private const double _KilogramForce = 9.80665;
        private const double _PoundForce = 4.4482216152605;
        private const double Poundal = 0.138254954376;

        /// <summary>Creates a force value expressed in newtons (N).</summary>
        public static ForceMeasure Newtons(this double value) => new(value * Newton);

        /// <summary>Creates a force value expressed in kilonewtons (kN).</summary>
        public static ForceMeasure Kilonewtons(this double value) => new(value * Kilonewton);

        /// <summary>Creates a force value expressed in meganewtons (MN).</summary>
        public static ForceMeasure Meganewtons(this double value) => new(value * Meganewton);

        /// <summary>Creates a force value expressed in dynes (dyn).</summary>
        public static ForceMeasure Dynes(this double value) => new(value * Dyne);

        /// <summary>Creates a force value expressed in kilogram-force (kgf).</summary>
        public static ForceMeasure KilogramForce(this double value) => new(value * _KilogramForce);

        /// <summary>Creates a force value expressed in pound-force (lbf).</summary>
        public static ForceMeasure PoundForce(this double value) => new(value * _PoundForce);

        /// <summary>Creates a force value expressed in poundals (pdl).</summary>
        public static ForceMeasure Poundals(this double value) => new(value * Poundal);

        /// <summary>Converts the force to newtons (N).</summary>
        public static double ToNewtons(this ForceMeasure f) => f.To(Newton);

        /// <summary>Converts the force to kilonewtons (kN).</summary>
        public static double ToKilonewtons(this ForceMeasure f) => f.To(Kilonewton);

        /// <summary>Converts the force to meganewtons (MN).</summary>
        public static double ToMeganewtons(this ForceMeasure f) => f.To(Meganewton);

        /// <summary>Converts the force to dynes (dyn).</summary>
        public static double ToDynes(this ForceMeasure f) => f.To(Dyne);

        /// <summary>Converts the force to kilogram-force (kgf).</summary>
        public static double ToKilogramForce(this ForceMeasure f) => f.To(_KilogramForce);

        /// <summary>Converts the force to pound-force (lbf).</summary>
        public static double ToPoundForce(this ForceMeasure f) => f.To(_PoundForce);

        /// <summary>Converts the force to poundals (pdl).</summary>
        public static double ToPoundals(this ForceMeasure f) => f.To(Poundal);
    }
}