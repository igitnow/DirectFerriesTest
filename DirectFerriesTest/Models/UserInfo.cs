using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DirectFerriesTest.Models
{
    public class UserInfo
    {
        [DisplayName("Full Name")]
        public string FullName { get; set; } = string.Empty;
        

        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; } = DateTime.MinValue;
        
        
        

    }
}
