using AutoMapper;
using Pro.MYS.Application.Dto;
using Pro.MYS.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application.Service
{
    public class HintService : IHintService
    {
        public IHintRepository _hintRepository { get; }
        public IMapper _mapper { get; }

        public HintService(IHintRepository hintRepository, IMapper mapper)
        {
            _hintRepository = hintRepository;
            _mapper = mapper;
        }


        public async Task<long> CreateHint(CreateHintDto param)
        {
            var newHint = _mapper.Map<Domains.Hint>(param);
            var res = await _hintRepository.Insert(newHint);
            return res.Id;
        }

        public async Task<long> UpdateHint(CreateHintDto param)
        {
            var old = await _hintRepository.GetById(param.Id);
            if (old == null)
            {
                throw new ArgumentException("موردی برای ویرایش یافت نشد");
            }
            old.Title = param.Title;
            old.Description = param.Description;
            var res = await _hintRepository.Update(old);
            return res;
        }

        public async Task<HintDto> FindHint(long id)
        {
            var old = await _hintRepository.GetById(id);
            var hint = _mapper.Map<HintDto>(old);
            return hint;
        }

        public async Task<List<HintDto>> ListHint()
        {
            var data = await _hintRepository.GetAll();

            var lstHint = _mapper.Map<List<HintDto>>(data);

            return lstHint;
        }
    }
}
