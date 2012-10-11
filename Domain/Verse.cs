using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBS.Core.Domain
{
    public class Verse : Entity
    {
        public virtual string VerseIdentifier { get; set; }
        // Words to the verse. We're not going as far as individual lines.
        public virtual string Text { get; set; } 
    }
}
