using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagement.Models;
using SoftwareHouseManagement.Models.Entities;

namespace SoftwareHouseManagement.Models.Services
{
    public class PositionService
    {
        private readonly SoftwareHouseDbContext _context;

        public PositionService(SoftwareHouseDbContext context)
        {
            _context = context;
        }

        public void CreatePosition(string name, decimal Wage)
        {
            var entity = new Position
            {
                Name = name,
                Wage=Wage
            };
            _context.Positions.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Position> GetAll()
        {
            var positions = _context.Positions.Select(x => new Position()
            {
                Id = x.Id,
                Name = x.Name,
                Wage = x.Wage
            }).ToList();
            return positions;
        }
        public void ModifyPosition(long id, string name, decimal wage)
        {
            var position = _context.Positions.FirstOrDefault(x => x.Id == id);
            position.Name = name;
            position.Wage = wage;
            _context.SaveChanges();
        }

        public void DeletePosition(long id)
        {
            var position = _context.Positions.FirstOrDefault(x => x.Id == id);
            _context.Positions.Remove(position);
            _context.SaveChanges();
        }

        public void AssignPosition(string workerId, long positionId)
        {
            var worker = _context.Workers.FirstOrDefault(x => x.Id == workerId);
            var position = _context.Positions.FirstOrDefault(x=>x.Id==positionId);
            worker.Positions.Add(position);
            _context.SaveChanges();
        }

        public void DeleteAllAssignedPositions(string workerId)
        {
            var worker = _context.Workers.Include(y=>y.Positions).FirstOrDefault(x => x.Id == workerId);
            worker.Positions.Clear();
            _context.SaveChanges();
        }

        public IEnumerable<Worker> GetAllWithPositions()
        {
            var workers = _context.Workers.Select(x=>new Worker()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Positions = x.Positions,
                Email = x.Email
            }).Where(y=>y.Positions.Count!=0).ToList();
            return workers;
        }
    } 
}
