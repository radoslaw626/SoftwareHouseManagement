using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Position
    {

        public Position()
        {
            Workers = new Collection<Worker>();
            Responsibilities = new Collection<Responsibilities>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Wage { get; set; }
        
        public virtual IList<Worker> Workers { get; set; }
        public virtual IList<Responsibilities> Responsibilities { get; set; }
    }
}
