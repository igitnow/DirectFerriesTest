using DirectFerriesTest.Interfaces;
using DirectFerriesTest.Models;

namespace DirectFerriesTest.Services
{
    public class UserProcessorService : IUserProcessor
    {
        public UserResults GetUserResults(UserInfo userInfo)
        {
            return new UserResults()
            {
                FirstName = GetFirstName(userInfo),
                Age = GetAge(userInfo),
                DaysToBirthday = GetDaysToBirthday(userInfo),
                VowelsCount = GetVowelsCount(userInfo),
                DOB = userInfo.DOB
            };
        }
        private int GetDaysToBirthday(UserInfo userInfo)
        {
            DateTime today = DateTime.Today;
            DateTime next = userInfo.DOB.AddYears(today.Year - userInfo.DOB.Year);
            if (next < today) next = next.AddYears(1);
            return (next - today).Days;
        }

        private int GetVowelsCount(UserInfo userInfo)
        {
            if (string.IsNullOrEmpty(userInfo.FullName)) return 0;
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            string firstName = GetFirstName(userInfo);
            return firstName.ToLower().Count(c => vowels.Contains(c));

        }

        private string GetFirstName(UserInfo userInfo)
        {
            if (string.IsNullOrEmpty(userInfo.FullName)) { return string.Empty; }

            string firstName = userInfo.FullName.Trim().Split(" ")[0];
            return char.ToUpper(firstName.First()) + firstName.Substring(1).ToLower();
        }

        private int GetAge(UserInfo userInfo)
        {
            DateTime today = DateTime.Today;
            var age = today.Year - userInfo.DOB.Year;
            if (userInfo.DOB.Date > today.AddYears(-age)) age--;
            return age;
        }

        
    }
}
