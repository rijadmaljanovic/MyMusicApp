using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Core.Entities
{
    public class SongRating
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int SongId { get; set; }
        public virtual Song Song { get; set; }

        public int Rating { get; set; }
    }
}
