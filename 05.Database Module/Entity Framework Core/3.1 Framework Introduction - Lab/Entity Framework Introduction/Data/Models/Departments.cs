﻿using System;
using System.Collections.Generic;

namespace Entity_Framework_Introduction.Data.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }

        public virtual Employees Manager { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
