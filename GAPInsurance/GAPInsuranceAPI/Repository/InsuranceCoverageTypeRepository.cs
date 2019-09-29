using DAL;
using Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceAPI.Repository
{
    public class InsuranceCoverageTypeRepository : Interface.IRepository<InsuranceCoverageType>
    {
        private DAL_InsuranceCoverageType _context;

        public InsuranceCoverageTypeRepository(IOptions<ConnectionConfig> connectionConfig)
        {
            var connection = connectionConfig.Value;
            var connectionString = connection.InsuranceApp;
            _context = new DAL_InsuranceCoverageType(connectionString);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InsuranceCoverageType> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InsuranceCoverageType> GetById(int id)
        {
            return _context.GetbyId(id);
        }

        public InsuranceCoverageType Insert(InsuranceCoverageType obj)
        {
            return _context.CreateEntity(obj);
        }

        public InsuranceCoverageType Update(InsuranceCoverageType obj)
        {
            throw new NotImplementedException();
        }
    }
}
