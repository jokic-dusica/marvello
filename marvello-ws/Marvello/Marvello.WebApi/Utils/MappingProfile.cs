using AutoMapper;
using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvello.WebApi.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectType, ProjectTypeDTO>();
            CreateMap<ProjectUser, ProjectUserDTO>();
            CreateMap<Data.Entities.Task, TaskDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<RefreshToken, RefreshTokenDTO>();

            CreateMap<CommentDTO, Comment>();
            CreateMap<ProjectDTO, Project> ();
            CreateMap<ProjectTypeDTO, ProjectType>();
            CreateMap<ProjectUserDTO, ProjectUser>();
            CreateMap<TaskDTO, Data.Entities.Task>();
            CreateMap<UserDTO, User>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<RefreshTokenDTO, RefreshToken>();
        }
    }
}
