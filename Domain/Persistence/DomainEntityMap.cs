using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;


namespace RBS.Core.Domain.Persistence
{
   
    public class EntityMap<ENTITY> : ClassMap<ENTITY> where ENTITY : Entity
    {
        public EntityMap()
        {
            Id(x => x.EntityId);
            Map(x => x.CreatedBy);
            Map(x => x.CreateDate);
            Map(x => x.ModifiedBy);
            Map(x => x.ModifiedDate);

        }
    }
}
