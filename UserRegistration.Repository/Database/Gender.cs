using System;
using System.Collections.Generic;

namespace UserRegistration.Repository.Database
{
    public partial class Gender
    {
        public Gender()
        {
            Registers = new HashSet<Register>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Register> Registers { get; set; }
    }
}
