using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace events_schedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event> { new Event { Id = 1, Title = "Birthday",Start=new DateTime(2023,09,19) } , new Event{Id=2, Title = "Holiday" ,Start = new DateTime(2023, 09, 20) }, new Event { Id = 3, Title = "party" , Start = new DateTime(2023, 09, 21) } } ;
        private static int count = 3;

        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

      
        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve )
        {
           
            events.Add(new Event { Id=count++, Title = eve.Title,Start=eve.Start });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event e)
        {
            var eve = events.Find(e => e.Id == id);

            eve.Title = e.Title;
            eve.Start = e.Start;
            eve.End=e.End;
          
            
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);

        }
    }
}
