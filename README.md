# Metricly

A lightweight, type-safe utility library for simple and fast unit conversions in .NET.

[![NuGet](https://img.shields.io/nuget/v/Metricly.svg)](https://www.nuget.org/packages/Metricly)
[![License](https://img.shields.io/github/license/Samuconfaa/Metricly.svg)](https://github.com/Samuconfaa/Metricly/blob/main/LICENSE)

## Overview

Metricly provides an intuitive, fluent API for converting between various units of measurement. With strong typing and extension methods, you can perform unit conversions with minimal code while maintaining type safety and readability.

## Features

-  **Lightweight**: Minimal dependencies and optimized performance
-  **Type-safe**: Strongly typed measurement classes prevent errors
-  **Fluent API**: Intuitive and readable syntax
-  **Comprehensive**: Supports 15+ measurement types
-  **Easy to use**: Simple extension methods for conversions
-  **High performance**: Aggressive inlining for optimal speed

## Supported Measurement Types

Metricly supports conversions for the following types:

- **Length** - meters, kilometers, miles, feet, inches, nautical miles, astronomical units, and more
- **Mass** - grams, kilograms, pounds, ounces, metric tons, and more
- **Temperature** - Celsius, Fahrenheit, Kelvin
- **Time** - seconds, minutes, hours, days, weeks, months, years, centuries
- **Speed** - m/s, km/h, mph, knots, feet per second
- **Area** - square meters, hectares, acres, square miles, and more
- **Volume** - liters, gallons (US/Imperial), cubic meters, cups, tablespoons, and more
- **Pressure** - Pascal, atmospheres, PSI, Torr
- **Energy** - joules, calories, watt-hours, BTU, electronvolts
- **Frequency** - hertz and all SI prefixes (nano to yotta)
- **Data Size** - bytes, KB/KiB, MB/MiB, GB/GiB, TB/TiB (decimal and binary)
- **Data Rate** - bits/bytes per second with various prefixes
- **Fuel Consumption** - km/L, L/100km, MPG (US/UK)
- **Angles** - degrees, radians, gradians, arcminutes, arcseconds

## Installation

Install Metricly via NuGet Package Manager:

```bash
dotnet add package Metricly --version 0.0.1-alpha.1
```


## Quick Start

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

// Time conversions
var duration = 2.5.Hours();
Console.WriteLine(duration.ToMinutes());      // 150
Console.WriteLine(duration.ToSeconds());      // 9000

// Speed conversions
var velocity = 100.KilometersPerHour();
Console.WriteLine(velocity.ToMilesPerHour()); // 62.137...
Console.WriteLine(velocity.ToMetersPerSecond()); // 27.777...

// Data size conversions
var fileSize = 5.GB();
Console.WriteLine(fileSize.ToMB());           // 5000
Console.WriteLine(fileSize.ToGiB());          // 4.656...

// Energy conversions
var energy = 1000.cal();
Console.WriteLine(energy.TokJ());             // 4.184
Console.WriteLine(energy.ToWh());             // 1.162...
```

## Usage Examples

### Length Measurements

```csharp
using Metricly.Core;

// Create measurements
var height = 180.Centimetres();
var distance = 26.2.Miles();
var space = 1.AstronomicalUnits();

// Convert to different units
Console.WriteLine($"Height: {height.ToFeet()} feet");
Console.WriteLine($"Marathon: {distance.ToKilometers()} km");
Console.WriteLine($"Earth-Sun: {space.ToKilometers()} km");
```

### Temperature Conversions

```csharp
using Metricly.Core;

var freezing = 0.Celsius();
var roomTemp = 68.Fahrenheit();
var absolute = 273.15.Kelvin();

Console.WriteLine($"{freezing.ToFahrenheit()}°F"); // 32°F
Console.WriteLine($"{roomTemp.ToCelsius()}°C");     // 20°C
Console.WriteLine($"{absolute.ToCelsius()}°C");     // 0°C
```

### Data Transfer Rates

```csharp
using Metricly.Core;

var internetSpeed = 100.MegabitsPerSecond();
Console.WriteLine($"{internetSpeed.ToMegabytesPerSecond()} MB/s"); // 12.5 MB/s

var downloadSpeed = 5.MegabytesPerSecond();
Console.WriteLine($"{downloadSpeed.ToMegabitsPerSecond()} Mbps");   // 40 Mbps
```

### Fuel Consumption

```csharp
using Metricly.Core;

var efficiency = 15.KmPerLiter();
Console.WriteLine($"{efficiency.ToMpgUS()} MPG US");        // 35.28 MPG
Console.WriteLine($"{efficiency.ToLiterPer100Km()} L/100km"); // 6.67 L/100km
```

### Volume Measurements

```csharp
using Metricly.Core;

var recipe = 2.CupsUS();
Console.WriteLine($"{recipe.ToMilliliters()} ml");    // 480 ml
Console.WriteLine($"{recipe.ToTablespoonsUS()} tbsp"); // 32 tbsp

var tank = 50.Liters();
Console.WriteLine($"{tank.ToGallonsUS()} gallons");   // 13.21 gallons
```

## Advanced Usage

### Chaining Conversions

```csharp
// You can chain operations using the measure objects
var marathon = 42.195.Kilometers();
var inMiles = marathon.ToMiles();
var inFeet = 42.195.Kilometers().ToMeters() * 3.28084; // Convert to feet manually

// Or use the measure as an intermediate
var distance = 100.Meters();
var speed = 10.MetersPerSecond();
var time = distance.BaseValue / speed.BaseValue; // 10 seconds
```

### Custom Calculations

```csharp
// Access the base value for calculations
var length1 = 10.Meters();
var length2 = 5.Meters();
var totalMeters = length1.BaseValue + length2.BaseValue; // 15 meters

var area = length1.BaseValue * length2.BaseValue; // 50 square meters
var areaInSquareFeet = (length1.ToFeet() * length2.ToFeet());
```

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

Future enhancements may include:

- [ ] Additional measurement types (luminosity, electrical units, etc.)
- [ ] Arithmetic operators between measurements
- [ ] String parsing and formatting
- [ ] Unit tests and benchmarks
- [ ] More comprehensive documentation

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Inspired by the need for simple, type-safe unit conversions in .NET
- Built with modern C# features for optimal performance and developer experience

## Support

If you encounter any issues or have questions, please file an issue on the [GitHub repository](https://github.com/Samuconfaa/Metricly/issues).

---

Made with ❤️ by [Samuconfaa](https://github.com/Samuconfaa)