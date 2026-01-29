using System;

namespace Metricly.Core.Constants
{
    /// <summary>
    /// Provides fundamental physical constants as strongly-typed measurements.
    /// Values are based on the 2019 redefinition of SI base units.
    /// </summary>
    public static class PhysicalConstants
    {
        // ========================================
        // UNIVERSAL CONSTANTS
        // ========================================

        /// <summary>
        /// Speed of light in vacuum (c).
        /// Exact value: 299,792,458 m/s
        /// </summary>
        public static SpeedMeasure SpeedOfLight => 299_792_458.0.MetersPerSecond();

        /// <summary>
        /// Gravitational constant (G).
        /// Value: 6.67430 × 10⁻¹¹ N⋅m²/kg²
        /// </summary>
        public const double GravitationalConstant = 6.67430e-11;

        /// <summary>
        /// Planck constant (h).
        /// Exact value: 6.62607015 × 10⁻³⁴ J⋅s
        /// </summary>
        public static EnergyMeasure PlanckConstantTimesFrequency(FrequencyMeasure frequency)
            => (6.62607015e-34 * frequency.BaseValue).J();

        /// <summary>
        /// Reduced Planck constant (ℏ = h/2π).
        /// Value: 1.054571817 × 10⁻³⁴ J⋅s
        /// </summary>
        public const double ReducedPlanckConstant = 1.054571817e-34;

        // ========================================
        // ELECTROMAGNETIC CONSTANTS
        // ========================================

        /// <summary>
        /// Elementary charge (e).
        /// Exact value: 1.602176634 × 10⁻¹⁹ C
        /// </summary>
        public const double ElementaryCharge = 1.602176634e-19;

        /// <summary>
        /// Magnetic constant (permeability of free space, μ₀).
        /// Value: 4π × 10⁻⁷ H/m ≈ 1.25663706212 × 10⁻⁶ H/m
        /// </summary>
        public const double MagneticConstant = 1.25663706212e-6;

        /// <summary>
        /// Electric constant (permittivity of free space, ε₀).
        /// Value: 8.8541878128 × 10⁻¹² F/m
        /// </summary>
        public const double ElectricConstant = 8.8541878128e-12;

        // ========================================
        // ATOMIC & QUANTUM CONSTANTS
        // ========================================

        /// <summary>
        /// Avogadro constant (Nₐ).
        /// Exact value: 6.02214076 × 10²³ mol⁻¹
        /// </summary>
        public const double AvogadroConstant = 6.02214076e23;

        /// <summary>
        /// Boltzmann constant (k).
        /// Exact value: 1.380649 × 10⁻²³ J/K
        /// </summary>
        public const double BoltzmannConstant = 1.380649e-23;

        /// <summary>
        /// Electron mass (mₑ).
        /// Value: 9.1093837015 × 10⁻³¹ kg
        /// </summary>
        public static MassMeasure ElectronMass => (9.1093837015e-28).Grams(); 

        /// <summary>
        /// Proton mass (mₚ).
        /// Value: 1.67262192369 × 10⁻²⁷ kg
        /// </summary>
        public static MassMeasure ProtonMass => (1.67262192369e-24).Grams(); 

        /// <summary>
        /// Neutron mass (mₙ).
        /// Value: 1.67492749804 × 10⁻²⁷ kg
        /// </summary>
        public static MassMeasure NeutronMass => (1.67492749804e-24).Grams(); 

        /// <summary>
        /// Fine-structure constant (α).
        /// Value: 7.2973525693 × 10⁻³ (dimensionless)
        /// </summary>
        public const double FineStructureConstant = 7.2973525693e-3;

        /// <summary>
        /// Rydberg constant (R∞).
        /// Value: 10,973,731.568160 m⁻¹
        /// </summary>
        public const double RydbergConstant = 10_973_731.568160;

        /// <summary>
        /// Bohr radius (a₀).
        /// Value: 5.29177210903 × 10⁻¹¹ m
        /// </summary>
        public static LengthMeasure BohrRadius => (5.29177210903e-11).Meters();

        // ========================================
        // THERMODYNAMIC CONSTANTS
        // ========================================

        /// <summary>
        /// Gas constant (R).
        /// Value: 8.314462618 J/(mol⋅K)
        /// </summary>
        public const double GasConstant = 8.314462618;

        /// <summary>
        /// Stefan-Boltzmann constant (σ).
        /// Value: 5.670374419 × 10⁻⁸ W/(m²⋅K⁴)
        /// </summary>
        public const double StefanBoltzmannConstant = 5.670374419e-8;

        /// <summary>
        /// Absolute zero in Celsius.
        /// Value: -273.15 °C
        /// </summary>
        public static TempMeasure AbsoluteZero => 0.0.Kelvin();

        /// <summary>
        /// Standard temperature (0°C).
        /// Value: 273.15 K
        /// </summary>
        public static TempMeasure StandardTemperature => 273.15.Kelvin();

        /// <summary>
        /// Standard pressure (1 atm).
        /// Value: 101,325 Pa
        /// </summary>
        public static PressureMeasure StandardPressure => 101_325.0.Pascal();

        // ========================================
        // GRAVITY & ASTRONOMY
        // ========================================

        /// <summary>
        /// Standard gravity on Earth's surface (g).
        /// Exact value: 9.80665 m/s²
        /// </summary>
        public static AccelerationMeasure StandardGravity => 9.80665.MetersPerSecondSquared();

