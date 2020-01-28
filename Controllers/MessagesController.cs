using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private MessageBoardContext _db;

        public MessagesController(MessageBoardContext db)
        {
            _db = db;
        }

        // GET api/messages
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get(string subject, string user, string date)
        {
            var query = _db.Messages.AsQueryable();

            if(subject != null)
            {
                query = query.Where(entry => entry.Subject == subject);
            }

            if(user != null)
            {
                query = query.Where(entry => entry.User == user);
            }

            if(date != null)
            {
                query = query.Where(entry => entry.Date == date);
            }

            return query.ToList();
        }
        // POST api/messages
        [HttpPost]
        public void Post([FromBody] Message message)
        {
            _db.Messages.Add(message);
            _db.SaveChanges();
        }

        // GET api/messages/5
        [HttpGet("{id}")]
        public ActionResult<Message> Get(int id)
        {
            return _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
        }

      

        // PUT api/messages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Message message)
        {
            message.MessageId = id;
            _db.Entry(message).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/messages/2/doug
        [HttpDelete("{id}/{user}")]
        public void Delete(int id, string user)
        {
            var messageToDelete = _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
            if(messageToDelete.User == user)
            {
                _db.Messages.Remove(messageToDelete);
                _db.SaveChanges();
            }
        }
    }
}
