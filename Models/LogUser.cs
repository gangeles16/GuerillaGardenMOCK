using System.ComponentModel.DataAnnotations;
using System;

namespace gorillatree.Models
{
    public class LogUser
    {
        [Required]
        [EmailAddress]
        public string LoginEmail{get;set;}
        [Required]
        [DataType(DataType.Password)]

        public string LoginPassword{get;set;}
        

    }
}