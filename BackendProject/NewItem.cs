using System;
using System.ComponentModel.DataAnnotations;
namespace assignment2
{
    public class NewItem
    {
        [Range (1, 99, ErrorMessage = "Level must be between 1 and 99")]
        public int Level { get; set; }

        [Range (0, 4, ErrorMessage = "Type must be between 0 and 4! Sword, Axe, Bow, Shield and Spear, respectively!")]
        public int Type { get; set; }
    }
}