﻿using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace D2XCP0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IGenreLogic logic;

        public GenreController(IGenreLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IEnumerable<Genre> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public Genre Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<GenreController>
        [HttpPost]
        public void Create([FromBody] Genre value)
        {
            this.logic.Create(value);
        }

        // PUT api/<GenreController>/5
        [HttpPut]
        public void Update([FromBody] Genre value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
