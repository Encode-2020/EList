using EList.Dto;
using EList.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Profile
{
    public class UserProfile: AutoMapper.Profile
    {
        public UserProfile()
        {
            //Source -> Target
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
