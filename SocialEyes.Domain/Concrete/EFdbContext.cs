using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFdbContext : DbContext
    {
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<PollVote> PollVotes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Company has many events relationship
            modelBuilder.Entity<Company>().HasKey(p => p.CompanyId);
            modelBuilder.Entity<Company>().Property(c => c.CompanyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().Property(e => e.EventId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Event>().HasRequired(p => p.Company).WithMany(e => e.Events).HasForeignKey(e => e.CompanyId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
