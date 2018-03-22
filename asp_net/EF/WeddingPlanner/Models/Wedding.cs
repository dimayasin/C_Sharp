
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using weddingplanner.Models;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        public int WeddingID { get; set; }
        [Required]
        public string WedderOne { get; set; }
        [Required]
        public string WedderTwo { get; set; }
        [Required]
        [DateValid]
        public DateTime WeddingDate { get; set; }
        public List<Guest> Guests { get; set; }
        public int UserId {get;set;}

        [Required]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Creator { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Wedding()
        {
            Guests = new List<Guest>();
        }

    }
    public class DateValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object userdate)
        {
            return userdate != null && (DateTime)userdate > DateTime.Now;
        }
    }
}