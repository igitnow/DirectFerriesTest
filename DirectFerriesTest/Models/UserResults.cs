using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DirectFerriesTest.Models
{
    public class UserResults
    {
        public string FirstName { get; set; }
        public int VowelsCount { get; set; }
        public int Age { get; set; }
        public int DaysToBirthday { get; set; }
        public DateTime DOB { get; set; }

    }
}
