using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Localizations.Queries.GetLocalizationQueryList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocalizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("allCities", Name = "GetAllCities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CityListVm>>> GetAllCities()
        {
            var dtos = await _mediator.Send(new GetCityListQuery());
            return Ok(dtos);
        }

        //[Authorize]
        [HttpGet("allCounties", Name = "GetAllCounties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CountyListVm>>> GetAllCounties(int cityId)
        {
            var dtos = await _mediator.Send(new GetCountyListQuery());
            dtos = dtos.Where(a=>a.CityId == cityId).ToList();
            return Ok(dtos);
        }
    }
}
