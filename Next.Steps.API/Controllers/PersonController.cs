using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dto;
using Next.Steps.Application.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// Get All People
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsyn()
        {
            var query = new PersonGetAllQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        /// <summary>
        /// Get Person by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new PersonGetByIdQuery
            {
                Id = id
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        /// <summary>
        /// Create Person
        /// </summary>
        /// <param name="p">Pessoa</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(PersonWriteDto p)
        {
            var command = new PersonCreateCommand
            {
                Person = p
            };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync(PersonUpdateDto p)
        {
            var command = new PersonUpdateCommand
            {
                Person = p
            };

            var status = await _mediator.Send(command);

            return Ok(status);
        }

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new PersonDeleteCommand
            {
                Id = id
            };

            var status = await _mediator.Send(command);

            return Ok(status);
        }

        /// <summary>
        /// Search person by firstname or lastname
        /// </summary>
        /// <param name="firstName">Firstname to search</param>
        /// <param name="lastName">Lastname to search</param>
        /// <returns></returns>
        [HttpGet("/[Action]")]
        public async Task<IActionResult> SearchAsync(string firstName, string lastName)
        {
            var query = new PersonSearchQuery
            {
                Firstname = firstName,
                Lastname = lastName
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}