using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace HolmesServices.DataAccess
{
    public class SpDB<T> where T : class
    {
        protected HolmesContext hContext { get; set; }
        private DbSet<T> hdbSet { get; set; }
        public SpDB(HolmesContext hdb)
        {
            hContext = hdb;
        }
        public bool Insert(T dbObj, string procedure, List<string> parameters)
        {
            string conStr = DBConnector.GetConnection();
            string 
        }
    }
}
