using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApiLab.API.Models;

namespace WebApiLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {

        private List<Person> People { get; set; } = new List<Person>();

        public PeopleController()
        {
            string jsonFile = System.IO.File.ReadAllText("./Resources/64KB.json");
            var peopleData = JsonSerializer.Deserialize<List<Person>>(
                jsonFile,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (peopleData != null)
            {
                People = peopleData;
            } 
        }
        
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(string id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}

