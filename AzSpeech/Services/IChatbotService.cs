using AzSpeech.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AzSpeech.Services
{
    public interface IChatbotService
    {
        Task<string> GetResponse(string request);
        Task<People> GetBorc(string VOEN);
        Task<IActionResult> PostPeople(string VOEN, string firstName, string lastName, string borc);
    }
}
