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
    public class DAL_CustomerInsurance : DAL_Base, IDAL_Base<CustomerInsurance>
    {
        public DAL_CustomerInsurance(string connectionString) : base(connectionString)
        {

        }

        public CustomerInsurance CreateEntity(CustomerInsurance Entity)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@CustomerID", Entity.CustomerId);
                    queryParameters.Add("@InsuranceID", Entity.InsuranceID);
                    
                    
                    db.Execute(@"[dbo].[sp_InsertCustomerInsurance]", queryParameters, commandType: CommandType.StoredProcedure);

                    return Entity;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteEntity(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerInsurance> GetAll()
        {
            try
            {
                List<CustomerInsurance> data = new List<CustomerInsurance>();
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    data = db.Query<CustomerInsurance>("EXEC [dbo].[sp_GetAllCustomerInsurance]").ToList();
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CustomerInsurance> GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public CustomerInsurance UpdateEntity(CustomerInsurance Entity)
        {
            throw new NotImplementedException();
        }
    }
}
