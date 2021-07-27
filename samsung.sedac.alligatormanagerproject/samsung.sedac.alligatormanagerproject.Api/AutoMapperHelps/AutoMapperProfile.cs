using AutoMapper;
using samsung.sedac.alligatormanagerproject.Api.DTO;
using samsung.sedac.alligatormanagerproject.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace samsung.sedac.alligatormanagerproject.Api.AutoMapperHelps
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Users, LoginUserDto>().ReverseMap();
        }
    }
}
