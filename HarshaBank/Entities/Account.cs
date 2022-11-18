using HarshaBank.Presentation.Attributes;

namespace HarshaBank.Entities
{
    /// <summary>
    /// Represents a single bank account.
    /// </summary>
    public class Account : ICloneable
    {
        /// <summary>
        /// Gets or sets the ID of the customer that owns the account.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the Account.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the account code - a more human-friendly identifier for the account.
        /// </summary>
        [DisplayGroup("Select", "List")]
        public long AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        [DisplayGroup("Create", "Edit", "Select", "List")]
        [Required]
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the current account balance.
        /// </summary>
        [DisplayGroup("Create", "Edit", "Select", "List")]
        [Required]
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets whether the account is active (has not been deleted).
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Creates a deep clone of the current <see cref="Account"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="Account"/> object.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a deep clone of the current <see cref="Account"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="Account"/> object.
        /// </returns>
        public Account Clone()
        {
            return new Account()
            {
                CustomerId = CustomerId,
                AccountId= AccountId,
                AccountCode = AccountCode,
                AccountName = AccountName,
                Balance = Balance,
                IsActive = IsActive
            };
        }
    }
}
