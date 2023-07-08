namespace PrinterReports.Domain
{
    /// <summary>
    /// Base entity interface for inheritance
    /// </summary>
    public interface IAggregateRoot
    {
        /// <summary>
        /// Binding Entity ID
        /// </summary>
        long Id { get; }
    }
}