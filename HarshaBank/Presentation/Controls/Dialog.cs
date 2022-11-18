using HarshaBank.Presentation.Views.Formatting;
using System.Globalization;

namespace HarshaBank.Presentation.Controls
{
    /// <summary>
    /// Helper functions for interacting with the user.
    /// </summary>
    internal static class Dialog
    {
        /// <summary>
        /// Displays an error to the user with a beep.
        /// </summary>
        /// <param name="message">
        /// The error message to be displayed.
        /// </param>
        public static void Error(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.Beep();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a notification to the user.
        /// </summary>
        /// <param name="message">
        /// The notification message to be displayed.
        /// </param>
        public static void Notify(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
        }

        /// <summary>
        /// Prompts the user for string input.
        /// </summary>
        /// <param name="label">
        /// Prompt label to indicate what the input is for.
        /// </param>
        /// <param name="prohibitCancel">
        /// true to treat "cancel" as legitimate input; false to return null when the user enters "cancel".
        /// </param>
        /// <returns>
        /// The text input by the user or null if the operation was cancelled by the user.
        /// </returns>
        public static string? Prompt(string label, bool prohibitCancel = false)
        {
            Console.Write($"{label}: ");
            string defaultInput = prohibitCancel ? "" : "cancel";
            // ReadLine will only return null if input has been redirected from the console
            string input = Console.ReadLine() ?? defaultInput;
            if (prohibitCancel)
            {
                return input;
            }
            return "cancel".Equals(input, StringComparison.OrdinalIgnoreCase) ? null : input;
        }

        /// <summary>
        /// Prompts the user to enter a date.
        /// </summary>
        /// <param name="label">
        /// Prompt label to indicate what the input is for.
        /// </param>
        /// <param name="defaultValue">
        /// Default value to be returned if the user does not enter a date.
        /// </param>
        /// <returns>
        /// The date input by the user or null if the user cancelled the input operation.
        /// </returns>
        public static DateTime? PromptForDate(string label, DateTime defaultValue)
        {
            while (true)
            {
                string? input = Dialog.Prompt(label);
                if (input == null)
                {
                    return null;
                }
                if (input == "")
                {
                    return defaultValue;
                }
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime parsedDate))
                {
                    return parsedDate;
                }
                Dialog.Error(ResourceManager.GetText("Dialog_Errors_InvalidDate"));
            }
        }

        /// <summary>
        /// Displays a title.
        /// </summary>
        /// <param name="type">
        /// Type of title to display.
        /// </param>
        /// <param name="text">
        /// Title text.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="type"/> is an unsupported value.
        /// </exception>
        public static void Title(TitleType type, string text)
        {
            string title = type switch
            {
                TitleType.Application => $"************** {text} *****************\n",
                TitleType.Login => $":: {text} ::",
                TitleType.Menu => $"\n::: {text} :::",
                TitleType.Mode => $"\n******** {text} ********\n",
                _ => throw new InvalidOperationException($"Unsupported title type: {Enum.GetName(type)}")
            };
            Console.WriteLine(title);
        }
    }
}
