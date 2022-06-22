using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Core.Models
{
    public class SongRequestModel
    {
        public int Page { get; set; }
        public SearchModel Search { get; set; }
    }
}
