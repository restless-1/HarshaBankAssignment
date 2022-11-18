using HarshaBank.Presentation.Attributes;
using HarshaBank.Presentation.Views.Formatting;
using System.Reflection;
using System.Text;

namespace HarshaBank.Extensions
{
    // Not a fan of extension methods, but since we use this in serveral places I
    // couldn't think of a more appropriate place to put it. :-/

    /// <summary>
    /// Extension methods for working with <see cref="PropertyInfo"/> instances.
    /// </summary>
    internal static class PropertyInfoExtensions
    {
        /// <summary>
        /// Gets or infers the label to be displayed for the property.
        /// 
        /// If the property is decorated with a <see cref="LabelAttribute"/>,
        /// it will be honored.  Otherwise the label will be inferred from the
        /// property name.
        /// </summary>
        /// <param name="propertyInfo">
        /// The <see cref="PropertyInfo"/> instance being extended.
        /// </param>
        /// <returns>
        /// The UI label for the property.
        /// </returns>
        public static string GetLabel(this PropertyInfo propertyInfo)
        {
            // If we have a Label attribute, use it
            var labelAttribute = propertyInfo.GetCustomAttribute<LabelAttribute>();
            if (labelAttribute != null)
            {
                return ResourceManager.GetText(labelAttribute.Label);
            }

            // Infer the label from the property name
            string propertyName = propertyInfo.Name;
            int numberOfCharacters = propertyName.Length;
            // Allocate enough space to complete the operation without reallocating
            StringBuilder labelBuilder = new StringBuilder(numberOfCharacters * 2);
            for (int characterIndex = 0; characterIndex < numberOfCharacters; characterIndex++)
            {
                char character = propertyName[characterIndex];
                if (characterIndex > 0 && Char.IsUpper(character))
                {
                    labelBuilder.Append(' ');
                }
                labelBuilder.Append(character);
            }
            return labelBuilder.ToString();
        }
    }
}
