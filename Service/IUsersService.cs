using WebAPI;

namespace Service
{
    public interface IUsersService
    {
        //Missing ; at the end of this line: the project doesn't build without it
        Userreg AddUser(Userreg user)
        Userreg GetUser(Userlog user);
        void UpdateUser(int id, Userreg user_1);
    }
}