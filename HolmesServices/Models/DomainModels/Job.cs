using System.ComponentModel.DataAnnotations;
using HolmesServices.ErrorMessages;
using HolmesServices.Errors;
using System.Collections.Generic;

namespace HolmesServices.Models
{
    public class Job
    {
        // Note the ErrorDict does not work with DataAnnotations
        [Required(ErrorMessage = "You must enter an Id")]
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        public int Id { get; set; }
        

        [Required(ErrorMessage = "Customer id required")]
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        //fk
        public int Customer_Id { get; set; }
        // nav property
        public Customer Customer { get; set; }


        [Required(ErrorMessage = "Design Id required")]
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        //fk
        public int Design_Id { get; set; }
        // nav property
        public Design Design { get; set; }

        public string Slug() => Customer_Id.ToString() + "-" + Design_Id.ToString();
    }
}
