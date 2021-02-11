using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MeetupAPI.Entities;
using System.Threading.Tasks;
using AutoMapper;
using MeetupAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Controllers
{

    [Route("api/meetup")]
    public class MeetupControler : ControllerBase
    {
        private readonly MeetupContext _meetupContext;
        private readonly IMapper _mapper;        

        public MeetupControler(MeetupContext meetupContext,IMapper mapper)
        {
                        _meetupContext = meetupContext;
                        _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<MeetupDetailsDto>> Get()
        {
            var meetups = _meetupContext.Meetups.Include(m=>m.Location).ToList();
            var meetupDtos=_mapper.Map<List<MeetupDetailsDto>>(meetups);                                
            
                        
                        
            return Ok(meetupDtos);
        }
    }
}
