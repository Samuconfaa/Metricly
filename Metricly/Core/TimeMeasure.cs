using System;

namespace Metricly.Core
{
    /// <summary>
    /// Represents a time value expressed in a base unit (seconds).
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="TimeMeasure"/> class
    /// using a value expressed in seconds.
    /// </remarks>
    /// <param name="baseValue">The time value in seconds.</param>
    public class TimeMeasure(double baseValue) : IMeasure<TimeMeasure>
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

        /// <summary>
        /// Creates a new time measurement from a base value.
        /// </summary>
        /// <param name="baseValue">The value in seconds.</param>
        /// <returns>A new <see cref="TimeMeasure"/> instance.</returns>
        public TimeMeasure FromBaseValue(double baseValue) => new(baseValue);

        /// <summary>
        /// Adds two time measurements.
        /// </summary>
        /// <param name="other">The time to add.</param>
        /// <returns>A new <see cref="TimeMeasure"/> representing the sum.</returns>
        public TimeMeasure Add(TimeMeasure other) => new(BaseValue + other.BaseValue);

        /// <summary>
        /// Subtracts another time measurement from this one.
        /// </summary>
        /// <param name="other">The time to subtract.</param>
        /// <returns>A new <see cref="TimeMeasure"/> representing the difference.</returns>
        public TimeMeasure Subtract(TimeMeasure other) => new(BaseValue - other.BaseValue);

        /// <summary>
        /// Multiplies the time by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new <see cref="TimeMeasure"/> representing the product.</returns>
        public TimeMeasure Multiply(double scalar) => new(BaseValue * scalar);

        /// <summary>
        /// Divides the time by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new <see cref="TimeMeasure"/> representing the quotient.</returns>
        public TimeMeasure Divide(double scalar) => new(BaseValue / scalar);

        /// <summary>
        /// Divides this time by another time to get a ratio.
        /// </summary>
        /// <param name="other">The time to divide by.</param>
        /// <returns>The ratio between the two times.</returns>
        public double DivideBy(TimeMeasure other) => BaseValue / other.BaseValue;

        /// <summary>
        /// Adds two time measurements.
        /// </summary>
        /// <param name="left">The first time.</param>
        /// <param name="right">The second time.</param>
        /// <returns>The sum of the two times.</returns>
        public static TimeMeasure operator +(TimeMeasure left, TimeMeasure right)
            => left.Add(right);

        /// <summary>
        /// Subtracts one time measurement from another.
        /// </summary>
        /// <param name="left">The time to subtract from.</param>
        /// <param name="right">The time to subtract.</param>
        /// <returns>The difference between the two times.</returns>
        public static TimeMeasure operator -(TimeMeasure left, TimeMeasure right)
            => left.Subtract(right);

        /// <summary>
        /// Multiplies a time measurement by a scalar.
        /// </summary>
        /// <param name="left">The time.</param>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>The product of the time and scalar.</returns>
        public static TimeMeasure operator *(TimeMeasure left, double scalar)
            => left.Multiply(scalar);

        /// <summary>
        /// Multiplies a time measurement by a scalar.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <param name="right">The time.</param>
        /// <returns>The product of the scalar and time.</returns>
        public static TimeMeasure operator *(double scalar, TimeMeasure right)
            => right.Multiply(scalar);

        /// <summary>
        /// Divides a time measurement by a scalar.
        /// </summary>
        /// <param name="left">The time.</param>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>The quotient of the time and scalar.</returns>
        public static TimeMeasure operator /(TimeMeasure left, double scalar)
            => left.Divide(scalar);

        /// <summary>
        /// Divides one time measurement by another.
        /// </summary>
        /// <param name="left">The dividend time.</param>
        /// <param name="right">The divisor time.</param>
        /// <returns>The ratio between the two times.</returns>
        public static double operator /(TimeMeasure left, TimeMeasure right)
            => left.DivideBy(right);

        /// <summary>
        /// Determines whether two time measurements are equal.
        /// </summary>
        /// <param name="left">The first time.</param>
        /// <param name="right">The second time.</param>
        /// <returns><c>true</c> if the times are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(TimeMeasure left, TimeMeasure right)
            => Math.Abs(left.BaseValue - right.BaseValue) < 1e-10;

        /// <summary>
        /// Determines whether two time measurements are not equal.
        /// </summary>
        /// <param name="left">The first time.</param>
        /// <param name="right">The second time.</param>
        /// <returns><c>true</c> if the times are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(TimeMeasure left, TimeMeasure right)
            => !(left == right);

        /// <summary>
        /// Determines whether one time measurement is greater than another.
        /// </summary>
        /// <param name="left">The first time.</param>
        /// <param name="right">The second time.</param>
        /// <returns><c>true</c> if the first time is greater; otherwise, <c>false</c>.</returns>
        public static bool operator >(TimeMeasure left, TimeMeasure right)
            => left.BaseValue > right.BaseValue;

        /// <summary>
        /// Determines whether one time measurement is less than another.
        /// </summary>
        /// <param name="left">The first time.</param>
        /// <param name="right">The second time.</param>
        /// <returns><c>true</c> if the first time is less; otherwise, <c>false</c>.</returns>
        public static bool operator <(TimeMeasure left, TimeMeasure right)
            => left.BaseValue < right.BaseValue;

