using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace assignment2
{
    public class NewPlaythrough
    {
        public List<Player> Players{ get; set; }
        public NewPlaythrough(){
            Players = new List<Player>();
        }
    }
}