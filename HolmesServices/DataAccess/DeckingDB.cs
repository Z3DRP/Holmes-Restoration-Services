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
    public static class DeckingDB
    {
        public static List<Decking> GetDeckings()
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetDecking]";
            List<Decking> deckings = new List<Decking>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    deckings = db.Query<Decking>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deckings;

        }
        public static Decking GetDeckingById(int id)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckById]";
            var parameter = new { id = id };
            Decking deck = new Decking();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    deck = db.QuerySingle<Decking>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deck;
        }
        public static List<Decking> GetDeckingByType(string type)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckByType]";
            var parameter = new { type = type };
            List<Decking> deckings = new List<Decking>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    deckings = db.Query<Decking>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deckings;
        }
        public static List<Decking> GetDeckingByPrice(double price)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckByPrice]";
            var parameter = new { price = price };
            List<Decking> deckings = new List<Decking>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    deckings = db.Query<Decking>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deckings;
        }
        public static Decking GetDeckingByImage(string image)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckByImage]";
            var parameter = new { image = image };
            Decking deck = new Decking();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    deck = db.QuerySingle<Decking>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return deck;
        }
        public static List<Decking> GetDeckingsSalesInfo()
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckingSaleInfo]";
            List<Decking> deckings = new List<Decking>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    deckings = db.Query<Decking>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deckings;
        }
        public static Decking GetDeckSalesInfo(int id)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckSaleInfo]";
            var parameter = new { id = id };
            Decking deck = new Decking();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    deck = db.QuerySingle<Decking>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deck;
        }
        public static DeckingPriceViewModel GetDeckPrice(int id)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckPrice]";
            var parameter = new { id = id };
            DeckingPriceViewModel deckPriceViewModel = new DeckingPriceViewModel();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    deckPriceViewModel = db.QuerySingle<DeckingPriceViewModel>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deckPriceViewModel;
        }
        public static List<DeckingPriceViewModel> GetDeckingsPrice()
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckingsPrice]";
            List<DeckingPriceViewModel> deckingPriceViewModel = new List<DeckingPriceViewModel>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    deckingPriceViewModel = db.Query<DeckingPriceViewModel>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deckingPriceViewModel;
        }
        public static List<double> GetDeckingsPrice_PerSqft()
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckingsPricePerSqft]";
            List<double> prices = new List<double>();

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    prices = db.Query<double>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return prices;
        }
        public static double GetDeckPrice_PerSqft(int id)
        {
            string con = DBConnector.GetConnection();
            string procedure = "[sp_GetDeckPricePerSqft]";
            var parameter = new { id = id };
            double price;

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    price = db.QuerySingle<double>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return price;
        }
        public static bool AddDecking(string productcode, string name, string type, double price, string image)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_AddDecking]";
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
                using(IDbConnection db = new SqlConnection(con))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;
        }
        public static bool AddDecking(Decking decking)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_AddDecking]";
            var parameters = new
            {
                productCode = decking.Product_Code,
                name = decking.Name,
                type = decking.Type,
                price = decking.Price_Per_SqFt,
                image = decking.Image
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
        public static bool CheckDecking(string productcode, string name)
        {
            bool deckingExists;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_CheckDecking]";
            var parameters = new { productCode = productcode, name = name };

            try
            {
                using (IDbConnection db = new SqlConnection(con))
                {
                    deckingExists = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return deckingExists;
        }
        public static bool UpdateDecking(int id, string productcode, string name, string type, double price, string image)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_UpdateDecking]";
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
        public static bool UpdateDecking(Decking decking)
        {
            int rowsAffected;
            bool success;
            string con = DBConnector.GetConnection();
            string procedure = "[sp_UpdateDecking]";
            var parameters = new
            {
                id = decking.Id,
                productCode = decking.Product_Code,
                name = decking.Name,
                type = decking.Type,
                price = decking.Price_Per_SqFt,
                image = decking.Image
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
