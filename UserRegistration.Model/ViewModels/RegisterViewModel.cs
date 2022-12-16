using System;

namespace UserRegistration.Model.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dob { get; set; }
        public int? GenderId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public string Gender {get; set;}

    }
}
