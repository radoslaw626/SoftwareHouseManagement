using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Task
    {
        public Task()
        {
            HoursWorked = new Collection<HoursWorked>();
        }
        public long Id { get; set; }
        public string Subject { get; set; }
        public long AssignedHours { get; set; }
        public long WorkedHours { get; set; }

        public virtual Team Team { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual IList<HoursWorked> HoursWorked { get; set; }
    }
}
