using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using weddingplanner.Models;

namespace WeddingPlanner.Models
{
    public class Guest : BaseEntity

    {
        public int GuestID {get; set;}
        public int WeddingID { get; set; }
        public Wedding Wedding { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }

}