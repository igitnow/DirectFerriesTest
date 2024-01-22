using DirectFerriesTest.Models;

namespace DirectFerriesTest.Interfaces
{
    public interface IValidation
    {
        public (List<string>, bool) ValidUserInfo(UserInfo userInfo);
        public (string, bool) ValidName(string fullName);
        public (string, bool) ValidDOB(DateTime dob);
    }
}
