  
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
                .HasData(
                    new Message { MessageId = 1, Subject = "Music", Body = "egg", User = "eggLover69", Date = "01/01/01" },
                    new Message { MessageId = 2, Subject = "Memes", Body = "egg", User = "doug", Date = "10/23/97" }
                );
        } 
    }
}