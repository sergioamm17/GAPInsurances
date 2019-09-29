using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAPInsuranceAPI.Interface;
using DAL;
using Microsoft.Extensions.Options;

namespace GAPInsuranceAPI.Repository
{
    public class InsuranceRepository : Interface.IRepository<Insurance>
    {
        private DAL_Insurance _context;

        public InsuranceRepository(IOptions<ConnectionConfig> connectionConfig)
        {
            var connection = connectionConfig.Value;
            var connectionString = connection.InsuranceApp;
            _context = new DAL_Insurance(connectionString);
        }
        public bool Delete(int id)
        {
            return _context.DeleteEntity(id);
        }

        public IEnumerable<Insurance> GetAll()
        {
            return _context.GetAll();
        }

        public Insurance GetById(int id)
        {
            return _context.GetbyId(id);
        }

        public Insurance Insert(Insurance obj)
        {
            return _context.CreateEntity(obj);
        }

        public Insurance Update(Insurance obj)
        {
            return _context.UpdateEntity(obj);
        }
    }
}
