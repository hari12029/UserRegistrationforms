using System;
using System.Collections.Generic;

namespace UserRegistrationforms.Api.Database
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            Registers = new HashSet<Register>();
        }

        public int Id { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
    }
}
