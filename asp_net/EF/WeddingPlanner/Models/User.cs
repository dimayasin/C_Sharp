
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using weddingplanner.Models;

namespace WeddingPlanner.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Wedding> Weddings { get; set; }
        public List<Guest> Guests {get; set;}
        public User(){
            Weddings = new List<Wedding>();
            Guests = new List<Guest>();
        }

    }
}