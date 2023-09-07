namespace AzSpeech.Entities
{
    public class ChatbotResponse
    {
        public Guid Id { get; set; }
        public string Intent { get; set; }
        public string Answer { get; set; }
    }
}
