using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Worker
    {
        public Worker()
        {
            Teams = new Collection<Team>();
            HoursWorked = new Collection<HoursWorked>();
        }
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Pole 'Powtórz hasło' jest wymagane")]
        public string Password { get; set; }
        
        public long? ComputerId { get; set; }
        public  virtual Computer Computer { get; set; }
        public virtual IList<Team> Teams { get; set; }
        public virtual IList<HoursWorked> HoursWorked { get; set; }
        public long? PositionId { get; set; }
        public virtual Position Position { get; set; }


    }
}
