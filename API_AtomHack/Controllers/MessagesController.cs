using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json.Linq;
using API_AtomHack.Model;
using API_AtomHack.ViewModel;

namespace API_AtomHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MessagesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }


        
        [HttpPost]
        public async Task<ActionResult<string>> PostMessage(Request request)
        {
            
            string responseString;

            using (var client = new HttpClient())

            {
                var obj = new
                {
                    requestMessage = (string)request.requestMessage
                };

                var response = await client.PostAsJsonAsync("http://158.160.44.53/getResponseFromTheModel", obj);

                responseString = await response.Content.ReadAsStringAsync();
                responseString = System.Text.RegularExpressions.Regex.Unescape(responseString);

            }
            var user = await _context.Users.FindAsync(request.UserId);
            var message = new Message { };
            message.Content = request.requestMessage;
            message.DataCreated = DateTime.Now;
            message.Response = responseString;
            message.AI = true;
            message.UserId = user.Id;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            var userHistory = new userHistory { Case = 5, messageId= (int)message.Id, UserId=user.Id, DateTime=DateTime.Now  };
            _context.userHistories.Add(userHistory);

            await _context.SaveChangesAsync();

            return responseString;
        }
    }
}
