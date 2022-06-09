using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HolmesServices.Models
{
    public static class InputValidator
    {
        // Method to determine if a value is all letters with regex
        public static (bool, string) IsValidStringData(string input)
        {
            bool validInput;
            string errMsg = string.Empty;

            //regex to test the input to see if it matches any non word characters one or more times
            Regex rgx1 = new Regex(@"[0-9+?]");
            // test for any non space characters and symbols
            Regex rgx2 = new Regex(@"\S+?\~+?\!+?\@+?\#+?\$+?\%+?\^+?\&+?\*+?\(+?\)+?\++?", RegexOptions.IgnorePatternWhitespace);
            // test for any duplicate words
            Regex rgx3 = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.IgnoreCase);
            // test for numbers
            Regex rgx4 = new Regex(@"\d+?");

            if (rgx1.IsMatch(input))
            { validInput = false; errMsg = " must contain a-z letters only"; }

            else if (rgx2.IsMatch(input))
            { validInput = false; errMsg = " cannot contain any symbols"; }

            else if (rgx3.IsMatch(input))
            { validInput = false; errMsg = " cannot contain repeating words"; }

            else if (rgx4.IsMatch(input))
            { validInput = false; errMsg = " can only contain letters a - z "; }

            else
                validInput = true;

            return (validInput, errMsg);
        }
        //sergio
        public static (bool, string) isValidUsername(string input)
        {
            bool validInput;
            string errMsg = string.Empty;

            Regex rgx = new Regex(@"^[a-zA-Z0-9_]*$"); //letters,numbers and underscores only
            if (!rgx.IsMatch(input))
            {
                validInput = false;
                errMsg = "username allows letters, numbers or underscores only";
            }
            else
                validInput = true;
            return (validInput, errMsg);
        }
        public static (bool, string) isValidPwd(string input)
        {
            bool validInput;
            string errMsg = string.Empty;

            Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (!rgx.IsMatch(input))
            {
                validInput = false;
                errMsg = "Password must be atleast 8 characters long, contain atleast one uppercase, one lowercase, and a number";
            }
            else
                validInput = true;
            return (validInput, errMsg);
        }
        public static (bool, string) IsValidStreet(string input)
        {
            bool validInput;
            string errMsg = string.Empty;

            Regex rgx1 = new Regex(@"\w+?\s*?", RegexOptions.IgnorePatternWhitespace);
            Regex rgx2 = new Regex(@"\S+?\~+?\!+?\@+?\#+?\$+?\%+?\^+?\&+?\*+?\(+?\)+?\++?", RegexOptions.IgnorePatternWhitespace);

            if (!rgx1.IsMatch(input))
            { validInput = false; errMsg = " address can only contain letters and numbers"; }
            else if (rgx2.IsMatch(input))
            { validInput = false; errMsg = " address cannot contain any symbols"; }
            else
                validInput = true;

            return (validInput, errMsg);
        }
        public static (bool, string) IsValidDate(DateTime date)
        {
            bool validInput;
            string errMsg = string.Empty;

            Regex rgx1 = new Regex(@"^(0?[1-9]|1[0-2])\/(0?[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$");

            if (!rgx1.IsMatch(date.ToShortDateString())) // Short date string = mm/dd/yyyy
            {
                validInput = false;
                errMsg = "Date must be in mm/dd/yyyy format";
            }
            else
                validInput = true;

            return (validInput, errMsg);
        }
        public static (bool, string) IsAllNumbers(string input)
        {
            bool validData;
            string errMsg = string.Empty;
            Regex rgx = new Regex(@"[0-9]+?");

            if (!rgx.IsMatch(input))
            {
                validData = false;
                errMsg = "Invalid format, input must be all numbers 0 -9";
            }
            else
                validData = true;

            return (validData, errMsg);
        }
        public static (bool, string) IsAllLetters(string input)
        {
            bool validData;
            string errMsg = string.Empty;
            Regex rgx = new Regex(@"[a-zA-Z]+?");

            if (!rgx.IsMatch(input))
            {
                validData = false;
                errMsg = "Invalid format, input must be all letters a-z or A-Z";
            }
            else
                validData = true;

            return (validData, errMsg);
        }
        public static (bool, string) IsValidIdFormat(string input)
        {
            bool validData;
            string errMsg = string.Empty;
            Regex rgx = new Regex(@"[0-9]{7}?[a-zA-Z]{3}?");

            if (!rgx.IsMatch(input))
            {
                validData = false;
                errMsg = "Invalid format, id must be 0000000XXX format";
            }
            else
                validData = true;

            return (validData, errMsg);
        }
    }
}
