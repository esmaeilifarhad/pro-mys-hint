using AutoMapper;
using Pro.MYS.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Domains.Hint, CreateHintDto>().ReverseMap();
        }
    }
}
