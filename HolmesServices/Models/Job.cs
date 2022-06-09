using System.ComponentModel.DataAnnotations;
using HolmesServices.ErrorMessages;
using HolmesServices.Errors;

namespace HolmesServices.Models
{
    public class Job
    {
        // Note the ErrorDict does not work with DataAnnotations
        [Required(ErrorMessage = "You must enter an Id")]
        public int? Id 
        { 
            get => Id.Value; 
            set
            {
                if (value > 0 && value <= int.MaxValue)
                    this.Id = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        [Required(ErrorMessage = "Customer id required")]
        public int? Customer_Id 
        {
            get => Customer_Id.Value;
            set
            {
                if (value > 0 && value <= int.MaxValue)
                    this.Customer_Id = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        [Required(ErrorMessage = "Design Id required")]
        public int? Design_Id
        {
            get => Design_Id.Value;
            set
            {
                if (value > 0 && value <= int.MaxValue)
                    this.Design_Id = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
    }
}
