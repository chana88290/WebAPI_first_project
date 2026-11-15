using WebAPI;

namespace Repositories
{
    public interface IUserRepository
    {
        Userreg AddUser(Userreg user);
        Userreg GetUser(Userlog user);
        //fix: added the missing semicolon, the interface did not compile
        void UpdateUser(int id, Userreg user_1);
    }
}