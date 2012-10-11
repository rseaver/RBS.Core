using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBS.Core.Domain
{
    public class Song : Entity
    {
        public virtual string Title { get; set; }

        // ReSharper disable UnassignedField.Local
        private List<Lyrics> _lyrics;
        // ReSharper restore UnassignedField.Local

        public virtual IEnumerable<Lyrics> LyricList()
        {
            return _lyrics;
        }

        public virtual void AddLyrics(Lyrics lyrics)
        {
            if(_lyrics.Any(x=>x.EntityId == lyrics.EntityId))
            {
                return;
            }
            _lyrics.Add(lyrics);

        }

        public virtual void RemoveLyrics(Lyrics lyrics)
        {
            _lyrics.Remove(lyrics);
        }
    }
}
