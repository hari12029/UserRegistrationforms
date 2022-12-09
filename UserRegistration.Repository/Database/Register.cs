using System;
using System.Collections.Generic;

namespace UserRegistration.Repository.Database
{
    public partial class Register
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? Mobile { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Id { get; set; }
    }
}
