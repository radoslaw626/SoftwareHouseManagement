using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagement.Models.Entities;
using Task = SoftwareHouseManagement.Models.Entities.Task;

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
                //Password = password,
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
                //Password = x.Password,
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
               //Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
            return workers;
        }

        public List<Task> GetWorkersTasks(string workerId)
        {
            var tasks = new List<Task>();
            var worker = _context.Workers
                .Include(y=>y.Teams).ThenInclude(z=>z.Task)
                .FirstOrDefault(x => x.Id == workerId);
            foreach(var item in worker.Teams)
            {
                tasks.Add(item.Task);
            }

            return tasks;

        }
    }
}
