﻿using AutoMapper;
using Core.DTO;
using Core.Entities.UserEntity;

namespace Core.Helpers.ApplicationProfiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserRegistrationDTO>().ReverseMap();
            CreateMap<User, UserRegistrationDTO>().ReverseMap()
                .ForMember(dest => dest.UserName,
                    act => act.MapFrom(src => src.Email));
            CreateMap<User, UserProfileInfoDTO>().ReverseMap();
            CreateMap<User, UserFullNameDTO>();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
