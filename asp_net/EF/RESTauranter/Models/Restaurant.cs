using System;
using System.ComponentModel.DataAnnotations;
using RESTauranter.Models;

namespace RESTauranter.Models
{

    public class Restaurant
    {
        [Key]
        public int ReviewID{get;set;}
        [Required]
        public string ReviewerName { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string Review { get; set; }
        [DateValid]
        public DateTime DateOfVisit { get; set; }
        public int Stars { get; set; }

        public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object userdate)
            {
                return userdate != null && (DateTime)userdate < DateTime.Now;
            }
        }

    }



}