using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Responsibilities
    {
        public Responsibilities()
        {
            Positions = new Collection<Position>();
        }
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Position> Positions { get; set; }
    }
}
