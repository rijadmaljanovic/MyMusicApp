using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Core.Entities
{
    public class Category
    {
        public int Id{ get; set; }
        public string CategoryName{ get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
