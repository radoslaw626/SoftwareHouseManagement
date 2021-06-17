using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftwareHouseManagement.Models.Entities;

namespace SoftwareHouseManagement.Models.Services
{
    public class WorkersService
    {
        private readonly SoftwareHouseDbContext _context;

        public WorkersService(SoftwareHouseDbContext context)
        {
            _context = context;
        }

        public void AddWorker(string firstName, string lastName, string email, string password, long positionId)
        {
            var position = _context.Positions
                .FirstOrDefault(x => x.Id == positionId);
            var worker = new Worker
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Position= position,
            };
            _context.Workers.Add(worker);
            _context.SaveChanges();
        }
        public IEnumerable<Worker> GetAll()
        {
            var workers = _context.Workers.Select(x => new Worker()
            {
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
            return workers;
        }
        public IEnumerable<Worker> GetAllWithoutComputer()
        {
            var workers = _context.Workers.Where(y=>y.Computer==null).Select(x => new Worker()
            {
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
            return workers;
        }
    }
}
