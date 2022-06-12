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
    public static class DesignDB
    {
        public static List<Design> GetDesigns()
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDesigns]";
            List<Design> designs = new List<Design>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    designs = db.Query<Design>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return designs;
        }
        public static Design GetDesignById(int id)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDesign]";
            var parameter = new { Id = id };
            Design design = new Design();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    design = db.QuerySingle<Design>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return design;
        }
        public static List<Design> GetCustomerDesigns(int? customerId)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetCustomerID]";
            var parameter = new { customerID = customerId };
            List<Design> designs = new List<Design>();

            if (customerId == null)
                throw new Exception("Id cannot be null");

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    designs = db.Query<Design>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return designs;
        }
        public static List<Design> GetDesignByDeckingId(int deckingId)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDesignsByDecking]";
            var parameter = new { deckingID = deckingId };
            List<Design> designs = new List<Design>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    designs = db.Query<Design>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return designs;
        }
        public static List<Design> GetDesignsByRailingId(int railingId)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDesignsByRailing]";
            var parameter = new { railingID = railingId };
            List<Design> designs = new List<Design>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    designs = db.Query<Design>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return designs;
        }
        public static List<Design> GetDesignsByStart(DateTime date)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDesignsByStart]";
            var parameter = new { startdate = date };
            List<Design> designs = new List<Design>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    designs = db.Query<Design>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return designs;
        }
        // will need to change this after I create the join query in mysql for now just do two querys 
        public static List<Design> GetDesignsByCustomerName(string firstname, string lastname)
        {
            string con = DBConnector.GetConnection();
            Customer customer = CustomerDB.GetCustomerByName(firstname, lastname);
            List<Design> designs = new List<Design>();

            if (customer != null)
            {
                int? customerId = customer.Id;
                designs = GetCustomerDesigns(customerId);
                return designs;
            }
            else
                throw new Exception("Error occured while retrieving designs");
        }
        public static bool CheckDesign(int customerId, int deckingId, int railingId)
        {
            bool designExists;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_CheckDesign]";
            var parameter = new { customerId = customerId, deckingId = deckingId, railingId = railingId };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    designExists = db.ExecuteScalar<bool>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return designExists;
        }
        public static bool AddDesign(int customerId, int deckingId, int railingId, double length, double width, double sqft, double estimate, DateTime date)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_AddDesign]";
            var parameters = new
            {
                customerId = customerId,
                deckingId = deckingId,
                railingId = railingId,
                len = length,
                wid = width,
                sqft = sqft,
                estimate = estimate,
                start = date
            };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;
        }
        public static bool AddDesign(Design design)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_AddDesign]";
            var parameters = new
            {
                customerId = design.Customer_Id,
                deckingId = design.Decking_Id,
                railingId = design.Railing_Id,
                len = design.Length,
                wid = design.Width,
                sqft = design.Square_Ft,
                estimate = design.Estimate,
                start = design.Start_Date
            };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;
        }
        public static bool UpdateDesign(int jobId, int customerId, int deckingId, int railingId, double length, double width, double sqft, double estimate, DateTime date)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_UpdateDesign]";
            var parameters = new
            {
                jobId = jobId,
                customerId = customerId,
                deckingId = deckingId,
                railingId = railingId,
                len = length,
                wid = width,
                sqft = sqft,
                estimate = estimate,
                start = date
            };

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
        public static bool UpdateDesign(Design design)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_UpdateDesign]";
            var parameters = new
            {
                id = design.Id,
                customerId = design.Customer_Id,
                deckingId = design.Decking_Id,
                railingId = design.Railing_Id,
                len = design.Length,
                wid = design.Width,
                sqft = design.Square_Ft,
                estimate = design.Estimate,
                start = design.Start_Date
            };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;
        }
    }
}
