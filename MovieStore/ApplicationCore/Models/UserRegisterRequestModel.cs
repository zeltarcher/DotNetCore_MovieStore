using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class UserRegisterRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
