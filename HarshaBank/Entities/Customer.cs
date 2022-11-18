using HarshaBank.Presentation.Attributes;
using System.Text.RegularExpressions;

namespace HarshaBank.Entities
{
    /// <summary>
    /// Represents a single bank customer.
    /// </summary>
    public class Customer : ICloneable
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Auto-generated code number of the customer
        /// </summary>
        [DisplayGroup("List", "Select")]
        public long CustomerCode { get; set; }

        /// <summary>
        /// Name of the customer
        /// </summary>
        [DisplayGroup("Create", "Edit", "List", "Select")]
        [Required]
        [Match("^.{0,40}$", "Value must be no more than 40 characters long")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Address of the customer
        /// </summary>
        [DisplayGroup("Create", "Edit", "List", "Select")]
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Landmark of the customer's address
        /// </summary>
        [DisplayGroup("Create", "Edit", "List", "Select")]
        [Required]
        public string Landmark { get; set; }

        /// <summary>
        /// City of the customer
        /// </summary>
        [DisplayGroup("Create", "Edit", "List", "Select")]
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        [DisplayGroup("Create", "Edit", "List", "Select")]
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// 10-digit Mobile number of the customer
        /// </summary>
        [DisplayGroup("Create", "Edit", "List", "Select")]
        [Required]
        [Match("^[0-9]{10}$", "Mobile number should be a 10-digit number")]
        public string Mobile { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Creates a deep clone of the current <see cref="Customer"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="Customer"/> object.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a deep clone of the current <see cref="Customer"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="Customer"/> object.
        /// </returns>
        public Customer Clone()
        {
            return new Customer()
            {
                CustomerId = CustomerId,
                CustomerCode = CustomerCode,
                CustomerName = CustomerName,
                Address = Address,
                Landmark = Landmark,
                City = City,
                Country = Country,
                Mobile = Mobile,
                IsActive = IsActive
            };
        }
    }
}

