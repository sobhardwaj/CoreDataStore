using System;
using CoreDataStore.Domain.Entities.Base;
using System.Collections.Generic;

namespace CoreDataStore.Domain.Entities
{
    public class LpcReport : IEntityBase, IAuditableEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string LPCId { get; set; }

        public string LPNumber { get; set; }

        public string ObjectType { get; set; }

        public string Architect { get; set; }

        public string Style { get; set; }

        public string Street { get; set; }

        public string Borough { get; set; }

        public DateTime DateDesignated { get; set; }

        public bool PhotoStatus { get; set; }

        public virtual string PhotoURL { get; set; }

        public LPCLocation LPCLocation { get; set; }

        public List<Landmark> Landmarks { get; set; }

    }
}
