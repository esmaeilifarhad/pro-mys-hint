using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pro.MYS.Application.Dto;
using Pro.MYS.Application.Service;

namespace Pro.MYS.Hint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HintController : ControllerBase
    {
        public IHintService _hintService { get; }

        public HintController(IHintService hintService)
        {
            _hintService = hintService;
        }


        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] CreateHintDto param)
        {
            try
            {
                var res=await _hintService.CreateHint(param);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
