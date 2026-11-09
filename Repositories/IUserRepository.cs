using WebAPI;

namespace Repositories
{
    public interface IUserRepository
    {
        Userreg AddUser(Userreg user);
        Userreg GetUser(Userlog user);
        void UpdateUser(int id, Userreg user_1)
    }
}