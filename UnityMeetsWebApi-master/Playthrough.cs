using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace assignment2
{

    public class Playthrough
    {
        public Guid id { get; set; }

        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display (Name = "Date")]
        [Required (ErrorMessage = "Date is mandatory")]
        [RestrictedDate] 
        public DateTime CreationTime { get; set; }
        public List<Player> Players { get; set; }
        public Playthrough(){
            Players = new List<Player>();
        }
    }

    public class PTListObj
    {
        public List<Playthrough> ptList {get;set;} = new List<Playthrough>();
    }

}