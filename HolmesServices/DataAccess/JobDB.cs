using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HolmesServices.Models;
using Dapper;
using MySql.Data.Types;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HolmesServices.DataAccess
{
    public static class JobDB
    {
        public static List<Job> GetJobs()
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetJobs]";
            List<Job> jobs = new List<Job>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    jobs = db.Query<Job>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return jobs;
        }
        public static Job GetJob(int id)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetJob]";
            var parameter = new { id = id };
            Job job = new Job();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    job = db.QuerySingle<Job>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return job;
        }
        public static List<Job> GetCustomerJobs(int customerid)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetCustomerJobs]";
            var parameter = new { customerId = customerid };
            List<Job> jobs = new List<Job>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    jobs = db.Query<Job>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return jobs;

        }
        public static Job GetJobByDesign(int designid)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetJobByDesign]";
            var parameter = new { designId = designid};
            Job job = new Job();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    job = db.QuerySingle<Job>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return job;
        }
        public static bool CheckJob(int customerId, int designId)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_CheckJob]";
            var parameters = new { customerId = customerId, desingId = designId };
            bool jobExists;

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    jobExists = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return jobExists;
        }
        public static bool AddJob(int customerId, int designId)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_AddJob]";
            var parameter = new { custoemrId = customerId, designId = designId };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rowsAffected = db.Execute(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;
        }
        public static bool UpdateJob(int jobId, int customerId, int designId)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_UpdateJob]";
            var parameters = new { jobId = jobId, customerId = customerId, designId = designId };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;
        }
        public static bool DeleteJob(int jobId)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_DeleteJob]";
            var parameter = new { id = jobId };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rowsAffected = db.Execute(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;

        }
    }
}
