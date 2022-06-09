using System.Collections.Generic;
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

        public static Dictionary<string, string> ErrorBuilder = new Dictionary<string, string>()
        {
            {"contain", " must contain " },
            {"long", " digits long" },
            {"must", "Error, you must " },
            {"mustBe"," must be in " },
        };
        public static Dictionary<string, string> HardMessages = new Dictionary<string, string>()
        {
            {"needBoth", "You must enter length and width to calculate square feet" },
            {"betweenDate", "Start date must be after today but no more than 4 months away" },
            {"zipChars", "Zipcode must be 5 characters" },        
        };
        public static Dictionary<string, string> GeneralErrors = new Dictionary<string, string>()
        {
            {"empty", " cannot be blank or empty." },
            {"noNumbers", " cannot contain numbers" },
            {"onlyNumbers", " must contain numbers only" },
            {"onlyLetters", " must contain letters only" },
            {"noSymbols", " cannot contain letter or symbols, ie @,#,$,%,^,&,*,(,),-,+,!,~." },
            {"idNotExist", " id does not exist." },
            {"isNull", " is null or empty" },
            {"alreadyExists", " already exists" },
            {"mustFormat", " format error, must be in " },
            {"notFound", " not found"  },
            {"notAdded",  " was not added" },
            {"notUpdated", " was not updated" },
            {"notFoundDenied", " not found, access denied" },
            {"pastToday", " date must be past current date" },
            {"beforeToday", " date must be before current date" },
            {"NotExist", " does not exist" },
            {"greaterZero", " must be greater than zero." },
            {"lessZero", " must be less than zero" }

        };
        public static Dictionary<string, string> GeneralErrors2 = new Dictionary<string, string>()
        {
            {"enterA", "You must enter a " },
            {"unkwn", "Error unknown " },
            {"mustSelect", "You must select a " },
            {"storingErr ", "An error occured while storing " },
            {"creatingErr", "There was an error while creating " },
            {"genInvld", "Invalid " },
            {"updateErr", "An error occured while updating " },
            {"addingErr", "An error occured while adding " },
            {"mustVerify", "You must verify " },
            {"maxDigits", "Max number of digits reached for " },
            {"endOfDigits", "You cannot add extra digits to end of " },
            {"errInvld", "Error invalid " },
        };
        public static Dictionary<string, string> SimpleErrors = new Dictionary<string, string>()
        {
            {"beforeToday", "Date must be prior to today's date." },

        };
        public static string GetCharLengthError(string input, string num)
        {
            return err + input + ErrorBuilder["contain"] + num + charLenErr;
        }
        public static string GetDigitLengthError(string input, string num)
        {
            return err + input + ErrorBuilder["contain"] + num + digitLenErr;
        }
        public static string GetFormatError(string input, string formt)
        {
            return errorStart + input + ErrorBuilder["mustBe"] + formt + formatStr;
        }
        public static string GetGeneralError(string ecode, string input)
        {
            return input + GeneralErrors[ecode];
        }
        public static string GetGeneralError2(string code, string input)
        {
            return GeneralErrors2[code] + input;
        }
        public static string GetError(string ecode) => SimpleErrors[ecode];
        // GetHardError is used for app specific errors
        public static string GetHardError(string ecode) => HardMessages[ecode];
    }
}
}