        /// <summary>
        /// Earth's mass.
        /// Value: 5.9722 × 10²⁴ kg
        /// </summary>
        public static MassMeasure EarthMass => (5.9722e27).Grams();

        /// <summary>
        /// Earth's equatorial radius.
        /// Value: 6,378,137 m
        /// </summary>
        public static LengthMeasure EarthRadius => 6_378_137.0.Meters();

        /// <summary>
        /// Solar mass.
        /// Value: 1.98847 × 10³⁰ kg
        /// </summary>
        public static MassMeasure SolarMass => (1.98847e33).Grams(); 

        /// <summary>
        /// Astronomical unit (AU) - average Earth-Sun distance.
        /// Exact value: 149,597,870,700 m
        /// </summary>
        public static LengthMeasure AstronomicalUnit => 149_597_870_700.0.Meters();

        /// <summary>
        /// Light year - distance light travels in one year.
        /// Value: 9.4607 × 10¹⁵ m
        /// </summary>
        public static LengthMeasure LightYear => 9.4607e15.Meters();

        /// <summary>
        /// Parsec - parallax of one arcsecond.
        /// Value: 3.0857 × 10¹⁶ m
        /// </summary>
        public static LengthMeasure Parsec => 3.0857e16.Meters();

        // ========================================
        // MATHEMATICAL & PHYSICAL LIMITS
        // ========================================

        /// <summary>
        /// Planck length - smallest meaningful length in physics.
        /// Value: 1.616255 × 10⁻³⁵ m
        /// </summary>
        public static LengthMeasure PlanckLength => 1.616255e-35.Meters();

        /// <summary>
        /// Planck time - smallest meaningful time interval.
        /// Value: 5.391247 × 10⁻⁴⁴ s
        /// </summary>
        public static TimeMeasure PlanckTime => 5.391247e-44.Seconds();

        /// <summary>
        /// Planck mass.
        /// Value: 2.176434 × 10⁻⁸ kg
        /// </summary>
        public static MassMeasure PlanckMass => (2.176434e-5).Grams(); 

        /// <summary>
        /// Planck temperature.
        /// Value: 1.416784 × 10³² K
        /// </summary>
        public static TempMeasure PlanckTemperature => 1.416784e32.Kelvin();

        // ========================================
        // COMMON DERIVED VALUES
        // ========================================

        /// <summary>
        /// Speed of sound in air at 20°C.
        /// Approximate value: 343 m/s
        /// </summary>
        public static SpeedMeasure SpeedOfSoundInAir => 343.0.MetersPerSecond();

        /// <summary>
        /// Density of water at 4°C.
        /// Value: 1000 kg/m³
        /// </summary>
        public static DensityMeasure WaterDensity => 1000.0.KilogramsPerCubicMeter();

        /// <summary>
        /// Density of air at sea level and 15°C.
        /// Value: 1.225 kg/m³
        /// </summary>
        public static DensityMeasure AirDensity => 1.225.KilogramsPerCubicMeter();

        /// <summary>
        /// Specific heat capacity of water.
        /// Value: 4,186 J/(kg⋅K)
        /// </summary>
        public const double WaterSpecificHeat = 4_186.0;

        /// <summary>
        /// Freezing point of water at standard pressure.
        /// Value: 0°C = 273.15 K
        /// </summary>
        public static TempMeasure WaterFreezingPoint => 273.15.Kelvin();

        /// <summary>
        /// Boiling point of water at standard pressure.
        /// Value: 100°C = 373.15 K
        /// </summary>
        public static TempMeasure WaterBoilingPoint => 373.15.Kelvin();

        // ========================================
        // ELECTRICAL REFERENCE VALUES
        // ========================================

        /// <summary>
        /// Resistance of copper wire at 20°C (per meter, 1mm² cross-section).
        /// Value: 0.0175 Ω⋅m/mm²
        /// </summary>
        public const double CopperResistivity = 1.68e-8; 

        /// <summary>
        /// Conductance quantum (G₀).
        /// Value: 7.748091729 × 10⁻⁵ S (siemens)
        /// </summary>
        public const double ConductanceQuantum = 7.748091729e-5;
    }

    /// <summary>
    /// Provides mathematical and physical constants.
    /// </summary>
    public static class MathematicalConstants
    {
        /// <summary>
        /// The mathematical constant π (pi).
        /// Value: 3.14159265358979323846...
        /// </summary>
        public const double Pi = Math.PI;

        /// <summary>
        /// The mathematical constant e (Euler's number).
        /// Value: 2.71828182845904523536...
        /// </summary>
        public const double E = Math.E;

        /// <summary>
        /// The golden ratio (φ).
        /// Value: 1.618033988749894...
        /// </summary>
        public const double GoldenRatio = 1.618033988749894;

        /// <summary>
        /// Square root of 2.
        /// Value: 1.414213562373095...
        /// </summary>
        public const double Sqrt2 = 1.414213562373095;

        /// <summary>
        /// Square root of 3.
        /// Value: 1.732050807568877...
        /// </summary>
        public const double Sqrt3 = 1.732050807568877;

        /// <summary>
        /// Natural logarithm of 2.
        /// Value: 0.693147180559945...
        /// </summary>
        public const double Ln2 = 0.693147180559945;

        /// <summary>
        /// Natural logarithm of 10.
        /// Value: 2.302585092994046...
        /// </summary>
        public const double Ln10 = 2.302585092994046;
    }
}