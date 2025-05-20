using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Dto.Response;
using AuthSystem.Model;
using AutoMapper;

namespace AuthSystem.Service
{

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Users, UserResponse>();
        }
    }
}

