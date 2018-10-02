using System;
using System.Linq;
using System.Collections.Generic;

namespace assignment2
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int level{get;set;}
        public int Score { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreationTime { get; set; }
        public List<Item> Items { get; set; }

        public Player(){
            Items = new List<Item>();
        }
    }
    
    public class NewPlayer
    {
        public string Name { get; set; }
    }
    public class ModifiedPlayer
    {
        public int level { get;set; }
        public int Score { get; set; }
    }
}