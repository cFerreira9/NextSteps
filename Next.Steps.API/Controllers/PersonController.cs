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
        /// <remarks>
        /// Sample:
        ///
        ///     Get /Person
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Success to get all people.</response>
        [HttpGet]
        [ProducesResponseType(200)]
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
        /// <remarks>
        /// Sample:
        ///
        ///     Get /Person/1
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success to get the person by the Id.</response>
        /// <response code="400">Invalid Id! The Id must be greater than 0.</response>
        /// <response code="404">Not found! There's no one with that id.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        /// <remarks>
        /// Sample:
        ///
        ///     Post /Person
        ///
        ///     {
        ///         "firstName": "Carlos",
        ///         "lastName": "Ferreira",
        ///         "profession": "Developer",
        ///         "birthdate": "1999-05-08",
        ///         "email": "carlos.ferreira@decode.pt",
        ///         "hobbies": [
        ///             {
        ///                 "name": "Pescar",
        ///                 "type": "Desporto Radical"
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <param name="p">Pessoa</param>
        /// <returns></returns>
        /// <response code="200">Success to create the person.</response>
        /// <response code="400">Couldn't create! Invalid parameters! Check the example.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
        /// <remarks>
        /// Sample:
        ///
        ///     Update /Person
        ///
        ///     {
        ///         "Id": "1",
        ///         "firstName": "Carlos",
        ///         "lastName": "Ferreira",
        ///         "profession": "Developer",
        ///         "birthdate": "1999-05-08",
        ///         "email": "carlos.ferreira@decode.pt",
        ///         "hobbies": [
        ///             {
        ///                 "name": "Pescar",
        ///                 "type": "Desporto Radical"
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <response code="200">Success to create the person.</response>
        /// <response code="400">Couldn't create! Invalid parameters! Check the example.</response>
        /// <response code="404">Not found! There's no one with that id.</response>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        /// <remarks>
        /// Sample:
        ///
        ///     Delete /Person/1
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success to delete the person.</response>
        /// <response code="400">Couldn't delete! Invalid Id! Check the Id, must be greater than 0.</response>
        /// <response code="404">Not found! There's no one with that id.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        /// <remarks>
        /// Sample:
        ///
        ///     Get /Search
        ///
        /// </remarks>
        /// <param name="firstName">Firstname to search</param>
        /// <param name="lastName">Lastname to search</param>
        /// <returns></returns>
        /// <response code="200">Success to search the person by firstname or lastname.</response>
        /// <response code="400">Couldn't search! Invalid firstname or lastname! Check the parametes, must be a valid name.</response>
        /// <response code="404">Not found! There's no one with that firstname or lastname.</response>
        [HttpGet("/[Action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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