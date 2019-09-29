using DAL;
using Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceAPI.Repository
{
    public class CustomerRepository : Interface.IRepository<Customer>
    {
        private DAL_Customer _context;

        public CustomerRepository(IOptions<ConnectionConfig> connectionConfig)
        {
            var connection = connectionConfig.Value;
            var connectionString = connection.InsuranceApp;
            _context = new DAL_Customer(connectionString);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.GetAll();
        }

        public IEnumerable<Customer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Insert(Customer obj)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
