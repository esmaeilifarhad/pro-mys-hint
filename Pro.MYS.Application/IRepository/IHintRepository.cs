
using Pro.MYS.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application.IRepository
{
    public interface IHintRepository : IRepositoryGeneric<Domains.Hint>
    {
       Task<PaginationOutDto<Domains.Hint>> ListHintPagination(PaginationParamDto param);
    }
}
