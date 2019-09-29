using DAL;
using Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceAPI.Repository
{
    public class RiskTypeRepository : Interface.IRepository<RiskType>
    {
        private DAL_RiskType _context;

        public RiskTypeRepository(IOptions<ConnectionConfig> connectionConfig)
        {
            var connection = connectionConfig.Value;
            var connectionString = connection.InsuranceApp;
            _context = new DAL_RiskType(connectionString);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RiskType> GetAll()
        {
            return _context.GetAll();
        }

        public IEnumerable<RiskType> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RiskType Insert(RiskType obj)
        {
            throw new NotImplementedException();
        }

        public RiskType Update(RiskType obj)
        {
            throw new NotImplementedException();
        }
    }
}
