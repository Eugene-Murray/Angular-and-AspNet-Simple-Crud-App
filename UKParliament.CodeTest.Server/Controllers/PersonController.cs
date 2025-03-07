﻿using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Server.ViewModels;
using UKParliament.CodeTest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UKParliament.CodeTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController(IPersonService personService) { }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(int id)
        {
            return Ok(new PersonViewModel() { FirstName = "Eugene", LastName = "Murray" });
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
