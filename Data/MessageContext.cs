using Microsoft.EntityFrameworkCore;
using MVCFRIB.Models;

namespace MVCFRIB.Data
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }

    }
}
