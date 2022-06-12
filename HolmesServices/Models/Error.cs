using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models
{
    public  class Error
    {
        public Error(string title, string message)
        {
            Title = title;
            Message = message;
        }
        public string Title { get; set; }
        public string Message { get; set; }  
    }
}
