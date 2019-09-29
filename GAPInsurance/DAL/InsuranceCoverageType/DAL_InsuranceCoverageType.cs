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
    public class DAL_InsuranceCoverageType : DAL_Base, IDAL_Base<InsuranceCoverageType>
    {
        public DAL_InsuranceCoverageType(string connectionString) : base(connectionString)
        {

        }

        public InsuranceCoverageType CreateEntity(InsuranceCoverageType Entity)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@InsuranceID", Entity.InsuranceID);
                    queryParameters.Add("@Name", Entity.CoverageTypeID);
                    
                    db.Execute(@"[dbo].[sp_InsertInsuranceCoverageType]", queryParameters, commandType: CommandType.StoredProcedure);

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

        public List<InsuranceCoverageType> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<InsuranceCoverageType> GetbyId(int Id)
        {
            try
            {
                List<InsuranceCoverageType> data = new List<InsuranceCoverageType>();
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@InsuranceID", Id);
                    data = db.Query<InsuranceCoverageType>("EXEC [dbo].[sp_GetByIDInsuranceCoverageType]", queryParameters, commandType: CommandType.StoredProcedure).ToList();
                }
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public InsuranceCoverageType UpdateEntity(InsuranceCoverageType Entity)
        {
            throw new NotImplementedException();
        }
    }
}
