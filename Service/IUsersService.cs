using WebAPI;

namespace Service
{
    public interface IUsersService
    {
        Userreg AddUser(Userreg user)
        Userreg GetUser(Userlog user);
        void UpdateUser(int id, Userreg user_1);
    }
}