using System.ComponentModel.DataAnnotations;
using HolmesServices.ErrorMessages;
using HolmesServices.Errors;

namespace HolmesServices.Models
{
    public class Railing
    {
        (bool, string) isValidInput;

        [Required(ErrorMessage = "Railing Id required")]
        public int? Id
        {
            get => Id.Value;
            set
            {
                if (value > 0 && value < int.MaxValue)
                    this.Id = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        [Required(ErrorMessage = "Product code required")]
        [MaxLength(255, ErrorMessage = "Product code must be 255 characters or less")]
        public string Product_Code
        {
            get => this.Product_Code;
            set
            {
                isValidInput = InputValidator.IsValidStringData(value);

                // if true
                if (!string.IsNullOrEmpty(value) && isValidInput.Item1)
                    this.Product_Code = value;
                else // if isValid == false use error message
                    Except.ThrowExcept(isValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "Name must be 255 characters or less")]
        public string Name
        {
            get => this.Name;
            set
            {
                isValidInput = InputValidator.IsValidStringData(value);

                if (!string.IsNullOrEmpty(value) && isValidInput.Item1)
                    this.Name = value;
                else
                    Except.ThrowExcept(isValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Rail type is required")]
        [MaxLength(100, ErrorMessage = "Rail type must be 100 characters or less")]
        public string Rail_Type
        {
            get => this.Rail_Type;
            set
            {
                isValidInput = InputValidator.IsValidStringData(value);

                if (!string.IsNullOrEmpty(value) && isValidInput.Item1)
                    this.Rail_Type = value;
                else
                    Except.ThrowExcept(isValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Price per square foot is required")]
        public double? Price_Per_SqFt
        {
            get => Price_Per_SqFt.Value;
            set
            {
                if (value > 0 && value <= double.MaxValue)
                    this.Price_Per_SqFt = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        [Required(ErrorMessage = "Image is required")]
        [MaxLength(255, ErrorMessage = "Image must be 255 characters or less")]
        public string Image
        {
            get => this.Image;
            set
            {
                // not sure about regex for image string yet
                if (!string.IsNullOrEmpty(value))
                    this.Image = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("empty", "Image"));
            }
        }
        public string Slug() => Product_Code + "-" + Name;

    }
}
