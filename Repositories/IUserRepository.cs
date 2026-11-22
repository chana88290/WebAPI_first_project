using WebAPI;

namespace Repositories
{
    public interface IUserRepository
    {
        Userreg AddUser(Userreg user);
        Userreg GetUser(Userlog user);
        //Missing ; at the end of this line: the project doesn't build without it
        void UpdateUser(int id, Userreg user_1)
    }
}