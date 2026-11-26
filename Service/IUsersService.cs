using WebAPI;

namespace Service
{
    public interface IUsersService
    {
        Task<Userreg> GetAsync(int id);
        Task<Userreg> PostAsync(Userreg user);
        Task<Userreg> PostLoginAsync(Userlog user);
        Task PutAsync(int id, Userreg user_1);
    }
}