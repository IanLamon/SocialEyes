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
            //Relationships
            //Company has many events
            modelBuilder.Entity<Company>().HasKey(p => p.CompanyId);
            modelBuilder.Entity<Company>().Property(c => c.CompanyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().Property(e => e.EventId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Event>().HasRequired(p => p.Company).WithMany(e => e.Events).HasForeignKey(e => e.CompanyId);

            //Company has many users
            modelBuilder.Entity<Company>().HasKey(p => p.CompanyId);
            modelBuilder.Entity<Company>().Property(c => c.CompanyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().HasRequired(p => p.Company).WithMany(u => u.Users).HasForeignKey(u => u.CompanyId);

            //Company has many categories
            modelBuilder.Entity<Company>().HasKey(p => p.CompanyId);
            modelBuilder.Entity<Company>().Property(c => c.CompanyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().HasKey(cat => cat.CategoryId);
            modelBuilder.Entity<Category>().Property(cat => cat.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().HasRequired(p => p.Company).WithMany(cat => cat.Categories).HasForeignKey(cat => cat.CompanyId);

            //Company has many polls
            modelBuilder.Entity<Company>().HasKey(p => p.CompanyId);
            modelBuilder.Entity<Company>().Property(c => c.CompanyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Poll>().HasKey(pl => pl.PollId);
            modelBuilder.Entity<Poll>().Property(pl => pl.PollId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Poll>().HasRequired(p => p.Company).WithMany(pl => pl.Polls).HasForeignKey(pl => pl.CompanyId);

            //Event has many attendees
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().Property(e => e.EventId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Attendee>().HasKey(a => a.AttendeeId);
            modelBuilder.Entity<Attendee>().Property(a => a.AttendeeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Attendee>().HasRequired(e => e.SE_Event).WithMany(a => a.Attendees).HasForeignKey(a => a.EventId);

            //User has many poll votes
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PollVote>().HasKey(pv => pv.PollVoteId);
            modelBuilder.Entity<PollVote>().Property(pv => pv.PollVoteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PollVote>().HasRequired(u => u.User).WithMany(pv => pv.PollVotes).HasForeignKey(pv => pv.UserId);

            //Category has many events
            modelBuilder.Entity<Category>().HasKey(cat => cat.CategoryId);
            modelBuilder.Entity<Category>().Property(cat => cat.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().Property(e => e.EventId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Event>().HasRequired(cat => cat.Category).WithMany(e => e.Events).HasForeignKey(e => e.CategoryId);

            //Poll has many poll votes
            modelBuilder.Entity<Poll>().HasKey(pl => pl.PollId);
            modelBuilder.Entity<Poll>().Property(pl => pl.PollId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PollVote>().HasKey(pv => pv.PollVoteId);
            modelBuilder.Entity<PollVote>().Property(pv => pv.PollVoteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PollVote>().HasRequired(pl => pl.Poll).WithMany(pv => pv.PollVotes).HasForeignKey(pv => pv.PollId);

            //Poll has many poll options
            modelBuilder.Entity<Poll>().HasKey(pl => pl.PollId);
            modelBuilder.Entity<Poll>().Property(pl => pl.PollId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PollOption>().HasKey(po => po.PollOptionId);
            modelBuilder.Entity<PollOption>().Property(po => po.PollOptionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PollOption>().HasRequired(pl => pl.Poll).WithMany(po => po.PollOptions).HasForeignKey(pv => pv.PollId);

            //Poll Option has many poll votes
            modelBuilder.Entity<PollOption>().HasKey(po => po.PollOptionId);
            modelBuilder.Entity<PollOption>().Property(po => po.PollOptionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PollVote>().HasKey(pv => pv.PollVoteId);
            modelBuilder.Entity<PollVote>().Property(pv => pv.PollVoteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PollVote>().HasRequired(po => po.PollOption).WithMany(pv => pv.PollVotes).HasForeignKey(pv => pv.PollOptionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
