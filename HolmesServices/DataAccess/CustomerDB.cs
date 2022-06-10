using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HolmesServices.Models;
using HolmesServices.Errors;
using Dapper;
using MySql.Data.Types;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            { Except.ThrowExcept(ex.Message); }

            return customers;
        }

    }
}
