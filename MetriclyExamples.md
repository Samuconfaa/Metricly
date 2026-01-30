# Metricly Real-World Examples

A comprehensive collection of practical examples demonstrating the Metricly unit conversion library.

## Table of Contents
- [Daily Life & Home](#daily-life--home)
- [Sports & Fitness](#sports--fitness)
- [Cooking & Nutrition](#cooking--nutrition)
- [Automotive & Transportation](#automotive--transportation)
- [Construction & Engineering](#construction--engineering)
- [Science & Research](#science--research)
- [Aviation & Space](#aviation--space)
- [Marine & Navigation](#marine--navigation)
- [Photography & Optics](#photography--optics)
- [Healthcare & Medicine](#healthcare--medicine)

---

## Daily Life & Home

### Air Conditioner Efficiency Calculator
**Category:** Home Appliances

```csharp
using Metricly.Core;
using Metricly.Core.Operations;

// Calculate AC efficiency and cost
var roomVolume = 50.0.CubicMeters();  // 5m × 4m × 2.5m
var targetTemp = 22.0.Celsius();
var outsideTemp = 35.0.Celsius();
var acPower = 2500.0.Watts();

var tempDifference = outsideTemp.ToCelsius() - targetTemp.ToCelsius();
Console.WriteLine($"Temperature difference: {tempDifference:F1}°C");

// Estimate cooling time (simplified model)
var airMass = roomVolume.ToCubicMeters() * 1.225; // kg (air density)
var specificHeat = 1005.0; // J/(kg·K) for air
var energyNeeded = airMass * specificHeat * tempDifference;

var coolingTime = energyNeeded / acPower.ToWatts();
Console.WriteLine($"Estimated cooling time: {(coolingTime / 60):F0} minutes");

// Daily cost calculation
var hoursPerDay = 8.0;
var dailyEnergy = acPower.ToKilowatts() * hoursPerDay;
var costPerKWh = 0.12;
var dailyCost = dailyEnergy * costPerKWh;

Console.WriteLine($"Daily energy: {dailyEnergy:F2} kWh");
Console.WriteLine($"Daily cost: ${dailyCost:F2}");
Console.WriteLine($"Monthly cost: ${dailyCost * 30:F2}");
```

### Smart Thermostat Optimizer
**Category:** Home Automation

```csharp
using Metricly.Core;

// Optimize heating schedule
var currentTemp = 18.0.Celsius();
var desiredTemp = 21.0.Celsius();
var heaterPower = 1500.0.Watts();
var roomSize = 30.0.CubicMeters();

var tempDiff = desiredTemp - currentTemp;
var heatCapacity = roomSize.ToCubicMeters() * 1.225 * 1005.0; // J/K

var energyRequired = heatCapacity * tempDiff.ToCelsius();
var timeToHeat = energyRequired / heaterPower.ToWatts();

Console.WriteLine($"Current: {currentTemp.ToFahrenheit():F1}°F");
Console.WriteLine($"Target: {desiredTemp.ToFahrenheit():F1}°F");
Console.WriteLine($"Heating time: {(timeToHeat / 60):F0} minutes");
Console.WriteLine($"Energy cost: ${(energyRequired / 3600000 * 0.12):F3}");

// Recommend pre-heating schedule
var desiredWakeTime = TimeSpan.FromHours(7); // 7:00 AM
var preheatStart = desiredWakeTime - TimeSpan.FromSeconds(timeToHeat);
Console.WriteLine($"Start heating at: {preheatStart:hh\\:mm}");
```

### Paint Calculator
**Category:** Home Improvement

```csharp
using Metricly.Core;

// Calculate paint needed for room
var wallHeight = 2.5.Meters();
var roomLength = 5.0.Meters();
var roomWidth = 4.0.Meters();

// Calculate wall area
var wallArea1 = (roomLength.ToMeters() * wallHeight.ToMeters()).SquareMeters();
var wallArea2 = (roomWidth.ToMeters() * wallHeight.ToMeters()).SquareMeters();
var totalWallArea = (wallArea1 + wallArea1 + wallArea2 + wallArea2);

// Subtract doors and windows
var doorArea = 2.0.SquareMeters();
var windowArea = 1.5.SquareMeters();
var paintableArea = totalWallArea - doorArea - windowArea;

// Paint coverage (typically 10 m²/L)
var coverage = 10.0; // m²/L
var coats = 2;
var paintNeeded = (paintableArea.ToSquareMeters() / coverage) * coats;

Console.WriteLine($"Wall area: {totalWallArea.ToSquareMeters():F1} m²");
Console.WriteLine($"Paintable area: {paintableArea.ToSquareMeters():F1} m²");
Console.WriteLine($"Paint needed: {paintNeeded:F1} L");
Console.WriteLine($"Paint cans (5L): {Math.Ceiling(paintNeeded / 5)} cans");
```

### Water Tank Fill Time
**Category:** Home Utilities

```csharp
using Metricly.Core;

// Calculate how long to fill a water tank
var tankCapacity = 500.0.Liters();
var waterPressure = 3.0.Atmospheres();
var pipeArea = (0.5 * 0.5 * Math.PI).SquareCentimeters(); // 1 cm diameter

// Flow rate estimate (simplified)
var flowRate = 20.0.LitersPerMinute();
var fillTime = tankCapacity.ToLiters() / flowRate;

Console.WriteLine($"Tank capacity: {tankCapacity.ToGallonsUS():F1} gallons");
Console.WriteLine($"Fill rate: {flowRate:F1} L/min");
Console.WriteLine($"Fill time: {fillTime:F0} minutes");
Console.WriteLine($"Water pressure: {waterPressure.ToPsi():F1} PSI");

// Calculate water cost
var costPerLiter = 0.002; // $0.002/L
var totalCost = tankCapacity.ToLiters() * costPerLiter;
Console.WriteLine($"Fill cost: ${totalCost:F2}");
```

---

## Sports & Fitness

### Running Performance Analyzer
**Category:** Fitness Tracking

```csharp
using Metricly.Core;
using Metricly.Core.Operations;

// Analyze running performance
var distance = 10.0.Kilometers();
var time = 45.0.Minutes();
var heartRate = 165; // bpm
var weight = 75.0.Kilograms();

var speed = distance.ToSpeed(time);
var pace = time.ToMinutes() / distance.ToKilometers(); // min/km

Console.WriteLine("=== Running Performance ===");
Console.WriteLine($"Distance: {distance.ToMiles():F2} miles");
Console.WriteLine($"Time: {time.ToMinutes():F0} minutes");
Console.WriteLine($"Average speed: {speed.ToKilometersPerHour():F1} km/h ({speed.ToMilesPerHour():F1} mph)");
Console.WriteLine($"Pace: {pace:F2} min/km ({pace * 1.609:F2} min/mile)");

// Estimate calories burned (MET method)
var met = 9.8; // Running at 10 km/h
var caloriesPerMinute = (met * 3.5 * weight.ToKilograms()) / 200;
var totalCalories = caloriesPerMinute * time.ToMinutes();

Console.WriteLine($"Estimated calories: {totalCalories:F0} kcal");
Console.WriteLine($"Heart rate: {heartRate} bpm");

// VO2 max estimation
var vo2max = 15.3 * (distance.ToMeters() / time.ToSeconds());
Console.WriteLine($"Estimated VO2 max: {vo2max:F1} ml/kg/min");
```

### Cycling Power Calculator
**Category:** Cycling

```csharp
using Metricly.Core;
using Metricly.Core.Operations;
using Metricly.Core.Constants;

// Calculate cycling power requirements
var speed = 30.0.KilometersPerHour();
var riderWeight = 70.0.Kilograms();
var bikeWeight = 8.0.Kilograms();
var totalWeight = riderWeight + bikeWeight;

var grade = 0.02; // 2% incline
var dragCoefficient = 0.88;
var frontalArea = 0.4; // m²
var rollingResistance = 0.004;
var airDensity = PhysicalConstants.AirDensity;

// Power components
var gravityPower = totalWeight.ToKilograms() * 9.81 * speed.ToMetersPerSecond() * grade;
var rollingPower = totalWeight.ToKilograms() * 9.81 * speed.ToMetersPerSecond() * rollingResistance;
var dragPower = 0.5 * airDensity.ToKilogramsPerCubicMeter() * dragCoefficient * frontalArea * 
                Math.Pow(speed.ToMetersPerSecond(), 3);

var totalPower = gravityPower + rollingPower + dragPower;

Console.WriteLine("=== Cycling Power Analysis ===");
Console.WriteLine($"Speed: {speed.ToKilometersPerHour():F1} km/h");
Console.WriteLine($"Grade: {grade * 100:F1}%");
Console.WriteLine($"Total weight: {totalWeight.ToKilograms():F1} kg");
Console.WriteLine($"Power required: {totalPower:F0} watts");
Console.WriteLine($"Gravity power: {gravityPower:F0} W");
Console.WriteLine($"Rolling resistance: {rollingPower:F0} W");
Console.WriteLine($"Air drag: {dragPower:F0} W");
```

### Swimming Lap Timer
**Category:** Swimming

```csharp
using Metricly.Core;

// Analyze swimming performance
var poolLength = 50.0.Meters();
var laps = 20;
var totalTime = 18.5.Minutes();

var totalDistance = (poolLength.ToMeters() * laps).Meters();
var averageSpeed = totalDistance.ToSpeed(totalTime);
var pacePerLap = totalTime.ToSeconds() / laps;
var pace100m = (100.0 / poolLength.ToMeters()) * pacePerLap;

Console.WriteLine("=== Swimming Analysis ===");
Console.WriteLine($"Pool: {poolLength.ToYards():F1} yards");
Console.WriteLine($"Total distance: {totalDistance.ToMeters():F0} m");
Console.WriteLine($"Total time: {totalTime.ToMinutes():F1} min");
Console.WriteLine($"Average speed: {averageSpeed.ToMetersPerSecond():F2} m/s");
Console.WriteLine($"Pace per lap: {pacePerLap:F1} seconds");
Console.WriteLine($"Pace per 100m: {(pace100m / 60):F2} min");

// Estimate calories
var met = 8.0; // Moderate swimming
var weight = 70.0.Kilograms();
var calories = (met * 3.5 * weight.ToKilograms() * totalTime.ToMinutes()) / 200;
Console.WriteLine($"Calories burned: {calories:F0} kcal");
```

### Weightlifting Volume Calculator
**Category:** Strength Training

```csharp
using Metricly.Core;

// Calculate training volume
var exercises = new[]
{
    ("Squat", 100.0.Kilograms(), 5, 3),      // weight, reps, sets
    ("Bench", 80.0.Kilograms(), 8, 3),
    ("Deadlift", 140.0.Kilograms(), 3, 3)
};

var totalVolume = 0.0.Kilograms();
Console.WriteLine("=== Training Session ===");

foreach (var (name, weight, reps, sets) in exercises)
{
    var exerciseVolume = weight * reps * sets;
    totalVolume = totalVolume + exerciseVolume;
    
    Console.WriteLine($"{name}: {weight.ToKilograms():F0} kg × {reps} × {sets} = {exerciseVolume.ToKilograms():F0} kg");
    Console.WriteLine($"  (In lbs: {weight.ToPounds():F0} lb)");
}

Console.WriteLine($"\nTotal volume: {totalVolume.ToKilograms():F0} kg ({totalVolume.ToPounds():F0} lb)");

// Calculate 1RM estimates using Epley formula
var benchWeight = 80.0.Kilograms();
var benchReps = 8;
var oneRepMax = benchWeight.ToKilograms() * (1 + benchReps / 30.0);
Console.WriteLine($"\nBench 1RM estimate: {oneRepMax:F0} kg ({(oneRepMax * 2.205):F0} lb)");
```

---

## Cooking & Nutrition

### Recipe Scaler
**Category:** Cooking

```csharp
using Metricly.Core;

// Scale recipe for different serving sizes
var originalServings = 4;
var desiredServings = 6;
var scaleFactor = (double)desiredServings / originalServings;

Console.WriteLine($"=== Recipe Scaler (×{scaleFactor:F2}) ===");

// Original recipe (for 4 servings)
var flour = 250.0.Grams();
var sugar = 150.0.Grams();
var butter = 100.0.Grams();
var milk = 200.0.Milliliters();
var eggs = 2;

// Scaled amounts
var scaledFlour = flour * scaleFactor;
var scaledSugar = sugar * scaleFactor;
var scaledButter = butter * scaleFactor;
var scaledMilk = milk * scaleFactor;
var scaledEggs = (int)Math.Round(eggs * scaleFactor);

Console.WriteLine($"Flour: {scaledFlour.ToGrams():F0} g ({scaledFlour.ToOunces():F1} oz)");
Console.WriteLine($"Sugar: {scaledSugar.ToGrams():F0} g ({scaledSugar.ToOunces():F1} oz)");
Console.WriteLine($"Butter: {scaledButter.ToGrams():F0} g ({scaledButter.ToOunces():F1} oz)");
Console.WriteLine($"Milk: {scaledMilk.ToMilliliters():F0} ml ({scaledMilk.ToCupsUS():F2} cups)");
Console.WriteLine($"Eggs: {scaledEggs}");
```

### Oven Temperature Converter
**Category:** Baking

```csharp
using Metricly.Core;

// Convert and adjust oven temperatures
var recipes = new[]
{
    ("Cake", 180.0.Celsius(), 45.Minutes()),
    ("Bread", 220.0.Celsius(), 30.Minutes()),
    ("Cookies", 175.0.Celsius(), 12.Minutes()),
    ("Pizza", 250.0.Celsius(), 15.Minutes())
};

Console.WriteLine("=== Oven Temperature Guide ===");
foreach (var (item, temp, time) in recipes)
{
    var fahrenheit = temp.ToFahrenheit();
    var gasmark = (temp.ToCelsius() - 140) / 20; // Approximation
    
    Console.WriteLine($"\n{item}:");
    Console.WriteLine($"  Temperature: {temp.ToCelsius():F0}°C / {fahrenheit:F0}°F / Gas Mark {gasmark:F0}");
    Console.WriteLine($"  Time: {time.ToMinutes():F0} minutes");
    
    // Fan oven adjustment (usually 20°C lower)
    var fanTemp = temp - 20.0.Celsius();
    Console.WriteLine($"  Fan oven: {fanTemp.ToCelsius():F0}°C ({fanTemp.ToFahrenheit():F0}°F)");
}
```

### Nutrition Calculator
**Category:** Health

```csharp
using Metricly.Core;

// Calculate nutritional information
var mealComponents = new[]
{
    ("Chicken breast", 200.0.Grams(), 165, 31.0, 3.6, 0.0),  // name, amount, calories, protein, fat, carbs
    ("Rice", 150.0.Grams(), 195, 4.0, 0.4, 43.0),
    ("Broccoli", 100.0.Grams(), 34, 2.8, 0.4, 7.0),
    ("Olive oil", 10.0.Milliliters(), 88, 0.0, 10.0, 0.0)
};

var totalCalories = 0.0;
var totalProtein = 0.0;
var totalFat = 0.0;
var totalCarbs = 0.0;

Console.WriteLine("=== Meal Nutritional Analysis ===\n");

foreach (var (name, amount, cal, protein, fat, carbs) in mealComponents)
{
    totalCalories += cal;
    totalProtein += protein;
    totalFat += fat;
    totalCarbs += carbs;
    
    if (amount.BaseValue < 1.0) // If less than 1L/1kg
    {
        Console.WriteLine($"{name}: {amount.ToMilliliters():F0} ml - {cal} cal");
    }
    else
    {
        Console.WriteLine($"{name}: {amount.ToGrams():F0} g ({amount.ToOunces():F1} oz) - {cal} cal");
    }
}

Console.WriteLine($"\n=== Totals ===");
Console.WriteLine($"Calories: {totalCalories:F0} kcal");
Console.WriteLine($"Protein: {totalProtein:F1} g ({(totalProtein * 4):F0} kcal)");
Console.WriteLine($"Fat: {totalFat:F1} g ({(totalFat * 9):F0} kcal)");
Console.WriteLine($"Carbs: {totalCarbs:F1} g ({(totalCarbs * 4):F0} kcal)");

// Macronutrient ratios
var proteinPercent = (totalProtein * 4 / totalCalories) * 100;
var fatPercent = (totalFat * 9 / totalCalories) * 100;
var carbsPercent = (totalCarbs * 4 / totalCalories) * 100;

Console.WriteLine($"\nMacro ratio: P{proteinPercent:F0}% F{fatPercent:F0}% C{carbsPercent:F0}%");
```

### Coffee Brewing Calculator
**Category:** Beverages

```csharp
using Metricly.Core;

// Calculate coffee-to-water ratio
var waterAmount = 300.0.Milliliters();
var coffeeRatio = 1.0 / 15.0; // 1g coffee per 15ml water (standard)

var coffeeNeeded = waterAmount.ToMilliliters() * coffeeRatio;
var brewTime = 4.0.Minutes(); // For pour-over
var waterTemp = 93.0.Celsius();

Console.WriteLine("=== Coffee Brewing Guide ===");
Console.WriteLine($"Water: {waterAmount.ToMilliliters():F0} ml ({waterAmount.ToFluidOuncesUS():F1} fl oz)");
Console.WriteLine($"Coffee: {coffeeNeeded:F1} g ({(coffeeNeeded / 5):F1} tbsp)");
Console.WriteLine($"Ratio: 1:{(1/coffeeRatio):F0}");
Console.WriteLine($"Temperature: {waterTemp.ToCelsius():F0}°C ({waterTemp.ToFahrenheit():F0}°F)");
Console.WriteLine($"Brew time: {brewTime.ToMinutes():F0} minutes");

// Calculate cups
var cupsProduced = waterAmount.ToCupsUS();
Console.WriteLine($"\nYield: {cupsProduced:F1} cups");

// Caffeine estimate (95mg per 8 oz cup)
var caffeine = cupsProduced * 95;
Console.WriteLine($"Estimated caffeine: {caffeine:F0} mg");
```

---

## Automotive & Transportation

### Tire Pressure Monitor
**Category:** Vehicle Maintenance

```csharp
using Metricly.Core;

// Check and convert tire pressure
var frontLeft = 32.0.Psi();
var frontRight = 31.0.Psi();
var rearLeft = 30.0.Psi();
var rearRight = 29.0.Psi();
var recommended = 32.0.Psi();

Console.WriteLine("=== Tire Pressure Check ===");
Console.WriteLine($"Recommended: {recommended.ToPsi():F0} PSI ({recommended.ToPascal():F0} kPa) ({recommended.ToAtmospheres():F2} bar)");
Console.WriteLine();

var tires = new[]
{
    ("Front Left", frontLeft),
    ("Front Right", frontRight),
    ("Rear Left", rearLeft),
    ("Rear Right", rearRight)
};

foreach (var (position, pressure) in tires)
{
    var difference = pressure - recommended;
    var percentDiff = (difference.ToPsi() / recommended.ToPsi()) * 100;
    var status = Math.Abs(percentDiff) > 5 ? "⚠️ Check" : "✓ OK";
    
    Console.WriteLine($"{position}: {pressure.ToPsi():F1} PSI {status}");
    if (Math.Abs(percentDiff) > 1)
    {
        Console.WriteLine($"  Difference: {difference.ToPsi():+F1;-F1} PSI ({percentDiff:+F1;-F1}%)");
    }
}

// Temperature effect warning
var tempDifference = 20.0.Celsius();
var pressureChange = (recommended.ToPsi() * tempDifference.ToCelsius() * 0.02); // ~2% per 10°C
Console.WriteLine($"\nNote: ±{tempDifference.ToCelsius():F0}°C = ±{pressureChange:F1} PSI change");
```

### EV Range Calculator
**Category:** Electric Vehicles

```csharp
using Metricly.Core;
using Metricly.Core.Operations;

// Calculate EV range and charging time
var batteryCapacity = 75.0.kWh();
var currentCharge = 20.0; // percent
var efficiency = 5.0; // km per kWh
var chargingPower = 11.0.Kilowatts(); // AC charger

var availableEnergy = batteryCapacity * (currentCharge / 100);
var currentRange = availableEnergy.TokWh() * efficiency;

Console.WriteLine("=== EV Range Calculator ===");
Console.WriteLine($"Battery: {batteryCapacity.TokWh():F0} kWh");
Console.WriteLine($"Current charge: {currentCharge:F0}% ({availableEnergy.TokWh():F1} kWh)");
Console.WriteLine($"Current range: {currentRange:F0} km ({(currentRange * 0.621):F0} miles)");
Console.WriteLine($"Efficiency: {efficiency:F1} km/kWh");

// Calculate charging time to 80%
var targetCharge = 80.0;
var energyNeeded = batteryCapacity * ((targetCharge - currentCharge) / 100);
var chargingTime = energyNeeded.ToEnergy(chargingPower);

Console.WriteLine($"\nTo charge to {targetCharge:F0}%:");
Console.WriteLine($"Energy needed: {energyNeeded.TokWh():F1} kWh");
Console.WriteLine($"Charging power: {chargingPower.ToKilowatts():F0} kW");
Console.WriteLine($"Time needed: {chargingTime.ToHours():F1} hours ({chargingTime.ToMinutes():F0} min)");

// Cost estimation
var costPerKWh = 0.15;
var chargingCost = energyNeeded.TokWh() * costPerKWh;
Console.WriteLine($"Charging cost: ${chargingCost:F2}");

// Full charge range
var fullRange = batteryCapacity.TokWh() * efficiency;
Console.WriteLine($"\nFull range (100%): {fullRange:F0} km ({(fullRange * 0.621):F0} miles)");
```

### Parking Lot Capacity
**Category:** Urban Planning

```csharp
using Metricly.Core;

// Calculate parking lot capacity and dimensions
var lotLength = 100.0.Meters();
var lotWidth = 50.0.Meters();
var totalArea = lotLength.ToArea(lotWidth);

// Standard parking space dimensions
var spaceLength = 5.0.Meters();
var spaceWidth = 2.5.Meters();
var spaceArea = spaceLength.ToArea(spaceWidth);

// Calculate with circulation space
var usablePercent = 0.65; // 35% for driving lanes
var usableArea = totalArea * usablePercent;
var capacity = Math.Floor(usableArea / spaceArea);

Console.WriteLine("=== Parking Lot Analysis ===");
Console.WriteLine($"Lot size: {lotLength.ToMeters():F0}m × {lotWidth.ToMeters():F0}m");
Console.WriteLine($"Total area: {totalArea.ToSquareMeters():F0} m² ({totalArea.ToAcres():F2} acres)");
Console.WriteLine($"Usable area: {usableArea.ToSquareMeters():F0} m² ({usablePercent * 100:F0}%)");
Console.WriteLine($"\nSpace size: {spaceLength.ToMeters():F1}m × {spaceWidth.ToMeters():F1}m");
Console.WriteLine($"Space area: {spaceArea.ToSquareMeters():F1} m²");
Console.WriteLine($"\nCapacity: {capacity:F0} vehicles");

// Per vehicle statistics
var areaPerVehicle = totalArea / capacity;
Console.WriteLine($"Area per vehicle: {areaPerVehicle.ToSquareMeters():F1} m²");
```

### Semi-Truck Load Calculator
**Category:** Logistics

```csharp
using Metricly.Core;

// Calculate truck load and weight distribution
var maxGrossWeight = 36_000.0.Kilograms(); // EU limit
var truckWeight = 15_000.0.Kilograms();
var trailerWeight = 8_000.0.Kilograms();
var maxPayload = maxGrossWeight - truckWeight - trailerWeight;

Console.WriteLine("=== Truck Load Calculator ===");
Console.WriteLine($"Max gross weight: {maxGrossWeight.ToMetricTons():F1} tonnes");
Console.WriteLine($"Truck weight: {truckWeight.ToKilograms():F0} kg");
Console.WriteLine($"Trailer weight: {trailerWeight.ToKilograms():F0} kg");
Console.WriteLine($"Max payload: {maxPayload.ToKilograms():F0} kg ({maxPayload.ToMetricTons():F1} tonnes)");

// Current load
var cargo = new[]
{
    ("Pallets", 10_000.0.Kilograms()),
    ("Boxes", 3_000.0.Kilograms()),
    ("Equipment", 500.0.Kilograms())
};

var totalCargo = 0.0.Kilograms();
Console.WriteLine("\n=== Current Load ===");
foreach (var (item, weight) in cargo)
{
    totalCargo = totalCargo + weight;
    Console.WriteLine($"{item}: {weight.ToKilograms():F0} kg");
}

var currentGross = truckWeight + trailerWeight + totalCargo;
var remaining = maxPayload - totalCargo;

Console.WriteLine($"\nTotal cargo: {totalCargo.ToKilograms():F0} kg ({totalCargo.ToPounds():F0} lb)");
Console.WriteLine($"Current gross: {currentGross.ToMetricTons():F2} tonnes");
Console.WriteLine($"Remaining capacity: {remaining.ToKilograms():F0} kg");
Console.WriteLine($"Load percentage: {(totalCargo / maxPayload * 100):F1}%");

if (currentGross > maxGrossWeight)
{
    Console.WriteLine("\n⚠️ WARNING: Overweight!");
}
```

---

## Construction & Engineering

### Concrete Volume Calculator
**Category:** Construction

```csharp
using Metricly.Core;

// Calculate concrete needed for a foundation
var length = 10.0.Meters();
var width = 8.0.Meters();
var thickness = 0.15.Meters(); // 15 cm slab

var volume = length.ToArea(width).ToVolume(thickness);
var concreteDensity = 2400.0.KilogramsPerCubicMeter();
var totalMass = concreteDensity.ToMass(volume);

Console.WriteLine("=== Concrete Calculator ===");
Console.WriteLine($"Dimensions: {length.ToMeters():F1}m × {width.ToMeters():F1}m × {thickness.ToCentimeters():F0}cm");
Console.WriteLine($"Volume: {volume.ToCubicMeters():F2} m³ ({volume.ToCubicYards():F2} yd³)");
Console.WriteLine($"Mass: {totalMass.ToMetricTons():F2} tonnes");

// Calculate number of bags needed
var bagWeight = 25.0.Kilograms();
var concreteYield = 0.0125; // m³ per 25kg bag
var bagsNeeded = Math.Ceiling(volume.ToCubicMeters() / concreteYield);

Console.WriteLine($"\nBags needed (25kg): {bagsNeeded:F0}");
Console.WriteLine($"Total weight: {(bagsNeeded * bagWeight.ToKilograms()):F0} kg");

// Cost estimation
var costPerBag = 6.50;
var totalCost = bagsNeeded * costPerBag;
var deliveryCost = 75.00;

Console.WriteLine($"\nMaterial cost: ${totalCost:F2}");
Console.WriteLine($"Delivery: ${deliveryCost:F2}");
Console.WriteLine($"Total: ${(totalCost + deliveryCost):F2}");
```

### Rebar Weight Calculator
**Category:** Structural Engineering

```csharp
using Metricly.Core;

// Calculate rebar weight for construction project
var rebarSizes = new[]
{
    ("10mm", 10.0.Millimeters(), 0.617, 150.0.Meters()),  // diameter, kg/m, length
    ("12mm", 12.0.Millimeters(), 0.888, 200.0.Meters()),
    ("16mm", 16.0.Millimeters(), 1.578, 100.0.Meters()),
    ("20mm", 20.0.Millimeters(), 2.466, 50.0.Meters())
};

var totalWeight = 0.0.Kilograms();
var steelDensity = 7850.0.KilogramsPerCubicMeter();

Console.WriteLine("=== Rebar Weight Calculator ===\n");

foreach (var (size, diameter, weightPerMeter, totalLength) in rebarSizes)
{
    var weight = weightPerMeter * totalLength.ToMeters();
    totalWeight = totalWeight + weight.Kilograms();
    
    Console.WriteLine($"{size} rebar:");
    Console.WriteLine($"  Length: {totalLength.ToMeters():F0} m ({totalLength.ToFeet():F0} ft)");
    Console.WriteLine($"  Weight: {weight:F1} kg ({(weight * 2.205):F1} lb)");
    Console.WriteLine($"  Weight/m: {weightPerMeter:F3} kg/m");
}

Console.WriteLine($"\nTotal rebar weight: {totalWeight.ToKilograms():F0} kg ({totalWeight.ToPounds():F0} lb)");
Console.WriteLine($"Total weight: {totalWeight.ToMetricTons():F2} tonnes");

// Transportation planning
var truckCapacity = 10.0.MetricTons();
var tripsNeeded = Math.Ceiling(totalWeight.ToMetricTons() / truckCapacity.ToMetricTons());
Console.WriteLine($"\nTrucks needed: {tripsNeeded:F0} (capacity: {truckCapacity.ToMetricTons():F0} tonnes each)");
```

### HVAC Duct Sizing
**Category:** Mechanical Engineering

```csharp
using Metricly.Core;

// Calculate duct size for HVAC system
var roomVolume = 100.0.CubicMeters();
var airChangesPerHour = 4; // For residential
var requiredAirflow = roomVolume.ToCubicMeters() * airChangesPerHour / 60; // m³/min

var airVelocity = 5.0.MetersPerSecond(); // Standard duct velocity
var ductArea = (requiredAirflow / 60) / airVelocity.ToMetersPerSecond(); // m²

// Calculate round duct diameter
var ductDiameter = Math.Sqrt(4 * ductArea / Math.PI);

Console.WriteLine("=== HVAC Duct Sizing ===");
Console.WriteLine($"Room volume: {roomVolume.ToCubicMeters():F0} m³");
Console.WriteLine($"Air changes/hour: {airChangesPerHour}");
Console.WriteLine($"Required airflow: {requiredAirflow:F2} m³/min ({(requiredAirflow * 35.31):F0} CFM)");
Console.WriteLine($"Air velocity: {airVelocity.ToMetersPerSecond():F1} m/s");
Console.WriteLine($"\nDuct area needed: {ductArea:F4} m²");
Console.WriteLine($"Round duct diameter: {(ductDiameter * 1000):F0} mm ({(ductDiameter * 39.37):F1} inches)");

// Rectangular duct alternative
var rectWidth = 0.3.Meters(); // 300mm
var rectHeight = ductArea / rectWidth.ToMeters();

Console.WriteLine($"\nRectangular duct alternative:");
Console.WriteLine($"Width: {(rectWidth.ToMeters() * 1000):F0} mm");
Console.WriteLine($"Height: {(rectHeight * 1000):F0} mm");
```

### Scaffold Load Calculator
**Category:** Construction Safety

```csharp
using Metricly.Core;
using Metricly.Core.Operations;

// Calculate scaffold load capacity and safety
var platformArea = 2.0.Meters() * 1.5.Meters();
var scaffoldArea = platformArea.SquareMeters();

// Load components
var materialWeight = 500.0.Kilograms();
var workerCount = 3;
var workerWeight = 80.0.Kilograms();
var totalWorkerWeight = workerWeight * workerCount;
var equipmentWeight = 100.0.Kilograms();

var totalLoad = materialWeight + totalWorkerWeight + equipmentWeight;
var loadPerArea = totalLoad.ToDensity((scaffoldArea.ToSquareMeters() / 1000).Liters()); // Simplified

Console.WriteLine("=== Scaffold Load Analysis ===");
Console.WriteLine($"Platform area: {scaffoldArea.ToSquareMeters():F1} m²");
Console.WriteLine($"\n=== Loads ===");
Console.WriteLine($"Materials: {materialWeight.ToKilograms():F0} kg");
Console.WriteLine($"Workers: {workerCount} × {workerWeight.ToKilograms():F0} kg = {totalWorkerWeight.ToKilograms():F0} kg");
Console.WriteLine($"Equipment: {equipmentWeight.ToKilograms():F0} kg");
Console.WriteLine($"\nTotal load: {totalLoad.ToKilograms():F0} kg ({totalLoad.ToPounds():F0} lb)");

// Calculate pressure
var pressurePa = (totalLoad.ToKilograms() * 9.81) / scaffoldArea.ToSquareMeters();
var pressure = pressurePa.Pascal();

Console.WriteLine($"Pressure: {pressure.ToPascal():F0} Pa ({pressure.ToPsi():F1} PSI)");

// Safety check (typical scaffold capacity: 2.5 kPa)
var maxCapacity = 2500.0.Pascal();
var safetyFactor = maxCapacity.ToPascal() / pressure.ToPascal();

Console.WriteLine($"\nMax capacity: {maxCapacity.ToPascal():F0} Pa");
Console.WriteLine($"Safety factor: {safetyFactor:F2}");

if (safetyFactor < 2.0)
{
    Console.WriteLine("⚠️ WARNING: Insufficient safety margin!");
}
else
{
    Console.WriteLine("✓ Load is within safe limits");
}
```

---

## Science & Research

### Laboratory Solution Preparation
**Category:** Chemistry

```csharp
using Metricly.Core;

// Prepare laboratory solutions
var targetVolume = 1.0.Liters();
var targetConcentration = 0.5; // mol/L
var molarMass = 58.44; // NaCl g/mol

var requiredMass = targetConcentration * targetVolume.ToLiters() * molarMass;

Console.WriteLine("=== Solution Preparation ===");
Console.WriteLine($"Target volume: {targetVolume.ToMilliliters():F0} ml");
Console.WriteLine($"Concentration: {targetConcentration:F1} M");
Console.WriteLine($"Compound: NaCl (MM = {molarMass:F2} g/mol)");
Console.WriteLine($"\nRequired mass: {requiredMass:F2} g");

// Dilution calculation
var stockConcentration = 2.0; // mol/L
var stockVolume = (targetConcentration * targetVolume.ToLiters()) / stockConcentration;
var waterVolume = targetVolume.ToLiters() - stockVolume;

Console.WriteLine($"\n=== Dilution Method ===");
Console.WriteLine($"Stock solution: {stockConcentration:F1} M");
Console.WriteLine($"Stock volume needed: {(stockVolume * 1000):F1} ml");
Console.WriteLine($"Water to add: {(waterVolume * 1000):F1} ml");
Console.WriteLine($"C1V1 = C2V2: {stockConcentration:F1} × {(stockVolume * 1000):F0} = {targetConcentration:F1} × {targetVolume.ToMilliliters():F0}");

// pH buffer preparation
Console.WriteLine($"\n=== Safety Notes ===");
Console.WriteLine($"Always add acid to water, never water to acid");
Console.WriteLine($"Use appropriate PPE");
Console.WriteLine($"Final volume: {targetVolume.ToLiters():F2} L ({targetVolume.ToGallonsUS():F2} gal)");
```

### Centrifuge Speed Calculator
**Category:** Laboratory Equipment

```csharp
using Metricly.Core;
using Metricly.Core.Operations;
using Metricly.Core.Constants;

// Calculate centrifuge parameters
var rpm = 3000.0; // revolutions per minute
var rotorRadius = 0.15.Meters();

// Convert RPM to angular velocity
var angularVelocity = (rpm * 2 * Math.PI) / 60; // rad/s
var linearSpeed = (angularVelocity * rotorRadius.ToMeters()).MetersPerSecond();

// Calculate RCF (Relative Centrifugal Force) in units of g
var centrifugalAccel = (angularVelocity * angularVelocity * rotorRadius.ToMeters()).MetersPerSecondSquared();
var rcf = centrifugalAccel / PhysicalConstants.StandardGravity;

Console.WriteLine("=== Centrifuge Calculator ===");
Console.WriteLine($"Speed: {rpm:F0} RPM");
Console.WriteLine($"Rotor radius: {rotorRadius.ToCentimeters():F1} cm");
Console.WriteLine($"\nLinear speed: {linearSpeed.ToMetersPerSecond():F2} m/s");
Console.WriteLine($"Centrifugal acceleration: {centrifugalAccel.ToMetersPerSecondSquared():F1} m/s²");
Console.WriteLine($"RCF: {rcf.ToStandardGravity():F0} × g");

// Calculate time for specific separation
var particleDiameter = 10.0.Micrometers();
var fluidViscosity = 0.001; // Pa·s (water)
var densityDifference = 100.0; // kg/m³

Console.WriteLine($"\n=== Separation Parameters ===");
Console.WriteLine($"Particle size: {particleDiameter.ToMicrometers():F0} μm");
Console.WriteLine($"Relative density: {densityDifference:F0} kg/m³");

// Stokes' law settling time (simplified)
var settlingTime = 9.Minutes(); // Estimated
Console.WriteLine($"Estimated time: {settlingTime.ToMinutes():F0} minutes");
```

### Telescope Magnification
**Category:** Astronomy

```csharp
using Metricly.Core;
using Metricly.Core.Constants;

// Calculate telescope parameters
var objectiveDiameter = 200.0.Millimeters(); // Primary mirror/lens
var focalLength = 2000.0.Millimeters();
var eyepieceFocalLength = 25.0.Millimeters();

var magnification = focalLength.ToMillimeters() / eyepieceFocalLength.ToMillimeters();
var fRatio = focalLength.ToMillimeters() / objectiveDiameter.ToMillimeters();
var exitPupil = objectiveDiameter.ToMillimeters() / magnification;

Console.WriteLine("=== Telescope Specifications ===");
Console.WriteLine($"Aperture: {objectiveDiameter.ToMillimeters():F0} mm ({objectiveDiameter.ToInches():F1} inches)");
Console.WriteLine($"Focal length: {focalLength.ToMillimeters():F0} mm");
Console.WriteLine($"f-ratio: f/{fRatio:F1}");
Console.WriteLine($"\n=== With {eyepieceFocalLength.ToMillimeters():F0}mm Eyepiece ===");
Console.WriteLine($"Magnification: {magnification:F0}×");
Console.WriteLine($"Exit pupil: {exitPupil:F1} mm");

// Calculate theoretical resolution (Dawes' limit)
var resolutionArcsec = 115.8 / objectiveDiameter.ToMillimeters();
Console.WriteLine($"Resolution: {resolutionArcsec:F2} arcseconds");

// Light gathering power compared to human eye
var eyeDiameter = 7.0.Millimeters(); // Dark-adapted pupil
var lightGatheringPower = Math.Pow(objectiveDiameter.ToMillimeters() / eyeDiameter, 2);
Console.WriteLine($"Light gathering: {lightGatheringPower:F0}× human eye");

// Calculate maximum useful magnification
var maxMagnification = objectiveDiameter.ToMillimeters() * 2;
Console.WriteLine($"\nMax useful magnification: {maxMagnification:F0}×");

// Field of view
var apparentFOV = 50.0; // degrees (typical eyepiece)
var trueFOV = apparentFOV / magnification;
Console.WriteLine($"True field of view: {trueFOV:F2}° ({(trueFOV * 60):F1} arcminutes)");
```

### Earthquake Energy Calculator
**Category:** Seismology

```csharp
using Metricly.Core;

// Calculate earthquake energy from Richter magnitude
var magnitudes = new[] { 5.0, 6.0, 7.0, 8.0, 9.0 };

Console.WriteLine("=== Earthquake Energy Calculator ===\n");

foreach (var magnitude in magnitudes)
{
    // Gutenberg-Richter relation: log10(E) = 4.8 + 1.5 * M
    var logEnergy = 4.8 + 1.5 * magnitude;
    var energyJoules = Math.Pow(10, logEnergy);
    var energyMJ = (energyJoules / 1_000_000).MJ();
    var energyTNT = energyJoules / 4.184e9; // Tons of TNT
    
    Console.WriteLine($"Magnitude {magnitude:F1}:");
    Console.WriteLine($"  Energy: {energyMJ.ToMJ():E2} MJ");
    Console.WriteLine($"  Equivalent: {energyTNT:F0} tons of TNT");
    Console.WriteLine($"  Gigajoules: {energyMJ.ToGJ():F0} GJ");
    
    if (magnitude >= 7.0)
    {
        var hiroshima = 63_000_000_000_000.0; // 15 kilotons
        var comparison = energyJoules / hiroshima;
        Console.WriteLine($"  = {comparison:F1}× Hiroshima bomb");
    }
    
    Console.WriteLine();
}

// Magnitude comparison
Console.WriteLine("Note: Each magnitude increase = 31.6× more energy");
Console.WriteLine("Magnitude 8.0 = 1000× more powerful than magnitude 6.0");
```

---

## Aviation & Space

### Flight Altitude Converter
**Category:** Aviation

```csharp
using Metricly.Core;
using Metricly.Core.Constants;

// Convert between flight levels and altitudes
var flightLevels = new[] { 100, 180, 280, 350, 410 };
var qnh = 1013.25.Pascal(); // Standard pressure
var temp = 15.0.Celsius(); // ISA standard

Console.WriteLine("=== Flight Level Converter ===");
Console.WriteLine($"QNH: {qnh.ToPascal():F2} hPa");
Console.WriteLine($"Temperature: {temp.ToCelsius():F0}°C (ISA)\n");

foreach (var fl in flightLevels)
{
    var altitudeFeet = (fl * 100).Feet();
    var altitudeMeters = altitudeFeet.ToMeters().Meters();
    
    // Calculate temperature at altitude (ISA: -2°C per 1000 ft)
    var tempAtAltitude = temp - ((altitudeFeet.ToFeet() / 1000) * 2).Celsius();
    
    // Calculate pressure at altitude (simplified)
    var pressureRatio = Math.Pow(1 - (altitudeMeters.ToMeters() / 44330), 5.255);
    var pressure = (qnh.ToPascal() * pressureRatio).Pascal();
    
    Console.WriteLine($"FL{fl}:");
    Console.WriteLine($"  Altitude: {altitudeFeet.ToFeet():F0} ft / {altitudeMeters.ToMeters():F0} m");
    Console.WriteLine($"  Temperature: {tempAtAltitude.ToCelsius():F1}°C");
    Console.WriteLine($"  Pressure: {pressure.ToPascal():F0} hPa");
    
    // True airspeed vs indicated airspeed
    var ias = 250.0.Knots(); // Indicated airspeed
    var tas = ias.ToKnots() * Math.Sqrt(pressureRatio);
    Console.WriteLine($"  TAS (at IAS 250kt): {tas:F0} kt\n");
}
```

### Rocket Delta-V Calculator
**Category:** Space Flight

```csharp
using Metricly.Core;
using Metricly.Core.Operations;

// Calculate rocket delta-v using Tsiolkovsky equation
var dryMass = 5000.0.Kilograms();
var fuelMass = 20000.0.Kilograms();
var totalMass = dryMass + fuelMass;
var exhaustVelocity = 3000.0.MetersPerSecond(); // Specific impulse × g

var massRatio = totalMass / dryMass;
var deltaV = exhaustVelocity.ToMetersPerSecond() * Math.Log(massRatio.ToKilograms());

Console.WriteLine("=== Rocket Delta-V Calculator ===");
Console.WriteLine($"Dry mass: {dryMass.ToKilograms():F0} kg");
Console.WriteLine($"Fuel mass: {fuelMass.ToKilograms():F0} kg");
Console.WriteLine($"Total mass: {totalMass.ToKilograms():F0} kg");
Console.WriteLine($"Mass ratio: {massRatio.ToKilograms():F2}:1");
Console.WriteLine($"Exhaust velocity: {exhaustVelocity.ToMetersPerSecond():F0} m/s");
Console.WriteLine($"\nDelta-V: {deltaV:F0} m/s ({(deltaV / 1000):F2} km/s)");

// Compare to Earth escape velocity
var escapeVelocity = 11_186.0.MetersPerSecond();
var percentOfEscape = (deltaV / escapeVelocity.ToMetersPerSecond()) * 100;
Console.WriteLine($"Escape velocity: {escapeVelocity.ToKilometersPerHour():F0} km/h");
Console.WriteLine($"Achieved: {percentOfEscape:F1}% of escape velocity");

// Orbital velocity
var orbitalVelocity = 7_800.0.MetersPerSecond();
Console.WriteLine($"\nLEO orbital velocity: {orbitalVelocity.ToKilometersPerHour():F0} km/h");

if (deltaV >= orbitalVelocity.ToMetersPerSecond())
{
    Console.WriteLine("✓ Sufficient for LEO");
}
else
{
    var deficit = orbitalVelocity.ToMetersPerSecond() - deltaV;
    Console.WriteLine($"⚠️ Need {deficit:F0} m/s more for orbit");
}
```

### Satellite Orbit Calculator
**Category:** Space

```csharp
using Metricly.Core;
using Metricly.Core.Operations;
using Metricly.Core.Constants;

// Calculate orbital parameters
var orbitAltitude = 400.0.Kilometers(); // ISS altitude
var earthRadius = PhysicalConstants.EarthRadius;
var earthMass = PhysicalConstants.EarthMass;
var orbitalRadius = earthRadius + orbitAltitude;

// Calculate orbital velocity: v = sqrt(GM/r)
var G = PhysicalConstants.GravitationalConstant;
var orbitalVelocity = Math.Sqrt((G * earthMass.ToKilograms()) / orbitalRadius.ToMeters());

// Calculate orbital period: T = 2π√(r³/GM)
var orbitalPeriod = 2 * Math.PI * Math.Sqrt(Math.Pow(orbitalRadius.ToMeters(), 3) / (G * earthMass.ToKilograms()));

Console.WriteLine("=== Satellite Orbit Calculator ===");
Console.WriteLine($"Orbit altitude: {orbitAltitude.ToKilometers():F0} km ({orbitAltitude.ToMiles():F0} mi)");
Console.WriteLine($"Orbital radius: {orbitalRadius.ToKilometers():F0} km");
Console.WriteLine($"\nOrbital velocity: {orbitalVelocity:F0} m/s ({(orbitalVelocity / 1000 * 3600):F0} km/h)");
Console.WriteLine($"Orbital period: {(orbitalPeriod / 60):F1} minutes ({(orbitalPeriod / 3600):F2} hours)");

// Calculate number of orbits per day
var orbitsPerDay = 86400 / orbitalPeriod;
Console.WriteLine($"Orbits per day: {orbitsPerDay:F1}");

// Ground track velocity
var earthCircumference = 2 * Math.PI * earthRadius.ToMeters();
var groundTrackVelocity = earthCircumference / orbitalPeriod;
Console.WriteLine($"\nGround track velocity: {groundTrackVelocity:F0} m/s");
Console.WriteLine($"Distance per orbit: {(orbitalVelocity * orbitalPeriod / 1000):F0} km");

// Compare to geostationary orbit
var geoAltitude = 35_786.0.Kilometers();
Console.WriteLine($"\nGeostationary altitude: {geoAltitude.ToKilometers():F0} km");
Console.WriteLine($"Height difference: {(geoAltitude - orbitAltitude).ToKilometers():F0} km");
```

### Aircraft Fuel Consumption
**Category:** Aviation

```csharp
using Metricly.Core;

// Calculate aircraft fuel consumption and range
var cruiseSpeed = 450.0.Knots();
var fuelFlow = 2000.0; // kg/hour
var fuelCapacity = 20000.0.Kilograms();
var reservePercent = 0.15; // 15% reserve

var usableFuel = fuelCapacity * (1 - reservePercent);
var endurance = usableFuel.ToKilograms() / fuelFlow;
var range = cruiseSpeed.ToKnots() * endurance;

Console.WriteLine("=== Aircraft Performance ===");
Console.WriteLine($"Cruise speed: {cruiseSpeed.ToKnots():F0} kt ({cruiseSpeed.ToKilometersPerHour():F0} km/h)");
Console.WriteLine($"Fuel flow: {fuelFlow:F0} kg/h");
Console.WriteLine($"Fuel capacity: {fuelCapacity.ToKilograms():F0} kg");
Console.WriteLine($"Usable fuel: {usableFuel.ToKilograms():F0} kg ({(usableFuel / fuelCapacity * 100):F0}%)");
Console.WriteLine($"\nEndurance: {endurance:F1} hours");
Console.WriteLine($"Range: {range:F0} nm ({(range * 1.852):F0} km)");

// Flight planning
var plannedDistance = 800.0; // nautical miles
var flightTime = plannedDistance / cruiseSpeed.ToKnots();
var fuelNeeded = flightTime * fuelFlow;
var fuelWithReserve = fuelNeeded * (1 + reservePercent);

Console.WriteLine($"\n=== Flight Plan ({plannedDistance:F0} nm) ===");
Console.WriteLine($"Flight time: {flightTime:F1} hours ({(flightTime * 60):F0} minutes)");
Console.WriteLine($"Fuel needed: {fuelNeeded:F0} kg");
Console.WriteLine($"With reserve: {fuelWithReserve:F0} kg");
Console.WriteLine($"Remaining: {(usableFuel.ToKilograms() - fuelWithReserve):F0} kg");

// Alternate airport requirement
var alternateDistance = 100.0; // nm
var alternateFuel = (alternateDistance / cruiseSpeed.ToKnots()) * fuelFlow;
Console.WriteLine($"\nFuel for alternate ({alternateDistance:F0} nm): {alternateFuel:F0} kg");
```

---

## Marine & Navigation

### Ship Fuel Consumption
**Category:** Maritime

```csharp
using Metricly.Core;

// Calculate ship fuel consumption and voyage planning
var cruiseSpeed = 18.0.Knots();
var fuelConsumption = 150.0; // tonnes per day
var fuelCapacity = 3000.0.MetricTons();
var voyageDistance = 4000.0.NauticalMiles();

var voyageTime = (voyageDistance / cruiseSpeed.ToKnots()).Days();
var fuelNeeded = (voyageTime.ToDays() * fuelConsumption).MetricTons();
var fuelMargin = fuelCapacity - fuelNeeded;

Console.WriteLine("=== Ship Voyage Planning ===");
Console.WriteLine($"Distance: {voyageDistance:F0} nm ({(voyageDistance * 1.852):F0} km)");
Console.WriteLine($"Cruise speed: {cruiseSpeed.ToKnots():F0} knots");
Console.WriteLine($"Fuel consumption: {fuelConsumption:F0} tonnes/day");
Console.WriteLine($"\nVoyage time: {voyageTime.ToDays():F1} days");
Console.WriteLine($"Fuel needed: {fuelNeeded.ToMetricTons():F0} tonnes");
Console.WriteLine($"Fuel capacity: {fuelCapacity.ToMetricTons():F0} tonnes");
Console.WriteLine($"Margin: {fuelMargin.ToMetricTons():F0} tonnes ({(fuelMargin / fuelCapacity * 100):F1}%)");

// Economic speed calculation
var speeds = new[] { 14.0, 16.0, 18.0, 20.0, 22.0 };
Console.WriteLine("\n=== Speed vs Fuel Analysis ===");

foreach (var speed in speeds)
{
    var time = (voyageDistance / speed).Days();
    // Fuel consumption increases with cube of speed (approximately)
    var speedRatio = Math.Pow(speed / 18.0, 3);
    var fuel = (time.ToDays() * fuelConsumption * speedRatio).MetricTons();
    var fuelCostPerTonne = 500.0; // USD
    var cost = fuel.ToMetricTons() * fuelCostPerTonne;
    
    Console.WriteLine($"{speed:F0} knots: {time.ToDays():F1} days, {fuel.ToMetricTons():F0} tonnes, ${cost:F0}");
}
```

### Tide Calculator
**Category:** Navigation

```csharp
using Metricly.Core;

// Calculate tide heights and times
var highTideHeight = 4.2.Meters();
var lowTideHeight = 0.8.Meters();
var tideRange = highTideHeight - lowTideHeight;
var tidePeriod = 12.42.Hours(); // Average lunar day / 2

Console.WriteLine("=== Tide Information ===");
Console.WriteLine($"High tide: {highTideHeight.ToMeters():F1} m ({highTideHeight.ToFeet():F1} ft)");
Console.WriteLine($"Low tide: {lowTideHeight.ToMeters():F1} m ({lowTideHeight.ToFeet():F1} ft)");
Console.WriteLine($"Tidal range: {tideRange.ToMeters():F1} m");
Console.WriteLine($"Period: {tidePeriod.ToHours():F2} hours");

// Calculate water depth at specific times using simplified sine wave
var currentTime = 0.0; // hours since high tide
var intervals = new[] { 0.0, 2.0, 4.0, 6.0, 8.0, 10.0, 12.0 };

Console.WriteLine("\n=== Predicted Heights ===");
Console.WriteLine("Time | Height");
Console.WriteLine("-----|-------");

foreach (var hours in intervals)
{
    var phase = (hours / tidePeriod.ToHours()) * 2 * Math.PI;
    var height = lowTideHeight.ToMeters() + (tideRange.ToMeters() / 2) * (1 + Math.Cos(phase));
    
    Console.WriteLine($"{hours:F1}h  | {height:F2} m");
}

// Chart datum and clearance
var chartDatum = lowTideHeight;
var vesselDraft = 3.0.Meters();
var requiredClearance = 0.5.Meters();
var minimumDepth = vesselDraft + requiredClearance;

Console.WriteLine($"\n=== Vessel Clearance ===");
Console.WriteLine($"Vessel draft: {vesselDraft.ToMeters():F1} m");
Console.WriteLine($"Required clearance: {requiredClearance.ToMeters():F1} m");
Console.WriteLine($"Minimum depth: {minimumDepth.ToMeters():F1} m");

if (minimumDepth.ToMeters() > chartDatum.ToMeters() + tideRange.ToMeters())
{
    Console.WriteLine("⚠️ Insufficient depth even at high tide");
}
else
{
    Console.WriteLine("✓ Safe passage at high tide");
}
```

### Anchor Chain Calculator
**Category:** Maritime

```csharp
using Metricly.Core;
using Metricly.Core.Operations;

// Calculate anchor chain requirements
var waterDepth = 15.0.Meters();
var vesselLength = 40.0.Meters();
var windSpeed = 25.0.Knots();
var currentSpeed = 1.5.Knots();

// Scope ratio (chain length : depth ratio)
var scopeRatio = 5.0; // Typical for good holding
var chainLength = waterDepth * scopeRatio;

Console.WriteLine("=== Anchor Chain Calculator ===");
Console.WriteLine($"Water depth: {waterDepth.ToMeters():F0} m ({waterDepth.ToFeet():F0} ft)");
Console.WriteLine($"Vessel length: {vesselLength.ToMeters():F0} m");
Console.WriteLine($"Recommended scope: {scopeRatio:F0}:1");
Console.WriteLine($"Chain length needed: {chainLength.ToMeters():F0} m ({chainLength.ToFeet():F0} ft)");

// Swinging circle
var swingingRadius = chainLength + (vesselLength / 2);
var swingingArea = (Math.PI * Math.Pow(swingingRadius.ToMeters(), 2)).SquareMeters();

Console.WriteLine($"\n=== Swinging Circle ===");
Console.WriteLine($"Radius: {swingingRadius.ToMeters():F0} m");
Console.WriteLine($"Area: {swingingArea.ToSquareMeters():F0} m²");

// Environmental conditions
Console.WriteLine($"\n=== Conditions ===");
Console.WriteLine($"Wind: {windSpeed.ToKnots():F0} knots ({windSpeed.ToKilometersPerHour():F0} km/h)");
Console.WriteLine($"Current: {currentSpeed.ToKnots():F1} knots");

// Holding force estimation (simplified)
var windForce = 0.00338 * vesselLength.ToMeters() * Math.Pow(windSpeed.ToKnots(), 2);
Console.WriteLine($"\nEstimated wind force: {windForce:F0} N");

// Chain weight (typical 13mm chain = 2.5 kg/m in water)
var chainWeight = 2.5; // kg/m
var totalChainWeight = (chainLength.ToMeters() * chainWeight).Kilograms();
Console.WriteLine($"Chain weight: {totalChainWeight.ToKilograms():F0} kg");
```

### Distance to Horizon
**Category:** Navigation

```csharp
using Metricly.Core;
using Metricly.Core.Constants;

// Calculate distance to horizon from different heights
var earthRadius = PhysicalConstants.EarthRadius;

var heights = new[]
{
    ("Eye level (1.7m)", 1.7.Meters()),
    ("Ship bridge (10m)", 10.0.Meters()),
    ("Lighthouse (50m)", 50.0.Meters()),
    ("Aircraft (3000m)", 3000.0.Meters())
};

Console.WriteLine("=== Distance to Horizon ===");
Console.WriteLine($"Earth radius: {earthRadius.ToKilometers():F0} km\n");

foreach (var (description, height) in heights)
{
    // Distance = sqrt(2 * R * h + h²) ≈ sqrt(2 * R * h) for small h
    var distance = Math.Sqrt(2 * earthRadius.ToMeters() * height.ToMeters());
    var distanceNM = distance / 1852.0;
    
    Console.WriteLine($"{description}:");
    Console.WriteLine($"  Height: {height.ToMeters():F1} m ({height.ToFeet():F0} ft)");
    Console.WriteLine($"  Horizon: {distance:F0} m ({(distance / 1000):F1} km)");
    Console.WriteLine($"  In nautical miles: {distanceNM:F1} nm");
    
    // Time for sunset/sunrise
    var earthRotationSpeed = (2 * Math.PI * earthRadius.ToMeters()) / 86400; // m/s
    var sunsetDuration = distance / earthRotationSpeed;
    Console.WriteLine($"  Sunset duration: {(sunsetDuration / 60):F1} minutes\n");
}

// Visibility between two points
var shipHeight = 10.0.Meters();
var lighthouseHeight = 50.0.Meters();
var visibilityRange = Math.Sqrt(2 * earthRadius.ToMeters() * shipHeight.ToMeters()) +
                       Math.Sqrt(2 * earthRadius.ToMeters() * lighthouseHeight.ToMeters());

Console.WriteLine($"=== Line of Sight ===");
Console.WriteLine($"Ship (10m) to lighthouse (50m):");
Console.WriteLine($"Maximum range: {(visibilityRange / 1000):F1} km ({(visibilityRange / 1852):F1} nm)");
```

---

## Photography & Optics

### Depth of Field Calculator
**Category:** Photography

```csharp
using Metricly.Core;

// Calculate depth of field for photography
var focalLength = 50.0.Millimeters();
var aperture = 2.8;
var focusDistance = 3.0.Meters();
var sensorSize = 36.0.Millimeters(); // Full frame width
var circleOfConfusion = 0.03.Millimeters(); // Full frame standard

// Calculate depth of field
var hyperfocalDistance = (focalLength.ToMillimeters() * focalLength.ToMillimeters()) / 
                         (aperture * circleOfConfusion.ToMillimeters());

var nearLimit = (focusDistance.ToMillimeters() * hyperfocalDistance) / 
                (hyperfocalDistance + (focusDistance.ToMillimeters() - focalLength.ToMillimeters()));

var farLimit = (focusDistance.ToMillimeters() * hyperfocalDistance) / 
               (hyperfocalDistance - (focusDistance.ToMillimeters() - focalLength.ToMillimeters()));

var dofTotal = (farLimit - nearLimit).Millimeters();

Console.WriteLine("=== Depth of Field Calculator ===");
Console.WriteLine($"Focal length: {focalLength.ToMillimeters():F0}mm");
Console.WriteLine($"Aperture: f/{aperture:F1}");
Console.WriteLine($"Focus distance: {focusDistance.ToMeters():F1}m");
Console.WriteLine($"\n=== Results ===");
Console.WriteLine($"Near limit: {(nearLimit / 1000):F2}m");
Console.WriteLine($"Far limit: {(farLimit > 100000 ? "∞" : $"{(farLimit / 1000):F2}m")}");
Console.WriteLine($"Total DoF: {(dofTotal.ToMillimeters() / 1000):F2}m");
Console.WriteLine($"Hyperfocal: {(hyperfocalDistance / 1000):F1}m");

// Field of view
var fov = 2 * Math.Atan(sensorSize / (2 * focalLength.ToMillimeters())) * (180 / Math.PI);
Console.WriteLine($"\n=== Field of View ===");
Console.WriteLine($"Horizontal FoV: {fov:F1}°");

// Calculate subject size in frame
var subjectDistance = focusDistance.ToMeters();
var frameWidth = (sensorSize / focalLength.ToMillimeters()) * subjectDistance;
Console.WriteLine($"Frame width at {subjectDistance:F1}m: {frameWidth:F2}m");
```

### Exposure Triangle Calculator
**Category:** Photography

```csharp
using Metricly.Core;

// Calculate equivalent exposures (reciprocity)
var baseSettings = new
{
    Aperture = 5.6,
    ShutterSpeed = 1.0 / 125, // seconds
    ISO = 200
};

Console.WriteLine("=== Exposure Calculator ===");
Console.WriteLine($"Base: f/{baseSettings.Aperture} | 1/{(1 / baseSettings.ShutterSpeed):F0}s | ISO {baseSettings.ISO}");
Console.WriteLine("\n=== Equivalent Exposures ===\n");

// Each stop change
var stops = new[] { -2, -1, 0, 1, 2 };

Console.WriteLine("Aperture Priority (keep ISO constant):");
foreach (var stop in stops)
{
    var aperture = baseSettings.Aperture * Math.Pow(Math.Sqrt(2), stop);
    var shutterSpeed = baseSettings.ShutterSpeed / Math.Pow(2, stop);
    Console.WriteLine($"  f/{aperture:F1} | 1/{(1 / shutterSpeed):F0}s | ISO {baseSettings.ISO}");
}

Console.WriteLine("\nShutter Priority (keep ISO constant):");
foreach (var stop in stops)
{
    var aperture = baseSettings.Aperture * Math.Pow(Math.Sqrt(2), -stop);
    var shutterSpeed = baseSettings.ShutterSpeed * Math.Pow(2, stop);
    Console.WriteLine($"  f/{aperture:F1} | 1/{(1 / shutterSpeed):F0}s | ISO {baseSettings.ISO}");
}

Console.WriteLine("\nISO Changes (keep aperture):");
foreach (var stop in stops)
{
    var iso = baseSettings.ISO * Math.Pow(2, stop);
    var shutterSpeed = baseSettings.ShutterSpeed / Math.Pow(2, stop);
    Console.WriteLine($"  f/{baseSettings.Aperture:F1} | 1/{(1 / shutterSpeed):F0}s | ISO {iso:F0}");
}

// Flash guide number calculation
var guideNumber = 32.0; // GN at ISO 100
var flashISO = 400;
var flashDistance = 3.0.Meters();

var flashAperture = (guideNumber * Math.Sqrt(flashISO / 100.0)) / flashDistance.ToMeters();
Console.WriteLine($"\n=== Flash Calculation ===");
Console.WriteLine($"Guide Number: {guideNumber} (ISO 100)");
Console.WriteLine($"At {flashDistance.ToMeters():F0}m, ISO {flashISO}:");
Console.WriteLine($"Use aperture: f/{flashAperture:F1}");
```

### Lens Equivalence Calculator
**Category:** Photography

```csharp
using Metricly.Core;

// Calculate equivalent focal lengths between sensor sizes
var sensors = new[]
{
    ("Full Frame", 36.0, 1.0),
    ("APS-C Canon", 22.2, 1.6),
    ("APS-C Nikon", 23.6, 1.5),
    ("Micro Four Thirds", 17.3, 2.0),
    ("1 inch", 13.2, 2.7),
    ("Smartphone", 6.0, 6.0)
};

var referenceFocalLength = 50.0.Millimeters();

Console.WriteLine($"=== Focal Length Equivalents ({referenceFocalLength.ToMillimeters():F0}mm Full Frame) ===\n");

foreach (var (name, sensorWidth, cropFactor) in sensors)
{
    var equivalentFL = referenceFocalLength.ToMillimeters() / cropFactor;
    var fov = 2 * Math.Atan(sensorWidth / (2 * equivalentFL)) * (180 / Math.PI);
    
    Console.WriteLine($"{name}:");
    Console.WriteLine($"  Sensor width: {sensorWidth:F1}mm");
    Console.WriteLine($"  Crop factor: {cropFactor:F1}×");
    Console.WriteLine($"  Actual focal length: {equivalentFL:F1}mm");
    Console.WriteLine($"  Field of view: {fov:F1}°");
    
    // Aperture equivalence for DoF
    var equivalentAperture = 2.8 * cropFactor;
    Console.WriteLine($"  f/2.8 DoF = f/{equivalentAperture:F1} FF\n");
}

// Common focal length classifications
Console.WriteLine("=== Focal Length Types (Full Frame) ===");
var types = new[]
{
    ("Ultra Wide", 14.0, 24.0),
    ("Wide", 24.0, 35.0),
    ("Normal", 40.0, 60.0),
    ("Portrait", 70.0, 135.0),
    ("Telephoto", 135.0, 300.0),
    ("Super Telephoto", 300.0, 600.0)
};

foreach (var (type, min, max) in types)
{
    Console.WriteLine($"{type}: {min:F0}mm - {max:F0}mm");
}
```

---

## Healthcare & Medicine

### BMI and Ideal Weight Calculator
**Category:** Health

```csharp
using Metricly.Core;

// Calculate BMI and ideal weight range
var height = 175.0.Centimeters();
var weight = 75.0.Kilograms();

var heightMeters = height.ToMeters();
var bmi = weight.ToKilograms() / (heightMeters * heightMeters);

Console.WriteLine("=== Body Mass Index Calculator ===");
Console.WriteLine($"Height: {height.ToCentimeters():F0} cm ({height.ToFeet():F1} ft)");
Console.WriteLine($"Weight: {weight.ToKilograms():F1} kg ({weight.ToPounds():F0} lb)");
Console.WriteLine($"\nBMI: {bmi:F1}");

// BMI classification
var classification = bmi switch
{
    < 18.5 => "Underweight",
    < 25.0 => "Normal weight",
    < 30.0 => "Overweight",
    < 35.0 => "Obese (Class I)",
    < 40.0 => "Obese (Class II)",
    _ => "Obese (Class III)"
};

Console.WriteLine($"Classification: {classification}");

// Ideal weight range (BMI 18.5-25)
var minHealthyWeight = 18.5 * heightMeters * heightMeters;
var maxHealthyWeight = 25.0 * heightMeters * heightMeters;

Console.WriteLine($"\n=== Healthy Weight Range ===");
Console.WriteLine($"Minimum: {minHealthyWeight:F1} kg ({(minHealthyWeight * 2.205):F0} lb)");
Console.WriteLine($"Maximum: {maxHealthyWeight:F1} kg ({(maxHealthyWeight * 2.205):F0} lb)");

var weightDifference = weight.ToKilograms() - ((minHealthyWeight + maxHealthyWeight) / 2);
if (Math.Abs(weightDifference) < 1.0)
{
    Console.WriteLine("✓ Within optimal range");
}
else
{
    Console.WriteLine($"Difference from center: {weightDifference:+F1;-F1} kg");
}

// Body Surface Area (Mosteller formula)
var bsa = Math.Sqrt((height.ToCentimeters() * weight.ToKilograms()) / 3600);
Console.WriteLine($"\nBody Surface Area: {bsa:F2} m²");
```

### Medication Dosage Calculator
**Category:** Medicine

```csharp
using Metricly.Core;

// Calculate medication dosages based on weight
var patientWeight = 70.0.Kilograms();
var concentration = 10.0; // mg/ml
var dosagePerKg = 5.0; // mg/kg

var totalDose = patientWeight.ToKilograms() * dosagePerKg;
var volumeNeeded = totalDose / concentration;

Console.WriteLine("=== Medication Dosage Calculator ===");
Console.WriteLine($"Patient weight: {patientWeight.ToKilograms():F1} kg ({patientWeight.ToPounds():F0} lb)");
Console.WriteLine($"Dosage: {dosagePerKg:F1} mg/kg");
Console.WriteLine($"Concentration: {concentration:F1} mg/ml");
Console.WriteLine($"\nTotal dose: {totalDose:F1} mg");
Console.WriteLine($"Volume needed: {volumeNeeded:F1} ml");

// Infusion rate calculation
var infusionDuration = 1.0.Hours();
var infusionRate = volumeNeeded / infusionDuration.ToMinutes();

Console.WriteLine($"\n=== Infusion ===");
Console.WriteLine($"Duration: {infusionDuration.ToMinutes():F0} minutes");
Console.WriteLine($"Rate: {infusionRate:F2} ml/min");

// Drop rate (for IV sets)
var dropFactor = 20.0; // drops per ml
var dropRate = infusionRate * dropFactor;

Console.WriteLine($"Drop rate: {dropRate:F0} drops/min");

// Safety checks
var maxDose = 500.0; // mg
if (totalDose > maxDose)
{
    Console.WriteLine($"\n⚠️ WARNING: Dose exceeds maximum ({maxDose:F0} mg)");
}
else
{
    Console.WriteLine($"\n✓ Dose within safe range (max: {maxDose:F0} mg)");
}
```

### Blood Pressure Classification
**Category:** Health Monitoring

```csharp
using Metricly.Core;

// Classify blood pressure readings
var readings = new[]
{
    (110.0.Torr(), 70.0.Torr(), "Morning"),
    (125.0.Torr(), 82.0.Torr(), "Afternoon"),
    (135.0.Torr(), 88.0.Torr(), "Evening"),
    (145.0.Torr(), 95.0.Torr(), "Night")
};

Console.WriteLine("=== Blood Pressure Monitor ===\n");

foreach (var (systolic, diastolic, time) in readings)
{
    var sys = systolic.ToTorr();
    var dia = diastolic.ToTorr();
    
    var category = (sys, dia) switch
    {
        ( < 120, < 80) => "Normal",
        ( < 130, < 80) => "Elevated",
        ( < 140, < 90) => "Hypertension Stage 1",
        ( < 180, < 120) => "Hypertension Stage 2",
        _ => "Hypertensive Crisis"
    };
    
    var mapPressure = (sys + 2 * dia) / 3; // Mean Arterial Pressure
    
    Console.WriteLine($"{time}: {sys:F0}/{dia:F0} mmHg");
    Console.WriteLine($"  Category: {category}");
    Console.WriteLine($"  MAP: {mapPressure:F0} mmHg");
    Console.WriteLine($"  Pulse pressure: {(sys - dia):F0} mmHg");
    
    if (category == "Hypertensive Crisis")
    {
        Console.WriteLine("  ⚠️ Seek emergency medical attention");
    }
    
    Console.WriteLine();
}

// Blood pressure zones
Console.WriteLine("=== BP Classification (AHA) ===");
Console.WriteLine("Normal: <120/<80 mmHg");
Console.WriteLine("Elevated: 120-129/<80 mmHg");
Console.WriteLine("Hypertension Stage 1: 130-139/80-89 mmHg");
Console.WriteLine("Hypertension Stage 2: ≥140/≥90 mmHg");
Console.WriteLine("Hypertensive Crisis: >180/>120 mmHg");
```

### Hydration Calculator
**Category:** Wellness

```csharp
using Metricly.Core;

// Calculate daily water intake needs
var bodyWeight = 70.0.Kilograms();
var activityLevel = "moderate"; // sedentary, moderate, active, very active
var temperature = 25.0.Celsius();

// Base calculation: 35ml per kg
var baseIntake = bodyWeight.ToKilograms() * 35.0;

// Activity multiplier
var activityMultiplier = activityLevel switch
{
    "sedentary" => 1.0,
    "moderate" => 1.2,
    "active" => 1.4,
    "very active" => 1.6,
    _ => 1.2
};

// Temperature adjustment
var tempAdjustment = temperature.ToCelsius() > 20 ? 1.1 : 1.0;

var totalIntake = (baseIntake * activityMultiplier * tempAdjustment).Milliliters();

Console.WriteLine("=== Daily Hydration Calculator ===");
Console.WriteLine($"Body weight: {bodyWeight.ToKilograms():F1} kg");
Console.WriteLine($"Activity level: {activityLevel}");
Console.WriteLine($"Temperature: {temperature.ToCelsius():F0}°C");
Console.WriteLine($"\nRecommended intake: {totalIntake.ToLiters():F2} L/day");
Console.WriteLine($"Approximately: {(totalIntake.ToMilliliters() / 250):F0} glasses (250ml each)");

// Break down by time
Console.WriteLine($"\n=== Suggested Schedule ===");
var hourlyIntake = totalIntake.ToMilliliters() / 16; // 16 waking hours
Console.WriteLine($"Hourly: {hourlyIntake:F0} ml");

var mealtimes = new[] { "Morning", "Lunch", "Afternoon", "Dinner", "Evening" };
var perMeal = totalIntake.ToMilliliters() / mealtimes.Length;

foreach (var meal in mealtimes)
{
    Console.WriteLine($"{meal}: {perMeal:F0} ml ({(perMeal / 250):F1} glasses)");
}

// Dehydration indicators
Console.WriteLine($"\n=== Dehydration Signs ===");
Console.WriteLine("• Thirst");
Console.WriteLine("• Dark colored urine");
Console.WriteLine("• Dry mouth");
Console.WriteLine("• Fatigue");
Console.WriteLine("• Dizziness");
```

---

These examples cover a wide range of practical applications from daily life to specialized technical fields, demonstrating the versatility and usefulness of the Metricly library.