namespace Metricly.Core
{
    public class LenghtMeasure
    {
        public double BaseValue { get; }

        public LenghtMeasure(double baseValue)
        {
            BaseValue = baseValue;
        }
        public double To(double factor) => BaseValue / factor;
    }

    public static class LenghtExtension
    {
        private const double Meter = 1.0;
        private const double Kilometer = 1000.0;
        private const double Centimeter = 0.01;
        private const double Millimeter = 0.001;
        private const double Micrometer = 0.000001;
        private const double Inch = 0.0254;
        private const double Mile = 1609.344;
        private const double Yard = 0.9144;
        private const double Foot = 0.3048;
        private const double NauticalMile = 1852;

        public static LenghtMeasure Meters(this double value) => new(value * Meter);
        public static LenghtMeasure Kilometers(this double value) => new(value * Kilometer);
        public static LenghtMeasure Centimetres(this double value) => new(value * Centimeter);
        public static LenghtMeasure Millimetres(this double value) => new(value * Millimeter);
        public static LenghtMeasure Micrometres(this double value) => new(value * Micrometer);
        public static LenghtMeasure Inches(this double value) => new(value * Inch);
        public static LenghtMeasure Miles(this double value) => new(value * Mile);
        public static LenghtMeasure Yards(this double value) => new(value * Yard);
        public static LenghtMeasure Feet(this double value) => new(value * Foot);
        public static LenghtMeasure NauticalMiles(this double value) => new(value * NauticalMile);


        public static double ToMeters(this LenghtMeasure m) => m.To(Meter);
        public static double ToKilometers(this LenghtMeasure m) => m.To(Kilometer);
        public static double ToCentimetres(this LenghtMeasure m) => m.To(Centimeter);
        public static double ToMillimetres(this LenghtMeasure m) => m.To(Millimeter);
        public static double ToMicrometres(this LenghtMeasure m) => m.To(Micrometer);
        public static double ToInches(this LenghtMeasure m) => m.To(Inch);
        public static double ToMiles(this LenghtMeasure m) => m.To(Mile);
        public static double ToYards(this LenghtMeasure m) => m.To(Yard);
        public static double ToFeet(this LenghtMeasure m) => m.To(Foot);
        public static double ToNauticalMiles(this LenghtMeasure m) => m.To(NauticalMile);


    }
}
