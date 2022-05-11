using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Computer
    {
        public Computer(string nameModel)
        {
            this.Model = nameModel;
        }

        public Computer()
        {
            
        }
        public long Id { get; set; }
        [Required]
        public string Model { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
