﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.Model.ViewModels
{
   public class CityViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }
    }
}
