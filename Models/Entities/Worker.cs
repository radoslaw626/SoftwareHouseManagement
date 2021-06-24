using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Worker : IdentityUser
    {
        public Worker()
        {
            Teams = new Collection<Team>();
            HoursWorked = new Collection<HoursWorked>();
        }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public long? ComputerId { get; set; }
        public  virtual Computer Computer { get; set; }
        public virtual IList<Team> Teams { get; set; }
        public virtual IList<HoursWorked> HoursWorked { get; set; }
        public long? PositionId { get; set; }
        public virtual Position Position { get; set; }


    }
}
