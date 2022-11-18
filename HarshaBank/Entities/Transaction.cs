namespace HarshaBank.Entities
{
    // NOTE: Some of the data in this class is duplicated to simplify lookups.  It is likely
    //       that a real system would also have this so the source and destination could be
    //       identified even if the corresponding customer and/or account had been hard deleted.

    /// <summary>
    /// Represents a transfer of funds from one account to another.
    /// </summary>
    public class Transaction : ICloneable
    {
        /// <summary>
        /// Gets or sets the date and time when the funds transfer occurred.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the amount of funds transferred.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the user-entered description of the funds transfer.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Gets or sets the source funds were transferred from.
        /// </summary>
        public TransactionActor Source { get; set; } = new();

        /// <summary>
        /// Gets or sets the destination funds were transferred to.
        /// </summary>
        public TransactionActor Destination { get; set; } = new();

        /// <summary>
        /// Creates a deep clone of the current <see cref="Transaction"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="Transaction"/> object.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a deep clone of the current <see cref="Transaction"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="Transaction"/> object.
        /// </returns>
        public Transaction Clone()
        {
            return new Transaction()
            {
                Timestamp = Timestamp,
                Amount = Amount,
                Description = Description,
                Source = Source.Clone(),
                Destination = Destination.Clone(),
            };
        }
    }

    /// <summary>
    /// Represents the source or destination of a funds transfer.
    /// </summary>
    public class TransactionActor : ICloneable
    {
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public TransactionActorEntity Customer { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public TransactionActorEntity Account { get; set; }

        /// <summary>
        /// Gets or sets the account balance before the funds transfer.
        /// </summary>
        public decimal OldBalance { get; set; }

        /// <summary>
        /// Gets or sets the account balance after the funds transfer.
        /// </summary>
        public decimal NewBalance { get; set; }

        /// <summary>
        /// Creates a deep clone of the current <see cref="TransactionActor"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="TransactionActor"/> object.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a deep clone of the current <see cref="TransactionActor"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="TransactionActor"/> object.
        /// </returns>
        public TransactionActor Clone()
        {
            return new TransactionActor()
            {
                Customer = Customer.Clone(),
                Account = Account.Clone(),
                OldBalance = OldBalance,
                NewBalance = NewBalance
            };
        }
    }

    /// <summary>
    /// Represents an individual entity in the source or destination of a funds transfer.
    /// </summary>
    public class TransactionActorEntity : ICloneable
    {
        /// <summary>
        /// Gets or sets the identifying code of the entity.
        /// </summary>
        public long Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates a deep clone of the current <see cref="TransactionActorEntity"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="TransactionActorEntity"/> object.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a deep clone of the current <see cref="TransactionActorEntity"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="TransactionActorEntity"/> object.
        /// </returns>
        public TransactionActorEntity Clone()
        {
            return new TransactionActorEntity()
            {
                Code = Code,
                Name = Name
            };
        }
    }
}
