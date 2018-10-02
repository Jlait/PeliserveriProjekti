using System;
using System.ComponentModel.DataAnnotations;

namespace assignment2
{

    public class Item
    {
/* 
        public enum Types
        {
            Sword,
            Axe,
            Bow,
            Shield,
            Spear
        } */
        public Guid id { get; set; }

        [Range (1, 99, ErrorMessage = "Level must be between 1 and 99")]
        public int Level { get; set; }

        [Range (0, 4, ErrorMessage = "Type must be between 0 and 4! Sword, Axe, Bow, Shield and Spear, respectively!")]
        public int Type { get; set; }

        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display (Name = "Date")]
        [Required (ErrorMessage = "Date is mandatory")]
        [RestrictedDate] 
        public DateTime CreationTime { get; set; }
    }
}