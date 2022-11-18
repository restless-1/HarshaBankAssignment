using HarshaBank.Extensions;
using HarshaBank.Presentation.Attributes;
using HarshaBank.Presentation.Views.Formatting;
using HarshaBank.Utility;
using System.Reflection;
using System.Text;

namespace HarshaBank.Presentation.Controls
{
    /// <summary>
    /// Takes input from a user based on the properties in the supplied class.
    /// </summary>
    /// <typeparam name="TResult">
    /// The class whose properties will be input.
    /// NOTE: Property values must be primitives or strings - objects are not supported.
    /// </typeparam>
    internal class FormControl<TResult> where TResult : class, ICloneable, new()
    {
        private readonly string? _displayGroup;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormControl"/> class.
        /// </summary>
        /// <param name="displayGroup">
        /// The display group specifying which properties to input.
        /// The default value depends on whether an argument is supplied to <see cref="InputData"/>.
        /// If an argument is supplied, the default is "Edit"; if not, the default is "Create".
        /// </param>
        public FormControl(string? displayGroup = null)
        {
            _displayGroup = string.IsNullOrEmpty(displayGroup) ? null : displayGroup;
        }

        /// <summary>
        /// Displays the form and inputs user data.
        /// </summary>
        /// <param name="current">
        /// If the form is being used to update data, this should be an instance of
        /// <typeparamref name="TResult"/> containing the current data.
        /// </param>
        /// <returns>
        /// A new instance of <typeparamref name="TResult"/> with data input by the user or
        /// null if the cancelled the input operation.
        /// </returns>
        /// <exception cref="Exception">
        /// A fatal error is encountered while collecting user input.
        /// </exception>
        public TResult? InputData(TResult? current = null)
        {
            Type resultType = typeof(TResult);
            TResult? result = (TResult?)(current == null ? Activator.CreateInstance(resultType) : current.Clone());

            if (result == null)
            {
                // If we get here, our code is broken somewhere
                throw new InvalidOperationException($"Failed to create instance of {resultType}");
            }

            StringBuilder validationErrors = new StringBuilder();

            // Gather input for each property
            string displayGroup = _displayGroup ?? (current == null ? "Create" : "Edit");
            PropertyInfo[] properties = resultType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                if (ShouldExclude(property, displayGroup))
                {
                    // Property lacks a getter or setter, or is not in the controls display group - move to the next property
                    continue;
                }

                object? defaultValue = current == null ? null : property.GetValue(current);
                string label = $"{property.GetLabel()}{(current == null ? "" : (defaultValue is decimal ? $" [{defaultValue:F2}]" : $" [{defaultValue}]"))}";
                object? value;

                IEnumerable<ValidationRuleAttribute> validationAttributes = property.GetCustomAttributes<ValidationRuleAttribute>();

                // Input the property with validation
                bool isInputNeeded;
                do
                {
                    isInputNeeded = false;
                    string? input = Dialog.Prompt(label);
                    if (input == null)
                    {
                        return null;
                    }

                    if (input == "" && defaultValue != null)
                    {
                        value = defaultValue;
                    }
                    else if (!Conversion.TryChangeType(input, property.PropertyType, out value))
                    {
                        Dialog.Error(ResourceManager.GetText("FormControl_Errors_TypeConversion", property.PropertyType.Name));
                        isInputNeeded = true;
                        continue;
                    }

                    // Execute validation rules against the input value
                    validationErrors.Clear();
                    foreach (ValidationRuleAttribute validationRuleAttribute in validationAttributes)
                    {
                        ValidationRuleResult validationResult = validationRuleAttribute.Validate(value);
                        if (!validationResult.IsValid)
                        {
                            isInputNeeded = true;
                            if (validationErrors.Length > 0)
                            {
                                validationErrors.AppendLine();
                            }
                            validationErrors.Append(validationResult.Message);
                            if (validationResult.IsTerminal)
                            {
                                break;
                            }
                        }
                    }
                    if (validationErrors.Length > 0)
                    {
                        Dialog.Error(validationErrors.ToString());
                    }
                } while (isInputNeeded);
                property.SetValue(result, value);
            }

            return result;
        }

        /// <summary>
        /// Returns whether the property should be excluded from the form.
        /// </summary>
        /// <param name="property">
        /// The property to be evaluated.
        /// </param>
        /// <param name="displayGroup">
        /// The display group for the form control.
        /// </param>
        /// <returns>
        /// true if the property should be EXCLUDED; false if the property should be INCLUDED.
        /// </returns>
        private bool ShouldExclude(PropertyInfo property, string displayGroup)
        {
            return !property.CanRead ||
                   !property.CanWrite ||
                   property.GetCustomAttribute<DisplayGroupAttribute>()?.IsInGroup(displayGroup) != true;
        }
    }
}
