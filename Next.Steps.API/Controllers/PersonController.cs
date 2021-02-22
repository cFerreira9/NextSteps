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
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private readonly IMediator _mediator;

        public PersonController(ILogger<PersonController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> GetAll()
        {
            var query = new PersonGetAllQuery();

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

        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetById(int id)
        {
            var query = new PersonGetByIdQuery
            {
                Id = id
            };

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

        [HttpPost()]
        public void Create(PersonDto p)
        {
            var command = new PersonCreateCommand
            {
                Person = p
            };

            var status = _mediator.Send(command);

            Ok(status);
        }

        [HttpPut()]
        public void Put(PersonDto p)
        {
            var command = new PersonUpdateCommand
            {
                Person = p
            };

            var status = _mediator.Send(command);

            Ok(status);
        }

        [HttpDelete()]
        public void Delete(PersonDto p)
        {
            var command = new PersonDeleteCommand
            {
                Person = p
            };

            var status = _mediator.Send(command);

            Ok(status);
        }
    }
}
