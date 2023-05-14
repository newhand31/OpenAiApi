using Microsoft.AspNetCore.Mvc;
using OpenAI_API;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        private readonly OpenAIAPI _openApiSvc;
        public AIController(IConfiguration config)
        {
            //_openApiSvc = new OpenAIAPI(new APIAuthentication(config["OpenAIServiceOptions:ApiKey"]));
            _openApiSvc = new OpenAIAPI(config["OpenAIServiceOptions:ApiKey"]);
        }


        // GET: api/<AIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AIController>
        [HttpPost]
        public async Task<string> PostAsync([FromBody] string text)
        {
            var a = _openApiSvc.Auth;
            var chat = _openApiSvc.Chat.CreateConversation();

            chat.AppendUserInput(text);

            string response = await chat.GetResponseFromChatbotAsync();

            return response;
        }

        // PUT api/<AIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
