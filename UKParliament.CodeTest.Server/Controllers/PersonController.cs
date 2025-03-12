using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.ViewModels;
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
        public ActionResult<List<PersonViewModel>> Get()
        {
            return Ok(_personService.Get());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(int id)
        {
            var person = _personService.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody]PersonViewModel person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newPerson = _personService.Add(person);

                return CreatedAtAction(nameof(Get), new { id = newPerson.Id }, newPerson);
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _personService.Edit(id, person);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // TODO: Log exception / do not return to UI...
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
                return NotFound("Person not found"); 
            }
        }
    }
}
