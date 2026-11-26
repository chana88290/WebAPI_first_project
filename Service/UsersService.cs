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

        public async Task<Userreg> GetAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<Userreg> PostAsync(Userreg user)
        {
            return await _userRepository.PostAsync(user);
        }

        public async Task<Userreg> PostLoginAsync(Userlog user)
        {
            return await _userRepository.PostLoginAsync(user);
        }

        public async Task PutAsync(int id, Userreg user_1)
        {
            await _userRepository.PutAsync(id, user_1);
        }
    }
}
