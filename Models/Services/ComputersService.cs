using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagement.Models.Entities;

namespace SoftwareHouseManagement.Models.Services
{
    public class ComputersService
    {
        private readonly SoftwareHouseDbContext _context;

        public ComputersService(SoftwareHouseDbContext context)
        {
            _context = context;
        }

        public void AddComputer(string model)
        {
            var computer = new Computer
            {
                Model = model
            };
            _context.Computers.Add(computer);
            _context.SaveChanges();
        }

        public IEnumerable<Computer> GetAll()
        {
            var computers = _context.Computers.Select(x => new Computer()
            {
                Id = x.Id,
                Model = x.Model,
                Worker = x.Worker
            }).ToList();
            return computers;
        }
        public IEnumerable<Computer> GetAllWithoutWorker()
        {
            var computers = _context.Computers.Where(y=>y.Worker==null).Select(x => new Computer()
            {
                Id = x.Id,
                Model = x.Model
            }).ToList();
            return computers;
        }

        public void AssignComputer(string workerId, long computerId)
        {
            var worker = _context.Workers.FirstOrDefault(x => x.Id == workerId);
            worker.ComputerId = computerId;
            _context.SaveChanges();
        }

        public void ModifyComputer(long computerId, string model)
        {
            var computer=_context.Computers.FirstOrDefault(x => x.Id == computerId);
            computer.Model = model;
            _context.SaveChanges();
        }

        public IEnumerable<Worker> GetAllWithComputers()
        {
            var workersWithComputers = _context.Workers.Include(y=>y.Computer).Where(x => x.ComputerId != null).ToList();
            return workersWithComputers;
        }

        public void DeleteAssignedComputers(string workerId)
        {
            var worker = _context.Workers.Include(x => x.Computer).FirstOrDefault(y => y.Id == workerId);
            worker.Computer = null;
            _context.SaveChanges();
        }

        public void AddComputersFromCsv(string fileName)
        {
            List<ComputerCsvViewModel> computersCsv = new List<ComputerCsvViewModel>();
            #region Read Csv

            var path =  fileName;
            using(var reader = new StreamReader(path))
            using (var csv=new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var computer = csv.GetRecord<ComputerCsvViewModel>();
                    computersCsv.Add(computer);
                }
            }
            #endregion

            #region Create Csv

            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(computersCsv);
            }
            #endregion

            foreach (var item in computersCsv)
            {
                var computerEntity = new Computer()
                {
                    Model = item.Model
                };
                _context.Computers.Add(computerEntity);
                _context.SaveChanges();
            }
        }
    }
}
 