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
    }
}
