using Repositories;
using System.Text.Json;
using WebAPI;

namespace Service
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public Userreg AddUser(Userreg user)
        {
            return _userRepository.AddUser(user);
        }

        public Userreg GetUser(Userlog user)
        {
            return _userRepository.GetUser(user);
        }

        public void UpdateUser(int id, Userreg user_1)
        {
            _userRepository.UpdateUser(id, user_1);
        }
    }
}
