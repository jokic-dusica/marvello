using AutoMapper;
using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
using Marvello.Service.Enums;
using Marvello.Service.Interfaces;
using Marvello.Service.Utils;
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

        public async Task <ResponseWrapper<List<UserDTO>>> GetAll()
        {
            try
            {
                var listUser = await _userRepository.GetAll();
                var listUserDTOs = _mapper.Map<List<UserDTO>>(listUser);
                var response = new ResponseWrapper<List<UserDTO>>()
                {
                    ResponseData = listUserDTOs,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<List<UserDTO>>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }

        public async Task <ResponseWrapper<UserDTO>> GetOne(long id)
        {
            try
            {
                var oneUser = await _userRepository.GetOne(id);
                var oneUserDTO = _mapper.Map<UserDTO>(oneUser);
                var response = new ResponseWrapper<UserDTO>()
                {
                    ResponseData = oneUserDTO,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<UserDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
        }
            

        public async Task <ResponseWrapper<UserDTO>> Save(UserDTO entity)
        {
            try
            {
                var saveUser = _mapper.Map<User>(entity);
                saveUser.CreatedOn = DateTime.UtcNow;
                await _userRepository.Save(saveUser);

                entity = _mapper.Map<UserDTO>(saveUser);
                var response = new ResponseWrapper<UserDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<UserDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }

        public async Task <ResponseWrapper<UserDTO>> Update(UserDTO entity)
        {
            try
            {
                var updateUser = _mapper.Map<User>(entity);
                updateUser.ModifiedOn = DateTime.UtcNow;
                await _userRepository.Update(updateUser);

                entity = _mapper.Map<UserDTO>(updateUser);
                var response = new ResponseWrapper<UserDTO>()
                {
                    ResponseData = entity,
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<UserDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }
        public async System.Threading.Tasks.Task <ResponseWrapper<UserDTO>> Delete(UserDTO entity)
        {
            try
            {
                var deleteUser = _mapper.Map<User>(entity);
                await _userRepository.Delete(deleteUser);
                var response = new ResponseWrapper<UserDTO>()
                {
                    ResponseData = _mapper.Map<UserDTO>(deleteUser),
                    IsSuccess = true
                };
                return response;
            }
            catch
            {
                var response = new ResponseWrapper<UserDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.ServerError),
                    IsSuccess = false
                };
                return response;
            }
            
        }
    }
}
