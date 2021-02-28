using AutoMapper;
using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
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
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var listUser = await _userRepository.GetAll();
            var listUserDTOs = _mapper.Map<List <UserDTO>>(listUser);
            return listUserDTOs;
        }

        public async Task<UserDTO> GetOne(long id)
        {
            var oneUser = await _userRepository.GetOne(id);
            var oneUserDTO = _mapper.Map<UserDTO>(oneUser);
            return oneUserDTO;
        }

        public async Task<UserDTO> Save(UserDTO entity)
        {
            var saveUser = _mapper.Map<User>(entity);
            saveUser.CreatedOn = DateTime.UtcNow;
            await _userRepository.Save(saveUser);

            entity = _mapper.Map<UserDTO>(saveUser);
            return entity;
        }

        public async Task<UserDTO> Update(UserDTO entity)
        {
            var updateUser = _mapper.Map<User>(entity);
            updateUser.ModifiedOn = DateTime.UtcNow;
            await _userRepository.Update(updateUser);

            entity = _mapper.Map<UserDTO>(updateUser);
            return entity;
        }
        public async System.Threading.Tasks.Task Delete(UserDTO entity)
        {
            var deleteUser = _mapper.Map<User>(entity);
            await _userRepository.Delete(deleteUser);
        }
    }
}
