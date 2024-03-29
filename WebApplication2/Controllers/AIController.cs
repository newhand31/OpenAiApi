﻿using Microsoft.AspNetCore.Mvc;
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
            //想說是這個問題
            //_openApiSvc = new OpenAIAPI(new APIAuthentication(config["OpenAIServiceOptions:ApiKey"]));

            _openApiSvc = new OpenAIAPI(config["OpenAIServiceOptions:ApiKey"]);
        }

        // POST api/<AIController>
        [HttpPost]
        public async Task<string> PostAsync([FromBody] string text)
        {
            var apiKey = _openApiSvc.Auth;
            var chat = _openApiSvc.Chat.CreateConversation();

            chat.AppendUserInput(text);

            string response = await chat.GetResponseFromChatbotAsync();

            return response;
        }
    }
}
