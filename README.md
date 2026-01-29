# Metricly

A lightweight, type-safe utility library for simple and fast unit conversions in .NET.

[![NuGet](https://img.shields.io/nuget/v/Metricly.svg)](https://www.nuget.org/packages/Metricly)
[![License](https://img.shields.io/github/license/Samuconfaa/Metricly.svg)](https://github.com/Samuconfaa/Metricly/blob/main/LICENSE)

## Overview

Metricly provides an intuitive, fluent API for converting between various units of measurement. With strong typing, extension methods, arithmetic operations, and dimensional calculations, you can perform unit conversions and physics-based calculations with minimal code while maintaining type safety and readability.

## Features

- **Lightweight**: Minimal dependencies and optimized performance
- **Type-safe**: Strongly typed measurement classes prevent errors
- **Fluent API**: Intuitive and readable syntax
- **Arithmetic operations**: Add, subtract, multiply, and divide measurements
- **Dimensional operations**: Physics-based calculations (Force = Mass × Acceleration, etc.)
- **Physical constants**: 80+ fundamental constants (speed of light, gravity, etc.)
- **Comparison operators**: Compare measurements with ==, !=, >, <, >=, <=
- **Comprehensive**: Supports 22 measurement types
- **Easy to use**: Simple extension methods for conversions
- **High performance**: Aggressive inlining for optimal speed

## Supported Measurement Types

Metricly supports conversions for the following types:

### Basic Measurements
- **Length** - meters, kilometers, miles, feet, inches, nautical miles, astronomical units, and more
- **Mass** - grams, kilograms, pounds, ounces, metric tons, and more
- **Temperature** - Celsius, Fahrenheit, Kelvin
- **Time** - seconds, minutes, hours, days, weeks, months, years, centuries
- **Speed** - m/s, km/h, mph, knots, feet per second
- **Area** - square meters, hectares, acres, square miles, and more
- **Volume** - liters, gallons (US/Imperial), cubic meters, cups, tablespoons, and more

### Physics & Engineering
- **Force** - Newton, kilonewton, pound-force, dyne, kilogram-force
- **Acceleration** - m/s², standard gravity (g), ft/s², gal
- **Pressure** - Pascal, atmospheres, PSI, Torr
- **Energy** - joules, calories, watt-hours, BTU, electronvolts
- **Power** - watts, kilowatts, horsepower
- **Torque** - Newton-meter, foot-pound, inch-pound
- **Density** - kg/m³, g/cm³, lb/ft³

### Electrical Units
- **Current** - Ampere, milliampere, microampere, kiloampere
- **Voltage** - Volt, millivolt, kilovolt, megavolt
- **Resistance** - Ohm, kiloohm, megaohm
- **Electric Power** - Watt, kilowatt, megawatt, horsepower

### Other
- **Frequency** - hertz and all SI prefixes (nano to yotta)
- **Data Size** - bytes, KB/KiB, MB/MiB, GB/GiB, TB/TiB (decimal and binary)
- **Data Rate** - bits/bytes per second with various prefixes
- **Fuel Consumption** - km/L, L/100km, MPG (US/UK)
- **Angles** - degrees, radians, gradians, arcminutes, arcseconds

## Installation

Install Metricly via NuGet Package Manager:

```bash
dotnet add package Metricly --version 0.1.0-beta.1
```

Or via Package Manager Console:

```powershell
NuGet\Install-Package Metricly -Version 0.1.0-beta.1
```

## Quick Start

### Basic Conversions

```csharp
using Metricly.Core;

// Length conversions
var distance = 5.Kilometers();
Console.WriteLine(distance.ToMiles());        // 3.106855...
Console.WriteLine(distance.ToMeters());       // 5000

// Temperature conversions
var temp = 100.Celsius();
Console.WriteLine(temp.ToFahrenheit());       // 212
Console.WriteLine(temp.ToKelvin());           // 373.15

// Mass conversions
var weight = 75.Kilograms();
Console.WriteLine(weight.ToPounds());         // 165.347...
Console.WriteLine(weight.ToGrams());          // 75000
```

### Arithmetic Operations

```csharp
using Metricly.Core;

// Addition and subtraction
var total = 1.Kilometers() + 500.Meters();
Console.WriteLine(total.ToKilometers());      // 1.5

var remaining = 42.Kilometers() - 10.Kilometers();
Console.WriteLine(remaining.ToKilometers());  // 32

// Multiplication and division
var triple = 5.Meters() * 3;
Console.WriteLine(triple.ToMeters());         // 15

var half = 10.Kilograms() / 2;
Console.WriteLine(half.ToKilograms());        // 5

// Ratio calculation
var ratio = 100.Kilometers() / 50.Kilometers();
Console.WriteLine(ratio);                     // 2.0
```

### Dimensional Operations (NEW in v0.1.0)

Metricly now supports physics-based dimensional operations using extension methods:

```csharp
using Metricly.Core;
using Metricly.Core.Operations;
using Metricly.Core.Constants;

// Kinematics: Speed = Distance / Time
var distance = 100.0.Meters();
var time = 10.0.Seconds();
var speed = distance.ToSpeed(time);
Console.WriteLine($"Speed: {speed.ToKilometersPerHour()} km/h");

// Dynamics: Force = Mass × Acceleration
var mass = 10.0.Kilograms();
var acceleration = 9.81.MetersPerSecondSquared();
var force = mass.ToForce(acceleration);
Console.WriteLine($"Force: {force.ToNewtons()} N");

// Electricity: Ohm's Law (V = I × R)
var current = 2.0.Amperes();
var resistance = 10.0.Ohms();
var voltage = current.ToVoltage(resistance);
Console.WriteLine($"Voltage: {voltage.ToVolts()} V");

// Energy calculations
var height = 10.0.Meters();
var potentialEnergy = DimensionalOperations.CalculatePotentialEnergy(
    mass, 
    PhysicalConstants.StandardGravity, 
    height);
Console.WriteLine($"PE: {potentialEnergy.TokJ()} kJ");
```

### Physical Constants (NEW in v0.1.0)

Access 80+ fundamental physical constants:

```csharp
using Metricly.Core.Constants;

// Universal constants
var c = PhysicalConstants.SpeedOfLight;  // 299,792,458 m/s
var g = PhysicalConstants.StandardGravity;  // 9.80665 m/s²

// Calculate time for light to travel from Sun to Earth
var sunDistance = PhysicalConstants.AstronomicalUnit;
var lightTime = sunDistance.ToTime(c);
Console.WriteLine($"Sun to Earth: {lightTime.ToMinutes():F2} minutes");

// Astronomical data
var earthMass = PhysicalConstants.EarthMass;
var solarMass = PhysicalConstants.SolarMass;

// Thermodynamic constants
var waterDensity = PhysicalConstants.WaterDensity;
var absoluteZero = PhysicalConstants.AbsoluteZero;
```

## Advanced Examples

### Example 1: Electrical Circuit Analysis

```csharp
using Metricly.Core;
using Metricly.Core.Operations;

// Circuit with voltage source and resistors in series
var voltage = 12.0.Volts();
var resistor1 = 100.0.Ohms();
var resistor2 = 200.0.Ohms();

// Total resistance
var totalResistance = resistor1 + resistor2;

// Calculate current (Ohm's Law: I = V / R)
var current = voltage.ToCurrent(totalResistance);
Console.WriteLine($"Current: {current.ToMilliamperes():F2} mA");  // 40 mA

// Calculate power dissipation (P = V × I)
var power = voltage.ToPower(current);
Console.WriteLine($"Power: {power.ToWatts():F3} W");  // 0.48 W
```

### Example 2: Projectile Motion

```csharp
using Metricly.Core;
using Metricly.Core.Operations;
using Metricly.Core.Constants;

var initialSpeed = 20.0.MetersPerSecond();
var gravity = PhysicalConstants.StandardGravity;

// Calculate kinetic energy
var mass = 1.0.Kilograms();
var kineticEnergy = DimensionalOperations.CalculateKineticEnergy(mass, initialSpeed);
Console.WriteLine($"Kinetic Energy: {kineticEnergy.ToJ()} J");

// Calculate maximum height (ignoring air resistance)
// At max height: PE = KE initial
// mgh = ½mv²  →  h = v²/(2g)
var maxHeight = (initialSpeed.BaseValue * initialSpeed.BaseValue) / 
                (2 * gravity.BaseValue);
Console.WriteLine($"Max height: {maxHeight:F2} m");
```

### Example 3: Home Energy Monitor

```csharp
using Metricly.Core;
using Metricly.Core.Operations;

// Calculate monthly energy consumption
var dailyUsage = 15.0.kWh();
var monthlyUsage = dailyUsage * 30;
Console.WriteLine($"Monthly: {monthlyUsage.TokWh()} kWh");

// Calculate cost (example rate)
var costPerKwh = 0.15; // $0.15 per kWh
var monthlyCost = monthlyUsage.TokWh() * costPerKwh;
Console.WriteLine($"Monthly cost: ${monthlyCost:F2}");

// Compare appliances
var ac = 5.0.kWh();
var heater = 3.0.kWh();
var total = ac + heater;
var acPercentage = (ac / total) * 100;
Console.WriteLine($"AC is {acPercentage:F1}% of total");
```

### Example 4: Speed of Light Calculations

```csharp
using Metricly.Core;
using Metricly.Core.Operations;
using Metricly.Core.Constants;

var lightSpeed = PhysicalConstants.SpeedOfLight;

// Time for light to reach Earth from the Sun
var sunToEarth = PhysicalConstants.AstronomicalUnit;
var timeToEarth = sunToEarth.ToTime(lightSpeed);
Console.WriteLine($"Sun to Earth: {timeToEarth.ToMinutes():F2} minutes");

// Time for light to reach the Moon
var moonDistance = 384_400.0.Kilometers();
var timeToMoon = moonDistance.ToTime(lightSpeed);
Console.WriteLine($"Earth to Moon: {timeToMoon.ToSeconds():F2} seconds");
```

## Dimensional Operations Reference

Metricly supports the following dimensional operations using extension methods:

| Physics Law | Method | Example |
|-------------|--------|---------|
| **Kinematics** |
| Speed = Distance / Time | `distance.ToSpeed(time)` | `100m.ToSpeed(10s)` |
| Distance = Speed × Time | `speed.ToDistance(time)` | `10mps.ToDistance(5s)` |
| Acceleration = Speed / Time | `speed.ToAcceleration(time)` | `20mps.ToAcceleration(5s)` |
| **Dynamics** |
| Force = Mass × Acceleration | `mass.ToForce(acceleration)` | `10kg.ToForce(9.81mps²)` |
| Work = Force × Distance | `force.ToEnergy(distance)` | `100N.ToEnergy(5m)` |
| Torque = Force × Lever | `force.ToTorque(lever)` | `50N.ToTorque(0.3m)` |
| **Electricity** |
| Voltage = Current × Resistance | `current.ToVoltage(resistance)` | `2A.ToVoltage(10Ω)` |
| Current = Voltage / Resistance | `voltage.ToCurrent(resistance)` | `12V.ToCurrent(100Ω)` |
| Power = Voltage × Current | `voltage.ToPower(current)` | `12V.ToPower(2A)` |
| **Geometry** |
| Area = Length × Width | `length.ToArea(width)` | `10m.ToArea(5m)` |
| Volume = Area × Height | `area.ToVolume(height)` | `50m².ToVolume(3m)` |
| **Other** |
| Density = Mass / Volume | `mass.ToDensity(volume)` | `1000kg.ToDensity(1m³)` |
| Pressure = Force / Area | `force.ToPressure(area)` | `1000N.ToPressure(0.1m²)` |
| Power = Energy / Time | `energy.ToPower(time)` | `1000J.ToPower(10s)` |

## Physical Constants Reference

Access fundamental physical constants through `PhysicalConstants` class:

### Universal Constants
- `SpeedOfLight` - c = 299,792,458 m/s
- `GravitationalConstant` - G = 6.67430×10⁻¹¹ N⋅m²/kg²
- `PlanckConstant` - h = 6.62607015×10⁻³⁴ J⋅s

### Electromagnetic
- `ElementaryCharge` - e = 1.602176634×10⁻¹⁹ C
- `MagneticConstant` - μ₀
- `ElectricConstant` - ε₀

### Atomic & Quantum
- `AvogadroConstant` - Nₐ = 6.02214076×10²³ mol⁻¹
- `BoltzmannConstant` - k = 1.380649×10⁻²³ J/K
- `ElectronMass`, `ProtonMass`, `NeutronMass`
- `BohrRadius`, `RydbergConstant`

### Gravity & Astronomy
- `StandardGravity` - g = 9.80665 m/s²
- `EarthMass`, `SolarMass`
- `EarthRadius`
- `AstronomicalUnit` - AU
- `LightYear`, `Parsec`

### Thermodynamic
- `GasConstant` - R = 8.314462618 J/(mol⋅K)
- `AbsoluteZero` - 0 K
- `StandardTemperature`, `StandardPressure`
- `WaterDensity`, `WaterFreezingPoint`, `WaterBoilingPoint`

### Planck Units
- `PlanckLength`, `PlanckTime`, `PlanckMass`, `PlanckTemperature`

## Performance

Metricly is designed for high performance:

- All conversion factors are compile-time constants
- Methods are marked with `AggressiveInlining` where appropriate
- Zero allocation conversions
- Minimal overhead compared to raw calculations

## Requirements

- .NET 10.0 or higher

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Roadmap

- [x] Core measurement types (Length, Mass, Temperature, etc.)
- [x] Arithmetic operators between measurements
- [x] Electrical units (Current, Voltage, Resistance, Power)
- [x] Force, Acceleration, Torque, Density
- [x] Dimensional operations (physics-based calculations)
- [x] Physical constants library
- [ ] String parsing and formatting
- [ ] Additional measurement types (Luminosity, Capacitance, Inductance)
- [ ] Unit tests and benchmarks
- [ ] More comprehensive documentation

## What's New in v0.1.0

### New Features

#### 8 New Measurement Types
- **Current** - Ampere, mA, μA, kA
- **Voltage** - Volt, mV, kV, MV
- **Resistance** - Ohm, kΩ, MΩ
- **Power** - Watt, kW, MW, Horsepower
- **Force** - Newton, kN, pound-force
- **Acceleration** - m/s², g-force
- **Density** - kg/m³, g/cm³
- **Torque** - Newton-meter, foot-pound

#### Dimensional Operations
Physics-based calculations using extension methods:
- Kinematics (speed, acceleration)
- Dynamics (force, work, torque)
- Electricity (Ohm's Law, power)
- Geometry (area, volume)
- Energy calculations (kinetic, potential)

#### Physical Constants
80+ fundamental constants including:
- Universal constants (c, G, h)
- Electromagnetic constants
- Atomic constants (electron mass, Avogadro, etc.)
- Astronomical data (AU, solar mass, etc.)
- Thermodynamic values
- Planck units

### Documentation
- Extended documentation with physics examples
- Complete API reference for new features
- Real-world usage examples

## License

This project is licensed under the Apache-2.0 License - see the [LICENSE](LICENSE) file for details.


## Support

If you encounter any issues or have questions, please file an issue on the [GitHub repository](https://github.com/Samuconfaa/Metricly/issues).

---

Made with ❤️ by [Samuconfaa](https://github.com/Samuconfaa)