        /// <summary>
        /// Determines whether one time measurement is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first time.</param>
        /// <param name="right">The second time.</param>
        /// <returns><c>true</c> if the first time is greater than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator >=(TimeMeasure left, TimeMeasure right)
            => left.BaseValue >= right.BaseValue;

        /// <summary>
        /// Determines whether one time measurement is less than or equal to another.
        /// </summary>
        /// <param name="left">The first time.</param>
        /// <param name="right">The second time.</param>
        /// <returns><c>true</c> if the first time is less than or equal; otherwise, <c>false</c>.</returns>
        public static bool operator <=(TimeMeasure left, TimeMeasure right)
            => left.BaseValue <= right.BaseValue;

        /// <summary>
        /// Determines whether the specified object is equal to the current time measurement.
        /// </summary>
        /// <param name="obj">The object to compare with the current time measurement.</param>
        /// <returns><c>true</c> if the specified object is equal to the current time measurement; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not LengthMeasure other)
                return false;

            return BaseValue.Equals(other.BaseValue);
        }

        /// <summary>
        /// Returns the hash code for this time measurement.
        /// </summary>
        /// <returns>A hash code for the current time measurement.</returns>
        public override int GetHashCode() => BaseValue.GetHashCode();

        /// <summary>
        /// Returns a string representation of the time measurement.
        /// </summary>
        /// <returns>A string representing the time in seconds.</returns>
        public override string ToString() => $"{BaseValue} s";
    }

    /// <summary>
    /// Provides extension methods for creating and converting <see cref="TimeMeasure"/> values.
    /// </summary>
    public static class TimeExtensions
    {
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

        /// <summary>Creates a time value expressed in seconds.</summary>
        /// <param name="value">The value in seconds.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Seconds(this double value) => new(value * Second);

        /// <summary>Creates a time value expressed in nanoseconds.</summary>
        /// <param name="value">The value in nanoseconds.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Nanoseconds(this double value) => new(value * Nanosecond);

        /// <summary>Creates a time value expressed in microseconds.</summary>
        /// <param name="value">The value in microseconds.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Microseconds(this double value) => new(value * Microsecond);

        /// <summary>Creates a time value expressed in milliseconds.</summary>
        /// <param name="value">The value in milliseconds.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Milliseconds(this double value) => new(value * Millisecond);

        /// <summary>Creates a time value expressed in minutes.</summary>
        /// <param name="value">The value in minutes.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Minutes(this double value) => new(value * Minute);

        /// <summary>Creates a time value expressed in hours.</summary>
        /// <param name="value">The value in hours.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Hours(this double value) => new(value * Hour);

        /// <summary>Creates a time value expressed in days.</summary>
        /// <param name="value">The value in days.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Days(this double value) => new(value * Day);

        /// <summary>Creates a time value expressed in weeks.</summary>
        /// <param name="value">The value in weeks.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Weeks(this double value) => new(value * Week);

        /// <summary>Creates a time value expressed in months.</summary>
        /// <param name="value">The value in months.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Months(this double value) => new(value * Month);

        /// <summary>Creates a time value expressed in years.</summary>
        /// <param name="value">The value in years.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Years(this double value) => new(value * Year);

        /// <summary>Creates a time value expressed in decades.</summary>
        /// <param name="value">The value in decades.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Decades(this double value) => new(value * Decade);

        /// <summary>Creates a time value expressed in centuries.</summary>
        /// <param name="value">The value in centuries.</param>
        /// <returns>A <see cref="TimeMeasure"/> representing the time.</returns>
        public static TimeMeasure Centuries(this double value) => new(value * Century);

        /// <summary>Converts the time value to seconds.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in seconds.</returns>
        public static double ToSeconds(this TimeMeasure t) => t.To(Second);

        /// <summary>Converts the time value to nanoseconds.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in nanoseconds.</returns>
        public static double ToNanoseconds(this TimeMeasure t) => t.To(Nanosecond);

        /// <summary>Converts the time value to microseconds.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in microseconds.</returns>
        public static double ToMicroseconds(this TimeMeasure t) => t.To(Microsecond);

        /// <summary>Converts the time value to milliseconds.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in milliseconds.</returns>
        public static double ToMilliseconds(this TimeMeasure t) => t.To(Millisecond);

        /// <summary>Converts the time value to minutes.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in minutes.</returns>
        public static double ToMinutes(this TimeMeasure t) => t.To(Minute);

        /// <summary>Converts the time value to hours.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in hours.</returns>
        public static double ToHours(this TimeMeasure t) => t.To(Hour);

        /// <summary>Converts the time value to days.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in days.</returns>
        public static double ToDays(this TimeMeasure t) => t.To(Day);

        /// <summary>Converts the time value to weeks.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in weeks.</returns>
        public static double ToWeeks(this TimeMeasure t) => t.To(Week);

        /// <summary>Converts the time value to months.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in months.</returns>
        public static double ToMonths(this TimeMeasure t) => t.To(Month);

        /// <summary>Converts the time value to years.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in years.</returns>
        public static double ToYears(this TimeMeasure t) => t.To(Year);

        /// <summary>Converts the time value to decades.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in decades.</returns>
        public static double ToDecades(this TimeMeasure t) => t.To(Decade);

        /// <summary>Converts the time value to centuries.</summary>
        /// <param name="t">The time measurement.</param>
        /// <returns>The time in centuries.</returns>
        public static double ToCenturies(this TimeMeasure t) => t.To(Century);
    }
}
