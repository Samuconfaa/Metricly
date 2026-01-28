using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents an energy value expressed in a base unit (joule).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="EnergyMeasure"/> class
    /// using a value expressed in joules.
    /// </remarks>
    /// <param name="baseValue">The energy value in joules.</param>
    public class EnergyMeasure(double baseValue) : IMeasure<EnergyMeasure>
    {
        /// <summary>
        /// Gets the internal value expressed in joules.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">The number of joules corresponding to one unit of the target measurement.</param>
        /// <returns>The converted value.</returns>
        public double To(double factor) => BaseValue / factor;

        /// <summary>
        /// Creates a new energy measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in joules.</param>
        /// <returns>A new <see cref="EnergyMeasure"/> instance.</returns>
        public EnergyMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two energy measurements.
        /// </summary>
        /// <param name="other">The energy to add.</param>
        /// <returns>A new <see cref="EnergyMeasure"/> representing the sum.</returns>
        public EnergyMeasure Add(EnergyMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another energy measurement from this one.
        /// </summary>
        /// <param name="other">The energy to subtract.</param>
        /// <returns>A new <see cref="EnergyMeasure"/> representing the difference.</returns>
        public EnergyMeasure Subtract(EnergyMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the energy by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="EnergyMeasure"/> representing the product.</returns>
        public EnergyMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the energy by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="EnergyMeasure"/> representing the quotient.</returns>
        public EnergyMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this energy by another energy to get a ratio.
        /// </summary>
        /// <param name="other">The energy to divide by.</param>
        /// <returns>The ratio between the two energies.</returns>
        public double DivideBy(EnergyMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two energy measurements.
        /// </summary>
        /// <param name="left">The first energy.</param>
        /// <param name="right">The second energy.</param>
        /// <returns>The sum of the two energies.</returns>
        public static EnergyMeasure operator +(EnergyMeasure left, EnergyMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one energy measurement from another.
        /// </summary>
        /// <param name="left">The energy to subtract from.</param>
        /// <param name="right">The energy to subtract.</param>
        /// <returns>The difference between the two energies.</returns>
        public static EnergyMeasure operator -(EnergyMeasure left, EnergyMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies an energy measurement by a scalar.
        /// </summary>
        /// <param name="left">The energy.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the energy and scalar.</returns>
        public static EnergyMeasure operator *(EnergyMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies an energy measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The energy.</param>
        /// <returns>The product of the scalar and energy.</returns>
        public static EnergyMeasure operator *(double scalar, EnergyMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides an energy measurement by a scalar.
        /// </summary>
        /// <param name="left">The energy.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the energy and scalar.</returns>
        public static EnergyMeasure operator /(EnergyMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one energy measurement by another.
        /// </summary>
        /// <param name="left">The dividend energy.</param>
        /// <param name="right">The divisor energy.</param>
        /// <returns>The ratio between the two energies.</returns>
        public static double operator /(EnergyMeasure left, EnergyMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two energy measurements are equal.
        /// </summary>
        /// <param name="left">The first energy.</param>
        /// <param name="right">The second energy.</param>
        /// <returns><c>true</c> if the energies are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(EnergyMeasure left, EnergyMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two energy measurements are not equal.
        /// </summary>
        /// <param name="left">The first energy.</param>
        /// <param name="right">The second energy.</param>
        /// <returns><c>true</c> if the energies are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(EnergyMeasure left, EnergyMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one energy measurement is greater than another.
        /// </summary>
        /// <param name="left">The first energy.</param>
        /// <param name="right">The second energy.</param>
        /// <returns><c>true</c> if the first energy is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(EnergyMeasure left, EnergyMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one energy measurement is less than another.
        /// </summary>
        /// <param name="left">The first energy.</param>
        /// <param name="right">The second energy.</param>
        /// <returns><c>true</c> if the first energy is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(EnergyMeasure left, EnergyMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one energy measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first energy.</param>
        /// <param name="right">The second energy.</param>
        /// <returns><c>true</c> if the first energy is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(EnergyMeasure left, EnergyMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one energy measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first energy.</param>
        /// <param name="right">The second energy.</param>
        /// <returns><c>true</c> if the first energy is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(EnergyMeasure left, EnergyMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current energy measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current energy measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current energy measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this energy measurement.
        /// </summary>
        /// <returns>A hash code for the current energy measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the energy measurement.
        /// </summary>
        /// <returns>A string representing the energy in joules.</returns>
        public override string ToString() => $"{BaseValue} J";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="EnergyMeasure"/> values.
    /// </summary>
    public static class EnergyExtensions
    {
        private const double Joule = 1.0;
        private const double KiloJoule = 1_000.0;
        private const double MegaJoule = 1_000_000.0;
        private const double GigaJoule = 1_000_000_000.0;
        private const double WattHour = 3_600.0;
        private const double KiloWattHour = 3_600_000.0;
        private const double Calorie = 4.184;
        private const double KiloCalorie = 4_184.0;
        private const double _BTU = 1_055.05585262;
        private const double ElectronVolt = 1.602176634e-19;
        private const double FootPound = 1.3558179483314;
        private const double Therm = 105_480_400.0;

        /// <summary>Creates an energy value expressed in joules (J).</summary>
        /// <param name="value">The value in joules.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure J(this double value) => new(value * Joule);

        /// <summary>Creates an energy value expressed in kilojoules (kJ).</summary>
        /// <param name="value">The value in kilojoules.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure kJ(this double value) => new(value * KiloJoule);

        /// <summary>Creates an energy value expressed in megajoules (MJ).</summary>
        /// <param name="value">The value in megajoules.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure MJ(this double value) => new(value * MegaJoule);

        /// <summary>Creates an energy value expressed in gigajoules (GJ).</summary>
        /// <param name="value">The value in gigajoules.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure GJ(this double value) => new(value * GigaJoule);

        /// <summary>Creates an energy value expressed in watt-hours (Wh).</summary>
        /// <param name="value">The value in watt-hours.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure Wh(this double value) => new(value * WattHour);

        /// <summary>Creates an energy value expressed in kilowatt-hours (kWh).</summary>
        /// <param name="value">The value in kilowatt-hours.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure kWh(this double value) => new(value * KiloWattHour);

        /// <summary>Creates an energy value expressed in calories (cal).</summary>
        /// <param name="value">The value in calories.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure cal(this double value) => new(value * Calorie);

        /// <summary>Creates an energy value expressed in kilocalories (kcal).</summary>
        /// <param name="value">The value in kilocalories.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure kcal(this double value) => new(value * KiloCalorie);

        /// <summary>Creates an energy value expressed in British Thermal Units (BTU).</summary>
        /// <param name="value">The value in BTU.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure BTU(this double value) => new(value * _BTU);

        /// <summary>Creates an energy value expressed in electronvolts (eV).</summary>
        /// <param name="value">The value in electronvolts.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure eV(this double value) => new(value * ElectronVolt);

        /// <summary>Creates an energy value expressed in foot-pounds (ft·lb).</summary>
        /// <param name="value">The value in foot-pounds.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure ftlb(this double value) => new(value * FootPound);

        /// <summary>Creates an energy value expressed in therms (therm, US).</summary>
        /// <param name="value">The value in therms.</param>
        /// <returns>An <see cref="EnergyMeasure"/> representing the energy.</returns>
        public static EnergyMeasure therm(this double value) => new(value * Therm);

        /// <summary>Converts the energy value to joules (J).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in joules.</returns>
        public static double ToJ(this EnergyMeasure e) => e.To(Joule);

        /// <summary>Converts the energy value to kilojoules (kJ).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in kilojoules.</returns>
        public static double TokJ(this EnergyMeasure e) => e.To(KiloJoule);

        /// <summary>Converts the energy value to megajoules (MJ).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in megajoules.</returns>
        public static double ToMJ(this EnergyMeasure e) => e.To(MegaJoule);

        /// <summary>Converts the energy value to gigajoules (GJ).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in gigajoules.</returns>
        public static double ToGJ(this EnergyMeasure e) => e.To(GigaJoule);

        /// <summary>Converts the energy value to watt-hours (Wh).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in watt-hours.</returns>
        public static double ToWh(this EnergyMeasure e) => e.To(WattHour);

        /// <summary>Converts the energy value to kilowatt-hours (kWh).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in kilowatt-hours.</returns>
        public static double TokWh(this EnergyMeasure e) => e.To(KiloWattHour);

        /// <summary>Converts the energy value to calories (cal).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in calories.</returns>
        public static double Tocal(this EnergyMeasure e) => e.To(Calorie);

        /// <summary>Converts the energy value to kilocalories (kcal).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in kilocalories.</returns>
        public static double Tokcal(this EnergyMeasure e) => e.To(KiloCalorie);

        /// <summary>Converts the energy value to British Thermal Units (BTU).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in BTU.</returns>
        public static double ToBTU(this EnergyMeasure e) => e.To(_BTU);

        /// <summary>Converts the energy value to electronvolts (eV).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in electronvolts.</returns>
        public static double ToeV(this EnergyMeasure e) => e.To(ElectronVolt);

        /// <summary>Converts the energy value to foot-pounds (ft·lb).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in foot-pounds.</returns>
        public static double Toftlb(this EnergyMeasure e) => e.To(FootPound);

        /// <summary>Converts the energy value to therms (therm, US).</summary>
        /// <param name="e">The energy measurement.</param>
        /// <returns>The energy in therms.</returns>
        public static double Totherm(this EnergyMeasure e) => e.To(Therm);
    }
}
