using System;
using System.ComponentModel.DataAnnotations;

namespace TODO.API.Models
{
    public class LoginViewModel
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime DateOfJoing { get; set; }
    }
}
