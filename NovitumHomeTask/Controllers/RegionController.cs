using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCruitChallenge.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NovitumHomeTask.Logic;
using NovitumHomeTask.Model;

namespace NovitumHomeTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionLogic _regionLogic;

        public RegionController(IRegionLogic regionLogic)
        {
            _regionLogic = regionLogic;
        }

        [HttpGet]
        [Route("novadi/")]
        public IActionResult FilterNovadsList([FromQuery] FilterParameters filterParams)
        {
            if (filterParams.IsValid(out IEnumerable<string> errors))
            {
                var result = _regionLogic.FilterNovadsList(filterParams);

                return Ok(result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpGet]
        [Route("novadi/{novadsId}/pagasti/")]
        public IActionResult FilterPagastsList([FromRoute] int novadsId, [FromQuery] FilterParameters filterParams)
        {
            if (filterParams.IsValid(out IEnumerable<string> errors))
            {
                var result = _regionLogic.FilterPagastsList(novadsId, filterParams);

                return Ok(result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpGet]
        [Route("novadi/{novadsId}/pagasti/{pagastsId}/polygon")]
        public IActionResult FilterPolygonList([FromRoute] int novadsId, [FromRoute]int pagastsId, [FromQuery] FilterParameters filterParams)
        {
            if (filterParams.IsValid(out IEnumerable<string> errors))
            {
                var result = _regionLogic.FilterPolygonList(novadsId, pagastsId, filterParams);

                return Ok(result);
            }
            else
            {
                return BadRequest(errors);
            }
        }
    }
}
