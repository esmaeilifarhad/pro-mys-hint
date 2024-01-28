using AutoMapper;
using Pro.MYS.Application.Dto;
using Pro.MYS.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application.Service
{
    public class HintService : IHintService
    {
        public IHintRepository _hintRepository { get; }
        public IMapper _mapper { get; }

        public HintService(IHintRepository hintRepository,IMapper mapper)
        {
            _hintRepository = hintRepository;
            _mapper = mapper;
        }


        public async Task<long> CreateHint(CreateHintDto param)
        {
           var newHint =  _mapper.Map<Domains.Hint>(param);
            //Domains.Hint newHint=new Domains.Hint() { 
            //Title=param.Title,
            //Description=param.Description
            //};
            var res=await _hintRepository.Insert(newHint);
            return res.Id;
        }
    }
}
