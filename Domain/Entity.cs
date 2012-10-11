using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBS.Core.Domain
{
    public class Entity
    {
        public virtual int EntityId { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual int ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
