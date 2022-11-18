namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Contract for settings used by <see cref="DataStore"/> instances.
    /// </summary>
    internal interface IDataStoreSettings
    {
        /// <summary>
        /// Gets or sets the path and file name of the file where application data will be stored
        /// or null if application data is to be discarded on application exit.
        /// </summary>
        string? DataFilePath { get; set; }

        /// <summary>
        /// Gets or sets the starting customer code number (only relevant when application data is not
        /// loaded from file).
        /// </summary>
        long BaseCustomerCode { get; set; }

        /// <summary>
        /// Gets or sets the starting account code number (only relevant when application data is not
        /// loaded from file).
        /// </summary>
        long BaseAccountCode { get; set; }
    }
}
