using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.ErrorMessages
{
    public static class ErrorDict
    {
        public static string field, number, format, obj;
        public static string charLenErr = " characters or less";
        public static string digitLenErr = " digits or less";
        public static string err = "Error,";
        public static string errorStart = "Must be ";
        public static string formatStr = " format only";
        public static Dictionary<int, string> ErrorsDict = new Dictionary<int, string>()
        {
            {1, " cannot be blank or empty." },
            {2, " must contain " },
            {3, " digits long" },
            {4, "Error, you must " }

        };
        public static Dictionary<int, string> GeneralErrors = new Dictionary<int, string>()
        {
            {1, " cannot contain numbers" },
            {2, " must contain numbers only" },
            {3, " must contain letters only" },
            {4, " cannot contain letter or symbols, ie @,#,$,%,^,&,*,(,),-,+,!,~." },
            {5, " id does not exist." },
            {6, " is null or empty" },
            {7, " already exists" },
            {8, " format error, must be in " },
            {9, " not found"  },
            {10,  " was not added" },
            {11, " was not updated" },
            {12, " not found, access denied" },
            {13, " date must be past current date" },
            {14, " date must be before current date" },
            {15, " does not exist" },

        };
        public static Dictionary<int, string> GeneralErrors2 = new Dictionary<int, string>()
        {
            {0, "You must enter a " },
            {1, "Error unknown " },
            {2, "You must select a " },
            {3, "An error occured while storing " },
            {4, "There was an error while creating " },
            {5, "Invalid " },
            {6, "An error occured while updating " },
            {7, "An error occured while adding " },
            {8, "You must verify " },
            {9, "Max number of digits reached for " },
            {10, "You cannot add extra digits to end of " },
            {11, "Error invalid " },
        };
        public static Dictionary<int, string> SimpleErrors = new Dictionary<int, string>()
        {
            {1, "Date must be prior to today's date." },
            {2, "Id must be greater than zero." },

        };
        public static string GetCharLengthError(string input, string num)
        {
            return err + input + ErrorsDict[2] + num + charLenErr;
        }
        public static string GetDigitLengthError(string input, string num)
        {
            return err + input + ErrorsDict[2] + num + digitLenErr;
        }
        public static string GetFormatError(string input, string formt)
        {
            return input + ErrorsDict[32] + formt + formatStr;
        }
        public static string GetGeneralError(int ecode, string input)
        {
            return input + GeneralErrors[ecode];
        }
        public static string GetGeneralError2(int code, string input)
        {
            return GeneralErrors2[code] + input;
        }
        public static string GetError(int ecode) => SimpleErrors[ecode];
    }
}
}
