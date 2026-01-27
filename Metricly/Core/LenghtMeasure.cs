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
        private const double Inch = 0.0254;

        public static LenghtMeasure Meters(this double value) => new LenghtMeasure(value * Meter);
        public static LenghtMeasure Kilometers(this double value) => new LenghtMeasure(value * Kilometer);
        public static LenghtMeasure Inches(this double value) => new LenghtMeasure(value * Inch);
        public static LenghtMeasure Centimetres(this double value) => new LenghtMeasure(value * Centimeter);


        public static double ToMeters(this LenghtMeasure m) => m.To(Meter);
        public static double ToKilometers(this LenghtMeasure m) => m.To(Kilometer);
        public static double ToInches(this LenghtMeasure m) => m.To(Inch);
        public static double ToCentimetres(this LenghtMeasure m) => m.To(Centimeter);

    }
}
