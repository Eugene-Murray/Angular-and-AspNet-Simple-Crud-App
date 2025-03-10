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
            var people = _personService.Get();
            return people.Select(p => new PersonViewModel() { 
                Id = p.Id, 
                FirstName = p.FirstName, 
                LastName = p.LastName, 
                DepartmentId = p.DepartmentId 
            }).ToList();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(int id)
        {
            var person = _personService.Get(id);

            return Ok(new PersonViewModel() { 
                Id = person.Id, 
                FirstName = person.FirstName, 
                LastName = person.LastName,
                DOB = person.DOB,
                DepartmentId = person.DepartmentId
            });
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody]PersonViewModel person)
        {
            try
            {
                _personService.Post(new Person() { 
                    FirstName = person.FirstName, 
                    LastName = person.LastName,
                    DOB = person.DOB,
                    DepartmentId = person.DepartmentId
                });

                return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PersonViewModel person)
        {
            try
            {
                _personService.Put(id, new Person() { 
                    FirstName = person.FirstName, 
                    LastName = person.LastName,
                    DOB = person.DOB,
                    DepartmentId = person.DepartmentId
                });

                return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _personService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
