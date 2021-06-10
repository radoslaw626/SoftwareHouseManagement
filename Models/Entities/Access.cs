﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Access
    {
        public Access()
        {
            Teams = new Collection<Team>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Team> Teams { get; set; }
    }
}
