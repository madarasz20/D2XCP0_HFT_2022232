using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace D2XCP0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorLogic logic;

        public AuthorController(IAuthorLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> ReadAll()
        {
            return this.logic.ReadAll();    
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Create([FromBody] Author value)
        {
            this.logic.Create(value);
        }

        // PUT api/<AuthorController>/5
        [HttpPut]
        public void Update([FromBody] Author value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
