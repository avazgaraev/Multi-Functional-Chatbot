namespace AzSpeech.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
        public string? PeopleId { get; set; }
        public People? People { get; set; }
    }
}
