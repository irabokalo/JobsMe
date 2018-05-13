using System;
using System.Diagnostics;
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
            Trace.TraceError("Controller method started...");

            //Let`s left this code here if in future any problem arise

            //var req = this.Request.Content.ReadAsStreamAsync().Result;
            //req.Seek(0, SeekOrigin.Begin);
            //string json = new StreamReader(req).ReadToEnd();
            //Trace.TraceError("Json: " + json);
            //update = JsonConvert.DeserializeObject<Update>(json);

            var commands = JobsMe.BotApp.Models.Bot.Commands;

            try
            {
                //NB!  very important place -  user can send new message ot edit existing
                var message = update.Message ?? update.EditedMessage;
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
                Trace.TraceError("Message: " + e.Message);
                Trace.TraceError("Stack trace: " + e.StackTrace);
                throw;
            }

            return Ok();
        }
    }
}
