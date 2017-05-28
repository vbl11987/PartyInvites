using Microsoft.EntityFrameworkCore;

namespace PartyInvites.Models
{
    public class PartyInvitesDbContext : DbContext
    {
        public PartyInvitesDbContext() {}

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            builder.UseSqlite("Filename=./PartyInvites.db");
        }

        public DbSet<GuestResponse> Invites {get; set;}
    }
}