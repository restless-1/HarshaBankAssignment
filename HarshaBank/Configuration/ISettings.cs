using HarshaBank.DataAccessLayer;

namespace HarshaBank.Configuration
{
    /// <summary>
    /// This interface acts as a roll-up of all interfaces implemented by <see cref="Settings"/>.
    /// </summary>
    internal interface ISettings : IDataStoreSettings
    {
    }
}
