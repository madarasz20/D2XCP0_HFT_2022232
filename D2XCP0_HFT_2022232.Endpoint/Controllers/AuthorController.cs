using D2XCP0_HFT_2022232.Endpoint.Services;
using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace D2XCP0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorLogic logic;
        IHubContext<SignalRHub> hub;
        public AuthorController(IAuthorLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Author> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Author value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("AuthorCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Author value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AuthorUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var authorToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AuthorDeleted", authorToDelete);
        }
    }
}
