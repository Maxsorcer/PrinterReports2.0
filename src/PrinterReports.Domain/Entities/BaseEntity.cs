

namespace PrinterReports.Domain.Entities
{
    /// <summary>
    /// Base entity implementation
    /// </summary>
    public abstract class BaseEntity : IAggregateRoot
    {
        public virtual long Id { get; set; }

        /// <summary>
        /// The instance is not, and has never been associated with any persistence context. It has no persistent identity (primary key value)
        /// </summary>
        /// <returns></returns>
        public virtual bool IsTransient()
        {
            return this.Id == default;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity)
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            BaseEntity item = (BaseEntity)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return (int)(Id%int.MaxValue);
        }
    }
}