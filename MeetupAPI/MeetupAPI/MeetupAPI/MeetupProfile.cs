using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetupAPI.Entities;
using MeetupAPI.Models;

namespace MeetupAPI
{
        public class MeetupProfile : Profile
        {
            public MeetupProfile()
            {
                        CreateMap<Meetup, MeetupDetailsDto>()
                                .ForMember(m => m.City, map => map.MapFrom(meetup => meetup.Location.City))
                                .ForMember(m => m.PostCode, map => map.MapFrom(meetup => meetup.Location.PostCode))
                                .ForMember(m => m.Steet, map => map.MapFrom(meetup => meetup.Location.Steet));

                        CreateMap<MeetupDto, Meetup>();

                        CreateMap<LectureDto, Lecture>()
                                .ReverseMap();

            }

        }
}
