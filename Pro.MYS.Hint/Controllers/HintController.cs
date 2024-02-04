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


        [HttpPost("CreateUpdate")]

        public async Task<IActionResult> Create([FromBody] CreateHintDto param)
        {
            try
            {
                if (param.Id > 0)
                {
                    var res = await _hintService.UpdateHint(param);
                    return Ok(res);
                }
                else
                {
                    var res = await _hintService.CreateHint(param);
                    return Ok(res);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("Find")]

        public async Task<IActionResult> Find([FromBody] long id)
        {
            try
            {
                var res = await _hintService.FindHint(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("ListHint")]

        public async Task<IActionResult> ListHint()
        {
            try
            {
                var res = await _hintService.ListHint();
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost("ListHintPagination")]

        public async Task<IActionResult> ListHintPagination(PaginationParamDto param)
        {
            try
            {
                var res = await _hintService.ListHintPagination(param);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}



