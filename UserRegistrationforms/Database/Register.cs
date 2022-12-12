using System;
using System.Collections.Generic;

namespace UserRegistrationforms.Api.Database
{
    public partial class Register
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Mobile { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
    }
}
