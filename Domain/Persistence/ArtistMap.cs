

using FluentNHibernate.Mapping;

namespace RBS.Core.Domain.Persistence
{
    public class ArtistMap : EntityMap<Artist>
    {
        public ArtistMap()
        {
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.DateOfBirth);
            Map(x => x.DateDeceased);
            Map(x => x.Biography);
//            HasMany(x=>x.Songs()).Access.CamelCaseField(Prefix.Underscore).LazyLoad();
        }
    }
}
