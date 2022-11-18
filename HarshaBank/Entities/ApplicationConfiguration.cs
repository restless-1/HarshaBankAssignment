using HarshaBank.Configuration;
using HarshaBank.Presentation.Attributes;

namespace HarshaBank.Entities
{
    /// <summary>
    /// Application configuration settings.
    /// </summary>
    internal class ApplicationConfiguration : ISettings, ICloneable
    {
        /// <inheritdoc />
        [DisplayGroup("Edit")]
        [Required]
        [GreaterThanOrEqualTo(0)]
        public long BaseCustomerCode { get; set; }

        /// <inheritdoc />
        [DisplayGroup("Edit")]
        [Required]
        [GreaterThanOrEqualTo(0)]
        public long BaseAccountCode { get; set; }

        /// <inheritdoc />
        [DisplayGroup("Edit")]
        [Label("ApplicationConfiguration_Label_DataFilePath")]
        public string? DataFilePath { get; set; }

        /// <summary>
        /// Creates a deep clone of the current <see cref="ApplicationConfiguration"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="ApplicationConfiguration"/> object.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a deep clone of the current <see cref="ApplicationConfiguration"/> object.
        /// </summary>
        /// <returns>
        /// A deep clone of the current <see cref="ApplicationConfiguration"/> object.
        /// </returns>
        public ApplicationConfiguration Clone()
        {
            return new()
            {
                BaseCustomerCode = BaseCustomerCode,
                BaseAccountCode = BaseAccountCode,
                DataFilePath = DataFilePath
            };
        }
    }
}
