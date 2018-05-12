using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;

namespace JobsMe.BotApp.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = JobsMe.BotApp.Models.Bot.Commands;
            Trace.TraceError("Controller method started...");
            try
            {
                var message = update.Message;
                var client = await JobsMe.BotApp.Models.Bot.Get();

                foreach (var command in commands)
                {
                    if (command.Contains(message.Text))
                    {
                        command.Execute(message, client);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
               Trace.TraceError(e.Message);
                throw;
            }
            
           
            return Ok();
        }
       
    }
}
