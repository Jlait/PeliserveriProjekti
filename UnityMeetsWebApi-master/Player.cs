using System;
using System.Linq;
using System.Collections.Generic;

namespace assignment2
{
    public class Player
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public int kills {get;set;}
        public int deaths { get; set; }
    }
    
    public class NewPlayer
    {
        public string Name { get; set; }
    }
    public class ModifiedPlayer
    {
        public int kills { get;set; }
        public int deaths { get; set; }
    }
}