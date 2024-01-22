using DirectFerriesTest.Interfaces;
using DirectFerriesTest.Models;
using System.ComponentModel.DataAnnotations;

namespace DirectFerriesTest.Services
{
    public class ValidationService : IValidation
    {
        public (string, bool) ValidDOB(DateTime dob)
        {
            if (dob.CompareTo( DateTime.Now)>0 )
                return ("Date of birth cannot be in the future.", false);

            return ("", true);
        }

        public (string, bool) ValidName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                return ("Name cannot be empty", false);

            if (fullName.Length <= 2)
                return ("Fullname too short", false);

            if (fullName.Trim().Split(" ").Length == 1)
                return ("Fullname required. Please include both name and surname.", false);

            return ("", true);

        }

        public (List<string>, bool) ValidUserInfo(UserInfo userInfo)
        {
            List<string> messages = new List<string>();
            bool validName, validDOB;
            string nameMessage, dobMessage;

            (nameMessage, validName) = ValidName(userInfo.FullName);
            (dobMessage, validDOB) = ValidDOB(userInfo.DOB);

            if (!validName) messages.Add(nameMessage);
            if (!validDOB) messages.Add(dobMessage);

            return (messages, validName && validDOB);
        }
    }
}
