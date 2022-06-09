using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HolmesServices.Models
{
    public class Job
    {
        [Required]
        public int? Id 
        { 
            get => this.Id; 
            set
            {
                if (value > 0)
                    this.Id = value;
                else
                    throw new Exception("")
            }
        }
    }
}
