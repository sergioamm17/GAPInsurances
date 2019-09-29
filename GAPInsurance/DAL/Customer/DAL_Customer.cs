using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Entities;

namespace DAL
{
    public class DAL_Customer : DAL_Base, IDAL_Base<Customer>
    {
        public DAL_Customer(string connectionString) : base(connectionString)
        {

        }

        public Customer CreateEntity(Customer Entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            try
            {
                List<Customer> data = new List<Customer>();
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    data = db.Query<Customer>("EXEC [dbo].[sp_GetAllCustomer]").ToList();
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Customer> GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateEntity(Customer Entity)
        {
            throw new NotImplementedException();
        }
    }
}
