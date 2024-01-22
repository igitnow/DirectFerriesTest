using DirectFerriesTest.Models;

namespace DirectFerriesTest.Interfaces
{
    public interface IUserProcessor
    {
        public UserResults GetUserResults(UserInfo userInfo);
    }
}
