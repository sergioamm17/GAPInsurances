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
    public class DAL_Insurance : DAL_Base, IDAL_Base<Insurance>
    {
        public DAL_Insurance(string connectionString) : base(connectionString)
        {

        }

        public Insurance CreateEntity(Insurance Entity)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@InsuranceID", Entity.InsuranceID);
                    queryParameters.Add("@Name", Entity.Name);
                    queryParameters.Add("@Description", Entity.Description);
                    queryParameters.Add("@CoveragePercentage", Entity.CoveragePercentage);
                    queryParameters.Add("@StartDate", Entity.StartDate);
                    queryParameters.Add("@CoverageTime", Entity.CoverageTime);
                    queryParameters.Add("@Amount", Entity.Amount);
                    queryParameters.Add("@RiskTypeID", Entity.RiskTypeID);
                    
                    db.Execute(@"[dbo].[sp_InsertInsurance]", queryParameters, commandType: CommandType.StoredProcedure);

                    int ID = queryParameters.Get<int>("@InsuranceID");
                    Entity.InsuranceID = ID;
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
            bool result = false;
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@InsuranceID", Id);

                    db.Execute(@"[dbo].[sp_DeleteInsurance]", queryParameters, commandType: CommandType.StoredProcedure);

                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public List<Insurance> GetAll()
        {
            try
            {
                List<Insurance> data = new List<Insurance>();
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    data = db.Query<Insurance>("EXEC [dbo].[sp_GetAllInsurance]").ToList();
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Insurance GetbyId(int Id)
        {
            try
            {
                List<Insurance> data = new List<Insurance>();
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@InsuranceID", Id);
                    data = db.Query<Insurance>("EXEC [Logistic].[SP_CustomerGetById]", queryParameters, commandType: CommandType.StoredProcedure).ToList();
                }
                return data.FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Insurance UpdateEntity(Insurance Entity)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@InsuranceID", Entity.InsuranceID);
                    queryParameters.Add("@Name", Entity.Name);
                    queryParameters.Add("@Description", Entity.Description);
                    queryParameters.Add("@CoveragePercentage", Entity.CoveragePercentage);
                    queryParameters.Add("@StartDate", Entity.StartDate);
                    queryParameters.Add("@CoverageTime", Entity.CoverageTime);
                    queryParameters.Add("@Amount", Entity.Amount);
                    queryParameters.Add("@RiskTypeID", Entity.RiskTypeID);
                    
                    db.Execute(@"[dbo].[sp_UpdateInsurance]", queryParameters, commandType: CommandType.StoredProcedure);

                    return Entity;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
