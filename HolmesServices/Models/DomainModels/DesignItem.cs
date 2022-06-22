using HolmesServices.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HolmesServices.Models.DomainModels
{
    public class DesignItem
    {
        // desing id is just a geneerated id to keep designs unique in
        // the session data. this id will not be stored in database
        public DesignDTO Design { get; set; }
        public double Estimate { get; set; }
    }
}
