using AlbertslundForsyning.Repositories;
using AlbertslundForsyning.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AlbertslundForsyning.Service
{
    public class UserService
    {
        Repositories.UserRepository userRepo = new Repositories.UserRepository();

        public async Task<User> Create(User user)
        {
            return await userRepo.Create(user);
        }

        public User ValidateLogin(User user)
        {
            return userRepo.ValidateLogin(user);
            
        }

        public async Task<List<User>> GetAll()
        {
            return await userRepo.GetAll();
        }
    }
    
}