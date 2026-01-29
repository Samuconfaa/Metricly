using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a density value expressed in a base unit (kilograms per cubic meter).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="DensityMeasure"/> class
    /// using a value expressed in kg/m³.
    /// </remarks>
    /// <param name="baseValue">The density value in kg/m³.</param>
    public class DensityMeasure(double baseValue) : IMeasure<DensityMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in kilograms per cubic meter.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of kg/m³ corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new density measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in kg/m³.</param>
        /// <returns>A new <see cref="DensityMeasure"/> instance.</returns>
        public DensityMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two density measurements.
        /// </summary>
        public DensityMeasure Add(DensityMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another density measurement from this one.
        /// </summary>
        public DensityMeasure Subtract(DensityMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the density by a scalar value.
        /// </summary>
        public DensityMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the density by a scalar value.
        /// </summary>
        public DensityMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this density by another density to get a ratio.
        /// </summary>
        public double DivideBy(DensityMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Somma due misure di densità.
        /// </summary>
        /// <param name="left">Il primo addendo.</param>
        /// <param name="right">Il secondo addendo.</param>
        /// <returns>Una nuova istanza di <see cref="DensityMeasure"/> che rappresenta la somma.</returns>
        public static DensityMeasure operator +(DensityMeasure left, DensityMeasure right) => left.Add(right);

        /// <summary>
        /// Sottrae una misura di densità da un'altra.
        /// </summary>
        /// <param name="left">Il valore da cui sottrarre.</param>
        /// <param name="right">Il valore da sottrarre.</param>
        /// <returns>Una nuova istanza di <see cref="DensityMeasure"/> che rappresenta la differenza.</returns>
        public static DensityMeasure operator -(DensityMeasure left, DensityMeasure right) => left.Subtract(right);

        /// <summary>
        /// Moltiplica una misura di densità per uno scalare.
        /// </summary>
        /// <param name="left">La misura di densità.</param>
        /// <param name="scalar">Il fattore di moltiplicazione.</param>
        /// <returns>Una nuova istanza di <see cref="DensityMeasure"/> scalata.</returns>
        public static DensityMeasure operator *(DensityMeasure left, double scalar) => left.Multiply(scalar);

        /// <summary>
        /// Moltiplica uno scalare per una misura di densità.
        /// </summary>
        /// <param name="scalar">Il fattore di moltiplicazione.</param>
        /// <param name="right">La misura di densità.</param>
        /// <returns>Una nuova istanza di <see cref="DensityMeasure"/> scalata.</returns>
        public static DensityMeasure operator *(double scalar, DensityMeasure right) => right.Multiply(scalar);

        /// <summary>
        /// Divide una misura di densità per uno scalare.
        /// </summary>
        /// <param name="left">La misura di densità.</param>
        /// <param name="scalar">Il divisore.</param>
        /// <returns>Una nuova istanza di <see cref="DensityMeasure"/> divisa.</returns>
        public static DensityMeasure operator /(DensityMeasure left, double scalar) => left.Divide(scalar);

        /// <summary>
        /// Calcola il rapporto tra due misure di densità.
        /// </summary>
        /// <param name="left">Il dividendo.</param>
        /// <param name="right">Il divisore.</param>
        /// <returns>Il rapporto numerico (adimensionale) tra le due densità.</returns>
        public static double operator /(DensityMeasure left, DensityMeasure right) => left.DivideBy(right);

        /// <summary>
        /// Determina se due istanze di <see cref="DensityMeasure"/> sono uguali entro una tolleranza di 1e-10.
        /// </summary>
        /// <param name="left">La prima misura da confrontare.</param>
        /// <param name="right">La seconda misura da confrontare.</param>
        /// <returns><c>true</c> se i valori sono considerati equivalenti; altrimenti <c>false</c>.</returns>
        public static bool operator ==(DensityMeasure left, DensityMeasure right) => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determina se due istanze di <see cref="DensityMeasure"/> sono diverse.
        /// </summary>
        public static bool operator !=(DensityMeasure left, DensityMeasure right) => !(left == right);

        /// <summary>
        /// Determina se la prima densità è maggiore della seconda.
        /// </summary>
        public static bool operator >(DensityMeasure left, DensityMeasure right) => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determina se la prima densità è minore della seconda.
        /// </summary>
        public static bool operator <(DensityMeasure left, DensityMeasure right) => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determina se la prima densità è maggiore o uguale alla seconda.
        /// </summary>
        public static bool operator >=(DensityMeasure left, DensityMeasure right) => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determina se la prima densità è minore o uguale alla seconda.
        /// </summary>
        public static bool operator <=(DensityMeasure left, DensityMeasure right) => left.BaseValue <= right.BaseValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is DensityMeasure other && BaseValue.Equals(other.BaseValue);

        /// <inheritdoc />
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Restituisce una stringa che rappresenta la densità espressa in chilogrammi al metro cubo (kg/m³).
        /// </summary>
        /// <returns>Una stringa nel formato "valore kg/m³".</returns>
        public override string ToString() => $"{BaseValue} kg/m³";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="DensityMeasure"/> values.
    /// </summary>
    public static class DensityExtensions
    {
        private const double KilogramPerCubicMeter = 1.0;
        private const double GramPerCubicCentimeter = 1_000.0;
        private const double GramPerLiter = 1.0;
        private const double PoundPerCubicFoot = 16.018463373960142;
        private const double PoundPerCubicInch = 27_679.904710191342;
        private const double PoundPerGallon = 119.82642731689663; // US gallon

        /// <summary>Creates a density value expressed in kilograms per cubic meter (kg/m³).</summary>
        public static DensityMeasure KilogramsPerCubicMeter(this double value) => new(value * KilogramPerCubicMeter);

        /// <summary>Creates a density value expressed in grams per cubic centimeter (g/cm³).</summary>
        public static DensityMeasure GramsPerCubicCentimeter(this double value) => new(value * GramPerCubicCentimeter);

        /// <summary>Creates a density value expressed in grams per liter (g/L).</summary>
        public static DensityMeasure GramsPerLiter(this double value) => new(value * GramPerLiter);

        /// <summary>Creates a density value expressed in pounds per cubic foot (lb/ft³).</summary>
        public static DensityMeasure PoundsPerCubicFoot(this double value) => new(value * PoundPerCubicFoot);

        /// <summary>Creates a density value expressed in pounds per cubic inch (lb/in³).</summary>
        public static DensityMeasure PoundsPerCubicInch(this double value) => new(value * PoundPerCubicInch);

        /// <summary>Creates a density value expressed in pounds per US gallon (lb/gal).</summary>
        public static DensityMeasure PoundsPerGallon(this double value) => new(value * PoundPerGallon);

        /// <summary>Converts the density to kilograms per cubic meter (kg/m³).</summary>
        public static double ToKilogramsPerCubicMeter(this DensityMeasure d) => d.To(KilogramPerCubicMeter);

        /// <summary>Converts the density to grams per cubic centimeter (g/cm³).</summary>
        public static double ToGramsPerCubicCentimeter(this DensityMeasure d) => d.To(GramPerCubicCentimeter);

        /// <summary>Converts the density to grams per liter (g/L).</summary>
        public static double ToGramsPerLiter(this DensityMeasure d) => d.To(GramPerLiter);

        /// <summary>Converts the density to pounds per cubic foot (lb/ft³).</summary>
        public static double ToPoundsPerCubicFoot(this DensityMeasure d) => d.To(PoundPerCubicFoot);

        /// <summary>Converts the density to pounds per cubic inch (lb/in³).</summary>
        public static double ToPoundsPerCubicInch(this DensityMeasure d) => d.To(PoundPerCubicInch);

        /// <summary>Converts the density to pounds per US gallon (lb/gal).</summary>
        public static double ToPoundsPerGallon(this DensityMeasure d) => d.To(PoundPerGallon);
    }
}