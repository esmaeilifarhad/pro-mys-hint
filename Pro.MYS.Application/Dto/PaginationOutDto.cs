using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application.Dto
{
    public class PaginationOutDto<T> 
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public int CountRecord { get; set; }

        public List<T> ListData { get; set; }
    }
}
