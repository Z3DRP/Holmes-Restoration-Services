using System.ComponentModel.DataAnnotations;
using HolmesServices.ErrorMessages;
using HolmesServices.Errors;

namespace HolmesServices.Models
{
    public class Decking
    {
        (bool, string) IsValidInput;

        [Required(ErrorMessage ="You must enter a id")]
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
        [Required(ErrorMessage = "Product code required")]
        [MaxLength(255, ErrorMessage = "Product code must be 255 characters or less")]
        public string Product_Code
        {
            get => this.Product_Code;
            set
            {
                IsValidInput = InputValidator.IsValidStringData(value);

                //if IsValidInput true
                if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.Product_Code = value;
                else // if IsValidInput false get error msg
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "Name must be 255 characters or less")]
        public string Name
        {
            get => this.Name;
            set
            {
                IsValidInput = InputValidator.IsValidStringData(value);

                if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.Name = value;
                else
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Deck type is required")]
        [MaxLength(100, ErrorMessage = "Deck type must be 100 characters or less")]
        public string Deck_Type
        {
            get => this.Deck_Type;
            set
            {
                IsValidInput = InputValidator.IsValidStringData(value);

                if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.Deck_Type = value;
                else
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Price per square foot required")]
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
                if (!string.IsNullOrEmpty(value))
                    this.Image = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("empty", "Image"));
            }
        }
    }
}
