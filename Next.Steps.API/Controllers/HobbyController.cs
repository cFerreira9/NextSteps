using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dto;
using Next.Steps.Application.Query;
using System.Collections.Generic;

namespace Next.Steps.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private readonly IMediator _mediator;

        public HobbyController(ILogger<PersonController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HobbyDto>> GetAll()
        {
            var query = new HobbyGetAllQuery();

            var response = _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public void Create(HobbyDto h)
        {
            var command = new HobbyCreateCommand
            {
                Hobby = h
            };

            var status = _mediator.Send(command);

            Ok(status);
        }

        [HttpPut]
        public void Put(HobbyDto h)
        {
            var command = new HobbyUpdateCommand
            {
                Hobby = h
            };

            var status = _mediator.Send(command);

            Ok(status);
        }

        [HttpDelete]
        public void Delete(HobbyDto h)
        {
            var command = new HobbyDeleteCommand
            {
                Hobby = h
            };

            var status = _mediator.Send(command);

            Ok(status);
        }
    }
}