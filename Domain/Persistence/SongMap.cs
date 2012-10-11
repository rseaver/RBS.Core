using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace RBS.Core.Domain.Persistence
{
    public class SongMap : EntityMap<Song>
    {
        public SongMap()
        {
            Map(x => x.Title);
            HasMany(x => x.LyricList()).Access.CamelCaseField(Prefix.Underscore).LazyLoad();
        }
    }
}
