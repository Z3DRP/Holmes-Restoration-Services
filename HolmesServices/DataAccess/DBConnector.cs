using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HolmesServices.DataAccess
{
    public static class DBConnector
    {
        // get connection string from appSetting.Json
        private static readonly IConfiguration _configuration;
        public static string GetConnection() => _configuration.GetConnectionString("dbConnection");
    }
}
