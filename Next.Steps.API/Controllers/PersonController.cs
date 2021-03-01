using MediatR;
using Microsoft.AspNetCore.Mvc;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dto;
using Next.Steps.Application.Query;
using Serilog;
using System.Threading.Tasks;

namespace Next.Steps.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get All People
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new PersonGetAllQuery();

            var response = await _mediator.Send(query);

            Log.Information("GetAll executado com sucesso.");
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
            if (id <= 0)
            {
                Log.Error("Id invalido: " + id);
                return BadRequest();
            }

            var query = new PersonGetByIdQuery
            {
                Id = id
            };

            var response = await _mediator.Send(query);

            Log.Information("GetById executado com sucesso.");
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
            if (p == null)
            {
                Log.Error("Objeto Person é null.");
                return BadRequest();
            }

            var command = new PersonCreateCommand
            {
                Person = p
            };

            var response = await _mediator.Send(command);

            Log.Information("Person criado com sucesso.");
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
            if (p == null)
            {
                Log.Error("Erro ao dar update.");
                return BadRequest();
            }

            var command = new PersonUpdateCommand
            {
                Person = p
            };

            var status = await _mediator.Send(command);

            Log.Information("Person atualizada com sucesso.");
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
            if (id <= 0)
            {
                Log.Error("Id invalido: " + id);
                return BadRequest();
            }

            var command = new PersonDeleteCommand
            {
                Id = id
            };

            var status = await _mediator.Send(command);

            Log.Information("Person removida com sucesso.");
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

            Log.Information("Search executado com sucesso.");
            return Ok(response);
        }
    }
}