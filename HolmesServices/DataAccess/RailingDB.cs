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
using HolmesServices.ViewModels;

namespace HolmesServices.DataAccess
{
    public static class RailingDB
    {
        public static List<Railing> GetRailings()
        {
            string con = DBConnector.GetConnection();
            string procedure = "[spGetRailings]";
            List<Railing> railings = new List<Railing>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    railings = db.Query<Railing>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return railings;
        }
        public static Railing GetRailingById(int id)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRail]";
            var parameter = new { id = id };
            Railing rail = new Railing();

            try
            {
                using(IDbConnection db = new SqlConnection(con))
                {
                    rail = db.QuerySingle<Railing>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return rail;
        }
        public static List<Railing> GetRailingByType(string type)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRailByType]";
            var parameter = new { type = type };
            List<Railing> railings = new List<Railing>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    railings = db.Query<Railing>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return railings;
        }
        public static Railing GetRailingByImage(string image)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRailByImage]";
            var parameter = new { image = image };
            Railing rail = new Railing();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rail = db.QuerySingle<Railing>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return rail;
        }
        public static List<Railing> GetRailingSaleInfo()
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRailingSaleInfo]";
            List<Railing> rails = new List<Railing>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rails = db.Query<Railing>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return rails;
        }
        public static Railing GetRailSaleInfo(int id)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRailSaleInfo]";
            var parameter = new { id = id };
            Railing rail = new Railing();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    rail = db.QuerySingle<Railing>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return rail;
        }
        public static RailingPriceViewModel GetRailPrice(int id)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRailPrice]";
            var parameter = new { id = id };
            RailingPriceViewModel railPriceViewModel = new RailingPriceViewModel();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    railPriceViewModel = db.QuerySingle<RailingPriceViewModel>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return railPriceViewModel;
        }
        public static List<RailingPriceViewModel> GetRailingsPrice()
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRailingsPrice]";
            List<RailingPriceViewModel> railingsPriceViewModel = new List<RailingPriceViewModel>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    railingsPriceViewModel = db.Query<RailingPriceViewModel>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return railingsPriceViewModel;
        }
        public static List<double> GetRailingsPrice_PerSqft()
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRailingsPricePerSqft]";
            List<double> prices = new List<double>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    prices = db.Query<double>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return prices;
        }
        public static double GetRailPrice_PerSqft(int id)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetRailPricePerSqft]";
            var parameter = new { id = id };
            double price;

            try
            {
                using(IDbConnection db = new SqlConnection(con))
                {
                    price = db.QuerySingle<double>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return price;
        }
        public static bool AddRailing(string productcode, string name, string type, double price, string image)
        {
            int rowsAffected;
            bool success;
            string procedure = "[sp_AddRailing]";
            string con = DBConnector.GetConnection();
            var parameters = new
            {
                productCode = productcode,
                name = name,
                type = type,
                price = price,
                image = image
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
        public static bool AddRailing(Railing railing)
        {
            int rowsAffected;
            bool success;
            string procedure = "[sp_AddRailing]";
            string con = DBConnector.GetConnection();
            var parameters = new
            {
                productCode = railing.Product_Code,
                name = railing.Name,
                type = railing.Rail_Type,
                price = railing.Price_Per_SqFt,
                image = railing.Image
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
        public static bool CheckRailing(string productCode, string name)
        {
            bool railingExsits;
            string procedure = "[sp_CheckRailing]";
            string con = DBConnector.GetConnection();
            var parameters = new { productCode = productCode, name = name };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    railingExsits = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return railingExsits;
        }
        public static bool UpdateRailing(int id, string productcode, string name, string type, double price, string image)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_UpdateRailing]";
            var parameters = new
            {
                id = id,
                productCode = productcode,
                name = name,
                type = type,
                price = price,
                image = image
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
        public static bool UpdateRailing(Railing railing)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_UpdateRailing]";
            var parameters = new
            {
                id = railing.Id,
                productCode = railing.Product_Code,
                name = railing.Name,
                type = railing.Rail_Type,
                price = railing.Price_Per_SqFt,
                image = railing.Image
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
        public static bool DeleteRailing(int id)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_DeleteRailing]";
            var parameter = new { id = id };

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
