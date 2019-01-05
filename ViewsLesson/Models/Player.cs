using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsLesson.Models
{
    public class Player:Entity
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public virtual Team Team { get; set; } // навигационное свойство
    }
}