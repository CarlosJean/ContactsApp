using ContactsApp.Abtracts;
using ContactsApp.DTOs;
using ContactsApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase {
        IContactRepository repository;
        public ContactController(IContactRepository contactRepository ) {
            repository = contactRepository;
        }
        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<Contact> Get() {
            return this.repository.Contacts;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return JsonConvert.SerializeObject(this.repository.Contact(id));
        }
        

        // POST api/<ContactController>
        [HttpPost]
        public ActionResult Post([FromBody] ContactDTO contactDTO) {
            var response = this.repository.Save(contactDTO);
            return Ok(response);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ContactDTO contactDTO) {
            var response = this.repository.Update(id,contactDTO);
            return Ok(response);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {            
            var response = this.repository.Delete(id);
            return Ok(response);
        }
    }
}
