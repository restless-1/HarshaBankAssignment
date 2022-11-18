using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Properties;

namespace HarshaBank.Configuration
{
    /// <summary>
    /// Project level configuration settings.
    /// </summary>
    public class Settings : ISettings
    {
        /// <inheritdoc />
        public string? DataFilePath
        {
            get
            {
                return UserSettings.Default.DataFilePath;
            }

            set
            {
                UserSettings.Default.DataFilePath = value;
                UserSettings.Default.Save();
            }
        }

        /// <inheritdoc />
        public long BaseCustomerCode {
            get
            {
                return UserSettings.Default.BaseCustomerCode;
            }

            set
            {
                UserSettings.Default.BaseCustomerCode = value;
                UserSettings.Default.Save();
            }
        }

        /// <inheritdoc />
        public long BaseAccountCode
        {
            get
            {
                return UserSettings.Default.BaseAccountCode;
            }

            set
            {
                UserSettings.Default.BaseAccountCode = value;
                UserSettings.Default.Save();
            }
        }
    }
}
