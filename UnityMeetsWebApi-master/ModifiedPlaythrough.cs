using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace assignment2
{
    public class ModifiedPlaythrough
    {
        public List<Player> Players{ get; set; }
        public ModifiedPlaythrough(){
            Players = new List<Player>();
        }
    }
}