namespace HarshaBank.Utility
{
    /// <summary>
    /// Helper methods for performing type conversions.
    /// </summary>
    internal static class Conversion
    {
        /// <summary>
        /// Attempts to convert the specified value to the specified type.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type to convert <paramref name="value"/> to.
        /// </typeparam>
        /// <param name="value">
        /// The value to be converted.
        /// </param>
        /// <param name="convertedValue">
        /// If the result of this function is true, <paramref name="convertedValue"/> will
        /// contain the converted value.  If the result of this function is false,
        /// <paramref name="convertedValue"/> will contain the default value of
        /// <typeparamref name="TResult"/>.
        /// </param>
        /// <returns>
        /// true if the conversion was successful; false otherwise.
        /// </returns>
        public static bool TryChangeType<TResult>(object? value, out TResult? convertedValue)
        {
            object? convertedObject;
            bool succeeded = TryChangeType(value, typeof(TResult), out convertedObject);
            convertedValue = (TResult?)convertedObject;
            return succeeded;
        }

        /// <summary>
        /// Attempts to convert the specified value to the specified type.
        /// </summary>
        /// <param name="value">
        /// The value to be converted.
        /// </param>
        /// <param name="type">
        /// The type to convert <paramref name="value"/> to.
        /// </param>
        /// <param name="convertedValue">
        /// If the result of this function is true, <paramref name="convertedValue"/> will
        /// contain the converted value.  If the result of this function is false,
        /// <paramref name="convertedValue"/> will contain the default value of
        /// <paramref name="type"/>.
        /// </param>
        /// <returns>
        /// true if the conversion was successful; false otherwise.
        /// </returns>
        public static bool TryChangeType(object? value, Type type, out object? convertedValue)
        {
            if (value == null)
            {
                convertedValue = default;
                return type.IsByRef;
            }

            try
            {
                convertedValue = Convert.ChangeType(value, type);
                return true;
            }
            catch
            {
                convertedValue = default;
                return false;
            }
        }
    }
}
