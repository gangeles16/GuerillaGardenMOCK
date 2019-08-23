using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gorillatree.Models {
    public class Tree {
        [Key]
        public int TreeId { get; set; }
        

        [Required]
        [Display (Name = "Tree Type")]
        public string TreeType { get; set; }
        [Required]
        [Display(Name="Flower Type")]
        public string FlowerType{get;set;}
        
        [Required]
        [Display (Name = "Gender")]

        public string Gender { get; set; }

        [Required]
        [Display (Name = "Location")]
        public string Location { get; set; }

        
        [Required]
        public string Fruit{get;set;}

        [Required]
        public string GrowthHabit{get;set;}

        [Required]
        public string CareInstructions{get;set;}

        [Required]
        public string Attributes {get;set;}
        public string Image{get;set;}
        public int UserId{get;set;}
        public User Planter{get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        
    }
}