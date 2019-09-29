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
    public class DAL_CoverageType : DAL_Base, IDAL_Base<CoverageType>
    {
        public DAL_CoverageType(string connectionString) : base(connectionString)
        {

        }

        public CoverageType CreateEntity(CoverageType Entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CoverageType> GetAll()
        {
            try
            {
                List<CoverageType> data = new List<CoverageType>();
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    data = db.Query<CoverageType>("[dbo].[sp_GetAllCoverageType]", commandType: CommandType.StoredProcedure).ToList();
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CoverageType GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public CoverageType UpdateEntity(CoverageType Entity)
        {
            throw new NotImplementedException();
        }
    }
}
