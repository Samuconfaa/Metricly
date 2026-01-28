using System;

namespace Metricly.Core
{
    /// <summary>
    /// Defines a generic interface for measurement types that support arithmetic operations.
    /// </summary>
    /// <typeparam name="T">The concrete measurement type implementing this interface.</typeparam>
    public interface IMeasure<T> where T : IMeasure<T>
    {
        /// <summary>
        /// Gets the internal value expressed in the base unit of measurement.
        /// </summary>
        double BaseValue { get; }

        /// <summary>
        /// Creates a new instance of the measurement type with the specified base value.
        /// </summary>
        /// <param name="baseValue">The value in the base unit.</param>
        /// <returns>A new measurement instance.</returns>
        T FromBaseValue(double baseValue);

        /// <summary>
        /// Adds two measurements of the same type.
        /// </summary>
        /// <param name="other">The measurement to add.</param>
        /// <returns>A new measurement representing the sum.</returns>
        T Add(T other);

        /// <summary>
        /// Subtracts another measurement from this one.
        /// </summary>
        /// <param name="other">The measurement to subtract.</param>
        /// <returns>A new measurement representing the difference.</returns>
        T Subtract(T other);

        /// <summary>
        /// Multiplies the measurement by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar multiplier.</param>
        /// <returns>A new measurement representing the product.</returns>
        T Multiply(double scalar);

        /// <summary>
        /// Divides the measurement by a scalar value.
        /// </summary>
        /// <param name="scalar">The scalar divisor.</param>
        /// <returns>A new measurement representing the quotient.</returns>
        T Divide(double scalar);

        /// <summary>
        /// Divides this measurement by another measurement of the same type.
        /// </summary>
        /// <param name="other">The measurement to divide by.</param>
        /// <returns>The ratio between the two measurements.</returns>
        double DivideBy(T other);
    }

    
}