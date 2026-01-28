using System.Runtime.CompilerServices;

namespace Metricly.Core
{
    public class MassMeasure(double baseValue)
    {
        public double BaseValue { get; } = baseValue;

        public double To(double factor) => BaseValue / factor;
    }

    public static class MassExtension
    {
        private const double Gram = 1.0;
        private const double MetricTon = 1_000_000.0;
        private const double Kilogram = 1_000.0;
        private const double Milligram = 0.001;
        private const double Microgram = 0.000001;

        private const double Ounce = 28.349523125;
        private const double Pound = 453.59237;
        private const double _Stone = 6350.29318;

        private const double ShortTon = 907_184.74;
        private const double LongTon = 1_016_046.9088;


        public static MassMeasure Grams(this double value) => new(value * Gram);
        public static MassMeasure MetricTons(this double value) => new(value * MetricTon);
        public static MassMeasure Kilograms(this double value) => new(value * Kilogram);
        public static MassMeasure Milligrams(this double value) => new(value * Milligram);
        public static MassMeasure Micrograms(this double value) => new(value * Microgram);
        //------------------------------------------------------------------------------------
        public static MassMeasure Ounces(this double value) => new(value * Ounce);
        public static MassMeasure Pounds(this double value) => new(value * Pound);
        public static MassMeasure Stone(this double value) => new(value * _Stone);
        //------------------------------------------------------------------------------------
        public static MassMeasure ShortTons(this double value) => new(value * ShortTon);
        public static MassMeasure LongTons(this double value) => new(value * LongTon);

        //------------------------------------------------------------------------------------
        // TO
        //------------------------------------------------------------------------------------
        public static double ToGrams(this MassMeasure m) => m.To(Gram);
        public static double ToMetricTons(this MassMeasure m) => m.To(MetricTon);
        public static double ToKilograms(this MassMeasure m) => m.To(Kilogram);
        public static double ToMilligrams(this MassMeasure m) => m.To(Milligram);
        public static double ToMicrograms(this MassMeasure m) => m.To(Microgram);
        //------------------------------------------------------------------------------------
        public static double ToOunces(this MassMeasure m) => m.To(Ounce);
        public static double ToPounds(this MassMeasure m) => m.To(Pound);
        public static double ToStone(this MassMeasure m) => m.To(_Stone);
        //------------------------------------------------------------------------------------
        public static double ToShortTons(this MassMeasure m) => m.To(ShortTon);
        public static double ToLongTons(this MassMeasure m) => m.To(LongTon);


    }
}
