using System;
using System.Collections.Generic;

namespace UserRegistrationforms.Api.Database
{
    public partial class City
    {
        public City()
        {
            Registers = new HashSet<Register>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
    }
}
