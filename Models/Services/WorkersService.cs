using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Models.Services
{
    public class WorkersService
    {
        private readonly SoftwareHouseDbContext _context;

        public WorkersService(SoftwareHouseDbContext context)
        {
            _context = context;
        }



    }
}
