using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Client
    {
        public Client()
        {
            Tasks = new Collection<Task>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public virtual IList<Task> Tasks { get; set; }
    }
}
