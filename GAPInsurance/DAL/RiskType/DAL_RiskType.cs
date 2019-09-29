using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entities;
using Dapper;
using System.Linq;

namespace DAL
{
    public class DAL_RiskType : DAL_Base, IDAL_Base<RiskType>
    {
        public DAL_RiskType(string connectionString) : base(connectionString)
        {

        }

        public RiskType CreateEntity(RiskType Entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(int Id)
        {
            throw new NotImplementedException();
        }

        public List<RiskType> GetAll()
        {
            try
            {
                List<RiskType> data = new List<RiskType>();
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    data = db.Query<RiskType>("[dbo].[sp_GetAllRiskType]", commandType: CommandType.StoredProcedure).ToList();
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RiskType> GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public RiskType UpdateEntity(RiskType Entity)
        {
            throw new NotImplementedException();
        }
    }
}
