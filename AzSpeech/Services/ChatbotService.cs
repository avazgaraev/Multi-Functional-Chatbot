using AzSpeech.Context;
using AzSpeech.Entities;
using ChatGPT.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AzSpeech.Services
{
    public class ChatbotService : IChatbotService
    {
        private const string chatgptKey = "";
        private const string witAIKey = "";
        private HttpClient client = new();
        private HttpResponseMessage response = new();
        private AzSpeechDbContext _context;

        public ChatbotService(AzSpeechDbContext context)
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {witAIKey}");
            response.Content.Headers.Add("content-type", "application/json; charset=utf-8");
            _context = context;
        }

        public async Task<string> GetResponse(string request)
        {
            response = await client.GetAsync($"{"WITAURL"}={request}");

            HttpContent responseContent = response.Content;

            var jsonData = responseContent.ReadAsStringAsync().Result;
            dynamic? deserializedData = JsonConvert.DeserializeObject(jsonData);

            Console.WriteLine(deserializedData);
            if (deserializedData.intents.Count != 0)
            {
                string str = deserializedData.intents[0].name;
                
                str = _context.ChatbotResponses.FirstOrDefault(r => r.Intent == str).Answer;
                //switch (str.Value)
                //{
                //    case "Hi":
                //        str = "Salam, sizə necə kömək edə bilərəm ?";
                //        break;
                //    case "Name":
                //        str = "Mənim adım AzSpeechBot'dur. Sizə necə kömək edə bilərəm ?";
                //        break;
                //    default:
                //        break;
                //}
                return str;
            }
            else
            {
                var bot = new ChatGpt(chatgptKey);
                bot.Config.MaxTokens = 1024;

                var chatGptResponse = await bot.Ask(request);

                return chatGptResponse;
            }
        }

        public async Task<People> GetBorc(string VOEN)
        {
            var resp = _context.People.FirstOrDefault(x => x.VOEN == VOEN);
            return resp;
        }

        public async Task<IActionResult> PostPeople(string VOEN, string firstName, string lastName, string borc)
        {
            var resp = new People();
            resp.Id = Guid.NewGuid();
            resp.FirstName = firstName;
            resp.LastName = lastName;
            resp.Borc = borc;
            resp.VOEN = VOEN;
            resp.Messages = new List<Message>();
            _context.People.Add(resp);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        //public async Task<IActionResult> PostMessages(string request, string response)
        //{
            
        //    var messages = new Message
        //    {
        //        Id = Guid.NewGuid(),
        //        PeopleId
        //    }
        //}

    }
}
