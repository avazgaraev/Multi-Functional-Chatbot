using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AzSpeech.Entities;
using AzSpeech.Services;
using ChatGPT.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzSpeech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private const string chatgptKey = "";
        private readonly ICognitiveServices _cognitiveServices;
        private readonly IChatbotService _chatbotService;


        public ChatController(ICognitiveServices cognitiveServices, IChatbotService chatbotService)
        {
            _cognitiveServices = cognitiveServices;
            _chatbotService = chatbotService;
        }

        [HttpGet("[action]")]
        public async Task<People> GetBorc(string VOEN)
        {
            var resp = await _chatbotService.GetBorc(VOEN);
            return resp;
        }

        [HttpGet]
        public async Task<string> GetData(string request)
        {
            //var bot = new ChatGpt(chatgptKey);
            //bot.Config.MaxTokens = 1024;

            //var response = await bot.Ask(request);

            var response = await _chatbotService.GetResponse(request);

            return response;
        }

        [HttpGet("[action]")]
        public void CognitiveServices()
        {
            _cognitiveServices.GetSpeech();
        }

        [HttpPost("action")]
        public async Task<IActionResult> PostPeople(string VOEN, string firstName, string lastName, string borc)
        {
            await _chatbotService.PostPeople(VOEN, firstName, lastName, borc);    
            return Ok();
        }

        //[HttpGet("[action]")]
        //public async Task<string> GetDataFromWitAI(string request)
        //{
        //    var client = new HttpClient();

        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer ZLLHXWWUOUF4SQD75JSZL7I7HQF3HRCA");
        //    //client.DefaultRequestHeaders.Add("content-type", "application/json; charset=utf-8");

        //    HttpResponseMessage response = new();
        //    response.Content.Headers.Add("content-type", "application/json; charset=utf-8");
        //    response = await client.GetAsync($"{APIURL}={request}");

        //    HttpContent responseContent = response.Content;

        //    var jsonData = responseContent.ReadAsStringAsync().Result;
        //    dynamic? deserializedData = JsonConvert.DeserializeObject(jsonData);

        //    //Console.WriteLine(deserializedData.text);
        //    //Console.WriteLine(deserializedData.intents[0].name);

        //    var str = deserializedData.intents[0].name;

        //    return str;
        //}
    }
}