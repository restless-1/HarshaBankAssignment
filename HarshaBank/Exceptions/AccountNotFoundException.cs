// NOTE: We extend Exception instead of ApplicationException as per remarks in MSDN.
//       See https://learn.microsoft.com/en-us/dotnet/api/system.applicationexception?view=net-7.0

namespace HarshaBank.Exceptions
{
    /// <summary>
    /// Indicates the requested account was not found.
    /// </summary>
    public class AccountNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// A human-readable description of the error.
        /// </param>
        /// <param name="innerException">
        /// The <see cref="Exception"/> that caused the <see cref="AccountNotFoundException"/>.
        /// </param>
        public AccountNotFoundException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
