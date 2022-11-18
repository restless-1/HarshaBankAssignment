// NOTE: We extend Exception instead of ApplicationException as per remarks in MSDN.
//       See https://learn.microsoft.com/en-us/dotnet/api/system.applicationexception?view=net-7.0

namespace HarshaBank.Exceptions
{
    /// <summary>
    /// Indicates an attempt was made to delete an account with a non-zero balance.
    /// </summary>
    public class AccountHasNonZeroBalanceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHasNonZeroBalanceException"/> class.
        /// </summary>
        /// <param name="message">
        /// A human-readable description of the error.
        /// </param>
        /// <param name="innerException">
        /// The <see cref="Exception"/> that caused the <see cref="AccountHasNonZeroBalanceException"/>.
        /// </param>
        public AccountHasNonZeroBalanceException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
