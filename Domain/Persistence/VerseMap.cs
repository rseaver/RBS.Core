using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace RBS.Core.Domain.Persistence
{
    public class VerseMap : EntityMap<Verse>
    {
        public VerseMap()
        {
            Map(x => x.VerseIdentifier);
            Map(x => x.Text);
        }
    }
}
