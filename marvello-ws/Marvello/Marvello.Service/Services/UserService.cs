using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Marvello.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll()
        {
           return (List<User>)await _userRepository.GetAll();
        }

        public async Task<User> GetOne(long id)
        {
            return await _userRepository.GetOne(id);
        }

        public async Task<User> Save(User entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await _userRepository.Save(entity);
            return entity;
        }

        public async Task<User> Update(User entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            await _userRepository.Update(entity);
            return entity;
        }
        public async System.Threading.Tasks.Task Delete(User entity)
        {
            await _userRepository.Delete(entity);
        }
    }
}
