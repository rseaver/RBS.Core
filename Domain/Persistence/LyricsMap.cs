using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace RBS.Core.Domain.Persistence
{
    class LyricsMap : EntityMap<Lyrics>
    {
        public LyricsMap()
        {
            HasMany(x => x.Verses()).Access.CamelCaseField(Prefix.Underscore).LazyLoad();
        }
    }
}
