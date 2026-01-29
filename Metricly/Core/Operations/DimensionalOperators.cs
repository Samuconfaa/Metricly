using Metricly.Core;
using System;

namespace Metricly.Core.Operations
{
    /// <summary>
    /// Provides dimensional operations between different measurement types.
    /// These operations follow physical laws and dimensional analysis.
    /// Use these extension methods to perform physics-based calculations.
    /// </summary>
    public static class DimensionalOperations
    {
        // NOTE: Operators cannot be defined in static classes in C#.
        // Instead, we provide extension methods and helper functions.
        // For actual operator overloading, see the individual measure classes.

        // ========================================
        // SPEED = DISTANCE / TIME
        // ========================================

        /// <summary>
        /// Calculates speed from distance and time (Speed = Distance / Time).
        /// </summary>
        public static SpeedMeasure ToSpeed(this LengthMeasure distance, TimeMeasure time)
            => new(distance.BaseValue / time.BaseValue);

        /// <summary>
        /// Calculates distance from speed and time (Distance = Speed × Time).
        /// </summary>
        public static LengthMeasure ToDistance(this SpeedMeasure speed, TimeMeasure time)
            => new(speed.BaseValue * time.BaseValue);

        /// <summary>
        /// Calculates time from distance and speed (Time = Distance / Speed).
        /// </summary>
        public static TimeMeasure ToTime(this LengthMeasure distance, SpeedMeasure speed)
            => new(distance.BaseValue / speed.BaseValue);

        // ========================================
        // ACCELERATION = SPEED / TIME
        // ========================================

        /// <summary>
        /// Calculates acceleration from speed change and time (Acceleration = ΔSpeed / Time).
        /// </summary>
        public static AccelerationMeasure ToAcceleration(this SpeedMeasure speed, TimeMeasure time)
            => new(speed.BaseValue / time.BaseValue);

        /// <summary>
        /// Calculates speed change from acceleration and time (ΔSpeed = Acceleration × Time).
        /// </summary>
        public static SpeedMeasure ToSpeed(this AccelerationMeasure acceleration, TimeMeasure time)
            => new(acceleration.BaseValue * time.BaseValue);

        // ========================================
        // FORCE = MASS × ACCELERATION
        // ========================================

        /// <summary>
        /// Calculates force from mass and acceleration (Force = Mass × Acceleration).
        /// </summary>
        public static ForceMeasure ToForce(this MassMeasure mass, AccelerationMeasure acceleration)
            => new((mass.BaseValue / 1000.0) * acceleration.BaseValue); // Convert grams to kg

        /// <summary>
        /// Calculates mass from force and acceleration (Mass = Force / Acceleration).
        /// </summary>
        public static MassMeasure ToMass(this ForceMeasure force, AccelerationMeasure acceleration)
            => new((force.BaseValue / acceleration.BaseValue) * 1000.0); // Result in grams

        /// <summary>
        /// Calculates acceleration from force and mass (Acceleration = Force / Mass).
        /// </summary>
        public static AccelerationMeasure ToAcceleration(this ForceMeasure force, MassMeasure mass)
            => new(force.BaseValue / (mass.BaseValue / 1000.0)); // Convert grams to kg

        // ========================================
        // AREA = LENGTH × LENGTH
        // ========================================

        /// <summary>
        /// Calculates area from two lengths (Area = Length × Width).
        /// </summary>
        public static AreaMeasure ToArea(this LengthMeasure length, LengthMeasure width)
            => new(length.BaseValue * width.BaseValue);

        // ========================================
        // VOLUME = AREA × LENGTH
        // ========================================

        /// <summary>
        /// Calculates volume from area and height (Volume = Area × Height).
        /// </summary>
        public static VolumeMeasure ToVolume(this AreaMeasure area, LengthMeasure height)
            => new((area.BaseValue * height.BaseValue) / 1000.0); // Convert m³ to liters

        // ========================================
        // DENSITY = MASS / VOLUME
        // ========================================

        /// <summary>
        /// Calculates density from mass and volume (Density = Mass / Volume).
        /// </summary>
        public static DensityMeasure ToDensity(this MassMeasure mass, VolumeMeasure volume)
            => new((mass.BaseValue / 1000.0) / (volume.BaseValue / 1000.0)); // Convert to kg/m³

        /// <summary>
        /// Calculates mass from density and volume (Mass = Density × Volume).
        /// </summary>
        public static MassMeasure ToMass(this DensityMeasure density, VolumeMeasure volume)
            => new(density.BaseValue * (volume.BaseValue / 1000.0) * 1000.0); // Result in grams

        /// <summary>
        /// Calculates volume from mass and density (Volume = Mass / Density).
        /// </summary>
        public static VolumeMeasure ToVolume(this MassMeasure mass, DensityMeasure density)
            => new((mass.BaseValue / 1000.0) / density.BaseValue * 1000.0); // Result in liters

        // ========================================
        // POWER = ENERGY / TIME
        // ========================================

