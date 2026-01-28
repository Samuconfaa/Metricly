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
    public class EnergyMeasure(double baseValue)
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
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="EnergyMeasure"/> values.
    /// </summary>
    public static class EnergyExtensions
    {
        // -------------------------
        // Conversion factors 
        // -------------------------
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

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates an energy value expressed in joules (J).</summary>
        public static EnergyMeasure J(this double value) => new(value * Joule);

        /// <summary>Creates an energy value expressed in kilojoules (kJ).</summary>
        public static EnergyMeasure kJ(this double value) => new(value * KiloJoule);

        /// <summary>Creates an energy value expressed in megajoules (MJ).</summary>
        public static EnergyMeasure MJ(this double value) => new(value * MegaJoule);

        /// <summary>Creates an energy value expressed in gigajoules (GJ).</summary>
        public static EnergyMeasure GJ(this double value) => new(value * GigaJoule);

        /// <summary>Creates an energy value expressed in watt-hours (Wh).</summary>
        public static EnergyMeasure Wh(this double value) => new(value * WattHour);

        /// <summary>Creates an energy value expressed in kilowatt-hours (kWh).</summary>
        public static EnergyMeasure kWh(this double value) => new(value * KiloWattHour);

        /// <summary>Creates an energy value expressed in calories (cal).</summary>
        public static EnergyMeasure cal(this double value) => new(value * Calorie);

        /// <summary>Creates an energy value expressed in kilocalories (kcal).</summary>
        public static EnergyMeasure kcal(this double value) => new(value * KiloCalorie);

        /// <summary>Creates an energy value expressed in British Thermal Units (BTU).</summary>
        public static EnergyMeasure BTU(this double value) => new(value * _BTU);

        /// <summary>Creates an energy value expressed in electronvolts (eV).</summary>
        public static EnergyMeasure eV(this double value) => new(value * ElectronVolt);

        /// <summary>Creates an energy value expressed in foot-pounds (ft·lb).</summary>
        public static EnergyMeasure ftlb(this double value) => new(value * FootPound);

        /// <summary>Creates an energy value expressed in therms (therm, US).</summary>
        public static EnergyMeasure therm(this double value) => new(value * Therm);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the energy value to joules (J).</summary>
        public static double ToJ(this EnergyMeasure e) => e.To(Joule);

        /// <summary>Converts the energy value to kilojoules (kJ).</summary>
        public static double TokJ(this EnergyMeasure e) => e.To(KiloJoule);

        /// <summary>Converts the energy value to megajoules (MJ).</summary>
        public static double ToMJ(this EnergyMeasure e) => e.To(MegaJoule);

        /// <summary>Converts the energy value to gigajoules (GJ).</summary>
        public static double ToGJ(this EnergyMeasure e) => e.To(GigaJoule);

        /// <summary>Converts the energy value to watt-hours (Wh).</summary>
        public static double ToWh(this EnergyMeasure e) => e.To(WattHour);

        /// <summary>Converts the energy value to kilowatt-hours (kWh).</summary>
        public static double TokWh(this EnergyMeasure e) => e.To(KiloWattHour);

        /// <summary>Converts the energy value to calories (cal).</summary>
        public static double Tocal(this EnergyMeasure e) => e.To(Calorie);

        /// <summary>Converts the energy value to kilocalories (kcal).</summary>
        public static double Tokcal(this EnergyMeasure e) => e.To(KiloCalorie);

        /// <summary>Converts the energy value to British Thermal Units (BTU).</summary>
        public static double ToBTU(this EnergyMeasure e) => e.To(_BTU);

        /// <summary>Converts the energy value to electronvolts (eV).</summary>
        public static double ToeV(this EnergyMeasure e) => e.To(ElectronVolt);

        /// <summary>Converts the energy value to foot-pounds (ft·lb).</summary>
        public static double Toftlb(this EnergyMeasure e) => e.To(FootPound);

        /// <summary>Converts the energy value to therms (therm, US).</summary>
        public static double Totherm(this EnergyMeasure e) => e.To(Therm);
    }
}
