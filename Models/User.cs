using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gorillatree.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [MinLength(2)] //these are for the one below!
        [Display(Name="First Name")]
        public string FirstName {get; set;}



        [Required]
        [MinLength(2)]
        [Display(Name="Last Name")]
        public string LastName{get;set;}



        [Required]
        [EmailAddress] //has some regex esc built in for emails
        public string Email{get;set;}



        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}



        [Required]
        [DataType(DataType.Password)]   
        [Display(Name="Confirm Password")]
        [Compare("Password")]
        public string ComparePassword{get; set;}

        public List<Tree> mytrees{get; set;}

        public int TreeId{get;set;} 

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt{get; set;} = DateTime.Now;

    }
}