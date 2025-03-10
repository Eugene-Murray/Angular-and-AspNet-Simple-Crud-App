using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Server.ViewModels;
using UKParliament.CodeTest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UKParliament.CodeTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService) { 
            _personService = personService;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public List<PersonViewModel> Get()
        {
            //return new List<PersonViewModel> {
            //    new PersonViewModel() { FirstName = "Eugene", LastName = "Murray" },
            //    new PersonViewModel() { FirstName = "Bob", LastName = "Dylan" }
            //};

            var people = _personService.Get();
            return people.Select(p => new PersonViewModel() { FirstName = p.FirstName, LastName = p.LastName }).ToList();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(int id)
        {
            var person = _personService.Get(id);

            return Ok(new PersonViewModel() { FirstName = person.FirstName, LastName = person.LastName });
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody]PersonViewModel person)
        {
            _personService.Post(new Person() { FirstName = person.FirstName, LastName = person.LastName });
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PersonViewModel person)
        {
            _personService.Put(id, new Person() { FirstName = person.FirstName, LastName = person.LastName });
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personService.Delete(id);
        }
    }
}
