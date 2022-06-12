using System.ComponentModel.DataAnnotations;
using HolmesServices.ErrorMessages;
using HolmesServices.Errors;

namespace HolmesServices.Models
{
    public class Customer
    {
        (bool, string) IsValidInput;

        [Required(ErrorMessage = "Id required")]
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
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(100,ErrorMessage = "First name must be 100 characters or less")]
        public string First_Name
        {
            get => this.First_Name;
            set
            {
                IsValidInput = Validate(value);

                if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.First_Name = value;
                else
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100, ErrorMessage = "Last name must be 100 characters or less")]
        public string Last_Name
        {
            get => this.Last_Name;
            set
            {
                IsValidInput = Validate(value);

                if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.Last_Name = value;
                else
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(100, ErrorMessage = "Email address must be 100 characters or less")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Invalid email format")]
        public string Email
        {
            get => this.Email;
            set
            {
                // add email regex in future sprint if data annotation does not work right
                if (!string.IsNullOrEmpty(value))
                    this.Email = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("empty", "Email"));
            }
        }
        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(12,ErrorMessage = "Phone number must be 12 characters")]
        [DataType(DataType.PhoneNumber,ErrorMessage = "Invalid phone number format")]
        public string Phone_Number
        {
            get => this.Phone_Number;
            set
            {
                // add phone number regex if data annotation does not work right
                if (!string.IsNullOrEmpty(value))
                    this.Phone_Number = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("empty", "Phone number"));
            }
        }
        [Required(ErrorMessage = "Street address is required")]
        [MaxLength(75, ErrorMessage = "Street address must be 75 characers or less")]
        public string Street_Address
        {
            get => this.Street_Address;
            set
            {
                IsValidInput = ValidateStreet(value);

                if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.Street_Address = value;
                else
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "City is required")]
        [MaxLength(75, ErrorMessage = "City must be 75 characters or less")]
        public string City
        {
            get => this.City;
            set
            {
                IsValidInput = ValidateString(value);

                if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.City = value;
                else
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "State is required")]
        [MaxLength(50, ErrorMessage = "State must be 50 characters or less")]
        public string State
        {
            get => this.State;
            set
            {
                IsValidInput = ValidateString(value);

                if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.State = value;
                else
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        [Required(ErrorMessage = "Zipcode is required")]
        [MaxLength(5, ErrorMessage = "Zipcode cannot be more than 5 characters")]
        public string Zipcode
        {
            get => this.Zipcode;
            set
            {
                IsValidInput = ValidateNumbers(value);

                if (value.Length > 5 || value.Length < 5)
                    Except.ThrowExcept(ErrorDict.GetHardError("zipChars"));
                else if (!string.IsNullOrEmpty(value) && IsValidInput.Item1)
                    this.Zipcode = value;
                else
                    Except.ThrowExcept(IsValidInput.Item2);
            }
        }
        public (bool,string) ValidateNumbers(string input)
        {
            (bool, string) isValid = InputValidator.IsAllNumbers(input);
            return isValid;
        }
        public (bool,string) ValidateString(string input)
        {
            (bool valid, string emsg) isValid = InputValidator.IsValidString(input);
            return isValid;
        }
        public (bool,string) ValidateStreet(string input)
        {
            (bool valid, string emsg) isValid = InputValidator.IsValidStreet(input);
            return isValid;
        }
        public (bool,string) Validate(string input)
        {
            (bool valid, string emsg) isValid = InputValidator.IsValidStringData(input);
            return isValid;
        }
        public string GetCustomerFullname() => First_Name + Last_Name;
        public string Slug() => Last_Name + "-" + First_Name;
    }
}
