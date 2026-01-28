using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a time value expressed in a base unit (seconds).
    /// </summary>
    /// <remarks>
    /// The internal value is always stored in seconds.
    /// Conversions to other time units are performed using predefined factors.
    /// </remarks>
    /// <remarks>
    /// Initializes a new instance of the <see cref="TimeMeasure"/> class
    /// using a value expressed in seconds.
    /// </remarks>
    /// <param name="baseValue">The time value in seconds.</param>
    public class TimeMeasure(double baseValue)
    {
        /// <summary>
        /// Gets the internal time value expressed in seconds.
        /// </summary>
        public double BaseValue { get; } = baseValue;

        /// <summary>
        /// Converts the internal value to a target unit using the given factor.
        /// </summary>
        /// <param name="factor">How many seconds correspond to one unit of the target measurement.</param>
        /// <returns>The converted time value.</returns>
        public double To(double factor) => BaseValue / factor;
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="TimeMeasure"/> values.
    /// </summary>
    public static class TimeExtensions
    {
        // -------------------------
        // Time constants 
        // -------------------------
        private const double Second = 1.0;
        private const double Nanosecond = 1e-9;
        private const double Microsecond = 1e-6;
        private const double Millisecond = 0.001;

        private const double Minute = 60.0;
        private const double Hour = 3600.0;
        private const double Day = 86400.0;
        private const double Week = 604800.0;

        private const double Month = 2_629_746.0;           
        private const double Year = 31_556_952.0;           
        private const double Decade = 315_569_520.0;        
        private const double Century = 3_155_695_200.0;     

        // -------------------------
        // Factory methods
        // -------------------------

        /// <summary>Creates a time value expressed in seconds.</summary>
        public static TimeMeasure Seconds(this double value) => new(value * Second);

        /// <summary>Creates a time value expressed in nanoseconds.</summary>
        public static TimeMeasure Nanoseconds(this double value) => new(value * Nanosecond);

        /// <summary>Creates a time value expressed in microseconds.</summary>
        public static TimeMeasure Microseconds(this double value) => new(value * Microsecond);

        /// <summary>Creates a time value expressed in milliseconds.</summary>
        public static TimeMeasure Milliseconds(this double value) => new(value * Millisecond);

        /// <summary>Creates a time value expressed in minutes.</summary>
        public static TimeMeasure Minutes(this double value) => new(value * Minute);

        /// <summary>Creates a time value expressed in hours.</summary>
        public static TimeMeasure Hours(this double value) => new(value * Hour);

        /// <summary>Creates a time value expressed in days.</summary>
        public static TimeMeasure Days(this double value) => new(value * Day);

        /// <summary>Creates a time value expressed in weeks.</summary>
        public static TimeMeasure Weeks(this double value) => new(value * Week);

        /// <summary>Creates a time value expressed in months.</summary>
        public static TimeMeasure Months(this double value) => new(value * Month);

        /// <summary>Creates a time value expressed in years.</summary>
        public static TimeMeasure Years(this double value) => new(value * Year);

        /// <summary>Creates a time value expressed in decades.</summary>
        public static TimeMeasure Decades(this double value) => new(value * Decade);

        /// <summary>Creates a time value expressed in centuries.</summary>
        public static TimeMeasure Centuries(this double value) => new(value * Century);

        // -------------------------
        // Conversion methods
        // -------------------------

        /// <summary>Converts the time value to seconds.</summary>
        public static double ToSeconds(this TimeMeasure t) => t.To(Second);

        /// <summary>Converts the time value to nanoseconds.</summary>
        public static double ToNanoseconds(this TimeMeasure t) => t.To(Nanosecond);

        /// <summary>Converts the time value to microseconds.</summary>
        public static double ToMicroseconds(this TimeMeasure t) => t.To(Microsecond);

        /// <summary>Converts the time value to milliseconds.</summary>
        public static double ToMilliseconds(this TimeMeasure t) => t.To(Millisecond);

        /// <summary>Converts the time value to minutes.</summary>
        public static double ToMinutes(this TimeMeasure t) => t.To(Minute);

        /// <summary>Converts the time value to hours.</summary>
        public static double ToHours(this TimeMeasure t) => t.To(Hour);

        /// <summary>Converts the time value to days.</summary>
        public static double ToDays(this TimeMeasure t) => t.To(Day);

        /// <summary>Converts the time value to weeks.</summary>
        public static double ToWeeks(this TimeMeasure t) => t.To(Week);

        /// <summary>Converts the time value to months.</summary>
        public static double ToMonths(this TimeMeasure t) => t.To(Month);

        /// <summary>Converts the time value to years.</summary>
        public static double ToYears(this TimeMeasure t) => t.To(Year);

        /// <summary>Converts the time value to decades.</summary>
        public static double ToDecades(this TimeMeasure t) => t.To(Decade);

        /// <summary>Converts the time value to centuries.</summary>
        public static double ToCenturies(this TimeMeasure t) => t.To(Century);
    }
}