        /// <summary>
        /// Calculates power from energy and time (Power = Energy / Time).
        /// </summary>
        public static PowerMeasure ToPower(this EnergyMeasure energy, TimeMeasure time)
            => new(energy.BaseValue / time.BaseValue);

        /// <summary>
        /// Calculates energy from power and time (Energy = Power × Time).
        /// </summary>
        public static EnergyMeasure ToEnergy(this PowerMeasure power, TimeMeasure time)
            => new(power.BaseValue * time.BaseValue);

        // ========================================
        // WORK/ENERGY = FORCE × DISTANCE
        // ========================================

        /// <summary>
        /// Calculates work/energy from force and distance (Work = Force × Distance).
        /// </summary>
        public static EnergyMeasure ToEnergy(this ForceMeasure force, LengthMeasure distance)
            => new(force.BaseValue * distance.BaseValue);

        // ========================================
        // TORQUE = FORCE × DISTANCE (perpendicular)
        // ========================================

        /// <summary>
        /// Calculates torque from force and lever arm (Torque = Force × Distance).
        /// </summary>
        public static TorqueMeasure ToTorque(this ForceMeasure force, LengthMeasure leverArm)
            => new(force.BaseValue * leverArm.BaseValue);

        // ========================================
        // PRESSURE = FORCE / AREA
        // ========================================

        /// <summary>
        /// Calculates pressure from force and area (Pressure = Force / Area).
        /// </summary>
        public static PressureMeasure ToPressure(this ForceMeasure force, AreaMeasure area)
            => new(force.BaseValue / area.BaseValue);

        /// <summary>
        /// Calculates force from pressure and area (Force = Pressure × Area).
        /// </summary>
        public static ForceMeasure ToForce(this PressureMeasure pressure, AreaMeasure area)
            => new(pressure.BaseValue * area.BaseValue);

        // ========================================
        // ELECTRICAL: OHM'S LAW & POWER
        // ========================================

        /// <summary>
        /// Calculates voltage from current and resistance (V = I × R, Ohm's Law).
        /// </summary>
        public static VoltageMeasure ToVoltage(this CurrentMeasure current, ResistanceMeasure resistance)
            => new(current.BaseValue * resistance.BaseValue);

        /// <summary>
        /// Calculates current from voltage and resistance (I = V / R, Ohm's Law).
        /// </summary>
        public static CurrentMeasure ToCurrent(this VoltageMeasure voltage, ResistanceMeasure resistance)
            => new(voltage.BaseValue / resistance.BaseValue);

        /// <summary>
        /// Calculates resistance from voltage and current (R = V / I, Ohm's Law).
        /// </summary>
        public static ResistanceMeasure ToResistance(this VoltageMeasure voltage, CurrentMeasure current)
            => new(voltage.BaseValue / current.BaseValue);

        /// <summary>
        /// Calculates electrical power from voltage and current (P = V × I).
        /// </summary>
        public static PowerMeasure ToPower(this VoltageMeasure voltage, CurrentMeasure current)
            => new(voltage.BaseValue * current.BaseValue);

        /// <summary>
        /// Calculates current from power and voltage (I = P / V).
        /// </summary>
        public static CurrentMeasure ToCurrent(this PowerMeasure power, VoltageMeasure voltage)
            => new(power.BaseValue / voltage.BaseValue);

        /// <summary>
        /// Calculates voltage from power and current (V = P / I).
        /// </summary>
        public static VoltageMeasure ToVoltage(this PowerMeasure power, CurrentMeasure current)
            => new(power.BaseValue / current.BaseValue);

        // ========================================
        // MOMENTUM = MASS × VELOCITY
        // ========================================

        /// <summary>
        /// Calculates momentum from mass and velocity.
        /// Returns the value in kg·m/s (mass in kg × velocity in m/s).
        /// </summary>
        public static double CalculateMomentum(MassMeasure mass, SpeedMeasure velocity)
            => (mass.BaseValue / 1000.0) * velocity.BaseValue; // Convert grams to kg

        // ========================================
        // KINETIC ENERGY = 1/2 × MASS × VELOCITY²
        // ========================================

        /// <summary>
        /// Calculates kinetic energy from mass and velocity.
        /// KE = 1/2 × m × v²
        /// </summary>
        public static EnergyMeasure CalculateKineticEnergy(MassMeasure mass, SpeedMeasure velocity)
        {
            double massKg = mass.BaseValue / 1000.0; // Convert grams to kg
            return new(0.5 * massKg * velocity.BaseValue * velocity.BaseValue);
        }

        // ========================================
        // POTENTIAL ENERGY = MASS × GRAVITY × HEIGHT
        // ========================================

        /// <summary>
        /// Calculates gravitational potential energy.
        /// PE = m × g × h
        /// </summary>
        public static EnergyMeasure CalculatePotentialEnergy(
            MassMeasure mass,
            AccelerationMeasure gravity,
            LengthMeasure height)
        {
            double massKg = mass.BaseValue / 1000.0; // Convert grams to kg
            return new(massKg * gravity.BaseValue * height.BaseValue);
        }

    }
}
