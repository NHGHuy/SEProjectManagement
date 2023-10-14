using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private static ITopicRepository repository = new TopicRepository();
        private static SEProjectManagementContext _context = new SEProjectManagementContext();

        // GET: api/<TopicController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            var listTopic = repository.GetTopic();

            if (listTopic == null)
            {
                return NotFound();
            }
            return listTopic;
        }

        // GET api/<TopicController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetTopic(int id)
        {
            Topic topic = repository.GetTopicByID(id);

            if (topic == null)
            {
                return NotFound();
            }
            return topic;
        }

        // POST api/<TopicController>
        [HttpPost]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            if (topic == null)
            {
                return Problem("Entity set 'MyStoreContext.Products'  is null.");
            }
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopic", new { id = topic.TopicId }, topic);
        }

        // PUT api/<TopicController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, Topic topic)
        {
            if (id != topic.TopicId)
            {
                return BadRequest();
            }

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<TopicController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            if (_context.Topics == null)
            {
                return NotFound();
            }
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TopicExists(int id)
        {
            return (_context.Topics?.Any(e => e.TopicId == id)).GetValueOrDefault();
        }
    }
}
