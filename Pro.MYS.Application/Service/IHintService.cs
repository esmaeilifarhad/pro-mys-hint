using Pro.MYS.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application.Service
{
    public interface IHintService
    {
        Task<long> CreateHint(CreateHintDto param);
        Task<long> UpdateHint(CreateHintDto param);
        Task<HintDto> FindHint(long id);
        Task<List<HintDto>> ListHint();
        Task<PaginationOutDto<HintDto>> ListHintPagination(PaginationParamDto param);
        Task<int> DeleteHint(long id);
    }
}
