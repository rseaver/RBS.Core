using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBS.Core.Domain
{
    public class Lyrics : Entity
    {
        // ReSharper disable UnassignedField.Local
        private List<Verse> _verses;
        // ReSharper restore UnassignedField.Local

        public virtual IEnumerable<Verse> Verses()
        {
            return _verses;
        }

        public virtual void AddVerse(Verse verse)
        {
            if (_verses.Any(x=>x.EntityId == EntityId))
            {
                return;
            }

            _verses.Add(verse);
        }

        public virtual void RemoveVerse(Verse verse)
        {
            _verses.Remove(verse);
        }
    }
}
