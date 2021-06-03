using ContactsApp.Abtracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : ControllerBase {
        IContactTypeRepository repository;
        public ContactTypeController(IContactTypeRepository contactTypeRepository) {
            repository = contactTypeRepository;
        }
        // GET: api/<ContactTypeController>
        [HttpGet]
        public ActionResult Get() {
            try {
                return Ok(this.repository.ContactTypes);
            } catch (Exception) {
                return BadRequest();                     
            }
        }

        //// GET api/<ContactTypeController>/5
        //[HttpGet("{id}")]
        //public string Get(int id) {
        //    return "value";
        //}

        //// POST api/<ContactTypeController>
        //[HttpPost]
        //public void Post([FromBody] string value) {
        //}

        //// PUT api/<ContactTypeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value) {
        //}

        //// DELETE api/<ContactTypeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id) {
        //}
    }
}
