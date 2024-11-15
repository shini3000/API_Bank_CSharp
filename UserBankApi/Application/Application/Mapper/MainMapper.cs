﻿using AutoMapper;
using UserBankApi.Models.Dto;
using UserBankApi.Models.Entities;

namespace Application.Mapper
{
    public class MainMapper : Profile
    {
        public MainMapper()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
