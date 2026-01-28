using System;
using System.Collections.Generic;
using System.Text;

namespace Metricly.Core
{
    public class TempMeasure
    {
        public double KelvinValue { get; }

        public TempMeasure(double kelvinValue)
        {
            KelvinValue = kelvinValue;
        }

        public double To(double ratio, double offset) => (KelvinValue - offset) / ratio;
        public double To() => KelvinValue;
    }

    public static class TemperatureExtensions
    {
        private const double KelvinOffset = 0.0;
        private const double CelsiusOffset = 273.15;
        private const double FahrenheitOffset = 459.67;
        private const double FahrenheitRatio = 5.0 / 9.0;


        //chiamo il metodo con il valore in kelvin
        public static TempMeasure Celsius(this double value)
            => new(value + CelsiusOffset);

        public static TempMeasure Fahrenheit(this double value)
            => new((value + FahrenheitOffset) * FahrenheitRatio);

        public static TempMeasure Kelvin(this double value)
            => new(value);

        //grazie al valore in kelvin faccio poi la conversione
        public static double ToCelsius(this TempMeasure m)
            => m.KelvinValue - CelsiusOffset;

        public static double ToFahrenheit(this TempMeasure m)
            => (m.KelvinValue / FahrenheitRatio) - FahrenheitOffset;

        public static double ToKelvin(this TempMeasure m) => m.KelvinValue;
    }
}
