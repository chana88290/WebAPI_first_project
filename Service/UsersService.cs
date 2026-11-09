using Repositories;
using System.Text.Json;
using WebAPI;

namespace Service
{
    public class UsersService
    {
        UserRepository userRepository = new UserRepository();

        public Userreg AddUser(Userreg user)
        {
            return userRepository.AddUser(user);
        }

        public Userreg GetUser(Userlog user)
        {
            return userRepository.GetUser(user);
        }

        public void UpdateUser(int id, Userreg user_1)
        {
            userRepository.UpdateUser(id, user_1);
        }
    }
}
