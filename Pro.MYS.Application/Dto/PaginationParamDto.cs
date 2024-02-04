using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application.Dto
{
    public class PaginationParamDto
    {
     
        public string? Search { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
