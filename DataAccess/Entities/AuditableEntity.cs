using System;

namespace DataAccess
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public abstract string CreatedBy { get; set; }
        public abstract DateTime CreatedDate { get; set; }
        public abstract string UpdatedBy { get; set; }
        public abstract DateTime UpdatedDate { get; set; }
    }
}