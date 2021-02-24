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
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;

        private readonly IMediator _mediator;

        public PersonController(ILogger<PersonController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<PersonReadDto>> GetAll()
        {
            var query = new PersonGetAllQuery();

            var response = _mediator.Send(query).Result;

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        /// <summary>
        /// Get Person by Id
        /// </summary>
        /// <param name="id">1</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<PersonReadDto> GetById(int id)
        {
            var query = new PersonGetByIdQuery
            {
                Id = id
            };

            var response = _mediator.Send(query).Result;

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        /// <summary>
        /// Create Person
        /// </summary>
        /// <param name="p">Pessoa</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(PersonWriteDto p)
        {
            var command = new PersonCreateCommand
            {
                Person = p
            };

            var response = _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put(PersonReadDto p)
        {
            var command = new PersonUpdateCommand
            {
                Person = p
            };

            var status = _mediator.Send(command);

            return Ok(status);
        }

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(PersonReadDto p)
        {
            var command = new PersonDeleteCommand
            {
                Person = p
            };

            var status = _mediator.Send(command);

            return Ok(status);
        }

        /// <summary>
        /// Search person by firstname or lastname
        /// </summary>
        /// <param name="firstName">Carlos</param>
        /// <param name="lastName">Ferreira</param>
        /// <returns></returns>
        [HttpGet("/search")]
        public IActionResult Search(string firstName, string lastName = "")
        {
            var query = new PersonSearchQuery();

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
    }
}