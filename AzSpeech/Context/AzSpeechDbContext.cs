using AzSpeech.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzSpeech.Context
{
    public class AzSpeechDbContext : DbContext
    {
        public AzSpeechDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ChatbotResponse> ChatbotResponses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<People> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
