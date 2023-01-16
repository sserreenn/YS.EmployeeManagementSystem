using AutoMapper;
using EMS.Core.Extensions;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace EMS.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CompanyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        { 
            var includes = new List<string> { "Branches" };

            var query = new GetCompanyQuery(c => c.Status == true, includes);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
