using HarshaBank.Presentation.Attributes;

namespace HarshaBank.Entities
{
    /// <summary>
    /// Formatting class to allow accounts to be listed in a form.
    /// </summary>
    public class AccountListItem
    {
        /// <summary>
        /// Gets or sets a string representation of the customer who owns the account.
        /// </summary>
        [DisplayGroup("List", "Select")]
        public string Customer { get; set; } = "";

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        [DisplayGroup("List", "Select")]
        public long Code { get; set; }

        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        [DisplayGroup("List", "Select")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the account balance.
        /// </summary>
        [DisplayGroup("List", "Select")]
        public decimal Balance { get; set; }
    }
}
