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
    public class HobbyController : Controller
    {
        private readonly ILogger<HobbyController> _logger;

        private readonly IMediator _mediator;

        public HobbyController(ILogger<HobbyController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
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
        public IActionResult Create(HobbyDto h)
        {
            var command = new HobbyCreateCommand
            {
                Hobby = h
            };

            var status = _mediator.Send(command);

            return Ok(status);
        }

        [HttpPut]
        public IActionResult Put(HobbyDto h)
        {
            var command = new HobbyUpdateCommand
            {
                Hobby = h
            };

            var status = _mediator.Send(command);

            return Ok(status);
        }

        [HttpDelete]
        public IActionResult Delete(HobbyDto h)
        {
            var command = new HobbyDeleteCommand
            {
                Hobby = h
            };

            var status = _mediator.Send(command);

            return Ok(status);
        }
    }
}