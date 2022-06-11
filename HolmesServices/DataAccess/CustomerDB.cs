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
    public static class CustomerDB
    {
        public static List<Customer> GetCustomers()
        {
            string connection = DBConnector.GetConnection();
            // state name of procedure
            string procedure = "[sp_GetCustomers]";
            List<Customer> customers = new List<Customer>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    customers = db.Query<Customer>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return customers;
        }
        public static Customer GetCustomer(int id)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetCustomerById]";
            var parameter = new { id = id };
            Customer requestedCustomer = new Customer();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    requestedCustomer = db.QuerySingle<Customer>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedCustomer;
        }
        public static Customer GetCustomerByName(string firstname, string lastname)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetCustomerByName]";
            var parameters = new { firstname = firstname, lastname = lastname };
            Customer requestedCustomer = new Customer();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    requestedCustomer = db.QuerySingle<Customer>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedCustomer;
        }
        public static List<Customer> GetCustomerByLastName(string lastname)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_GetCustomerByLastName]";
            var parameter = new { lastname = lastname };
            List<Customer> customers = new List<Customer>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    customers = db.Query<Customer>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return customers;
        }
        public static List<Customer> SearchCustomerByName(string fname, string lname)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_SearchCustomerByName]";
            var parameters = new { firstname = fname, lastname = lname };
            List<Customer> customers = new List<Customer>();

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    customers = db.Query<Customer>(procedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return customers;
        }
        public static bool CheckCustomer(string fname, string lname)
        {
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_CheckCustomer]";
            var parameter = new { fname = fname, lname = lname };
            bool customerExist;

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    customerExist = db.ExecuteScalar<bool>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return customerExist;
        }
        public static bool AddCustomer(string fname, string lname, string email, string phone, string street, string city, string state, string zip)
        {
            int rowsAffected;
            bool success;
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_AddCustomer]";
            var parameters = new
            {
                fname = fname,
                lname = lname,
                email = email,
                phone = phone,
                street = street,
                city = city,
                state = state,
                zip = zip
            };
            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;
        }
        public static bool UpdateCustomer(int id, string fname, string lname, string email, string phone, string street, string city, string state, string zip)
        {
            bool success;
            int rowsAffected;
            string connection = DBConnector.GetConnection();
            string procedure = "[sp_UpdateCustomer]";
            var parameters = new
            {
                id = id,
                fname = fname,
                lname = lname,
                email = email,
                phone = phone,
                street = street,
                city = city,
                state = state,
                zip = zip
            };

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            success = rowsAffected > 0 ? true : false;
            return success;
        }
    }
}
