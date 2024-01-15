using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Localizations.Queries.GetLocalizationQueryList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [HttpGet("all", Name = "GetAllCities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CityListVm>>> GetAllCities()
        {
            var dtos = await _mediator.Send(new GetCityListQuery());
            return Ok(dtos);
        }

        ////[Authorize]
        //[HttpGet("all", Name = "GetAllCounties")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<List<CountyListVm>>> GetAllCounties()
        //{
        //    var dtos = await _mediator.Send(new GetCountyListQuery());
        //    return Ok(dtos);
        //}
    }
}
