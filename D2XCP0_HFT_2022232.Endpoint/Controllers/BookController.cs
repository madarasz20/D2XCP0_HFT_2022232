using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace D2XCP0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookLogic logic;

        public BookController(IBookLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Create([FromBody] Book value)
        {
            this.logic.Create(value);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public void Update([FromBody] Book value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
