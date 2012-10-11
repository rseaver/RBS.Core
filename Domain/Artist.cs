using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBS.Core.Domain
{
    public class Artist : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual DateTime DateDeceased { get; set; }
        public virtual string Biography { get; set; }

        // ReSharper disable UnassignedField.Local
        private List<Song> _songs = new List<Song>();
        // ReSharper restore UnassignedField.Local

        public virtual IEnumerable<Song> Songs()
        {
            return _songs;
        }

        public virtual void AddSong(Song song)
        {
            if (_songs.Any(x => x.EntityId == song.EntityId))
            {
                return;            
            }
            _songs.Add(song);
        }

        public virtual void RemoveSong(Song song)
        {
            _songs.Remove(song);
        }
    }
}
