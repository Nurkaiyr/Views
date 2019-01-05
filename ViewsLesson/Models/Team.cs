using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsLesson.Models
{
    public class Team:Entity
    {
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public virtual ICollection<Player> Players { get; set; } = new List<Player>(); 
    }
}