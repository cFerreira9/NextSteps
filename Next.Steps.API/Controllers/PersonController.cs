using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Next.Steps.Domain.Entities;
using Next.Steps.Repository.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Next.Steps.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private readonly FakeRepo _frepo = new FakeRepo();

        public PersonController(ILogger<PersonController> logger)
        {
           _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var personCommand = _frepo.GetAll();

            if (personCommand == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(personCommand);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var personCommand = _frepo.GetByID(id);

            if (personCommand != _frepo.GetByID(id))
            {
                return NotFound();
            }
            else
            {
                return Ok(personCommand);
            }
        }

        [HttpPost()]
        public void Create(Person p)
        {
            var personCommand = _frepo.Create(p);

            if (personCommand != true)
            {
                _logger.LogError("COULDN'T CREATE!");
            }
            else
            {
                Ok(personCommand);
            }
        }

        [HttpPut("{id}")]
        public void Put(Person p)
        {
            var personCommand = _frepo.Update(p);

            if (personCommand != true)
            {
                _logger.LogError("COULDN'T UPDATE!");
            }
            else
            {
                Ok(personCommand);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(Person p)
        {
            var personCommand = _frepo.Delete(p);

            if (personCommand != true)
            {
                _logger.LogError("COULDN'T REMOVE!");
            }
            else
            {
                _logger.LogWarning("PERSON WILL BE DELETED!");

                Ok(personCommand);
            }
        }
    }
}
