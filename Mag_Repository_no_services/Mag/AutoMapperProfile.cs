﻿using AutoMapper;
using Mag.Dtos;
using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag
{
        public class AutoMapperProfile:Profile
        {
                public AutoMapperProfile()
                {
                        CreateMap<User, UserDto>().ReverseMap();
                }
        }
}
