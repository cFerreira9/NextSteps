using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Next.Steps.Domain.Entities;
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

        public PersonController(ILogger<PersonController> logger)
        {
           _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            var list = new List<Person>();

            //_logger.LogInformation("");

            //if (list == null)
            //{
            //    _logger.LogWarning("");
            //    return NotFound();
            //}
            return list;
        }

        [HttpGet("{id}")]
        public Person GetById(int id)
        {
            return null;
        }

        [HttpPost]
        public void Post(Person p)
        {
        }

        [HttpPut("{id}")]
        public void Put(Person p)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(Person p)
        {

        }
    }
}
