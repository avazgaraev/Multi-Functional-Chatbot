namespace AzSpeech.Entities
{
    public class People
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? VOEN { get; set; }
        public string? Borc { get; set; }
        public List<Message>? Messages { get; set; }
    }
}
