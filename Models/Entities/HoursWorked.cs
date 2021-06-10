using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SoftwareHouseManagement.Models.Entities
{
    public class HoursWorked
    {
        public long Id { get; set; }
        public DateTime Month { get; set; }

        public long WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
