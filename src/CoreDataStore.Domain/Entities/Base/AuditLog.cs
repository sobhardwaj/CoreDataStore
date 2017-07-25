using System;

namespace CoreDataStore.Domain.Entities.Base
{
    public class AuditLog : IEntityBase
    {
        public long Id { get; set; }

        public bool IsDeleted { get; set; }

        public virtual string UserName { get; set; }

        public virtual string ImportType { get; set; }

        public virtual DateTime EventDateUtc { get; set; }

        public virtual string EventType { get; set; }

        public virtual string TableName { get; set; }

        public virtual int RecordId { get; set; }

        public virtual string ColumnName { get; set; }

        public virtual string OriginalValue { get; set; }

        public virtual string NewValue { get; set; }


    }
}
