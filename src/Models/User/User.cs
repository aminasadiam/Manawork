using System;
using System.ComponentModel.DataAnnotations;

namespace Manawork.Models.User
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Username")]
        [MaxLength(250)]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [MaxLength(250)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [MaxLength(250)]
        [Required]
        public string Password { get; set; }
        
        public DateTime RegisterDate { get; set; }
        public bool IsDelete { get; set; }
    }
}