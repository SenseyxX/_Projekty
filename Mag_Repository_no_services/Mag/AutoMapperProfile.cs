using AutoMapper;
using Mag.Dtos;
using Mag.Dtos.ItemDtos;
using Mag.Dtos.UserDtos;
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
                    #region UserDtos
                        CreateMap<User, UserAddDto>().ReverseMap();
                        CreateMap<User, UserDeleteDto>().ReverseMap();
                        CreateMap<User, UserGetDto>().ReverseMap();
                        CreateMap<User, UserGetIdDto>().ReverseMap();
                        CreateMap<User, UserUpdateDto>().ReverseMap();
                    #endregion

                    #region ItemDtos
                        CreateMap<Item, ItemAddDto>().ReverseMap();
                        CreateMap<Item, ItemDeleteDto>().ReverseMap();
                        CreateMap<Item, ItemGetDto>().ReverseMap();
                        CreateMap<Item, ItemGetIdDto>().ReverseMap();
                        CreateMap<Item, ItemUpdateDto>().ReverseMap();
                    #endregion
        }
    }
}
