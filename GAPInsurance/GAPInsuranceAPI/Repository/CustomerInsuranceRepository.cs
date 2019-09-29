using DAL;
using Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceAPI.Repository
{
    public class CustomerInsuranceRepository : Interface.IRepository<CustomerInsurance>
    {
        private DAL_CustomerInsurance _context;

        public CustomerInsuranceRepository(IOptions<ConnectionConfig> connectionConfig)
        {
            var connection = connectionConfig.Value;
            var connectionString = connection.InsuranceApp;
            _context = new DAL_CustomerInsurance(connectionString);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerInsurance> GetAll()
        {
            return _context.GetAll();
        }

        public IEnumerable<CustomerInsurance> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerInsurance Insert(CustomerInsurance obj)
        {
            return _context.CreateEntity(obj);
        }

        public CustomerInsurance Update(CustomerInsurance obj)
        {
            throw new NotImplementedException();
        }
    }
}
