﻿using D2XCP0_HFT_2022232.Endpoint.Services;
using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace D2XCP0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IGenreLogic logic;
        IHubContext<SignalRHub> hub;
        public GenreController(IGenreLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Genre> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Genre Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Genre value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("GenreCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Genre value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("GenreUpdated", value);
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var genreToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("GenreDeleted", genreToDelete);
        }
    }
}
