﻿using System;
using System.Collections.Generic;

namespace Entity_Framework_Introduction.Data.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
