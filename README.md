# Metricly

A lightweight, type-safe utility library for simple and fast unit conversions in .NET.

[![NuGet](https://img.shields.io/nuget/v/Metricly.svg)](https://www.nuget.org/packages/Metricly)
[![License](https://img.shields.io/github/license/Samuconfaa/Metricly.svg)](https://github.com/Samuconfaa/Metricly/blob/main/LICENSE)

## Overview

Metricly provides an intuitive, fluent API for converting between various units of measurement. With strong typing, extension methods, and arithmetic operations, you can perform unit conversions and calculations with minimal code while maintaining type safety and readability.

## Features

-  **Lightweight**: Minimal dependencies and optimized performance
-  **Type-safe**: Strongly typed measurement classes prevent errors
-  **Fluent API**: Intuitive and readable syntax
-  **Arithmetic operations**: Add, subtract, multiply, and divide measurements
-  **Comparison operators**: Compare measurements with ==, !=, >, <, >=, <=
-  **Comprehensive**: Supports 14 measurement types
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

### Comparisons

```csharp
using Metricly.Core;

var length1 = 100.Centimeters();
var length2 = 1.Meters();

Console.WriteLine(length1 == length2);        // true
Console.WriteLine(length1 > length2);         // false
Console.WriteLine(1.5.Meters() >= length2);   // true
```

## Usage Examples

### Length Measurements

```csharp
using Metricly.Core;

var height = 180.Centimeters();
var distance = 26.2.Miles();
var space = 1.AstronomicalUnits();

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

### Mixed Unit Calculations

```csharp
using Metricly.Core;

// Calculate total distance
var run1 = 5.Kilometers();
var run2 = 3.Miles();
var run3 = 2000.Meters();
var totalRun = run1 + run2 + run3;

Console.WriteLine($"Total: {totalRun.ToKilometers():F2} km");
Console.WriteLine($"Average: {(totalRun / 3).ToKilometers():F2} km");
```

### Data Transfer Rates

```csharp
using Metricly.Core;

var internetSpeed = 100.MegabitsPerSecond();
Console.WriteLine($"{internetSpeed.ToMegabytesPerSecond()} MB/s"); // 12.5 MB/s

var downloadSpeed = 5.MegabytesPerSecond();
Console.WriteLine($"{downloadSpeed.ToMegabitsPerSecond()} Mbps");   // 40 Mbps
```

## Advanced Usage

### Chaining Operations

```csharp
var distance = 100.Meters();
var speed = 10.MetersPerSecond();
var time = distance / speed;

var doubled = distance * 2;
var half = distance / 2;
```

### Custom Calculations

```csharp
// Access base value for calculations
var length1 = 10.Meters();
var length2 = 5.Meters();
var totalMeters = length1.BaseValue + length2.BaseValue; // 15

// Calculate area
var area = length1.BaseValue * length2.BaseValue; // 50 square meters
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
- [x] Arithmetic operators between measurements
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