using DAL;
using Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceAPI.Repository
{
    public class CoverageTypeRepository : Interface.IRepository<CoverageType>
    {
        private DAL_CoverageType _context;

        public CoverageTypeRepository(IOptions<ConnectionConfig> connectionConfig)
        {
            var connection = connectionConfig.Value;
            var connectionString = connection.InsuranceApp;
            _context = new DAL_CoverageType(connectionString);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoverageType> GetAll()
        {
            return _context.GetAll();
        }

        public CoverageType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CoverageType Insert(CoverageType obj)
        {
            throw new NotImplementedException();
        }

        public CoverageType Update(CoverageType obj)
        {
            throw new NotImplementedException();
        }
    }
}
