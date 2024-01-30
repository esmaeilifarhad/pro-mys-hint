using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application.Dto
{
    public class HintDto
    {
        public long Id { get; set; }
        public DateTime? RefreshDate { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public string? Title { get; set; }
    }
}
