using AutoMapper;
using Mag.Dtos;
using Mag.Dtos.CategoryDtos;
using Mag.Dtos.ItemDtos;
using Mag.Dtos.LoanHistoryDtos;
using Mag.Dtos.QualityDtos;
using Mag.Dtos.SquadDtos;
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

                    #region CategoryDtos
                        CreateMap<Category, CategoryAddDto>().ReverseMap();
                        CreateMap<Category, CategoryDeleteDto>().ReverseMap();
                        CreateMap<Category, CategoryGetDto>().ReverseMap();
                        CreateMap<Category, CategoryGetIdDto>().ReverseMap();
                        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
                    #endregion

                    #region ItemDtos
                        CreateMap<Item, ItemAddDto>().ReverseMap();
                        CreateMap<Item, ItemDeleteDto>().ReverseMap();
                        CreateMap<Item, ItemGetDto>().ReverseMap();
                        CreateMap<Item, ItemGetIdDto>().ReverseMap();
                        CreateMap<Item, ItemUpdateDto>().ReverseMap();
                    #endregion

                    #region QualityDto
                        CreateMap<Quality, QualityGetDto>().ReverseMap();
                        CreateMap<Quality, QualityGetIdDto>().ReverseMap();
                    #endregion

                    #region LoanHistoryDtos   
                        CreateMap<LoanHistory, LoanHistoryAddDto>().ReverseMap();
                        CreateMap<LoanHistory, LoanHistoryDeleteDto>().ReverseMap();
                        CreateMap<LoanHistory, LoanHistoryGetDto>().ReverseMap();
                        CreateMap<LoanHistory, LoanHistoryGetIdDto>().ReverseMap();
                        CreateMap<LoanHistory, LoanHistoryUpdateDto>().ReverseMap();
            #endregion

                    #region SquadDtos
                        CreateMap<Squad, SquadAddDto>().ReverseMap();
                        CreateMap<Squad, SquadDeleteDto>().ReverseMap();
                        CreateMap<Squad, SquadGetDto>().ReverseMap();                        
                        CreateMap<Squad, SquadGetIdDto>().ReverseMap();
                        CreateMap<Squad, SquadUpdateDto>().ReverseMap();
                    #endregion

                    #region UserDtos
                        CreateMap<User, UserAddDto>().ReverseMap();
                        CreateMap<User, UserDeleteDto>().ReverseMap();
                        CreateMap<User, UserGetDto>().ReverseMap();
                        CreateMap<User, UserGetIdDto>().ReverseMap();
                        CreateMap<User, UserUpdateDto>().ReverseMap();
                    #endregion

                }
        }
}
